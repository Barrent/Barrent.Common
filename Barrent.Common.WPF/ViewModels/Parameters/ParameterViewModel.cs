using System;
using Barrent.Common.WPF.Events;
using Barrent.Common.WPF.Interfaces.Models;
using Barrent.Common.WPF.Interfaces.ViewModels;

namespace Barrent.Common.WPF.ViewModels.Parameters;

public class ParameterViewModel<T> : ValidatableViewModelBase<ParameterViewModel<T>>, IParameterViewModel<T> where T : IComparable
{
    public ParameterViewModel(IParameter<T> parameter, bool isReadOnly = false)
        : this(parameter, new ErrorCollection<ParameterViewModel<T>>(), isReadOnly)
    {
    }

    public ParameterViewModel(IParameter<T> parameter, ErrorCollection<ParameterViewModel<T>> errors, bool isReadOnly = false)
        : base(errors)
    {
        IsReadOnly = isReadOnly;
        Parameter = parameter;
        Parameter.ValueChanged += OnValueChanged;
    }

    public bool IsReadOnly { get; }
    public string? Name => Parameter.Name;
    public T Value
    {
        get => Parameter.Value;
        set => Parameter.Value = value;
    }

    protected IParameter<T> Parameter { get; }


    protected override void Dispose(bool disposing)
    {
        Parameter.ValueChanged -= OnValueChanged;
        base.Dispose(disposing);
    }

    protected virtual void OnValueChanged(IParameter<T> sender, ParameterValueChangedEventArgs<T> args)
    {
        RaisePropertyChanged(nameof(Value));
    }
}