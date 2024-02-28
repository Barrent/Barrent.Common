using System.IO;
using System.Windows.Input;
using Barrent.Common.Events;
using Barrent.Common.Interfaces.Models;
using Barrent.Common.WPF.Interfaces.Services;
using Barrent.Common.WPF.Interfaces.ViewModels.Parameters;
using Barrent.Common.WPF.Resources;
using Prism.Commands;

namespace Barrent.Common.WPF.ViewModels.Parameters;

/// <summary>
/// Parameter containing folder path.
/// </summary>
public class FolderPathParameterViewModel : ParameterViewModel<string>, IFolderPathParameterViewModel
{
    /// <summary>
    /// Service to display a dialog to select a folder.
    /// </summary>
    private readonly IDialogService _dialogService;

    /// <summary>
    /// Initializes a new instance of <see cref="FolderPathParameterViewModel"/>
    /// </summary>
    /// <param name="dialogService"></param>
    /// <param name="parameter"></param>
    /// <param name="isReadOnly"></param>
    public FolderPathParameterViewModel(IDialogService dialogService,
        IParameter<string> parameter, bool isReadOnly = false)
        : base(parameter, isReadOnly)
    {
        _dialogService = dialogService;
        BrowseFolderCommand = new DelegateCommand(BrowseFolder);

        Validate();
        RegisterErrorCriteria();
        CheckForErrors();
    }

    /// <summary>
    /// Open select folder dialog.
    /// </summary>
    public ICommand BrowseFolderCommand { get; }

    /// <summary>
    /// Indicates if selected folder exists.
    /// </summary>
    public bool Exists { get; set; }

    /// <summary>
    /// Open dialog to pick a folder.
    /// </summary>
    private void BrowseFolder()
    {
        var path = _dialogService.SelectFolder();
        if (path != null)
        {
            Value = path;
        }
    }

    /// <summary>
    /// Handles change of wrapped parameter value to update validation.
    /// Useful when value is change outside of this view model.
    /// </summary>
    /// <param name="sender">Event sender.</param>
    /// <param name="args">Event args.</param>
    protected override void OnValueChanged(IParameter<string> sender, ParameterValueChangedEventArgs<string?> args)
    {
        Validate();
        base.OnValueChanged(sender, args);
    }

    /// <summary>
    /// Updates validation.
    /// </summary>
    private void Validate()
    {
        Exists = Directory.Exists(Value);
    }

    /// <summary>
    /// Register validation rules.
    /// </summary>
    private void RegisterErrorCriteria()
    {
        ErrorCriteria.Add(nameof(Value), ValidationStrings.FolderNotSelectedError, vm => string.IsNullOrEmpty(vm.Value));
        ErrorCriteria.Add(nameof(Value), ValidationStrings.FolderDoesntExist, vm => !((FolderPathParameterViewModel)vm).Exists);
    }
}