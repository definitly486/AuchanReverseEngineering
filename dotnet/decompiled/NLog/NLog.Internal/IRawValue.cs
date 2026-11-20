namespace NLog.Internal;

internal interface IRawValue
{
	bool TryGetRawValue(LogEventInfo logEvent, out object? value);
}
