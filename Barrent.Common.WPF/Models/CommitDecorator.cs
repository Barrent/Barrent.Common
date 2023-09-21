using System;
using Barrent.Common.WPF.Events;
using Barrent.Common.WPF.Interfaces.Models;

namespace Barrent.Common.WPF.Models;

public class CommitDecorator<T> : ICommitDecorator<T> where T : IComparable
{
    private readonly IParameter<T> _parameter;
    private T? _value;

    public CommitDecorator(IParameter<T> parameter)
    {
        _parameter = parameter;
        _value = _parameter.Value;
    }

    public event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T>>? ValueChanged;

    public string? Name
    {
        get { return _parameter.Name; }
        set { _parameter.Name = value; }
    }

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

    public void CommitChanges()
    {
        _parameter.Value = _value;
    }
}