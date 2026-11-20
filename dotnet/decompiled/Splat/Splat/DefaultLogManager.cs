using System;

namespace Splat;

public sealed class DefaultLogManager : ILogManager
{
	private static readonly IFullLogger _nullLogger = new WrappingFullLogger(new NullLogger());

	private readonly MemoizingMRUCache<Type, IFullLogger> _loggerCache;

	public DefaultLogManager(IReadonlyDependencyResolver? dependencyResolver = null)
	{
		if (dependencyResolver == null)
		{
			dependencyResolver = Locator.Current;
		}
		_loggerCache = new MemoizingMRUCache<Type, IFullLogger>(delegate(Type type, object? _)
		{
			ILogger service = dependencyResolver.GetService<ILogger>();
			if (service == null)
			{
				throw new LoggingException("Couldn't find an ILogger. This should never happen, your dependency resolver is probably broken.");
			}
			return new WrappingFullLogger(new WrappingPrefixLogger(service, type));
		}, 64);
	}

	public IFullLogger GetLogger(Type type)
	{
		if (type == typeof(MemoizingMRUCache<Type, IFullLogger>))
		{
			return _nullLogger;
		}
		lock (_loggerCache)
		{
			return _loggerCache.Get(type);
		}
	}
}
