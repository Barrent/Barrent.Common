using System.Windows;

namespace Barrent.Common.WPF.Interfaces.Services;

public interface IDialogService
{
    void Show(string message, string? caption = null);

    string? SelectFolder();
    bool? ShowDialog(Window window);
}