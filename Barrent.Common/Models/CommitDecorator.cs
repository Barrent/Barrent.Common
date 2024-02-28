using Barrent.Common.Events;
using Barrent.Common.Interfaces.Models;

namespace Barrent.Common.Models;

/// <summary>
/// Postpones change of parameter value. Change can be done anytime later by calling <see cref="CommitChanges"/> method.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public class CommitDecorator<T> : ICommitDecorator<T> where T : IComparable
{
    /// <summary>
    /// Parameter to decorate.
    /// </summary>
    private readonly IParameter<T> _parameter;

    /// <summary>
    /// Value.
    /// </summary>
    private T? _value;

    /// <summary>
    /// Initializes a new instance of <see cref="CommitDecorator{T}"/>.
    /// </summary>
    /// <param name="parameter">Parameter to decorate.</param>
    public CommitDecorator(IParameter<T> parameter)
    {
        _parameter = parameter;
        _value = _parameter.Value;
    }

    /// <summary>
    /// Raised on value change.
    /// </summary>
    public event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T?>>? ValueChanged;

    /// <summary>
    /// Parameter name.
    /// </summary>
    public string? Name
    {
        get { return _parameter.Name; }
        set { _parameter.Name = value; }
    }

    /// <summary>
    /// Parameter value.
    /// </summary>
    public T? Value
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
                var args = new ParameterValueChangedEventArgs<T?>(oldValue, value);
                ValueChanged?.Invoke(this, args);
            }
        }
    }

    /// <summary>
    /// Writes cached value to decorated parameter. 
    /// </summary>
    public void CommitChanges()
    {
        _parameter.Value = _value;
    }

    /// <summary>
    /// Resets cached value.
    /// </summary>
    public void UndoChanges()
    {
        Value = _parameter.Value;
    }
}