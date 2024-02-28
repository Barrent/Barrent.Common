using System;
using System.ComponentModel;

namespace Barrent.Common.WPF.Interfaces.Services;

/// <summary>
/// Allows to control window state.
/// </summary>
public interface IWindowController
{
    /// <summary>
    /// Raised when window is closed.
    /// </summary>
    event EventHandler? WindowClosed;

    /// <summary>
    /// Raised when window is about to be closed.
    /// </summary>
    event CancelEventHandler? WindowClosing;

    /// <summary>
    /// Closes the window.
    /// </summary>
    void Close();

    /// <summary>
    /// Shows the window.
    /// </summary>
    void Show();
}