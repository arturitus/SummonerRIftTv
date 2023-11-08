using LeagueSpectator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.IServices
{
    internal interface IFrozenDataService
    {
        public FrozenLeagueObject<T> GetLeagueObject<T>(int id, T leagueType) where T : Enum;
    }
}
