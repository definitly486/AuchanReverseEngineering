using System;

namespace Splat;

public class FuncLogManager(Func<Type, IFullLogger> getLoggerFunc) : ILogManager
{
	private readonly Func<Type, IFullLogger> _inner = getLoggerFunc;

	public IFullLogger GetLogger(Type type)
	{
		return getLoggerFunc(type);
	}
}
