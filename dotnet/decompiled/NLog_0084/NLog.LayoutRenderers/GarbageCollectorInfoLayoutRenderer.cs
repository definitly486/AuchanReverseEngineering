using System;
using System.Text;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("gc")]
public class GarbageCollectorInfoLayoutRenderer : LayoutRenderer
{
	public GarbageCollectorProperty Property { get; set; }

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		long value = GetValue();
		if (value >= 0 && value < uint.MaxValue)
		{
			builder.AppendInvariant((uint)value);
		}
		else
		{
			builder.Append(value);
		}
	}

	private long GetValue()
	{
		long result = 0L;
		switch (Property)
		{
		case GarbageCollectorProperty.TotalMemory:
			result = GC.GetTotalMemory(forceFullCollection: false);
			break;
		case GarbageCollectorProperty.TotalMemoryForceCollection:
			result = GC.GetTotalMemory(forceFullCollection: true);
			break;
		case GarbageCollectorProperty.CollectionCount0:
			result = GC.CollectionCount(0);
			break;
		case GarbageCollectorProperty.CollectionCount1:
			result = GC.CollectionCount(1);
			break;
		case GarbageCollectorProperty.CollectionCount2:
			result = GC.CollectionCount(2);
			break;
		case GarbageCollectorProperty.MaxGeneration:
			result = GC.MaxGeneration;
			break;
		}
		return result;
	}
}
