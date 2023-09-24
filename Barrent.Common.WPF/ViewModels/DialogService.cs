using System.Windows;
using Barrent.Common.WPF.Interfaces.Services;
using Barrent.Common.WPF.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Barrent.Common.WPF.ViewModels;

public class DialogService : IDialogService
{
    private readonly Window _mainWindow;

    public DialogService([FromKeyedServices(ServiceKey.Main)] Window mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public void Show(string message, string? caption = null)
    {
        MessageBox.Show(message, caption ?? string.Empty, MessageBoxButton.OK);
    }

    public string? SelectFolder()
    {
        var dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            return dialog.FileName;
        }

        return null;
    }

    public bool? ShowDialog(Window window)
    {
        window.Owner = _mainWindow;
        return window.ShowDialog();
    }
}