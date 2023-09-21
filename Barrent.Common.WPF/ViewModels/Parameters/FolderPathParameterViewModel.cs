using System.IO;
using System.Reflection.Metadata;
using System.Windows.Input;
using Barrent.Common.WPF.Events;
using Barrent.Common.WPF.Interfaces.Models;
using Barrent.Common.WPF.Interfaces.Services;
using Barrent.Common.WPF.Models;
using Barrent.Common.WPF.Resources;
using Prism.Commands;

namespace Barrent.Common.WPF.ViewModels.Parameters;

public class FolderPathParameterViewModel : ParameterViewModel<string>
{
    private readonly IDialogService _dialogService;

    public FolderPathParameterViewModel(IDialogService dialogService,
        IParameter<string> parameter, bool isReadOnly = false)
        : base(parameter, isReadOnly)
    {
        _dialogService = dialogService;
        BrowseFolderCommand = new DelegateCommand(BrowseFolder);

        Validate();
        RegisterErrors();
        ApplyRules();
    }

    public ICommand BrowseFolderCommand { get; }

    public bool Exists { get; set; }

    private void BrowseFolder()
    {
        var path = _dialogService.SelectFolder();
        if (path != null)
        {
            Value = path;
        }
    }

    protected override void OnValueChanged(IParameter<string> sender, ParameterValueChangedEventArgs<string> args)
    {
        Validate();
        base.OnValueChanged(sender, args);
    }


    private void Validate()
    {
        Exists = Directory.Exists(Value);
    }

    private void RegisterErrors()
    {
        Errors.Add(nameof(Value), ValidationStrings.FolderNotSelectedError, vm => string.IsNullOrEmpty(vm.Value));
        Errors.Add(nameof(Value), ValidationStrings.FolderDoesntExist, vm => !((FolderPathParameterViewModel)vm).Exists);
    }
}