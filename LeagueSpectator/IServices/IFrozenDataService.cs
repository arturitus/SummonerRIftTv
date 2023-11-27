using LeagueSpectator.Services;
using System;

namespace LeagueSpectator.IServices
{
    internal interface IFrozenDataService
    {
        public FrozenLeagueObject<T> GetLeagueObject<T>(int id, T leagueType) where T : Enum;
    }
}
