using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Barrent.Common.WPF.Interfaces.ViewModels;

/// <summary>
/// View model of a menu item.
/// </summary>
public interface IMenuItemViewModel
{
    /// <summary>
    /// Command of menu item. Executed if there are no child items.
    /// </summary>
    ICommand Command { get; }

    /// <summary>
    /// Menu item text.
    /// </summary>
    string Header { get; }

    /// <summary>
    /// Child menu items.
    /// </summary>
    ObservableCollection<IMenuItemViewModel> Items { get; }
}