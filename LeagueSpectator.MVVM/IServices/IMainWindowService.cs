using LeagueSpectator.MVVM.DTOs;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;

namespace LeagueSpectator.MVVM.IServices
{
    public interface IMainWindowService
    {
        event Action<SpectateState, bool> SpectateChanged;
        Task<ActiveGameDTO> SearchSpectableGameAsync(string summonerName, string tagLine, Region region, string apiKey);
        Task SpectateGameAsync(string lolFolderPath);
    }
}