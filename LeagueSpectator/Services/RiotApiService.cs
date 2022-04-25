using LeagueSpectator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    public class RiotApiService : IRiotApiService
    {
        async Task<ActiveGame> IRiotApiService.GetActiveGameAsync(string summonerId, Region region, string apiKey)
        {            
            using (HttpClient httpClient = new())
            {
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{region}1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{summonerId}?api_key={apiKey}").Result)
                {
                    responseMessage.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<ActiveGame>(await responseMessage.Content.ReadAsStringAsync());
                }
            }

        }

        async Task<Summoner> IRiotApiService.GetSummonerByNameAsync(string summonerName, Region region, string apiKey)
        {
            using (HttpClient httpClient = new())
            {
                using (HttpResponseMessage responseMessage = httpClient.GetAsync($"https://{region}1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={apiKey}").Result)
                {
                    responseMessage.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<Summoner>(await responseMessage.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
