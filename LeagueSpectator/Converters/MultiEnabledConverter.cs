using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeagueSpectator.Converters
{
    public class MultiEnabledConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Any(x => x == null))
            {
                return false;
            }
            if (string.IsNullOrEmpty((string)values[0]!) || string.IsNullOrWhiteSpace((string)values[0]!) || (int)values[1]! <= -1)
            {
                return false;
            }
            return true;
        }
    }
}
