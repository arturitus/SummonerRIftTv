﻿

using LeagueSpectator.IServices;
using LeagueSpectator.Models;
using Newtonsoft.Json;
using Splat;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                RiotApiResponse<Summoner> res = riotApiService.GetSummonerByNameAsync(summonerName, region, apiKey).Result;
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

        Task<bool> IMainWindowService.SearchSpectableGameAsync(string summonerId, Region region, string apiKey, out Team blueTeam, out Team redTeam)
        {
            try
            {
                RiotApiResponse<ActiveGame> res = riotApiService.GetActiveGameAsync(summonerId, region, apiKey).Result;
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
                blueTeam = new Team();
                foreach (Participant participant in res.Response.Participants!.Where(x => x.TeamId == 100))
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
