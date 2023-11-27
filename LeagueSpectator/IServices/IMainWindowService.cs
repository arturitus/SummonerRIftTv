using LeagueSpectator.Models;
using System.Threading.Tasks;

namespace LeagueSpectator.IServices
{
    internal interface IMainWindowService
    {
        Task<bool> SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId);
        Task<bool> SearchSpectableGameAsync(string summonerId, Region region, string apiKey, out Team players1, out Team players2);
        Task<bool> SpectateGameAsync(string lolFolderPath);
    }
}