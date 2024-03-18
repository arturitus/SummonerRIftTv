using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace SummonerRiftTv.Avalonia.Converters
{
    public class EnumToLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return App.Current.FindResource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
