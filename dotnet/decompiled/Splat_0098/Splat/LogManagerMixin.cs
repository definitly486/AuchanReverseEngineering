namespace Splat;

public static class LogManagerMixin
{
	public static IFullLogger GetLogger<T>(this ILogManager logManager)
	{
		logManager.ThrowArgumentNullExceptionIfNull("logManager");
		return logManager.GetLogger(typeof(T));
	}
}
