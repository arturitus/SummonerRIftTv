using Avalonia.Data.Converters;
using LeagueSpectator.MVVM.Extensions;
using System;
using System.Globalization;

namespace LeagueSpectator.Converters
{
    public class ObjectToLocalizationConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string a = value.GetDisplayName(culture);
            return a;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
