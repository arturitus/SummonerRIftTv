

using LeagueSpectator.Models;
using Newtonsoft.Json;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    internal class MainWindowService : IMainWindowService
    {
        private readonly IRiotApiService riotApiService;
        private const string APP_DATA_PATH = "./Assets/AppData.json";
        private const string BAT_PATH = "./Assets/spectator.bat";
        private string authentication;
        private long matchId;
        private string _region;
        private string spectatorRegion;

        public MainWindowService()
        {
            riotApiService = Locator.Current.GetService<IRiotApiService>();
            authentication = string.Empty;
            _region = string.Empty;
            spectatorRegion = string.Empty;
        }

        Task<bool> IMainWindowService.SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId)
        {
            try
            {
                Summoner summoner = riotApiService.GetSummonerByNameAsync(summonerName, region, apiKey).Result;
                summonerId = summoner.Id!;
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                summonerId = string.Empty;
                return Task.FromResult(false);
            }
        }

        Task<bool> IMainWindowService.SearchSpectableGameAsync(string summonerId, Region region, string apiKey, out ObservableCollection<int> championsIds)
        {
            try
            {
                ActiveGame activeGame = riotApiService.GetActiveGameAsync(summonerId, region, apiKey).Result;
                authentication = activeGame.Observers!.EncryptionKey!;
                matchId = activeGame.GameId;
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
                championsIds = new ObservableCollection<int>();
                foreach (Participant participant in activeGame.Participants!)
                {
                    championsIds.Add(participant.ChampionId);
                }
                return Task.FromResult(activeGame != null);
            }
            catch (Exception)
            {
                championsIds = new ObservableCollection<int>();
                return Task.FromResult(false);
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

        Task<bool> IMainWindowService.GetAppData(ref AppData appData)
        {
            try
            {
                appData = JsonConvert.DeserializeObject<AppData>(File.ReadAllText(APP_DATA_PATH));
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                appData = new AppData();
                return Task.FromResult(false);
            }
        }

        Task<bool> IMainWindowService.SetAppData(AppData appData)
        {
            try
            {
                File.WriteAllText(APP_DATA_PATH, JsonConvert.SerializeObject(appData, Formatting.Indented));
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
