using System;
using Barrent.Common.Events;
using Barrent.Common.Interfaces.Models;
using Barrent.Common.WPF.Interfaces.ViewModels.Parameters;

namespace Barrent.Common.WPF.ViewModels.Parameters;

/// <summary>
/// View model of a parameter.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public class ParameterViewModel<T> : ValidatableViewModelBase<ParameterViewModel<T>>, IParameterViewModel<T> where T : IComparable
{
    /// <summary>
    /// Initializes a new instance of <see cref="ParameterViewModel{T}"/>.
    /// </summary>
    /// <param name="parameter">Parameter to wrap.</param>
    /// <param name="isReadOnly">Indicates if parameter is readonly.</param>
    public ParameterViewModel(IParameter<T> parameter, bool isReadOnly = false)
        : this(parameter, new ErrorCriterionCollection<ParameterViewModel<T>>(), isReadOnly)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ParameterViewModel{T}"/>.
    /// </summary>
    /// <param name="parameter">Parameter to wrap.</param>
    /// <param name="errorCriteria">Errors to check for.</param>
    /// <param name="isReadOnly">Indicates if parameter is readonly.</param>
    public ParameterViewModel(IParameter<T> parameter, ErrorCriterionCollection<ParameterViewModel<T>> errorCriteria,
        bool isReadOnly = false)
        : base(errorCriteria)
    {
        IsReadOnly = isReadOnly;
        Parameter = parameter;
        Parameter.ValueChanged += OnValueChanged;
    }

    /// <summary>
    /// Indicates of parameter is read only.
    /// </summary>
    public bool IsReadOnly { get; }

    /// <summary>
    /// Parameter name.
    /// </summary>
    public string? Name => Parameter.Name;

    /// <summary>
    /// Parameter value.
    /// </summary>
    public T? Value
    {
        get => Parameter.Value;
        set => Parameter.Value = value;
    }

    /// <summary>
    /// Wrapped parameter.
    /// </summary>
    protected IParameter<T> Parameter { get; }


    /// <summary>
    /// Releases the memory associated to this class.
    /// All derived classes must override this function to release
    /// its respective managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">A value indicating whether the Dispose has been called by
    /// this class or by the garbage collector finalizer.</param>
    protected override void Dispose(bool disposing)
    {
        Parameter.ValueChanged -= OnValueChanged;
        base.Dispose(disposing);
    }

    /// <summary>
    /// Handles change of parameter value.
    /// </summary>
    /// <param name="sender">Event sender.</param>
    /// <param name="args">Event args.</param>
    protected virtual void OnValueChanged(IParameter<T> sender, ParameterValueChangedEventArgs<T?> args)
    {
        RaisePropertyChanged(nameof(Value));
    }
}