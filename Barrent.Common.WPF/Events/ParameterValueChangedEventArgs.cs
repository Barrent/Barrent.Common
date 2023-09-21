using System;

namespace Barrent.Common.WPF.Events;

public class ParameterValueChangedEventArgs<T> : EventArgs
{
    public ParameterValueChangedEventArgs(T oldValue, T value)
    {
        OldValue = oldValue;
        Value = value;
    }

    public T Value { get; }

    public T OldValue { get; }
}