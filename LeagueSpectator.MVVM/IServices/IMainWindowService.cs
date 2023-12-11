using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;

namespace LeagueSpectator.MVVM.IServices
{
    public interface IMainWindowService
    {
        Task<bool> SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId);
        Task<bool> SearchSpectableGameAsync(string summonerId, Region region, string apiKey, out Team players1, out Team players2);
        Task<bool> SpectateGameAsync(string lolFolderPath);
    }
}