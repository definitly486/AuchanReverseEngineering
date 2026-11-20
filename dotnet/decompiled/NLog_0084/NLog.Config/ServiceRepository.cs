using System;

namespace NLog.Config;

public abstract class ServiceRepository : IServiceProvider
{
	public abstract void RegisterService(Type type, object instance);

	public abstract object GetService(Type serviceType);

	internal abstract bool TryGetService<T>(out T? serviceInstance) where T : class;

	internal ServiceRepository()
	{
	}
}
