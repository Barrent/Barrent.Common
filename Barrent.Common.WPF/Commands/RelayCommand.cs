using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Barrent.Common.WPF.Commands;

public class RelayCommand<T> : ICommand, IDisposable
{
    private readonly Predicate<T>? _canExecute;

    private readonly List<EventHandler> _canExecuteSubscribers;

    private readonly Action<T> _execute;
    private bool _isDisposed;

    public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
    {
        _canExecuteSubscribers = new List<EventHandler>();
        _execute = execute;
        _canExecute = canExecute;
    }

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
            _canExecuteSubscribers.Add(value);
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
            _canExecuteSubscribers.Remove(value);
        }
    }

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

    /// <summary>
    /// Performs application-defined tasks associated with freeing,
    /// releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Execute(T parameter)
    {
        _execute(parameter);
    }

    public void Execute(object parameter)
    {
        Execute((T)parameter);
    }

    /// <summary>
    /// Releases resources and unsubscribes event handlers.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (disposing)
        {
            foreach (var eventHandler in _canExecuteSubscribers.ToArray())
            {
                CanExecuteChanged -= eventHandler;
            }
        }

        _isDisposed = true;
    }
}

public class RelayCommand : RelayCommand<object>
{

    public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null) : base(execute, canExecute)
    {
    }
}