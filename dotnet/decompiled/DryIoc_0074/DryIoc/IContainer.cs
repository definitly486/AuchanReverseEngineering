using System;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public interface IContainer : IRegistrator, IResolverContext, IResolver, IServiceProvider, IDisposable
{
	IContainer With(Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope);

	IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope, IScope currentScope);

	IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope, IScope currentScope, IsRegistryChangePermitted? isRegistryChangePermitted);

	IContainer WithNoMoreRegistrationAllowed(bool ignoreInsteadOfThrow = false);

	Factory ResolveFactory(Request request);

	Factory GetServiceFactoryOrDefault(Request request);

	KV<object, Factory>[] GetAllServiceFactories(Type serviceType, bool bothClosedAndOpenGenerics = false);

	KV<object, Factory>[] GetServiceRegisteredAndDynamicFactories(Type serviceType);

	Factory GetWrapperFactoryOrDefault(Type serviceType);

	bool IsWrapper(Type serviceType, Type openGenericServiceType = null);

	Factory[] GetDecoratorFactoriesOrDefault(Type serviceType);

	Factory[] GetDecoratorFactoriesOrDefault(int serviceTypeHash, Type serviceType);

	Expression GetDecoratorExpressionOrDefault(Request request);

	Type GetWrappedType(Type serviceType, Type requiredServiceType);

	Type GetWrappedType(Type serviceType);

	Expression GetConstantExpression(object item, Type itemType = null, bool throwIfStateRequired = false);

	bool ClearCache(Type serviceType, FactoryType? factoryType, object serviceKey);

	new void Use(Type serviceType, object instance);
}
