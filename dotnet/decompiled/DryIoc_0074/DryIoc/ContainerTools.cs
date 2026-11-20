using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class ContainerTools
{
	public class GeneratedExpressions
	{
		public readonly List<KeyValuePair<ServiceInfo, Expression<FactoryDelegate>>> Roots = new List<KeyValuePair<ServiceInfo, Expression<FactoryDelegate>>>();

		public readonly List<KeyValuePair<Request, Expression>> ResolveDependencies = new List<KeyValuePair<Request, Expression>>();

		public readonly List<KeyValuePair<ServiceInfo, ContainerException>> Errors = new List<KeyValuePair<ServiceInfo, ContainerException>>();
	}

	internal static readonly ConstantExpression NullTypeConstant = Expression.ConstantNull<Type>();

	internal static readonly ConstantExpression IfUnresolvedThrowConstant = Expression.Constant(IfUnresolved.Throw);

	internal static readonly ConstantExpression IfUnresolvedReturnDefaultConstant = Expression.Constant(IfUnresolved.ReturnDefault);

	internal static readonly ConstantExpression IfUnresolvedReturnDefaultIfNotRegisteredConstant = Expression.Constant(IfUnresolved.ReturnDefaultIfNotRegistered);

	public const string FacadeKey = "@facade";

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ConstantExpression ToConstant(this Type type)
	{
		if (!(type == null))
		{
			return Expression.ConstantOf(type);
		}
		return NullTypeConstant;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ConstantExpression ToConstant(this IfUnresolved ifUnresolved)
	{
		return ifUnresolved switch
		{
			IfUnresolved.ReturnDefault => IfUnresolvedThrowConstant, 
			IfUnresolved.Throw => IfUnresolvedThrowConstant, 
			_ => IfUnresolvedReturnDefaultIfNotRegisteredConstant, 
		};
	}

	public static Rules WithFacadeRules(this Rules rules, string facadeKey = "@facade")
	{
		return rules.WithDefaultRegistrationServiceKey(facadeKey).WithFactorySelector(Rules.SelectKeyedOverDefaultFactory(facadeKey));
	}

	public static IContainer CreateFacade(this IContainer container, string facadeKey = "@facade")
	{
		Rules newRules = container.Rules.WithFacadeRules(facadeKey);
		return container.CreateChild(null, newRules);
	}

	public static IContainer CreateChild(this IContainer container, RegistrySharing registrySharing, object childDefaultServiceKey, IfAlreadyRegistered? ifAlreadyRegistered = null, Rules newRules = null, bool withDisposables = false)
	{
		Rules rules = ((newRules != null && newRules != container.Rules) ? newRules : container.Rules);
		if (childDefaultServiceKey != null)
		{
			rules = rules.WithDefaultRegistrationServiceKey(childDefaultServiceKey).WithFactorySelector(Rules.SelectKeyedOverDefaultFactory(childDefaultServiceKey));
		}
		if (ifAlreadyRegistered.HasValue)
		{
			rules = rules.WithDefaultIfAlreadyRegistered(ifAlreadyRegistered.Value);
		}
		return container.With(container.Parent, rules, container.ScopeContext, registrySharing, container.SingletonScope.Clone(withDisposables), container.CurrentScope?.Clone(withDisposables));
	}

	public static IContainer CreateChild(this IContainer container, IfAlreadyRegistered? ifAlreadyRegistered = null, Rules newRules = null, bool withDisposables = false)
	{
		Rules rules = ((newRules != null && newRules != container.Rules) ? newRules : container.Rules);
		return container.With(container.Parent, (!ifAlreadyRegistered.HasValue) ? rules : rules.WithDefaultIfAlreadyRegistered(ifAlreadyRegistered.Value), container.ScopeContext, RegistrySharing.CloneAndDropCache, container.SingletonScope.Clone(withDisposables), container.CurrentScope?.Clone(withDisposables));
	}

	public static IContainer With(this IContainer container, Func<Rules, Rules> configure = null, IScopeContext scopeContext = null)
	{
		return container.With(configure?.Invoke(container.Rules) ?? container.Rules, scopeContext ?? container.ScopeContext, RegistrySharing.CloneAndDropCache, container.SingletonScope);
	}

	public static IContainer WithExpressionGeneration(this IContainer container, bool allowRuntimeState = false)
	{
		return container.With((Rules rules) => rules.WithExpressionGeneration(allowRuntimeState));
	}

	public static IContainer WithoutCache(this IContainer container)
	{
		return container.With(container.Rules, container.ScopeContext, RegistrySharing.CloneAndDropCache, container.SingletonScope);
	}

	public static IContainer WithoutSingletonsAndCache(this IContainer container)
	{
		return container.With(container.Rules, container.ScopeContext, RegistrySharing.CloneAndDropCache, null);
	}

	public static IContainer WithRegistrationsCopy(this IContainer container, bool preserveCache = false)
	{
		return container.With(container.Rules, container.ScopeContext, preserveCache ? RegistrySharing.CloneButKeepCache : RegistrySharing.CloneAndDropCache, container.SingletonScope);
	}

	public static IContainer WithRegistrationsCopy(this IContainer container, IsRegistryChangePermitted isRegistryChangePermitted, bool preserveCache = false)
	{
		return container.With(container.Parent, container.Rules, container.ScopeContext, preserveCache ? RegistrySharing.CloneButKeepCache : RegistrySharing.CloneAndDropCache, container.SingletonScope, container.OwnCurrentScope, isRegistryChangePermitted);
	}

	public static TService InjectPropertiesAndFields<TService>(this IResolverContext r, TService instance)
	{
		return InjectPropertiesAndFields(r, instance, (string[])null);
	}

	public static TService InjectPropertiesAndFields<TService>(this IResolverContext r, TService instance, params string[] propertyAndFieldNames)
	{
		r.InjectPropertiesAndFields(instance, propertyAndFieldNames);
		return instance;
	}

	public static object New(this IContainer container, Type concreteType, Setup setup, Made made = null, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		IContainer container2 = container.With(container.Parent, container.Rules, container.ScopeContext, registrySharing, container.SingletonScope, container.OwnCurrentScope, null);
		Type wrappedType = container2.GetWrappedType(concreteType, null);
		Func<Factory, bool> condition = ((setup == null && made == null) ? null : ((made == null) ? ((Func<Factory, bool>)((Factory f) => f.Setup == setup)) : ((setup == null) ? ((Func<Factory, bool>)((Factory f) => f.Made == made)) : ((Func<Factory, bool>)((Factory f) => f.Made == made && f.Setup == setup)))));
		if (!Registrator.IsRegistered(container2, wrappedType, null, FactoryType.Service, condition))
		{
			container2.Register(wrappedType, null, made, setup);
		}
		return container2.Resolve(concreteType, IfUnresolved.Throw);
	}

	public static object New(this IContainer container, Type concreteType, Made made = null, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return container.New(concreteType, null, made, registrySharing);
	}

	public static T New<T>(this IContainer container, Made made = null, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return (T)container.New(typeof(T), made, registrySharing);
	}

	public static T New<T>(this IContainer container, Made.TypedMade<T> made, RegistrySharing registrySharing = RegistrySharing.CloneButKeepCache)
	{
		return (T)container.New(typeof(T), made, registrySharing);
	}

	[Obsolete("Please use WithAutoFallbackDynamicRegistration instead")]
	public static IContainer WithAutoFallbackResolution(this IContainer container, IEnumerable<Type> implTypes, Func<IReuse, Request, IReuse> changeDefaultReuse = null, Func<Request, bool> condition = null)
	{
		return container.ThrowIfNull().With((Rules rules) => rules.WithUnknownServiceResolvers(Rules.AutoRegisterUnknownServiceRule(implTypes, changeDefaultReuse, condition)));
	}

	[Obsolete("Please use WithAutoFallbackDynamicRegistration instead")]
	public static IContainer WithAutoFallbackResolution(this IContainer container, IEnumerable<Assembly> implTypeAssemblies, Func<IReuse, Request, IReuse> changeDefaultReuse = null, Func<Request, bool> condition = null)
	{
		return container.WithAutoFallbackResolution(implTypeAssemblies.ThrowIfNull().SelectMany((Assembly assembly) => assembly.GetLoadedTypes()).Where(Registrator.IsImplementationType)
			.ToArray(), changeDefaultReuse, condition);
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, Func<Type, object, IEnumerable<Type>> getImplTypes, Func<Type, Factory> factory = null)
	{
		return container.ThrowIfNull().With((Rules rules) => rules.WithDynamicRegistrationsAsFallback(Rules.AutoFallbackDynamicRegistrations(getImplTypes, factory)));
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, DynamicRegistrationFlags flags, Func<Type, object, IEnumerable<Type>> getImplTypes, Func<Type, Factory> factory = null)
	{
		return container.ThrowIfNull().With((Rules rules) => rules.WithDynamicRegistrationsAsFallback(flags, Rules.AutoFallbackDynamicRegistrations(getImplTypes, factory)));
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, params Type[] implTypes)
	{
		return container.WithAutoFallbackDynamicRegistrations((Type _, object __) => implTypes);
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, IReuse reuse, params Type[] implTypes)
	{
		return container.WithAutoFallbackDynamicRegistrations((Type _, object __) => implTypes, (Type implType) => ReflectionFactory.Of(implType, reuse));
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, IReuse reuse, Setup setup, params Type[] implTypes)
	{
		return container.WithAutoFallbackDynamicRegistrations((Type ignoredServiceType, object ignoredServiceKey) => implTypes, (Type implType) => ReflectionFactory.Of(implType, reuse, null, setup));
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, Func<Type, object, IEnumerable<Assembly>> getImplTypeAssemblies, Func<Type, Factory> factory = null)
	{
		return container.WithAutoFallbackDynamicRegistrations(Rules.DefaultDynamicRegistrationFlags, getImplTypeAssemblies, factory);
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, DynamicRegistrationFlags flags, Func<Type, object, IEnumerable<Assembly>> getImplTypeAssemblies, Func<Type, Factory> factory = null)
	{
		return container.ThrowIfNull().With((Rules rules) => rules.WithDynamicRegistrationsAsFallback(flags, Rules.AutoFallbackDynamicRegistrations(delegate(Type serviceType, object serviceKey)
		{
			IEnumerable<Assembly> enumerable = getImplTypeAssemblies(serviceType, serviceKey);
			return (enumerable == null) ? ((IEnumerable<Type>)ArrayTools.Empty<Type>()) : ((IEnumerable<Type>)(from t in enumerable.SelectMany((Assembly a) => a.GetLoadedTypes())
				where t.IsImplementationType()
				select t).ToArray());
		}, factory)));
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, params Assembly[] implTypeAssemblies)
	{
		return container.WithAutoFallbackDynamicRegistrations((Type _, object __) => implTypeAssemblies);
	}

	public static IContainer WithAutoFallbackDynamicRegistrations(this IContainer container, IEnumerable<Assembly> implTypeAssemblies)
	{
		return container.WithAutoFallbackDynamicRegistrations((Type _, object __) => implTypeAssemblies);
	}

	public static IContainer WithDependencies(this IContainer container, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return container.With((Rules rules) => rules.With(Made.Create(rules.FactoryMethodOrSelector, rules.Parameters.OverrideWith(parameters), rules.PropertiesAndFields.OverrideWith(propertiesAndFields), rules._made.IsConditionalImplementation), overrideRegistrationMade: true));
	}

	public static GeneratedExpressions GenerateResolutionExpressions(this IContainer container, Func<IEnumerable<ServiceRegistrationInfo>, IEnumerable<ServiceInfo>> getRoots = null, bool allowRuntimeState = false)
	{
		IContainer container2 = container.WithExpressionGeneration(allowRuntimeState);
		IEnumerable<ServiceRegistrationInfo> serviceRegistrations = container2.GetServiceRegistrations();
		IEnumerable<ServiceInfo> enumerable = ((getRoots != null) ? getRoots(serviceRegistrations) : serviceRegistrations.Select((ServiceRegistrationInfo r) => r.ToServiceInfo()));
		GeneratedExpressions generatedExpressions = new GeneratedExpressions();
		foreach (ServiceInfo item in enumerable)
		{
			try
			{
				Request request = Request.Create(container2, item);
				Expression expression = container2.ResolveFactory(request)?.GetExpressionOrDefault(request);
				if (expression != null)
				{
					generatedExpressions.Roots.Add(item.Pair(expression.WrapInFactoryExpression()));
				}
			}
			catch (ContainerException value)
			{
				generatedExpressions.Errors.Add(item.Pair(value));
			}
		}
		ImHashMap<Request, Expression> value2 = container2.Rules.DependencyResolutionCallExprs.Value;
		generatedExpressions.ResolveDependencies.AddRange(from r in value2.Enumerate()
			select r.Key.Pair(r.Value));
		return generatedExpressions;
	}

	public static GeneratedExpressions GenerateResolutionExpressions(this IContainer container, Func<ServiceRegistrationInfo, bool> condition)
	{
		return container.GenerateResolutionExpressions((IEnumerable<ServiceRegistrationInfo> regs) => from r in regs.Where(condition.ThrowIfNull())
			select r.ToServiceInfo());
	}

	public static GeneratedExpressions GenerateResolutionExpressions(this IContainer container, params ServiceInfo[] roots)
	{
		return container.GenerateResolutionExpressions(((IEnumerable<ServiceInfo>)roots).ToFunc<IEnumerable<ServiceRegistrationInfo>, IEnumerable<ServiceInfo>>);
	}

	public static bool DefaultValidateCondition(ServiceRegistrationInfo reg)
	{
		return !reg.ServiceType.IsOpenGeneric();
	}

	public static KeyValuePair<ServiceInfo, ContainerException>[] Validate(this IContainer container, Func<ServiceRegistrationInfo, bool> condition = null)
	{
		ServiceRegistrationInfo[] array = ArrayTools.Empty<ServiceRegistrationInfo>();
		if (condition == null)
		{
			ServiceRegistrationInfo[] array2 = container.GetServiceRegistrations().Where(DefaultValidateCondition).ToArray();
			if (array2.Length == 0)
			{
				Throw.It(Error.FoundNoRootsToValidate, container);
			}
			array = array2.Match((ServiceRegistrationInfo r) => r.Factory.Setup.AsResolutionRoot);
			if (array.Length == 0)
			{
				array = array2;
			}
		}
		else
		{
			array = (from r in container.GetServiceRegistrations()
				where condition(r) && DefaultValidateCondition(r)
				select r).ToArray();
			if (array.Length == 0)
			{
				Throw.It(Error.FoundNoRootsToValidate, container);
			}
		}
		return container.Validate(array.Map((ServiceRegistrationInfo r) => r.ToServiceInfo()));
	}

	public static void ValidateAndThrow(this IContainer container, Func<ServiceRegistrationInfo, bool> condition = null)
	{
		KeyValuePair<ServiceInfo, ContainerException>[] source = container.Validate(condition);
		if (!source.IsNullOrEmpty())
		{
			Throw.Many(Error.ValidateFoundErrors, source.Map((KeyValuePair<ServiceInfo, ContainerException> x) => x.Value));
		}
	}

	public static KeyValuePair<ServiceInfo, ContainerException>[] Validate(this IContainer container, params ServiceInfo[] roots)
	{
		IContainer container2 = container.With((Rules rules) => rules.ForValidate());
		RequestStack stack = RequestStack.Create(16);
		List<KeyValuePair<ServiceInfo, ContainerException>> list = null;
		foreach (ServiceInfo serviceInfo in roots)
		{
			try
			{
				Request request = Request.CreateForValidation(container2, serviceInfo, stack);
				container2.ResolveFactory(request)?.GetExpressionOrDefault(request);
			}
			catch (ContainerException value)
			{
				if (list == null)
				{
					list = new List<KeyValuePair<ServiceInfo, ContainerException>>();
				}
				list.Add(serviceInfo.Pair(value));
			}
		}
		return list?.ToArray() ?? ArrayTools.Empty<KeyValuePair<ServiceInfo, ContainerException>>();
	}

	public static void ValidateAndThrow(this IContainer container, params ServiceInfo[] roots)
	{
		KeyValuePair<ServiceInfo, ContainerException>[] source = container.Validate(roots);
		if (!source.IsNullOrEmpty())
		{
			Throw.Many(Error.ValidateFoundErrors, source.Map((KeyValuePair<ServiceInfo, ContainerException> x) => x.Value));
		}
	}

	public static Expression GetRequestExpression(this IContainer container, Request request, RequestFlags requestParentFlags = RequestFlags.Default)
	{
		if (request.IsEmpty)
		{
			if ((requestParentFlags & RequestFlags.OpensResolutionScope) == 0)
			{
				return Request.EmptyRequestExpr;
			}
			return Expression.Field(typeof(Request).GetField("EmptyOpensResolutionScope"));
		}
		RequestFlags requestFlags = request.Flags | requestParentFlags;
		Request request2 = ((requestParentFlags == RequestFlags.Default) ? request : request.WithFlags(requestFlags));
		if (!container.Rules.UsedForExpressionGeneration)
		{
			return Expression.Constant(request2.IsolateRequestChain());
		}
		Expression requestExpression = container.GetRequestExpression(request.DirectParent);
		Type serviceType = request2.ServiceType;
		ServiceDetails serviceDetails = request2.GetServiceDetails();
		int factoryID = request2.FactoryID;
		FactoryType factoryType = request2.FactoryType;
		Type implementationType = request2.ImplementationType;
		int decoratedFactoryID = request2.DecoratedFactoryID;
		ConstantExpression constantExpression = Expression.Constant(serviceType);
		ConstantExpression constantExpression2 = Expression.ConstantInt(factoryID);
		ConstantExpression constantExpression3 = Expression.ConstantOf(implementationType);
		Expression expression = ((request2.Reuse == null) ? Expression.ConstantNull<IReuse>() : request2.Reuse.ToExpression((object it) => container.GetConstantExpression(it)));
		if (serviceDetails.IfUnresolved == IfUnresolved.Throw && serviceDetails.RequiredServiceType == null && serviceDetails.ServiceKey == null && serviceDetails.MetadataKey == null && serviceDetails.Metadata == null && factoryType == FactoryType.Service && decoratedFactoryID == 0)
		{
			if (requestFlags == RequestFlags.Default)
			{
				return Expression.Call(requestExpression, Request.PushMethodWith4Args.Value, constantExpression, constantExpression2, constantExpression3, expression);
			}
			return Expression.Call(requestExpression, Request.PushMethodWith5Args.Value, constantExpression, constantExpression2, constantExpression3, expression, Expression.ConstantOf(requestFlags));
		}
		ConstantExpression constantExpression4 = Expression.ConstantOf(serviceDetails.RequiredServiceType);
		Expression constantExpression5 = container.GetConstantExpression(serviceDetails.ServiceKey, typeof(object));
		ConstantExpression constantExpression6 = Expression.ConstantOf(factoryType);
		ConstantExpression constantExpression7 = Expression.ConstantOf(requestFlags);
		if (serviceDetails.IfUnresolved == IfUnresolved.Throw && serviceDetails.MetadataKey == null && serviceDetails.Metadata == null && decoratedFactoryID == 0)
		{
			return Expression.Call(requestExpression, Request.PushMethodWith8Args.Value, constantExpression, constantExpression4, constantExpression5, constantExpression2, constantExpression6, constantExpression3, expression, constantExpression7);
		}
		ConstantExpression constantExpression8 = serviceDetails.IfUnresolved.ToConstant();
		ConstantExpression constantExpression9 = Expression.ConstantOf(decoratedFactoryID);
		if (serviceDetails.MetadataKey == null && serviceDetails.Metadata == null)
		{
			return Expression.Call(requestExpression, Request.PushMethodWith10Args.Value, constantExpression, constantExpression4, constantExpression5, constantExpression8, constantExpression2, constantExpression6, constantExpression3, expression, constantExpression7, constantExpression9);
		}
		ConstantExpression constantExpression10 = Expression.Constant(serviceDetails.MetadataKey);
		Expression constantExpression11 = container.GetConstantExpression(serviceDetails.Metadata, typeof(object));
		return Expression.Call(requestExpression, Request.PushMethodWith12Args.Value, constantExpression, constantExpression4, constantExpression5, constantExpression10, constantExpression11, constantExpression8, constantExpression2, constantExpression6, constantExpression3, expression, constantExpression7, constantExpression9);
	}

	public static void ValidateAndThrow(this IContainer container, params Type[] serviceTypes)
	{
		KeyValuePair<ServiceInfo, ContainerException>[] source = container.Validate(serviceTypes);
		if (!source.IsNullOrEmpty())
		{
			Throw.Many(Error.ValidateFoundErrors, source.Map((KeyValuePair<ServiceInfo, ContainerException> x) => x.Value));
		}
	}

	public static bool ClearCache<T>(this IContainer container, FactoryType? factoryType = null, object serviceKey = null)
	{
		return container.ClearCache(typeof(T), factoryType, serviceKey);
	}

	public static KeyValuePair<ServiceInfo, ContainerException>[] Validate(this IContainer container, params Type[] serviceTypes)
	{
		if (serviceTypes.IsNullOrEmpty())
		{
			Throw.It(Error.NoServiceTypesToValidate, container);
		}
		return container.Validate(serviceTypes.Map((Type t) => ServiceInfo.Of(t)));
	}

	public static bool ClearCache(this IContainer container, Type serviceType, FactoryType? factoryType = null, object serviceKey = null)
	{
		return container.ClearCache(serviceType, factoryType, serviceKey);
	}

	public static void Use(this IContainer container, Type serviceType, FactoryDelegate factory)
	{
		container.Use(serviceType, factory);
	}
}
