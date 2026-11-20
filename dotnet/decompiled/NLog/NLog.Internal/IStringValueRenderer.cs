namespace NLog.Internal;

internal interface IStringValueRenderer
{
	string? GetFormattedString(LogEventInfo logEvent);
}
