using Avalonia.Data.Converters;
using LeagueSpectator.MVVM.Extensions;
using LeagueSpectator.MVVM.Services;
using System;
using System.Globalization;

namespace LeagueSpectator.Avalonia.Converters
{
    public class ObjectToLocalizationConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string b = ((Enum)value).GetDisplayName();
            string a = value.GetDisplayName(culture);
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
