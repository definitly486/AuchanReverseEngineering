using System;
using System.Collections.Generic;

namespace NLog.Internal;

internal interface IScopeContextAsyncState : IDisposable
{
	IScopeContextAsyncState? Parent { get; }

	object? NestedState { get; }

	long NestedStateTimestamp { get; }

	IReadOnlyCollection<KeyValuePair<string, object?>>? CaptureContextProperties(ref ScopeContextPropertyCollector contextCollector);

	IList<object>? CaptureNestedContext(ref ScopeContextNestedStateCollector contextCollector);
}
