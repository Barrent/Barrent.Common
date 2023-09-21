using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Barrent.Common.WPF.ViewModels;

public class ErrorCollection<T> : Collection<Error<T>>
{
    public void Add(string propertyName, string error, ErrorPredicate<T> errorCondition)
    {
        Add(new Error<T>(propertyName, error, errorCondition));
    }

    public IEnumerable<string> Detect(T obj, string propertyName)
    {
        foreach (var rule in this)
        {
            if (string.IsNullOrEmpty(propertyName) || rule.PropertyName.Equals(propertyName))
            {
                if (rule.Detect(obj))
                {
                    yield return rule.Message;
                }
            }
        }
    }
}