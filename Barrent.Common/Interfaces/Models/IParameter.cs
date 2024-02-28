using Barrent.Common.Events;

namespace Barrent.Common.Interfaces.Models;

/// <summary>
/// Extends any type with generic properties like name, value change event, etc.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public interface IParameter<T> where T : IComparable
{
    /// <summary>
    /// Raised on value change.
    /// </summary>
    event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T?>> ValueChanged;

    /// <summary>
    /// Parameter name.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Parameter value.
    /// </summary>
    T? Value { get; set; }
}