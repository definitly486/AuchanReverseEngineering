using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("db-null")]
[ThreadAgnostic]
public class DbNullLayoutRenderer : LayoutRenderer, IRawValue
{
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object value)
	{
		value = DBNull.Value;
		return true;
	}
}
