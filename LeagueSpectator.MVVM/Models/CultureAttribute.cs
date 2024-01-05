using System.Globalization;

namespace LeagueSpectator.MVVM.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CultureAttribute(string cultureInfo) : Attribute
    {
        public CultureInfo CultureInfo { get; } = new CultureInfo(cultureInfo);
    }
}

