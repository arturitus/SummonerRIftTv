using Avalonia.Data.Converters;
using SummonerRiftTv.Avalonia.Extensions;
using System;
using System.Globalization;

namespace SummonerRiftTv.Avalonia.Converters
{
    public class UriToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return ((Uri)value).GetCachedBitmap();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
