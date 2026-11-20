using System;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[ThreadAgnostic]
internal sealed class FuncThreadAgnosticLayoutRenderer : FuncLayoutRenderer, IRawValue
{
	public FuncThreadAgnosticLayoutRenderer(string layoutRendererName, Func<LogEventInfo, LoggingConfiguration?, object> renderMethod)
		: base(layoutRendererName, renderMethod)
	{
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		value = RenderValue(logEvent);
		return true;
	}
}
