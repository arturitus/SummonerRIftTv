using System.Globalization;

namespace LeagueSpectator.MVVM.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class LocalizationFieldAttribute : Attribute
    {
        public CultureInfo CultureInfo { get; }
        public string DisplayName { get; }

        public LocalizationFieldAttribute(string cultureInfo, string displayName)
        {
            CultureInfo = new CultureInfo(cultureInfo);
            DisplayName = displayName;
        }
    }
}

