using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LeagueSpectator.Converters
{
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
