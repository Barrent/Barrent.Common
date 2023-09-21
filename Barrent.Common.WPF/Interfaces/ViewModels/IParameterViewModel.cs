using System.ComponentModel;

namespace Barrent.Common.WPF.Interfaces.ViewModels;

public interface IParameterViewModel : INotifyDataErrorInfo, INotifyPropertyChanged
{
    bool IsReadOnly { get; }
}

public interface IParameterViewModel<T> : IParameterViewModel
{
    T Value { get; set; }
}