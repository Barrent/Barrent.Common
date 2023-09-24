using System.Windows.Input;

namespace Barrent.Common.WPF.Interfaces.ViewModels.Parameters;

public interface IFolderPathParameterViewModel : IParameterViewModel<string>
{
    ICommand BrowseFolderCommand { get; }
}