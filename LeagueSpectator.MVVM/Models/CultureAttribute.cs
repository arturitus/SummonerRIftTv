using System.Globalization;

namespace LeagueSpectator.MVVM.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CultureAttribute : Attribute
    {
        public CultureInfo CultureInfo { get; }

        public CultureAttribute(string cultureInfo)
        {
            CultureInfo = new CultureInfo(cultureInfo);
        }
    }
}

