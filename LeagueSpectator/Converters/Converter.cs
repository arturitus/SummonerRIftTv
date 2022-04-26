using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.Converters
{
    public class Converter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && value!.ToString() != "(unset)" && (int)value != -1)
            {
                return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/{value}.png")));
            }
            return null;
        }
    

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiEnabledConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)values[0]!) || string.IsNullOrWhiteSpace((string)values[0]!) || (int) values[1]! <= 0 )
            {
                return false;
            }
            return true;
        }
    }
}
