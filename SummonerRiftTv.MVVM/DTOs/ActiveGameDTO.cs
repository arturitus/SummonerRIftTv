using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;
using System.Collections.ObjectModel;

namespace SummonerRiftTv.MVVM.DTOs
{
    public class ActiveGameDTO : LocalizableObject
    {
        public ObservableCollection<ParticipantDTO> BlueTeamPlayers { get; } = new ObservableCollection<ParticipantDTO>();
        public ObservableCollection<BannedChampionDTO> BlueTeamBans { get; } = new ObservableCollection<BannedChampionDTO>();
        public ObservableCollection<ParticipantDTO> RedTeamPlayers { get; } = new ObservableCollection<ParticipantDTO>();
        public ObservableCollection<BannedChampionDTO> RedTeamBans { get; } = new ObservableCollection<BannedChampionDTO>();

        public int MapId { get; set; }
        public string GameMode { get; set; }
        public string GameType { get; set; }
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
    }
}
