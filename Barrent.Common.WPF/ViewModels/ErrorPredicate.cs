namespace Barrent.Common.WPF.ViewModels;

/// <summary>
/// Error condition to trigger.
/// </summary>
/// <typeparam name="T">Type of entity to validate.</typeparam>
/// <param name="entity">Entity to validate.</param>
/// <returns>True if condition is met.</returns>
public delegate bool ErrorPredicate<in T>(T entity);
