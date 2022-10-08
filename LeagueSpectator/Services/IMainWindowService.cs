﻿using LeagueSpectator.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    internal interface IMainWindowService
    {
        Task<bool> SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId);
        Task<bool> SearchSpectableGameAsync(string summonerId, Region region, string apiKey, out ObservableCollection<Participant> players1, out ObservableCollection<Participant> players2);
        Task<bool> SpectateGameAsync(string lolFolderPath);
        Task<bool> GetAppData(ref AppData appData);
        Task<bool> SetAppData(AppData appData);
    }
}