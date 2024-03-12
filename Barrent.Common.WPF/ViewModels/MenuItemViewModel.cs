using System.Collections.ObjectModel;
using System.Windows.Input;
using Barrent.Common.WPF.Interfaces.ViewModels;

namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Viewmodel of menu item.
/// </summary>
public class MenuItemViewModel : IMenuItemViewModel
{
    /// <summary>
    /// Command of menu item. Executed if there are no child items.
    /// </summary>
    public ICommand? Command { get; set; }

    /// <summary>
    /// Menu item text.
    /// </summary>
    public string? Header { get; set; }

    /// <summary>
    /// Child menu items.
    /// </summary>
    public ObservableCollection<IMenuItemViewModel>? Items { get; set; }
}