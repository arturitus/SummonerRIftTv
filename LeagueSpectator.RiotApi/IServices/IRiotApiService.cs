using LeagueSpectator.RiotApi.Models;

namespace LeagueSpectator.RiotApi.IServices
{
    public interface IRiotApiService
    {
        Task<RiotApiResponse<Summoner>> GetSummonerByNameAsync(string summonerName, Region region, string apiKey);
        Task<RiotApiResponse<ActiveGame>> GetActiveGameAsync(string summonerId, Region region, string apiKey);
    }
}