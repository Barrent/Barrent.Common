namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Stores condition to trigger an error.
/// </summary>
/// <typeparam name="T">Type of object to validate.</typeparam>
/// <param name="propertyName">Name of property to validate.</param>
/// <param name="message">Error message.</param>
/// <param name="errorCondition">Error condition.</param>
public class ErrorCriterion<T>(string propertyName, string message, ErrorPredicate<T> errorCondition)
{
    /// <summary>
    /// Name of property to validate.
    /// </summary>
    public string PropertyName { get; } = propertyName;

    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; } = message;

    /// <summary>
    /// Checks entity for error.
    /// </summary>
    /// <param name="entity">Entity to validate.</param>
    /// <returns>True if there is an error.</returns>
    public bool CheckForError(T entity)
    {
        return errorCondition(entity);
    }
}