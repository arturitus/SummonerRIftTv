using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Styling;
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
    public class EnumToLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = App.Current.FindResource(value.ToString());
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
}
