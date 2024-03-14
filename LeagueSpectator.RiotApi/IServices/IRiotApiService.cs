using LeagueSpectator.RiotApi.Models;

namespace LeagueSpectator.RiotApi.IServices
{
    public interface IRiotApiService
    {
        Task<Account> GetAccountByNameTag(string summonerName, string tagLine, Region region, string apiKey);
        Task<Summoner> GetSummonerByEncryptedPUUID(string encryptedPUUID, Region region, string apiKey);
        Task<Summoner> GetSummonerByNameAsync(string summonerName, Region region, string apiKey);
        Task<ActiveGame> GetActiveGameAsync(string summonerId, Region region, string apiKey);
    }
}