using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Barrent.Common.WPF.Converters;

public class BoolToStyleConverter : IValueConverter
{
    public Style TrueStyle { get; set; }

    public Style FalseStyle { get; set; }

    public Style DefaultStyle { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var flag = value as bool?;

        if (flag == true)
        {
            return TrueStyle;
        }

        if (flag == false)
        {
            return FalseStyle;
        }

        return DefaultStyle;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}