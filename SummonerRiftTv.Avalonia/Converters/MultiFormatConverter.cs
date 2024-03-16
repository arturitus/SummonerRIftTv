using Avalonia.Controls;
using Avalonia.Data.Converters;
using SummonerRiftTv.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SummonerRiftTv.Avalonia.Converters
{
    public class MultiFormatConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not string || values[1] is not InfoDialogKeys)
            {
                return string.Empty;
            }
            string b = App.Current.FindResource(values[1].ToString()) as string;
            return string.Format(b, values[0]);
        }
    }
}
