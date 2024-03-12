using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Barrent.Common.WPF;

/// <summary>
/// Extends <see cref="Application"/> with DI container initialization.
/// </summary>
public abstract class BaseApp : Application
{
    /// <summary>
    /// DI container.
    /// </summary>
    protected IHost? Container { get; private set; }

    /// <summary>
    /// Initializes <see cref="Container"/> and registers app dependencies.
    /// </summary>
    protected void InitContainer()
    {
        if (Container == null)
        {
            Container = CreateContainer();
        }
    }

    /// <summary>
    /// Creates DI container.
    /// </summary>
    /// <returns>DI container.</returns>
    protected virtual IHost CreateContainer()
    {
        return Host.CreateDefaultBuilder().ConfigureServices(RegisterDependencies).Build();
    }

    /// <summary>
    /// Registers classes in the DI container.
    /// </summary>
    /// <param name="context">Build context.</param>
    /// <param name="services">Services.</param>
    protected abstract void RegisterDependencies(HostBuilderContext context, IServiceCollection services);

    /// <summary>
    /// Raises the <see cref="Application.Exit" /> event.
    /// </summary>
    /// <param name="e">An <see cref="ExitEventArgs" /> that contains the event data.</param>
    protected override async void OnExit(ExitEventArgs e)
    {
        if (Container != null)
        {
            await Container.StopAsync();
        }

        base.OnExit(e);
    }

    /// <summary>
    /// Creates instance of the main window.
    /// </summary>
    /// <returns>Main window.</returns>
    protected abstract Window ResolveMainWindow();

    /// <summary>
    /// Creates data context of the main window.
    /// </summary>
    /// <returns>View model of thr main window.</returns>
    protected abstract object ResolveMainWindowDataContext();

    /// <summary>
    /// Raises the <see cref="Application.Startup" /> event.
    /// </summary>
    /// <param name="e">A <see cref="StartupEventArgs" /> that contains the event data.</param>
    protected override async void OnStartup(StartupEventArgs e)
    {
        InitContainer();

        await Container!.StartAsync();

        var window = ResolveMainWindow();
        var viewModel = ResolveMainWindowDataContext();
        window.DataContext = viewModel;
        window.Show();

        base.OnStartup(e);
    }
}