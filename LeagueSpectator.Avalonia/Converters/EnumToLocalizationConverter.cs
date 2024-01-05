using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace LeagueSpectator.Avalonia.Converters
{
    public class EnumToLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object b = App.Current.FindResource(value.ToString());
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
