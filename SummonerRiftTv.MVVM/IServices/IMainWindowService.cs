using SummonerRiftTv.MVVM.DTOs;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.MVVM.IServices
{
    public interface IMainWindowService
    {
        event Action<SpectateState, bool> SpectateChanged;
        Task<ActiveGameDTO> SearchSpectableGameAsync(string summonerName, string tagLine, Region region);
        Task SpectateGameAsync(string lolFolderPath);
    }
}