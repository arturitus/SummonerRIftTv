using LeagueSpectator.Models;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    public interface IRiotApiService
    {
        Task<Summoner> GetSummonerByNameAsync(string summonerName, Region region, string apiKey);
        Task<ActiveGame> GetActiveGameAsync(string summonerId, Region region, string apiKey);
    }
}