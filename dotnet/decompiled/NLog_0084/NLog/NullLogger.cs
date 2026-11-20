using NLog.Internal;

namespace NLog;

public sealed class NullLogger : Logger
{
	public NullLogger(LogFactory factory)
	{
		Guard.ThrowIfNull(factory, "factory");
		string empty = string.Empty;
		ITargetWithFilterChain[] noTargetsByLevel = TargetWithFilterChain.NoTargetsByLevel;
		Initialize(empty, noTargetsByLevel, factory);
	}
}
