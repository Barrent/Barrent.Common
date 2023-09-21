using System;
using System.ComponentModel;
using System.Windows;
using Barrent.Common.WPF.Interfaces.Services;

namespace Barrent.Common.WPF.Services
{
    /// <summary>
    /// The dock state change manager.
    /// </summary>
    public class WindowController : IWindowController
    {
        /// <summary>
        /// The window.
        /// </summary>
        private readonly Window _window;

        public WindowController(Window window)
        {
            _window = window;
            _window.Closing += OnWindowClosing;
            _window.Closed += OnWindowClosed;
        }

        public event CancelEventHandler? WindowClosing;

        public event EventHandler? WindowClosed;

        /// <summary>
        /// Shows the window.
        /// </summary>
        public void Show()
        {
            _window.Show();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        public virtual void Close()
        {
            _window.Close();
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            _window.Closing -= OnWindowClosing;
            _window.Closed -= OnWindowClosed;
            WindowClosed?.Invoke(this, e);
        }

        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            WindowClosing?.Invoke(this, e);
        }
    }
}
