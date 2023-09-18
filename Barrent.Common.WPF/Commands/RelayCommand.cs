using System;
using System.Windows.Input;

namespace Barrent.Common.WPF.Commands;

public class RelayCommand<T> : ICommand
{
    private readonly Predicate<T>? _canExecute;

    private readonly Action<T> _execute;

    public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(T parameter)
    {
        if (_canExecute == null)
        {
            return true;
        }

        return _canExecute(parameter);
    }

    public bool CanExecute(object parameter)
    {
        return CanExecute((T)parameter);
    }

    public void Execute(T parameter)
    {
        _execute(parameter);
    }

    public void Execute(object parameter)
    {
        Execute((T)parameter);
    }
}

public class RelayCommand : RelayCommand<object>
{

    public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null) : base(execute, canExecute)
    {
    }
}