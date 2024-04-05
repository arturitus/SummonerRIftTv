using SummonerRiftTv.RiotApi.Extensions;
using SummonerRiftTv.RiotApi.IServices;
using SummonerRiftTv.RiotApi.Models;
using System.Net;
using System.Text.Json;

namespace SummonerRiftTv.RiotApi.Services
{
    public class RiotApiService : IRiotApiService
    {
        private const string BASE_ADDRESS = "https://summonerrifttv.netlify.app/";
        private const string NETLIFY_FUNCTIONS = ".netlify/functions";

        async Task<Account> IRiotApiService.GetAccountByNameTagAsync(string summonerName, string tagLine, Region? region)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_ADDRESS) })
            {
                if (string.IsNullOrEmpty(tagLine))
                {
                    tagLine = region.ToTagLine().ToString();
                }
                RiotServerRegion riotServerRegion = region.ToRiotServerRegion();

                string requestUri = $"{NETLIFY_FUNCTIONS}/getAccountByNameTag" +
                                    $"?riotServerRegion={riotServerRegion}" +
                                    $"&summonerName={summonerName}" +
                                    $"&tagLine={tagLine}";

                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.Account);
                    }

                    if (responseMessage.StatusCode is HttpStatusCode.NotFound)
                    {
                        throw new SummonerNotFoundException();
                    }

                    throw new InvalidApiKeyException();
                }
            }
        }

        async Task<HashSet<LeagueItem>> IRiotApiService.GetLeagueEntryBySummonerIdAsync(string summonerId, Region? region)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_ADDRESS) })
            {
                string requestUri = $"{NETLIFY_FUNCTIONS}/getLeagueEntries?region={region}&summonerId={summonerId}";
                //string requestUri = $"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{summonerId}?api_key=RGAPI-00db2ab2-cec3-441b-a283-eca0a9b52105";

                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri))
                {
                    //responseMessage.EnsureSuccessStatusCode();
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string json = await responseMessage.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize(json, SourceGenerationContext.Default.HashSetLeagueItem);
                    }

                    if (responseMessage.StatusCode is HttpStatusCode.NotFound)
                    {
                        throw new SummonerNotFoundException();
                    }

                    throw new InvalidApiKeyException();
                }
            }        
        }

        async Task<Summoner> IRiotApiService.GetSummonerByEncryptedPUUIDAsync(string encryptedPUUID, Region? region)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_ADDRESS) })
            {
                string requestUri = $"{NETLIFY_FUNCTIONS}/getSummonerByEncryptedPUUID?region={region}&encryptedPUUID={encryptedPUUID}";

                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.Summoner);
                    }

                    if (responseMessage.StatusCode is HttpStatusCode.NotFound)
                    {
                        throw new SummonerNotFoundException();
                    }

                    throw new InvalidApiKeyException();
                }
            }
        }

        async Task<Summoner> IRiotApiService.GetSummonerByNameAsync(string summonerName, Region? region)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_ADDRESS) })
            {
                string requestUri = $"{NETLIFY_FUNCTIONS}/getSummonerByName?region={region}&summonerName={summonerName}";
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri))
                {

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.Summoner);
                    }

                    if (responseMessage.StatusCode is HttpStatusCode.NotFound)
                    {
                        throw new SummonerNotFoundException();
                    }
                    throw new InvalidApiKeyException();
                }
            }
        }
        async Task<ActiveGame> IRiotApiService.GetActiveGameAsync(string summonerId, Region? region)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_ADDRESS) })
            {
                string requestUri = $"{NETLIFY_FUNCTIONS}/getActiveGames?region={region}&summonerId={summonerId}";

                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.ActiveGame);
                    }
                    if (responseMessage.StatusCode is HttpStatusCode.NotFound)
                    {
                        throw new GameNotFoundException();
                    }
                    throw new InvalidApiKeyException();
                }
            }
        }
    }
}
//https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/