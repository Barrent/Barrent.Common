using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Barrent.Common.WPF.Interfaces.ViewModels;

public interface IMenuItemViewModel
{
    ICommand Command { get; }
    string Header { get; }

    ObservableCollection<IMenuItemViewModel> Items { get; }
}