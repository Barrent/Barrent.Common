using Barrent.Common.Events;
using Barrent.Common.Interfaces.Models;

namespace Barrent.Common.Models;

/// <summary>
/// Extends any type with generic properties like name, value change event, etc.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
/// <param name="value">Parameter value.</param>
/// <param name="comparer">Comparer to verify value update.</param>
public class Parameter<T>(T? value, IComparer<T?>? comparer = null) : IParameter<T>
    where T : IComparable
{
    /// <summary>
    /// Comparer to verify value update.
    /// </summary>
    private IComparer<T?> _comparer = comparer ?? Comparer<T?>.Default;

    /// <summary>
    /// Parameter value.
    /// </summary>
    private T? _value = value;

    /// <summary>
    /// Raised on value change.
    /// </summary>
    public event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T?>>? ValueChanged;

    /// <summary>
    /// Parameter name.
    /// </summary>
    public string? Name { get; set; }

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

            if (_comparer.Compare(_value, value) != 0)
            {
                var oldValue = _value;
                _value = value;
                var args = new ParameterValueChangedEventArgs<T?>(oldValue, value);
                ValueChanged?.Invoke(this, args);
            }
        }
    }
}