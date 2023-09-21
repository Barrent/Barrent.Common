using System;

namespace Barrent.Common.WPF.Events;

public delegate void EventHandler<in TS, in TA>(TS sender, TA args)
    where TA : EventArgs;
