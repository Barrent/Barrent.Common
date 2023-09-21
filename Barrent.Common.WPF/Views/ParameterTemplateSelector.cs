using System.Windows;
using System.Windows.Controls;
using Barrent.Common.WPF.ViewModels.Parameters;

namespace Barrent.Common.WPF.Views;

public class ParameterTemplateSelector : DataTemplateSelector
{
    public DataTemplate FolderPathTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var type = item.GetType();
        if (type.IsAssignableFrom(typeof(FolderPathParameterViewModel)))
        {
            return FolderPathTemplate;
        }

        return base.SelectTemplate(item, container);
    }
}