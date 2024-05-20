using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.RiotApi.IServices
{
    public interface IRiotApiService
    {
        Task<Account> GetAccountByNameTagAsync(string summonerName, string tagLine, Region? region);
        Task<Summoner> GetSummonerByEncryptedPUUIDAsync(string encryptedPUUID, Region? region);
        Task<ActiveGame> GetActiveGameAsync(string encryptedPUUID, Region? region);
        Task<HashSet<LeagueItem>> GetLeagueEntryBySummonerIdAsync(string summonerId, Region? region);
    }
}