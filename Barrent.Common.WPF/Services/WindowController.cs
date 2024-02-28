using System;
using System.ComponentModel;
using System.Windows;
using Barrent.Common.WPF.Interfaces.Services;

namespace Barrent.Common.WPF.Services
{
    /// <summary>
    /// Allows to control window state.
    /// </summary>
    public class WindowController : IWindowController
    {
        /// <summary>
        /// Window to control.
        /// </summary>
        private readonly Window _window;

        /// <summary>
        /// Initializes a new instance of <see cref="WindowController"/>.
        /// </summary>
        /// <param name="window">Window to control.</param>
        public WindowController(Window window)
        {
            _window = window;
            _window.Closing += OnWindowClosing;
            _window.Closed += OnWindowClosed;
        }

        /// <summary>
        /// Raised when window is closed.
        /// </summary>
        public event EventHandler? WindowClosed;

        /// <summary>
        /// Raised when window is about to be closed.
        /// </summary>
        public event CancelEventHandler? WindowClosing;

        /// <summary>
        /// Closes the window.
        /// </summary>
        public virtual void Close()
        {
            _window.Close();
        }

        /// <summary>
        /// Shows the window.
        /// </summary>
        public void Show()
        {
            _window.Show();
        }

        /// <summary>
        /// Handles <see cref="Window.Closed"/>.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void OnWindowClosed(object? sender, EventArgs e)
        {
            _window.Closing -= OnWindowClosing;
            _window.Closed -= OnWindowClosed;
            WindowClosed?.Invoke(this, e);
        }

        /// <summary>
        /// Handles <see cref="Window.Closing"/>.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            WindowClosing?.Invoke(this, e);
        }
    }
}
