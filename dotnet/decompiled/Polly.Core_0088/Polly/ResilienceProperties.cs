using System.Collections.Generic;
using System.Diagnostics;

namespace Polly;

[DebuggerDisplay("{Options}")]
public sealed class ResilienceProperties
{
	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	internal IDictionary<string, object?> Options { get; set; } = new Dictionary<string, object>();
}
