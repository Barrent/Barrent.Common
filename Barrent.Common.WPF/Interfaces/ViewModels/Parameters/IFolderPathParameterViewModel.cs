using System.Windows.Input;

namespace Barrent.Common.WPF.Interfaces.ViewModels.Parameters;

/// <summary>
/// Folder path parameter.
/// </summary>
public interface IFolderPathParameterViewModel : IParameterViewModel<string>
{
    /// <summary>
    /// Open select folder dialog.
    /// </summary>
    ICommand BrowseFolderCommand { get; }

    /// <summary>
    /// Indicates if selected folder exists.
    /// </summary>
    bool Exists { get; }
}