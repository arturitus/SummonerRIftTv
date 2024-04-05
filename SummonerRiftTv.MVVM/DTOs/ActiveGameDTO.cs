using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SummonerRiftTv.MVVM.DTOs
{
    public class ActiveGameDTO : LocalizableObject
    {
        public AverageTier BlueTeamAvgTier => TeamAverageTier(BlueTeamPlayers);
        public AverageTier RedTeamAvgTier => TeamAverageTier(RedTeamPlayers);
        public ObservableCollection<ParticipantDTO> BlueTeamPlayers { get; } = new ObservableCollection<ParticipantDTO>();
        public ObservableCollection<BannedChampionDTO> BlueTeamBans { get; } = new ObservableCollection<BannedChampionDTO>();
        public ObservableCollection<ParticipantDTO> RedTeamPlayers { get; } = new ObservableCollection<ParticipantDTO>();
        public ObservableCollection<BannedChampionDTO> RedTeamBans { get; } = new ObservableCollection<BannedChampionDTO>();

        public int MapId { get; set; }
        public string? GameMode { get; set; }
        public string? GameType { get; set; }
        public int GameLength { get; set; }

        public override void LocalizeObject()
        {
            LocalizeCollection(BlueTeamPlayers);
            LocalizeCollection(BlueTeamBans);
            LocalizeCollection(RedTeamPlayers);
            LocalizeCollection(RedTeamBans);
        }

        public void ClearPrevouisMatch()
        {
            BlueTeamPlayers.Clear();
            BlueTeamBans.Clear();
            RedTeamPlayers.Clear();
            RedTeamBans.Clear();
        }

        private static void LocalizeCollection<T>(ObservableCollection<T> items) where T : LocalizableObject
        {
            foreach (T item in items)
            {
                item.LocalizeObject();
            }
        }

        public static implicit operator ActiveGameDTO(ActiveGame activeGame)
        {
            ActiveGameDTO activeGameDTO = new ActiveGameDTO()
            {
                MapId = activeGame.MapId,
                GameMode = activeGame.GameMode,
                GameType = activeGame.GameType,
                GameLength = activeGame.GameLength
            };
            foreach (ParticipantDTO participant in activeGame.Participants)
            {
                if (participant.TeamId is TeamId.BlueTeam)
                {
                    activeGameDTO.AddPlayer(participant);
                    continue;
                }
                activeGameDTO.AddPlayer(participant);
            }
            foreach (BannedChampionDTO participant in activeGame.BannedChampions)
            {
                if (participant.TeamId is TeamId.BlueTeam)
                {
                    activeGameDTO.AddBan(participant);
                    continue;
                }
                activeGameDTO.AddBan(participant);
            }
            return activeGameDTO;
        }

        public static async Task<ActiveGameDTO> FromActiveGameAsync(ActiveGame activeGame, Func<string?, Task<HashSet<LeagueItem>>> func)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ActiveGameDTO activeGameDTO = new ActiveGameDTO()
            {
                MapId = activeGame.MapId,
                GameMode = activeGame.GameMode,
                GameType = activeGame.GameType,
                GameLength = activeGame.GameLength
            };
            foreach (ParticipantDTO participant in activeGame.Participants)
            {
                HashSet<LeagueItem> list = await Task.Factory.StartNew(async () => await func.Invoke(participant.SummonerId),
                                                     cancellationTokenSource.Token,
                                                     TaskCreationOptions.LongRunning,
                                                     TaskScheduler.Default).Unwrap();

                if (list.Count > 0)
                {
                    participant.SoloQueueRank = list.FirstOrDefault(l => ((LeagueItemDTO?)l)?.QueueType == QueueType.RANKED_SOLO_5x5);
                }
                if (participant.TeamId is TeamId.BlueTeam)
                {
                    activeGameDTO.AddPlayer(participant);
                    continue;
                }
                activeGameDTO.AddPlayer(participant);
            }
            foreach (BannedChampionDTO participant in activeGame.BannedChampions)
            {
                if (participant.TeamId is TeamId.BlueTeam)
                {
                    activeGameDTO.AddBan(participant);
                    continue;
                }
                activeGameDTO.AddBan(participant);
            }
            await cancellationTokenSource.CancelAsync();
            return activeGameDTO;
        }

        private void AddPlayer(ParticipantDTO participant)
        {
            if (participant.TeamId is TeamId.BlueTeam)
            {
                BlueTeamPlayers.Add(participant);
                return;
            }
            RedTeamPlayers.Add(participant);
        }

        private void AddBan(BannedChampionDTO participant)
        {
            if (participant.TeamId is TeamId.BlueTeam)
            {
                BlueTeamBans.Add(participant);
                return;
            }
            RedTeamBans.Add(participant);
        }

        private static AverageTier TeamAverageTier(ObservableCollection<ParticipantDTO> participants)
        {
            List<AverageTier> averageTier = [];
            IEnumerable<int> possibleTiers = Enum.GetValues<AverageTier>().Select(x => (int)x);
            IEnumerable<AverageTier> possibleTiers2 = Enum.GetValues<AverageTier>();

            foreach (ParticipantDTO item in participants)
            {
                if (item.SoloQueueRank is not null)
                {
                    averageTier.Add((AverageTier)((int)item.SoloQueueRank.Tier | (int)item.SoloQueueRank.Rank));
                }
            }

            if (averageTier.Count <= 0)
            {
                return AverageTier.Unranked;
            }

            double avg = averageTier.Average(x => (int)x);
            int closestTier = possibleTiers.OrderBy(x => Math.Abs(x - avg)).FirstOrDefault();

            return (AverageTier)closestTier;
        }
    }
}
