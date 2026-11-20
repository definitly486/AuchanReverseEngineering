using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class Resolver
{
	internal static readonly MethodInfo ResolveFastMethod = typeof(IResolver).Method("Resolve", typeof(Type), typeof(IfUnresolved));

	internal static readonly MethodInfo ResolveMethod = typeof(IResolver).Method("Resolve", typeof(Type), typeof(object), typeof(IfUnresolved), typeof(Type), typeof(Request), typeof(object[]));

	internal static readonly MethodInfo ResolveManyMethod = typeof(IResolver).GetMethod("ResolveMany");

	internal static readonly ConstructorInfo ResolutionScopeNameCtor = typeof(ResolutionScopeName).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];

	public static object Resolve(this IResolver resolver, Type serviceType)
	{
		return resolver.Resolve(serviceType, IfUnresolved.Throw);
	}

	public static object Resolve(this IResolver resolver, Type serviceType, IfUnresolved ifUnresolved)
	{
		return resolver.Resolve(serviceType, ifUnresolved);
	}

	public static TService Resolve<TService>(this IResolver resolver, IfUnresolved ifUnresolved = IfUnresolved.Throw)
	{
		return (TService)resolver.Resolve(typeof(TService), ifUnresolved);
	}

	public static object Resolve(this IResolver resolver, Type serviceType, bool ifUnresolvedReturnDefault)
	{
		return resolver.Resolve(serviceType, ifUnresolvedReturnDefault ? IfUnresolved.ReturnDefault : IfUnresolved.Throw);
	}

	public static object Resolve<TService>(this IResolver resolver, bool ifUnresolvedReturnDefault)
	{
		return resolver.Resolve(typeof(TService), ifUnresolvedReturnDefault);
	}

	public static object Resolve(this IResolver resolver, Type serviceType, Type requiredServiceType, IfUnresolved ifUnresolved = IfUnresolved.Throw, object[] args = null, object serviceKey = null)
	{
		return resolver.Resolve(serviceType, serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static TService Resolve<TService>(this IResolver resolver, Type requiredServiceType, IfUnresolved ifUnresolved = IfUnresolved.Throw, object[] args = null, object serviceKey = null)
	{
		return (TService)resolver.Resolve(typeof(TService), serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static TService Resolve<TService, TRequiredService>(this IResolver resolver, IfUnresolved ifUnresolved = IfUnresolved.Throw, object[] args = null, object serviceKey = null)
	{
		return (TService)resolver.Resolve(typeof(TService), serviceKey, ifUnresolved, typeof(TRequiredService), Request.Empty, args);
	}

	public static object Resolve(this IResolver resolver, Type serviceType, object serviceKey, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, object[] args = null)
	{
		return resolver.Resolve(serviceType, serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static TService Resolve<TService>(this IResolver resolver, object serviceKey, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, object[] args = null)
	{
		return (TService)resolver.Resolve(typeof(TService), serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static object Resolve(this IResolver resolver, Type serviceType, object[] args, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, object serviceKey = null)
	{
		return resolver.Resolve(serviceType, serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static TService Resolve<TService>(this IResolver resolver, object[] args, IfUnresolved ifUnresolved = IfUnresolved.Throw, Type requiredServiceType = null, object serviceKey = null)
	{
		return (TService)resolver.Resolve(typeof(TService), serviceKey, ifUnresolved, requiredServiceType, Request.Empty, args);
	}

	public static IEnumerable<TService> ResolveMany<TService>(this IResolver resolver, Type requiredServiceType = null, ResolveManyBehavior behavior = ResolveManyBehavior.AsLazyEnumerable, object[] args = null, object serviceKey = null)
	{
		if (behavior != ResolveManyBehavior.AsLazyEnumerable)
		{
			return resolver.Resolve<IEnumerable<TService>>(serviceKey, IfUnresolved.Throw, requiredServiceType, args);
		}
		return resolver.ResolveMany(typeof(TService), serviceKey, requiredServiceType, Request.Empty, args).Cast<TService>();
	}

	public static IEnumerable<object> ResolveMany(this IResolver resolver, Type serviceType, ResolveManyBehavior behavior = ResolveManyBehavior.AsLazyEnumerable, object[] args = null, object serviceKey = null)
	{
		return resolver.ResolveMany<object>(serviceType, behavior, args, serviceKey);
	}

	public static object New(this IResolver resolver, Type concreteType, Made made = null, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return resolver.Resolve<IContainer>().New(concreteType, null, made, registrySharing);
	}

	public static T New<T>(this IResolver resolver, Made made = null, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return (T)resolver.New(typeof(T), made, registrySharing);
	}

	public static T New<T>(this IResolver resolver, Made.TypedMade<T> made, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return (T)resolver.New(typeof(T), made, registrySharing);
	}

	public static Expression CreateResolutionExpression(Request request, bool openResolutionScope = false, bool asResolutionCall = false)
	{
		if (request.Rules.DependencyResolutionCallExprs != null)
		{
			Factory factory = request.Factory;
			if (factory != null && !factory.HasRuntimeState)
			{
				PopulateDependencyResolutionCallExpressions(request);
			}
		}
		IContainer container = request.Container;
		Type serviceType = request.ServiceType;
		ConstantExpression arg = Expression.ConstantOf(serviceType);
		ServiceDetails serviceDetails = request.GetServiceDetails();
		ConstantExpression arg2 = serviceDetails.IfUnresolved.ToConstant();
		ConstantExpression arg3 = serviceDetails.RequiredServiceType.ToConstant();
		Expression arg4 = ((serviceDetails.ServiceKey == null) ? Expression.NullConstant : container.GetConstantExpression(serviceDetails.ServiceKey, typeof(object)));
		Expression instance;
		if (!openResolutionScope)
		{
			instance = ResolverContext.GetRootOrSelfExpr(request);
		}
		else
		{
			NewExpression arg5 = Expression.New(ResolutionScopeNameCtor, Expression.ConstantOf(request.GetActualServiceType()), arg4);
			Factory factory2 = request.Factory;
			ConstantExpression arg6 = Expression.Constant(factory2 == null || !factory2.Setup.AvoidResolutionScopeTracking);
			instance = Expression.Call(ResolverContext.OpenScopeMethod, FactoryDelegateCompiler.ResolverContextParamExpr, arg5, arg6);
		}
		RequestFlags requestFlags = RequestFlags.Default;
		if (openResolutionScope)
		{
			requestFlags |= RequestFlags.OpensResolutionScope;
		}
		if (asResolutionCall || (request.Flags & RequestFlags.StopRecursiveDependencyCheck) != RequestFlags.Default)
		{
			requestFlags |= RequestFlags.StopRecursiveDependencyCheck;
		}
		Expression requestExpression = container.GetRequestExpression(request.DirectParent, requestFlags);
		MethodCallExpression methodCallExpression = Expression.Call(instance, ResolveMethod, arg, arg4, arg2, arg3, requestExpression, request.GetInputArgsExpr());
		if (serviceType == typeof(object))
		{
			return methodCallExpression;
		}
		return serviceType.Cast(methodCallExpression);
	}

	private static void PopulateDependencyResolutionCallExpressions(Request request)
	{
		Request directParent = request.DirectParent;
		while (!directParent.IsEmpty)
		{
			if (directParent.FactoryID == request.FactoryID)
			{
				return;
			}
			directParent = directParent.DirectParent;
		}
		Factory factory = request.Container.ResolveFactory(request);
		if (factory == null || factory is FactoryPlaceholder || (request.Flags & RequestFlags.IsGeneratedResolutionDependencyExpression) != RequestFlags.Default)
		{
			return;
		}
		request.Flags |= RequestFlags.IsGeneratedResolutionDependencyExpression;
		Expression expression = factory.GetExpressionOrDefault(request)?.NormalizeExpression();
		if (expression != null)
		{
			Request a = request.IsolateRequestChain();
			request.Container.Rules.DependencyResolutionCallExprs.Swap(a, expression, (ImHashMap<Request, Expression> x, Request req, Expression facExpr) => x.AddOrUpdate(req, facExpr));
		}
	}
}
