using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Barrent.Common.WPF.ViewModels;

public abstract class ViewModelBase : BindableBase, IDisposable
{

    private bool _isDisposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the memory associated to this class.
    /// All derived classes must override this function to release
    /// its respective managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">A value indicating whether the Dispose has been called by
    /// this class or by the garbage collector finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            // Dispose only managed resources here.
        }

        // Dispose any unmanaged resources here.

        _isDisposed = true;
    }

    protected bool SetValue<T>(ref T variable, T value, [CallerMemberName] string propertyName = null)
    {
        return SetProperty(ref variable, value, propertyName);
    }

    protected bool SetValue<T>(T currentValue, T newValue, Action<T> applyNewValue, [CallerMemberName] string propertyName = null)
    {
        return SetProperty(currentValue, newValue, applyNewValue, propertyName);
    }

    protected bool SetProperty<T>(T currentValue, T newValue, Action<T> applyNewValue, [CallerMemberName] string propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
        {
            applyNewValue(newValue);
            RaisePropertyChanged(propertyName);
            return true;
        }

        return false;
    }
}