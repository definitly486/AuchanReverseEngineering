using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[ThreadAgnostic]
internal sealed class LiteralWithRawValueLayoutRenderer : LiteralLayoutRenderer, IRawValue
{
	private readonly bool _rawValueSuccess;

	private readonly object? _rawValue;

	public LiteralWithRawValueLayoutRenderer(string text, bool rawValueSuccess, object? rawValue)
	{
		_rawValueSuccess = rawValueSuccess;
		_rawValue = rawValue;
		base.Text = text;
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		value = _rawValue;
		return _rawValueSuccess;
	}
}
