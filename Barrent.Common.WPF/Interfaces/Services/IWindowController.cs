using System;
using System.ComponentModel;

namespace Barrent.Common.WPF.Interfaces.Services;

public interface IWindowController
{
    event CancelEventHandler WindowClosing;
    event EventHandler WindowClosed;

    /// <summary>
    /// Shows the window.
    /// </summary>
    void Show();

    /// <summary>
    /// Closes the window.
    /// </summary>
    void Close();
}