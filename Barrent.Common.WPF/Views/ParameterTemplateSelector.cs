using System.Windows;
using System.Windows.Controls;
using Barrent.Common.WPF.ViewModels.Parameters;

namespace Barrent.Common.WPF.Views;

/// <summary>
/// Selects data template to display parameter view model.
/// </summary>
public class ParameterTemplateSelector : DataTemplateSelector
{
    /// <summary>
    /// Template of a parameter representing path to a folder.
    /// </summary>
    public DataTemplate? FolderPathTemplate { get; set; }

    /// <summary>
    /// Default template.
    /// </summary>
    public DataTemplate? DefaultTemplate { get; set; }

    /// <summary>
    /// When overridden in a derived class, returns a <see cref="DataTemplate" /> based on custom logic.
    /// </summary>
    /// <param name="item">The data object for which to select the template.</param>
    /// <param name="container">The data-bound object.</param>
    /// <returns>Returns a <see cref="DataTemplate" /> or <see langword="null" />. The default value is <see langword="null" />.</returns>
    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        if (item == null)
        {
            return base.SelectTemplate(item, container);
        }

        var type = item.GetType();

        if (type.IsAssignableTo(typeof(FolderPathParameterViewModel)) && FolderPathTemplate != null)
        {
            return FolderPathTemplate;
        }

        if (DefaultTemplate != null)
        {
            return DefaultTemplate;
        }

        return base.SelectTemplate(item, container);
    }
}