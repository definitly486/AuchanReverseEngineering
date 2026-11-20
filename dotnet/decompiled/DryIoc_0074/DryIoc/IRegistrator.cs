using System;
using System.Collections.Generic;

namespace DryIoc;

public interface IRegistrator
{
	Rules Rules { get; }

	void Register(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered? ifAlreadyRegistered, bool isStaticallyChecked);

	bool IsRegistered(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition);

	void Unregister(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition);

	IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations();

	IEnumerable<DecoratorRegistrationInfo> GetDecoratorRegistrations();

	Factory[] GetRegisteredFactories(Type serviceType, object serviceKey, FactoryType factoryType);

	void Use(Type serviceType, object instance);
}
