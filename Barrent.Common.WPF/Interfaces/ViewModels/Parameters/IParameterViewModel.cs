using System.ComponentModel;

namespace Barrent.Common.WPF.Interfaces.ViewModels.Parameters;

/// <summary>
/// Parameter view model.
/// </summary>
public interface IParameterViewModel : INotifyDataErrorInfo, INotifyPropertyChanged
{
    /// <summary>
    /// Indicates of parameter is read only.
    /// </summary>
    bool IsReadOnly { get; }

    /// <summary>
    /// Parameter name.
    /// </summary>
    string? Name { get; }
}

/// <summary>
/// Parameter view model.
/// </summary>
/// <typeparam name="T">Type of value.</typeparam>
public interface IParameterViewModel<T> : IParameterViewModel
{
    /// <summary>
    /// Parameter value.
    /// </summary>
    T? Value { get; set; }
}