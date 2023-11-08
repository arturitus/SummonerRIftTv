using LeagueSpectator.IServices;
using LeagueSpectator.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
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
                        return new RiotApiResponse<ActiveGame>(JsonConvert.DeserializeObject<ActiveGame>(await responseMessage.Content.ReadAsStringAsync()));
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
                        return new RiotApiResponse<Summoner>(JsonConvert.DeserializeObject<Summoner>(await responseMessage.Content.ReadAsStringAsync()));
                    }
                    throw new RiotApiError(responseMessage.StatusCode, await responseMessage.Content.ReadAsStringAsync(), nameof(IRiotApiService.GetSummonerByNameAsync));
                }
            }
        }
    }
}


///lol/league/v4/entries/by-summoner/{encryptedSummonerId}