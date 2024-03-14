using LeagueSpectator.RiotApi.Extensions;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using System.Net;
using System.Text.Json;

namespace LeagueSpectator.RiotApi.Services
{
    public class RiotApiService : IRiotApiService
    {        
        async Task<Account> IRiotApiService.GetAccountByNameTag(string summonerName, string tagLine, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                if (string.IsNullOrEmpty(tagLine))
                {
                    tagLine = region.ToTagLine().ToString();
                }
                RiotServerRegion riotServerRegion = region.ToRiotServerRegion();
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{riotServerRegion}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{summonerName}/{tagLine}/?api_key={apiKey}").Result)
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

        async Task<Summoner> IRiotApiService.GetSummonerByEncryptedPUUID(string encryptedPUUID, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}?api_key={apiKey}").Result)
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

        async Task<Summoner> IRiotApiService.GetSummonerByNameAsync(string summonerName, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={apiKey}").Result)
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
        async Task<ActiveGame> IRiotApiService.GetActiveGameAsync(string summonerId, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{summonerId}?api_key={apiKey}").Result)
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