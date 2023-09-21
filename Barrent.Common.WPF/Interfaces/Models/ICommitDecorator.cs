using System;

namespace Barrent.Common.WPF.Interfaces.Models;

public interface ICommitDecorator<T> : IParameter<T> where T : IComparable
{
    void CommitChanges();
}