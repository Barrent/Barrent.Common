﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Barrent.Common.WPF.Converters;

/// <summary>
/// Converts <see cref="DateTime"/> to <see cref="string"/>. Backward conversion is not implemented.
/// </summary>
public class DateTimeToStringConverter : IValueConverter
{
    /// <summary>
    /// Conversion format.
    /// </summary>
    public string Format { get; set; } = "dd.MM.yyyy HH:mm:ss";

    /// <summary>
    /// Convert a value.  Called when moving a value from source to target.
    /// </summary>
    /// <param name="value">value as produced by source binding</param>
    /// <param name="targetType">target type</param>
    /// <param name="parameter">converter parameter</param>
    /// <param name="culture">culture information</param>
    /// <returns>
    ///     Converted value.
    ///
    ///     System.Windows.DependencyProperty.UnsetValue may be returned to indicate that
    ///     the converter produced no value and that the fallback (if available)
    ///     or default value should be used instead.
    ///
    ///     Binding.DoNothing may be returned to indicate that the binding
    ///     should not transfer the value or use the fallback or default value.
    /// </returns>
    /// <remarks>
    /// The data binding engine does not catch exceptions thrown by a user-supplied
    /// converter.  Thus any exception thrown by Convert, or thrown by methods
    /// it calls and not caught by the Convert, will be treated as a runtime error
    /// (i.e. a crash).  Convert should handle anticipated problems by returning
    /// DependencyProperty.UnsetValue.
    /// </remarks>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var dateTime = value as DateTime?;
        if (dateTime == null)
        {
            return null;
        }

        return dateTime.Value.ToString(Format);
    }

    /// <summary>
    /// Convert back a value.  Called when moving a value from target to source.
    /// This should implement the inverse of Convert.
    /// </summary>
    /// <param name="value">value, as produced by target</param>
    /// <param name="targetType">target type</param>
    /// <param name="parameter">converter parameter</param>
    /// <param name="culture">culture information</param>
    /// <returns>
    ///     Converted back value.
    ///
    ///     Binding.DoNothing may be returned to indicate that no value
    ///     should be set on the source property.
    ///
    ///     System.Windows.DependencyProperty.UnsetValue may be returned to indicate
    ///     that the converter is unable to provide a value for the source
    ///     property, and no value will be set to it.
    /// </returns>
    /// <remarks>
    /// The data binding engine does not catch exceptions thrown by a user-supplied
    /// converter.  Thus any exception thrown by ConvertBack, or thrown by methods
    /// it calls and not caught by the ConvertBack, will be treated as a runtime error
    /// (i.e. a crash).  ConvertBack should handle anticipated problems by returning
    /// DependencyProperty.UnsetValue.
    /// </remarks>
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}