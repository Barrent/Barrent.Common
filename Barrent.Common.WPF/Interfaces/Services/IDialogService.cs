using System.Windows;

namespace Barrent.Common.WPF.Interfaces.Services;

/// <summary>
/// Service to show dialog windows.
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Show a dialog to select a folder.
    /// </summary>
    /// <returns> Path to selected folder. Null if canceled.</returns>
    string? SelectFolder();

    /// <summary>
    /// Show message box where OK is the only available option.
    /// </summary>
    /// <param name="message">Message to show.</param>
    /// <param name="caption">Window caption.</param>
    void Show(string message, string? caption = null);

    /// <summary>
    /// Shows custom dialog window.
    /// </summary>
    /// <param name="window">Window to display as dialog.</param>
    /// <returns>True if user accepted.</returns>
    bool? ShowDialog(Window window);
}