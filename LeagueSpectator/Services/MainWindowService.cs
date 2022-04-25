

using LeagueSpectator.Models;
using Splat;
using System;
using System.Threading.Tasks;

namespace LeagueSpectator.Services
{
    internal class MainWindowService : IMainWindowService
    {
        private readonly IRiotApiService riotApiService;

        private string authentication;
        private long matchId;

        public MainWindowService()
        {
            riotApiService = Locator.Current.GetService<IRiotApiService>();
            authentication = string.Empty;
        }

        Task<bool> IMainWindowService.SearchSummonerAsync(string summonerName, Region region, string apiKey, out string summonerId)
        {
            try
            {
                Summoner summoner = riotApiService.GetSummonerByNameAsync(summonerName, region, apiKey).Result;
                summonerId = summoner.Id!;
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                summonerId = string.Empty;
                return Task.FromResult(false);
            }

        }

        async Task<bool> IMainWindowService.SearchSpectableGameAsync(string summonerId, Region region, string apiKey)
        {
            try
            {
                ActiveGame activeGame = await riotApiService.GetActiveGameAsync(summonerId, region, apiKey);
                authentication = activeGame.Observers!.EncryptionKey!;
                matchId = activeGame.GameId;
                return activeGame != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        Task<bool> IMainWindowService.SpectateGameAsync()
        {
            //TODO batFile con auth y matchid
            throw new NotImplementedException();
        }
    }
}
