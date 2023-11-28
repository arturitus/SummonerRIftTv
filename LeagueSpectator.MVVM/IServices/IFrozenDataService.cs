using LeagueSpectator.MVVM.Services;

namespace LeagueSpectator.MVVM.IServices
{
    public interface IFrozenDataService
    {
        public FrozenLeagueObject<T> GetLeagueObject<T>(int id, T leagueType) where T : Enum;
    }
}
