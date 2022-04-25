
using LeagueSpectator.Models;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    internal interface IMainWindowService
    {
        Task<bool> SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId);
        Task<bool> SearchSpectableGameAsync(string summonerId, Region region, string apiKey);
        Task<bool> SpectateGameAsync();
    }
}