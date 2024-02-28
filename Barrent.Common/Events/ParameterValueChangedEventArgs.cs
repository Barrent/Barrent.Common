namespace Barrent.Common.Events;

/// <summary>
/// Args of an event raised on value change.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
/// <param name="oldValue">Old value.</param>
/// <param name="value">New value.</param>
public class ParameterValueChangedEventArgs<T>(T oldValue, T value) : EventArgs
{
    /// <summary>
    /// Current value.
    /// </summary>
    public T Value { get; } = value;

    /// <summary>
    /// Previous value.
    /// </summary>
    public T OldValue { get; } = oldValue;
}