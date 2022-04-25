using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetEnumValues<T>()
        {
            foreach (T asdt in Enum.GetValues(typeof(T)))
            {
                yield return asdt;
            }
        }
    }
}
