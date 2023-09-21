using System;
using Barrent.Common.WPF.Events;

namespace Barrent.Common.WPF.Interfaces.Models;

public interface IParameter<T>
    where T : IComparable
{
    event EventHandler<IParameter<T>, ParameterValueChangedEventArgs<T>> ValueChanged;

    string? Name { get; set; }

    T Value { get; set; }
}