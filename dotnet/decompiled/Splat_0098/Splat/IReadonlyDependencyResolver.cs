using System;
using System.Collections.Generic;

namespace Splat;

public interface IReadonlyDependencyResolver
{
	object? GetService(Type? serviceType, string? contract = null);

	IEnumerable<object> GetServices(Type? serviceType, string? contract = null);
}
