using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Provides functionality for error validation.
/// </summary>
/// <typeparam name="T">Specific view model type</typeparam>
public abstract class ValidatableViewModelBase<T> : ViewModelBase, INotifyDataErrorInfo
    where T : ValidatableViewModelBase<T>
{
    #region Fields

    /// <summary>
    /// Occurred errors.
    /// </summary>
    private readonly Dictionary<string, List<string>> _detectedErrors;

    /// <summary>
    /// Indicates if there are any validation errors.
    /// </summary>
    private bool _hasErrors;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatableViewModelBase{T}"/> class.
    /// </summary>
    /// <param name="errors">Validation rules.</param>
    protected ValidatableViewModelBase(ErrorCollection<T> errors)
    {
        Errors = errors;
        _detectedErrors = new Dictionary<string, List<string>>();
    }

    /// <summary>
    /// Event raised when a property is changed.
    /// </summary>
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    /// <summary>
    /// Indicates if there are any validation errors.
    /// </summary>
    public bool HasErrors
    {
        get { return _hasErrors; }

        private set
        {
            SetValue(ref _hasErrors, value);
        }
    }

    /// <summary>
    /// Validation rules
    /// </summary>
    protected ErrorCollection<T> Errors { get; }

    /// <summary>
    /// Applies all rules to this instance.
    /// </summary>
    public void ApplyRules()
    {
        foreach (var propertyName in Errors.Select(x => x.PropertyName).Distinct())
        {
            ApplyRules(this, propertyName);
        }
    }

    /// <summary>
    /// Gets the validation errors for a specified property or for the entire entity.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    /// <returns>Error collection.</returns>
    public IEnumerable GetErrors(string propertyName)
    {
        return GetPropertyErrors(propertyName);
    }

    /// <summary>
    /// Gets the validation errors for a specified property or for the entire entity.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    /// <returns>Error collection.</returns>
    public IReadOnlyList<string> GetPropertyErrors(string propertyName)
    {
        IReadOnlyList<string> result;
        if (string.IsNullOrEmpty(propertyName))
        {
            var allErrors = new List<string>();

            foreach (var values in _detectedErrors.Values)
            {
                allErrors.AddRange(values);
            }

            result = allErrors;
        }
        else
        {
            result = _detectedErrors.TryGetValue(propertyName, out var error) ? error : new List<string>();
        }

        return result;
    }

    /// <summary>
    /// Applies the rules to this instance for the specified property.
    /// </summary>
    /// <param name="target">Target of validation</param>
    /// <param name="propertyName">Name of the property.</param>
    protected virtual void ApplyRules(object target, string propertyName)
    {
        var propertyErrors = Errors.Detect((T)target, propertyName).ToList();

        if (propertyErrors.Count > 0)
        {
            if (_detectedErrors.TryGetValue(propertyName, out var error))
            {
                error.Clear();
            }
            else
            {
                _detectedErrors[propertyName] = new List<string>();
            }

            _detectedErrors[propertyName].AddRange(propertyErrors);
        }
        else if (_detectedErrors.ContainsKey(propertyName))
        {
            _detectedErrors.Remove(propertyName);
        }

        OnErrorsChanged(propertyName);
    }

    /// <summary>
    /// Clears validation.
    /// </summary>
    protected void ClearErrors()
    {
        var properties = _detectedErrors.Keys;
        _detectedErrors.Clear();

        foreach (var property in properties)
        {
            OnErrorsChanged(property);
        }
    }

    /// <summary>
    /// Occurs when errors change
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    protected virtual void OnErrorsChanged(string propertyName)
    {
        HasErrors = _detectedErrors.Count > 0;
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    /// <summary>Raises this object's PropertyChanged event.</summary>
    /// <param name="args">The PropertyChangedEventArgs</param>
    protected override void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        if (string.IsNullOrEmpty(args.PropertyName))
        {
            ApplyRules();
        }
        else
        {
            ApplyRules(this, args.PropertyName);
        }

        base.OnPropertyChanged(args);
    }
}