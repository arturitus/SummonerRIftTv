using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.RiotApi.IServices
{
    public interface IRiotApiService
    {
        Task<Account> GetAccountByNameTagAsync(string summonerName, string tagLine, Region region);
        Task<Summoner> GetSummonerByEncryptedPUUIDAsync(string encryptedPUUID, Region region);
        Task<Summoner> GetSummonerByNameAsync(string summonerName, Region region);
        Task<ActiveGame> GetActiveGameAsync(string summonerId, Region region);
    }
}