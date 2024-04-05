using SummonerRiftTv.MVVM.Services;

namespace SummonerRiftTv.MVVM.IServices
{
    public interface IFrozenDataService
    {
        public FrozenLeagueObject<T>? GetLeagueObject<T>(int id, T? leagueType) where T : Enum;
    }
}
