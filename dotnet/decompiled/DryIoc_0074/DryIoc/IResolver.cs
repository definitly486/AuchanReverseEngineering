using System;
using System.Collections.Generic;

namespace DryIoc;

public interface IResolver : IServiceProvider
{
	object Resolve(Type serviceType, IfUnresolved ifUnresolved);

	object Resolve(Type serviceType, object serviceKey, IfUnresolved ifUnresolved, Type requiredServiceType, Request preResolveParent, object[] args);

	IEnumerable<object> ResolveMany(Type serviceType, object serviceKey, Type requiredServiceType, Request preResolveParent, object[] args);
}
