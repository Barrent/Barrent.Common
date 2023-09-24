using System;
using System.Globalization;
using System.Windows.Data;

namespace Barrent.Common.WPF.Converters;

public class DateTimeToStringConverter : IValueConverter
{
    public string Format { get; set; } = "dd.MM.yyyy HH:mm:ss";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var dateTime = value as DateTime?;
        if (dateTime == null)
        {
            return null;
        }

        return dateTime.Value.ToString(Format);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}