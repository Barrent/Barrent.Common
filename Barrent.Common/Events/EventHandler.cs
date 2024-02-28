namespace Barrent.Common.Events;

/// <summary>
/// Event handler with specified sender type.
/// </summary>
/// <typeparam name="TS">Sender type.</typeparam>
/// <typeparam name="TA">Argument type.</typeparam>
/// <param name="sender">Sender.</param>
/// <param name="args">Args.</param>
public delegate void EventHandler<in TS, in TA>(TS sender, TA args)
    where TA : EventArgs;