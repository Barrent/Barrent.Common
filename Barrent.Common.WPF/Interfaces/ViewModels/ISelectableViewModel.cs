namespace Barrent.Common.WPF.Interfaces.ViewModels;

/// <summary>
/// View model of an item that can be selected. (Data grid row, list view item etc.)
/// </summary>
public interface ISelectableViewModel
{
    /// <summary>
    /// Indicates if item is selected.
    /// </summary>
    bool IsSelected { get; set; }
}