using SummonerRiftTv.MVVM.DTOs;
using SummonerRiftTv.MVVM.IServices;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.IServices;
using SummonerRiftTv.RiotApi.Models;
using System.Diagnostics;
using System.Threading;

namespace SummonerRiftTv.MVVM.Services
{
    public class MainWindowService : IMainWindowService
    {
        private Process? m_LeagueProcess;
        private readonly IRiotApiService m_RiotApiService;
        private const string APP_DATA_PATH = "./Assets/AppData.json";
        private const string BAT_PATH = "./Assets/spectator.bat";
        private string authentication;
        private long matchId;
        private string? _region;
        private string? spectatorRegion;

        public event Action<SpectateState, bool>? SpectateChanged;

        public MainWindowService(IRiotApiService riotApiService)
        {
            m_RiotApiService = riotApiService;
            authentication = string.Empty;
            _region = string.Empty;
            spectatorRegion = string.Empty;
        }

        async Task<ActiveGameDTO> IMainWindowService.SearchSpectableGameAsync(string summonerName, string tagLine, Region? region)
        {
            try
            {
                Account account = await SearchAccountAsync(summonerName, tagLine, region);
                //Summoner summoner = await SearchSummonerByPUUIDAsync(account.Puuid, region);
                string encryptedPUUID = account.Puuid;
                ActiveGame res = await m_RiotApiService.GetActiveGameAsync(encryptedPUUID, region);
                authentication = res.Observers!.EncryptionKey!;
                matchId = res.GameId;
                //_region = region is Region.BR1 or Region.RU or Region.KR ? region.ToString() : $"{region}1";
                _region = region.ToString();
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

                ActiveGameDTO activeGameDTO = await ActiveGameDTO.FromActiveGameAsync(res,
                                              async (s) => await ActiveGameDTO_OnAskPlayerLeague(s, region));
                return activeGameDTO;
            }

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

        private async Task<HashSet<LeagueItem>> ActiveGameDTO_OnAskPlayerLeague(string? summonerId, Region? region)
        {
            return await m_RiotApiService.GetLeagueEntryBySummonerIdAsync(summonerId, region);
        }

        async Task IMainWindowService.SpectateGameAsync(string? lolFolderPath)
        {
            //TODO batFile con authentication y matchId FolderPath
            await Task.Run(() =>
            {
                try
                {
                    using (Process process = new())
                    {
                        process.StartInfo.FileName = BAT_PATH;
                        process.StartInfo.ArgumentList.Add(lolFolderPath ?? string.Empty);
                        process.StartInfo.ArgumentList.Add(authentication);
                        process.StartInfo.ArgumentList.Add(matchId.ToString());
                        process.StartInfo.ArgumentList.Add(_region ?? string.Empty);
                        process.StartInfo.ArgumentList.Add(spectatorRegion ?? string.Empty);
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        //var a = process.StandardOutput;
                        //string b = a.ReadToEnd();
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
                    if (m_LeagueProcess.HasExited)
                    {
                        return;
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

        private async Task<Summoner> SearchSummonerAsync(string summonerName, Region region)
        {
            try
            {
                Summoner res = await m_RiotApiService.GetSummonerByNameAsync(summonerName, region);
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
        private async Task<Account> SearchAccountAsync(string summonerName, string tagLine, Region? region)
        {
            try
            {
                Account res = await m_RiotApiService.GetAccountByNameTagAsync(summonerName, tagLine, region);
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

        private async Task<Summoner> SearchSummonerByPUUIDAsync(string encryptedPUUID, Region? region)
        {
            try
            {
                Summoner res = await m_RiotApiService.GetSummonerByEncryptedPUUIDAsync(encryptedPUUID, region);
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

        private void LeagueGameProcess_Exited(object? sender, EventArgs e)
        {
            if (m_LeagueProcess is not null)
            {
                m_LeagueProcess.Exited -= LeagueGameProcess_Exited;
                m_LeagueProcess.Dispose();
                m_LeagueProcess = null;
                SpectateChanged?.Invoke(SpectateState.Ended, true);
            }
        }
    }
}
