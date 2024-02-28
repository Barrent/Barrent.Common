using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Collection of error criteria.
/// </summary>
/// <typeparam name="T">Type of entity to validate.</typeparam>
public class ErrorCriterionCollection<T> : Collection<ErrorCriterion<T>>
{
    /// <summary>
    /// Adds criterion to the collection.
    /// </summary>
    /// <param name="propertyName">Name of property of entity to validate.</param>
    /// <param name="error">Error message.</param>
    /// <param name="errorCondition">Error condition.</param>
    public void Add(string propertyName, string error, ErrorPredicate<T> errorCondition)
    {
        Add(new ErrorCriterion<T>(propertyName, error, errorCondition));
    }

    /// <summary>
    /// Checks property of the entity for errors.
    /// </summary>
    /// <param name="entity">Entity to check.</param>
    /// <param name="propertyName">Property to check.</param>
    /// <returns>Error messages.</returns>
    public IEnumerable<string> CheckForError(T entity, string propertyName)
    {
        foreach (var rule in this)
        {
            if (string.IsNullOrEmpty(propertyName) || rule.PropertyName.Equals(propertyName))
            {
                if (rule.CheckForError(entity))
                {
                    yield return rule.Message;
                }
            }
        }
    }
}