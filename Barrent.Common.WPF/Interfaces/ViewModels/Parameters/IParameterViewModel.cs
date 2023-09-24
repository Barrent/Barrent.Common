using System.ComponentModel;

namespace Barrent.Common.WPF.Interfaces.ViewModels.Parameters;

public interface IParameterViewModel : INotifyDataErrorInfo, INotifyPropertyChanged
{
    bool IsReadOnly { get; }
    string? Name { get; }
}

public interface IParameterViewModel<T> : IParameterViewModel
{
    T Value { get; set; }
}