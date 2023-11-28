using LeagueSpectator.MVVM.DTOs;
using LeagueSpectator.MVVM.Models;

namespace LeagueSpectator.MVVM.IServices
{
    public interface IMainWindowService
    {
        Task<bool> SearchSummonerAsync(string summonerName, RegionDTO region, string apiKey, out string summonerId);
        Task<bool> SearchSpectableGameAsync(string summonerId, RegionDTO region, string apiKey, out Team players1, out Team players2);
        Task<bool> SpectateGameAsync(string lolFolderPath);
    }
}