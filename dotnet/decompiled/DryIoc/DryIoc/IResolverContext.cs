using System;

namespace DryIoc;

public interface IResolverContext : IResolver, IServiceProvider, IDisposable
{
	bool IsDisposed { get; }

	object DisposeInfo { get; }

	IResolverContext Parent { get; }

	IResolverContext Root { get; }

	IScope SingletonScope { get; }

	IScopeContext ScopeContext { get; }

	IScope CurrentScope { get; }

	IScope CurrentOrSingletonScope { get; }

	IScope OwnCurrentScope { get; }

	IResolverContext WithCurrentScope(IScope scope);

	void Use(Type serviceType, object instance);

	void InjectPropertiesAndFields(object instance, string[] propertyAndFieldNames);
}
