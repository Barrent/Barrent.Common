using System.Windows;
using Barrent.Common.WPF.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Barrent.Common.WPF.Services;

/// <summary>
/// Service to show dialog windows.
/// </summary>
/// <param name="mainWindow">Main window that will be set as a parent of any displayed dialog.</param>
public class DialogService([FromKeyedServices(ServiceKey.Main)] Window mainWindow) : IDialogService
{
    /// <summary>
    /// Show message box where OK is the only available option.
    /// </summary>
    /// <param name="message">Message to show.</param>
    /// <param name="caption">Window caption.</param>
    public void Show(string message, string? caption = null)
    {
        MessageBox.Show(message, caption ?? string.Empty, MessageBoxButton.OK);
    }

    /// <summary>
    /// Show a dialog to select a folder.
    /// </summary>
    /// <returns> Path to selected folder. Null if canceled.</returns>
    public string? SelectFolder()
    {
        var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            return dialog.FileName;
        }

        return null;
    }

    /// <summary>
    /// Shows custom dialog window.
    /// </summary>
    /// <param name="window">Window to display as dialog.</param>
    /// <returns>True if user accepted.</returns>
    public bool? ShowDialog(Window window)
    {
        window.Owner = mainWindow;
        return window.ShowDialog();
    }
}