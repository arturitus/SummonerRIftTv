using LeagueSpectator.MVVM.DTOs;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using System.Diagnostics;
using System.Net;

namespace LeagueSpectator.MVVM.Services
{
    public class MainWindowService : IMainWindowService
    {
        private Process m_LeagueProcess;
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

        public event Action<SpectateState, bool> SpectateChanged;

        async Task<Team[]> IMainWindowService.SearchSpectableGameAsync(string summonerName, Region region, string apiKey)
        {
            try
            {
                Team[] teams = [new Team(), new Team()];
                Summoner summoner = await SearchSummonerAsync(summonerName, region, apiKey);
                string summonerId = summoner.Id;
                ActiveGame res = await m_RiotApiService.GetActiveGameAsync(summonerId, region, apiKey);
                authentication = res.Observers!.EncryptionKey!;
                matchId = res.GameId;
                _region = region is Region.BR1 or Region.RU or Region.KR ? region.ToString() : $"{region}1";
                switch (region)
                {
                    case Region.KR:
                        spectatorRegion = "kr";
                        break;
                    case Region.NA1:
                        spectatorRegion = "na2";
                        break;
                    case Region.EUW1:
                        spectatorRegion = "euw1";
                        break;
                    case Region.RU:
                        break;
                    case Region.BR1:
                        break;
                    default:
                        spectatorRegion = _region;
                        break;
                }
                foreach (ParticipantDTO participant in res.Participants.Where(x => x.TeamId == 100))
                {
                    teams[0].Players.Add(participant);
                }
                foreach (BannedChampionDTO participant in res.BannedChampions.Where(x => x.TeamId == 100))
                {
                    teams[0].Bans.Add(participant);
                }
                foreach (ParticipantDTO participant in res.Participants.Where(x => x.TeamId == 200))
                {
                    teams[1].Players.Add(participant);
                }
                foreach (BannedChampionDTO participant in res.BannedChampions.Where(x => x.TeamId == 200))
                {
                    teams[1].Bans.Add(participant);
                }
                return teams;
            }
            //catch (RiotApiError e)
            //{
            //    if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
            //    {
            //        throw new MainWindowServiceError(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));
            //    }
            //    throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerIsNotInGame));
            //}

            catch (GameNotFoundException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerIsNotInGame));
            }
            catch (InvalidApiKeyException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));
            }
        }

        async Task<Team[]> IMainWindowService.SearchSpectableGameAsync(string summonerName, string tagLine, Region region, string apiKey)
        {
            try
            {
                Team[] teams = [new Team(), new Team()];
                Account account = await SearchAccountAsync(summonerName, tagLine, region, apiKey);
                Summoner summoner = await SearchSummonerByPUUIDAsync(account.Puuid, region, apiKey);
                string summonerId = summoner.Id;
                ActiveGame res = await m_RiotApiService.GetActiveGameAsync(summonerId, region, apiKey);
                authentication = res.Observers!.EncryptionKey!;
                matchId = res.GameId;
                _region = region is Region.BR1 or Region.RU or Region.KR ? region.ToString() : $"{region}1";
                switch (region)
                {
                    case Region.KR:
                        spectatorRegion = "kr";
                        break;
                    case Region.NA1:
                        spectatorRegion = "na2";
                        break;
                    case Region.EUW1:
                        spectatorRegion = "euw1";
                        break;
                    case Region.RU:
                        break;
                    case Region.BR1:
                        break;
                    default:
                        spectatorRegion = _region;
                        break;
                }
                foreach (ParticipantDTO participant in res.Participants.Where(x => x.TeamId == 100))
                {
                    teams[0].Players.Add(participant);
                }
                foreach (BannedChampionDTO participant in res.BannedChampions.Where(x => x.TeamId == 100))
                {
                    teams[0].Bans.Add(participant);
                }
                foreach (ParticipantDTO participant in res.Participants.Where(x => x.TeamId == 200))
                {
                    teams[1].Players.Add(participant);
                }
                foreach (BannedChampionDTO participant in res.BannedChampions.Where(x => x.TeamId == 200))
                {
                    teams[1].Bans.Add(participant);
                }
                return teams;
            }
            //catch (RiotApiError e)
            //{
            //    if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
            //    {
            //        throw new MainWindowServiceError(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));
            //    }
            //    throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerIsNotInGame));
            //}

            catch (SummonerNotFoundException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat($"{summonerName}#{tagLine}", InfoDialogKeys.SummonerDoesntExist));
            }
            catch (GameNotFoundException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat($"{summonerName}#{tagLine}", InfoDialogKeys.SummonerIsNotInGame));
            }
            catch (InvalidApiKeyException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));
            }
        }

        async Task IMainWindowService.SpectateGameAsync(string lolFolderPath)
        {
            //TODO batFile con authentication y matchId FolderPath
            await Task.Run(() =>
            {
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

                    int timer = 0;
                    while (m_LeagueProcess == null)
                    {
                        m_LeagueProcess = Process.GetProcessesByName("League of Legends").FirstOrDefault();
                        if (timer > 5000)
                        {
                            return;
                        }
                        timer += 100;
                        Thread.Sleep(100);
                    }
                    m_LeagueProcess.WaitForInputIdle();

                    //if (leagueGameProcess != null)
                    //{
                    SpectateChanged?.Invoke(SpectateState.Spectating, false);
                    m_LeagueProcess.EnableRaisingEvents = true;
                    m_LeagueProcess.Exited += LeagueGameProcess_Exited;
                }
                catch (Exception)
                {
                }
            });
        }

        private async Task<Summoner> SearchSummonerAsync(string summonerName, Region region, string apiKey)
        {
            try
            {
                Summoner res = await m_RiotApiService.GetSummonerByNameAsync(summonerName, region, apiKey);
                return res;
            }

            catch (SummonerNotFoundException)
            {
                throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerDoesntExist));
            }
            catch (InvalidApiKeyException)
            {
                throw;
            }
        }
        private async Task<Account> SearchAccountAsync(string summonerName, string tagLine, Region region, string apiKey)
        {
            try
            {
                Account res = await m_RiotApiService.GetAccountByNameTag(summonerName, tagLine, region, apiKey);
                return res;
            }

            catch (SummonerNotFoundException)
            {
                throw;
            }
            catch (InvalidApiKeyException)
            {
                throw;
            }            
        }

        private async Task<Summoner> SearchSummonerByPUUIDAsync(string encryptedPUUID, Region region, string apiKey)
        {
            try
            {
                Summoner res = await m_RiotApiService.GetSummonerByEncryptedPUUID(encryptedPUUID, region, apiKey);
                return res;
            }

            catch (SummonerNotFoundException)
            {
                throw;
            }
            catch (InvalidApiKeyException)
            {
                throw;
            }
        }

        private void LeagueGameProcess_Exited(object sender, EventArgs e)
        {
            m_LeagueProcess.Exited -= LeagueGameProcess_Exited;
            m_LeagueProcess.Dispose();
            m_LeagueProcess = null;
            SpectateChanged?.Invoke(SpectateState.Ended, true);
        }
    }
}
