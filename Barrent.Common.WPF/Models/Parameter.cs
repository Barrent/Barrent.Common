using System;
using Barrent.Common.WPF.Events;
using Barrent.Common.WPF.Interfaces.Models;

namespace Barrent.Common.WPF.Models;

public class Parameter<T> : IParameter<T> where T : IComparable
{
    private T? _value;

    public Parameter(T value)
    {
        _value = value;
    }

    public event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T>>? ValueChanged;

    public string? Name { get; set; }

    public T Value
    {
        get { return _value; }
        set
        {
            if (Equals(_value, value))
            {
                return;
            }

            if (_value == null || _value.CompareTo(value) != 0)
            {
                var oldValue = _value;
                _value = value;
                var args = new ParameterValueChangedEventArgs<T>(oldValue, value);
                ValueChanged?.Invoke(this, args);
            }
        }
    }
}