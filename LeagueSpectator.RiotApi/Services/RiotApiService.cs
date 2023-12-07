using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using System.Text.Json;

namespace LeagueSpectator.RiotApi.Services
{
    public class RiotApiService : IRiotApiService
    {
        async Task<RiotApiResponse<ActiveGame>> IRiotApiService.GetActiveGameAsync(string summonerId, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                object regionConcat = region;
                if (region != Region.KR && region != Region.RU)
                {
                    regionConcat = $"{regionConcat}1";
                }
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{regionConcat}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{summonerId}?api_key={apiKey}").Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return new RiotApiResponse<ActiveGame>(JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.ActiveGame));
                    }
                    throw new RiotApiError(responseMessage.StatusCode, await responseMessage.Content.ReadAsStringAsync(), nameof(IRiotApiService.GetActiveGameAsync));
                    //responseMessage.EnsureSuccessStatusCode();
                }
            }
        }

        async Task<RiotApiResponse<Summoner>> IRiotApiService.GetSummonerByNameAsync(string summonerName, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                object regionConcat = region;
                if (region != Region.KR && region != Region.RU && region != Region.EUNE)
                {
                    regionConcat = $"{regionConcat}1";
                }
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{regionConcat}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={apiKey}").Result)
                {
                    //responseMessage.EnsureSuccessStatusCode();
                    //return JsonConvert.DeserializeObject<Summoner>(await responseMessage.Content.ReadAsStringAsync());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return new RiotApiResponse<Summoner>(JsonSerializer.Deserialize(await responseMessage.Content.ReadAsStringAsync(), SourceGenerationContext.Default.Summoner));
                    }
                    throw new RiotApiError(responseMessage.StatusCode, await responseMessage.Content.ReadAsStringAsync(), nameof(IRiotApiService.GetSummonerByNameAsync));
                }
            }
        }
    }
}


///lol/league/v4/entries/by-summoner/{encryptedSummonerId}