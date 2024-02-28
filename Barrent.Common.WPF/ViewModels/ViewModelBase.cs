using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Base view model.
/// </summary>
public abstract class ViewModelBase : BindableBase, IDisposable
{
    /// <summary>
    /// Indicates if object is already disposed.
    /// </summary>
    private bool _isDisposed;

    /// <summary>
    /// Performs application-defined tasks associated with freeing,
    /// releasing, or resetting unmanaged resources.
    /// </summary>
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

    /// <summary>
    /// Sets property value.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="currentValue">Current property value.</param>
    /// <param name="newValue">New value.</param>
    /// <param name="applyNewValue">Action to apply value.</param>
    /// <param name="propertyName">Name of property to update.</param>
    /// <returns>True if updated. False if new value is the same as the current one.</returns>
    protected bool SetProperty<T>(T currentValue, T newValue, Action<T> applyNewValue, [CallerMemberName] string? propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
        {
            applyNewValue(newValue);
            RaisePropertyChanged(propertyName);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Sets property value.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="variable">Ref of a field to update.</param>
    /// <param name="value">New value.</param>
    /// <param name="propertyName">Name of property that wraps updated field.</param>
    /// <returns>True if updated. False if new value is the same as the current one.</returns>
    protected bool SetValue<T>(ref T variable, T value, [CallerMemberName] string? propertyName = null)
    {
        return SetProperty(ref variable, value, propertyName);
    }

    /// <summary>
    /// Sets property value.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    /// <param name="currentValue">Current property value.</param>
    /// <param name="newValue">New value.</param>
    /// <param name="applyNewValue">Action to apply value.</param>
    /// <param name="propertyName">Name of property to update.</param>
    /// <returns>True if updated. False if new value is the same as the current one.</returns>
    protected bool SetValue<T>(T currentValue, T newValue, Action<T> applyNewValue, [CallerMemberName] string? propertyName = null)
    {
        return SetProperty(currentValue, newValue, applyNewValue, propertyName);
    }
}