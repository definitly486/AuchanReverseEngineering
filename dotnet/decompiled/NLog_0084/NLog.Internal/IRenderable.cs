namespace NLog.Internal;

internal interface IRenderable
{
	string Render(LogEventInfo logEvent);
}
