using System;

namespace NLog.Config;

[Flags]
public enum StackTraceUsage
{
	None = 0,
	WithStackTrace = 1,
	WithFileNameAndLineNumber = 2,
	WithCallSite = 4,
	WithCallSiteClassName = 8,
	[Obsolete("Replace with `WithStackTrace`. Marked obsolete on NLog 5.0")]
	WithoutSource = 1,
	WithSource = 3,
	Max = 3
}
