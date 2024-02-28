namespace Barrent.Common.Interfaces.Models;

/// <summary>
/// Postpones change of parameter value. Change can be done anytime later by calling <see cref="CommitChanges"/> method.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public interface ICommitDecorator<T> : IParameter<T> where T : IComparable
{
    /// <summary>
    /// Writes cached value to decorated parameter. 
    /// </summary>
    void CommitChanges();

    /// <summary>
    /// Resets cached value.
    /// </summary>
    void UndoChanges();
}