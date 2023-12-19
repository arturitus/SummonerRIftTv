using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;

namespace LeagueSpectator.MVVM.IServices
{
    public interface IMainWindowService
    {
        event Action<SpectateState, bool> SpectateChanged;
        Task<Team[]> SearchSpectableGameAsync(string summonerId, Region region, string apiKey);
        Task SpectateGameAsync(string lolFolderPath);
    }
}