using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

public class FuncLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	private readonly Func<LogEventInfo, LoggingConfiguration?, object> _renderMethod;

	public string LayoutRendererName { get; }

	[Obsolete("Public API-property was a mistake. Marked obsolete with NLog v6.0")]
	public Func<LogEventInfo, LoggingConfiguration?, object> RenderMethod => _renderMethod;

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected FuncLayoutRenderer(string layoutRendererName)
	{
		LayoutRendererName = layoutRendererName;
		_renderMethod = (LogEventInfo evt, LoggingConfiguration? cfg) => string.Empty;
	}

	public FuncLayoutRenderer(string layoutRendererName, Func<LogEventInfo, LoggingConfiguration?, object> renderMethod)
	{
		_renderMethod = Guard.ThrowIfNull(renderMethod, "renderMethod");
		LayoutRendererName = layoutRendererName;
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		object value = RenderValue(logEvent);
		AppendFormattedValue(builder, logEvent, value, Format, Culture);
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (!"@".Equals(Format))
		{
			return FormatHelper.TryFormatToString(RenderValue(logEvent), Format, GetFormatProvider(logEvent, Culture));
		}
		return null;
	}

	protected virtual object? RenderValue(LogEventInfo logEvent)
	{
		return _renderMethod(logEvent, base.LoggingConfiguration);
	}
}
