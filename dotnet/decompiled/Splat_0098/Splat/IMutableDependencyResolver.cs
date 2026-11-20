using System;

namespace Splat;

public interface IMutableDependencyResolver
{
	bool HasRegistration(Type? serviceType, string? contract = null);

	void Register(Func<object?> factory, Type? serviceType, string? contract = null);

	void UnregisterCurrent(Type? serviceType, string? contract = null);

	void UnregisterAll(Type? serviceType, string? contract = null);

	IDisposable ServiceRegistrationCallback(Type serviceType, string? contract, Action<IDisposable> callback);
}
