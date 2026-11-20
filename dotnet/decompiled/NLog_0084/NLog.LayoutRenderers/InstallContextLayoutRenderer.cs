using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers;

[LayoutRenderer("install-context")]
public class InstallContextLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public string Parameter { get; set; } = string.Empty;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		object value = GetValue(logEvent);
		if (value != null)
		{
			IFormatProvider formatProvider = GetFormatProvider(logEvent);
			builder.Append(Convert.ToString(value, formatProvider));
		}
	}

	private object? GetValue(LogEventInfo logEvent)
	{
		if (logEvent.Properties.TryGetValue(Parameter, out object value))
		{
			return value;
		}
		return null;
	}
}
