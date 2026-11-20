using NLog.Layouts;

namespace NLog;

public static class LayoutTypedExtensions
{
	public static T? RenderValue<T>(this Layout<T>? layout, LogEventInfo logEvent, T? defaultValue = default(T?))
	{
		if (layout != null)
		{
			return layout.RenderTypedValue(logEvent, defaultValue);
		}
		return defaultValue;
	}
}
