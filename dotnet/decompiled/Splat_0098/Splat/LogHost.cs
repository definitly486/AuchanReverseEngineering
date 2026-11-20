using System;

namespace Splat;

public static class LogHost
{
	public static IStaticFullLogger Default => new StaticFullLogger((Locator.Current.GetService<ILogManager>() ?? throw new LoggingException("ILogManager is null. This should never happen, your dependency resolver is broken")).GetLogger(typeof(LogHost)));

	public static IFullLogger Log<T>(this T logClassInstance) where T : IEnableLogger
	{
		ILogManager service = Locator.Current.GetService<ILogManager>();
		if (service == null)
		{
			throw new InvalidOperationException("ILogManager is null. This should never happen, your dependency resolver is broken");
		}
		return service.GetLogger<T>();
	}
}
