using System.Windows;
using System.Windows.Controls;
using Barrent.Common.WPF.ViewModels.Parameters;

namespace Barrent.Common.WPF.Views;

public class ParameterTemplateSelector : DataTemplateSelector
{
    public DataTemplate? FolderPathTemplate { get; set; }

    public DataTemplate? DefaultTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
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