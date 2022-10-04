using LeagueSpectator.Models;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    public interface IRiotApiService
    {
        Task<RiotApiResponse<Summoner>> GetSummonerByNameAsync(string summonerName, Region region, string apiKey);
        Task<RiotApiResponse<ActiveGame>> GetActiveGameAsync(string summonerId, Region region, string apiKey);
    }
}