using LeagueSpectator.MVVM.DTOs;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using System.Diagnostics;

namespace LeagueSpectator.MVVM.Services
{
    public class MainWindowService : IMainWindowService
    {
        private readonly IRiotApiService m_RiotApiService;
        private const string APP_DATA_PATH = "./Assets/AppData.json";
        private const string BAT_PATH = "./Assets/spectator.bat";
        private string authentication;
        private long matchId;
        private string _region;
        private string spectatorRegion;

        public MainWindowService(IRiotApiService riotApiService)
        {
            m_RiotApiService = riotApiService;
            authentication = string.Empty;
            _region = string.Empty;
            spectatorRegion = string.Empty;
        }

        Task<bool> IMainWindowService.SearchSummonerAsync(string summonerName, RegionDTO region, string apiKey, out string summonerId)
        {
            try
            {
                RiotApiResponse<Summoner> res = m_RiotApiService.GetSummonerByNameAsync(summonerName, (Region)region, apiKey).Result;
                summonerId = res.Response!.Id!;
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                //summonerId = string.Empty;
                //return Task.FromResult(false);
                throw e.InnerException!;
            }
        }

        Task<bool> IMainWindowService.SearchSpectableGameAsync(string summonerId, RegionDTO region, string apiKey, out Team blueTeam, out Team redTeam)
        {
            try
            {
                RiotApiResponse<ActiveGame> res = m_RiotApiService.GetActiveGameAsync(summonerId, (Region)region, apiKey).Result;
                authentication = res.Response!.Observers!.EncryptionKey!;
                matchId = res.Response.GameId;
                _region = region == RegionDTO.BR || region == RegionDTO.KR ? region.ToString() : $"{region}1";
                switch (region)
                {
                    case RegionDTO.KR:
                        spectatorRegion = "kr";
                        break;
                    case RegionDTO.NA:
                        spectatorRegion = "na2";
                        break;
                    case RegionDTO.EUW:
                        spectatorRegion = "euw1";
                        break;
                    case RegionDTO.RU:
                        break;
                    case RegionDTO.BR:
                        break;
                    default:
                        spectatorRegion = _region;
                        break;
                }
                blueTeam = new Team();
                foreach (ParticipantDTO participant in res.Response.Participants!.Where(x => x.TeamId == 100))
                {
                    blueTeam.Players.Add(participant);
                }
                foreach (BannedChampion participant in res.Response.BannedChampions!.Where(x => x.TeamId == 100))
                {
                    blueTeam.Bans.Add(participant);
                }
                redTeam = new Team();
                foreach (Participant participant in res.Response.Participants!.Where(x => x.TeamId == 200))
                {
                    redTeam.Players.Add(participant);
                }
                foreach (BannedChampion participant in res.Response.BannedChampions!.Where(x => x.TeamId == 200))
                {
                    redTeam.Bans.Add(participant);
                }
                return Task.FromResult(res.Response != null);
            }
            catch (Exception e)
            {
                //championsIds = new ObservableCollection<int>();
                //return Task.FromResult(false);
                throw e.InnerException!;
            }
        }

        Task<bool> IMainWindowService.SpectateGameAsync(string lolFolderPath)
        {
            //TODO batFile con authentication y matchId FolderPath
            try
            {
                using (Process process = new())
                {
                    process.StartInfo.FileName = BAT_PATH;
                    process.StartInfo.ArgumentList.Add(lolFolderPath);
                    process.StartInfo.ArgumentList.Add(authentication);
                    process.StartInfo.ArgumentList.Add(matchId.ToString());
                    process.StartInfo.ArgumentList.Add(_region);
                    process.StartInfo.ArgumentList.Add(spectatorRegion);
                    process.Start();
                }
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
