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
                string summonerId = await SearchSummonerAsync(summonerName, region, apiKey);
                RiotApiResponse<ActiveGame> res = await m_RiotApiService.GetActiveGameAsync(summonerId, region, apiKey);
                authentication = res.Response!.Observers!.EncryptionKey!;
                matchId = res.Response.GameId;
                _region = region == Region.BR || region == Region.KR ? region.ToString() : $"{region}1";
                switch (region)
                {
                    case Region.KR:
                        spectatorRegion = "kr";
                        break;
                    case Region.NA:
                        spectatorRegion = "na2";
                        break;
                    case Region.EUW:
                        spectatorRegion = "euw1";
                        break;
                    case Region.RU:
                        break;
                    case Region.BR:
                        break;
                    default:
                        spectatorRegion = _region;
                        break;
                }
                foreach (ParticipantDTO participant in res.Response.Participants.Where(x => x.TeamId == 100))
                {
                    teams[0].Players.Add(participant);
                }
                foreach (BannedChampion participant in res.Response.BannedChampions.Where(x => x.TeamId == 100))
                {
                    teams[0].Bans.Add(participant);
                }
                foreach (Participant participant in res.Response.Participants.Where(x => x.TeamId == 200))
                {
                    teams[1].Players.Add(participant);
                }
                foreach (BannedChampion participant in res.Response.BannedChampions.Where(x => x.TeamId == 200))
                {
                    teams[1].Bans.Add(participant);
                }
                return teams;
            }
            catch (RiotApiError e)
            {
                if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new MainWindowServiceError(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));
                }
                throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerIsNotInGame));
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
        private async Task<string> SearchSummonerAsync(string summonerName, Region region, string apiKey)
        {
            try
            {
                RiotApiResponse<Summoner> res = await m_RiotApiService.GetSummonerByNameAsync(summonerName, region, apiKey);
                return res.Response.Id;
            }
            catch (RiotApiError e)
            {
                if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw;
                }
                throw new MainWindowServiceError(new ErrorDialogFormat(summonerName, InfoDialogKeys.SummonerDoesntExist));
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
    public class MainWindowServiceError(ErrorDialogFormat errorFormat) : Exception
    {
        public ErrorDialogFormat ErrorFormat { get; set; } = errorFormat;
    }
}
