using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class WrappersSupport
{
	public static readonly Type[] FuncTypes = new Type[8]
	{
		typeof(Func<>),
		typeof(Func<, >),
		typeof(Func<, , >),
		typeof(Func<, , , >),
		typeof(Func<, , , , >),
		typeof(Func<, , , , , >),
		typeof(Func<, , , , , , >),
		typeof(Func<, , , , , , , >)
	};

	public static readonly Type[] ActionTypes = new Type[8]
	{
		typeof(Action),
		typeof(Action<>),
		typeof(Action<, >),
		typeof(Action<, , >),
		typeof(Action<, , , >),
		typeof(Action<, , , , >),
		typeof(Action<, , , , , >),
		typeof(Action<, , , , , , >)
	};

	public static readonly Type[] SupportedCollectionTypes = typeof(object[]).GetInterfaces().Match((Type t) => t.IsGenericType, (Type t) => t.GetGenericTypeDefinition());

	public static readonly ImHashMap<Type, object> Wrappers = BuildSupportedWrappers();

	internal static readonly MethodInfo ToArrayMethod = typeof(ArrayTools).GetMethod("ToArrayOrSelf");

	private static readonly MethodInfo _enumerableCastMethod = typeof(Enumerable).GetMethod("Cast");

	internal static int CollectionWrapperID { get; private set; }

	public static bool IsFunc(this Type type)
	{
		if (type.IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			Type[] funcTypes = FuncTypes;
			for (int i = 0; i < funcTypes.Length; i++)
			{
				if ((object)funcTypes[i] == genericTypeDefinition)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static ImHashMap<Type, object> BuildSupportedWrappers()
	{
		ImHashMap<Type, object> map = ImHashMap<Type, object>.Empty;
		ExpressionFactory expressionFactory = new ExpressionFactory((Request r) => GetArrayExpression(r), null, Setup.Wrapper);
		CollectionWrapperID = expressionFactory.FactoryID;
		Type[] supportedCollectionTypes = SupportedCollectionTypes;
		for (int num = 0; num < supportedCollectionTypes.Length; num++)
		{
			map = map.AddOrUpdate(supportedCollectionTypes[num], expressionFactory);
		}
		map = map.AddOrUpdate(typeof(LazyEnumerable<>), new ExpressionFactory((Request r) => GetLazyEnumerableExpressionOrDefault(r), null, Setup.Wrapper));
		map = map.AddOrUpdate(typeof(Lazy<>), WrapperExpressionFactory.Of(GetLazyExpressionOrDefault));
		map = map.AddOrUpdate(typeof(KeyValuePair<, >), WrapperExpressionFactory.Of(GetKeyValuePairExpressionOrDefault, Setup.WrapperWith(1)));
		map = map.AddOrUpdate(typeof(Meta<, >), WrapperExpressionFactory.Of(GetMetaExpressionOrDefault, Setup.WrapperWith(0)));
		map = map.AddOrUpdate(typeof(Tuple<, >), WrapperExpressionFactory.Of(GetMetaExpressionOrDefault, Setup.WrapperWith(0)));
		map = map.AddOrUpdate(typeof(System.Linq.Expressions.LambdaExpression), new ExpressionFactory((Request r) => GetLambdaExpressionExpressionOrDefault(r), null, Setup.Wrapper));
		map = map.AddOrUpdate(typeof(DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression), new ExpressionFactory((Request r) => GetFastExpressionCompilerLambdaExpressionExpressionOrDefault(r), null, Setup.Wrapper));
		map = map.AddOrUpdate(typeof(FactoryDelegate), new ExpressionFactory((Request r) => GetFactoryDelegateExpressionOrDefault(r), null, Setup.Wrapper));
		map = map.AddOrUpdate(typeof(FactoryDelegate<>), new ExpressionFactory((Request r) => GetFactoryDelegateExpressionOrDefault(r), null, Setup.WrapperWith(0)));
		map = map.AddOrUpdate(typeof(Func<>), WrapperExpressionFactory.Of(GetFuncOrActionExpressionOrDefault, Setup.Wrapper));
		for (int num2 = 1; num2 < FuncTypes.Length; num2++)
		{
			map = map.AddOrUpdate(FuncTypes[num2], WrapperExpressionFactory.Of(GetFuncOrActionExpressionOrDefault, Setup.WrapperWith(num2)));
		}
		for (int num3 = 0; num3 < ActionTypes.Length; num3++)
		{
			map = map.AddOrUpdate(ActionTypes[num3], WrapperExpressionFactory.Of(GetFuncOrActionExpressionOrDefault, Setup.WrapperWith(-1, alwaysWrapsRequiredServiceType: false, typeof(void).ToFunc)));
		}
		return map.AddContainerInterfaces();
	}

	private static ImHashMap<Type, object> AddContainerInterfaces(this ImHashMap<Type, object> wrappers)
	{
		ExpressionFactory value = new ExpressionFactory(ResolverContext.GetRootOrSelfExpr, Reuse.Transient, Setup.WrapperWith(-1, alwaysWrapsRequiredServiceType: false, null, openResolutionScope: false, asResolutionCall: false, preventDisposal: true));
		ExpressionFactory value2 = new ExpressionFactory((Request r) => DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<IContainer>(ResolverContext.GetRootOrSelfExpr(r)), Reuse.Transient, Setup.WrapperWith(-1, alwaysWrapsRequiredServiceType: false, null, openResolutionScope: false, asResolutionCall: false, preventDisposal: true));
		ExpressionFactory value3 = new ExpressionFactory((Request r) => DryIoc.FastExpressionCompiler.LightExpression.Expression.ConvertViaCastClassIntrinsic<IRegistrator>(ResolverContext.GetRootOrSelfExpr(r)), Reuse.Transient, Setup.WrapperWith(-1, alwaysWrapsRequiredServiceType: false, null, openResolutionScope: false, asResolutionCall: false, preventDisposal: true));
		wrappers = wrappers.AddOrUpdate(typeof(IContainer), value2).AddOrUpdate(typeof(IRegistrator), value3).AddOrUpdate(typeof(IResolverContext), value)
			.AddOrUpdate(typeof(IResolver), value)
			.AddOrUpdate(typeof(IServiceProvider), value);
		return wrappers;
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetArrayExpression(Request request)
	{
		Type actualServiceType = request.GetActualServiceType();
		IContainer container = request.Container;
		Rules rules = container.Rules;
		Type type = actualServiceType.GetArrayElementTypeOrNull() ?? actualServiceType.GetGenericArguments()[0];
		if (rules.ResolveIEnumerableAsLazyEnumerable)
		{
			DryIoc.FastExpressionCompiler.LightExpression.Expression lazyEnumerableExpressionOrDefault = GetLazyEnumerableExpressionOrDefault(request);
			if (!(actualServiceType.GetGenericDefinitionOrNull() != typeof(IEnumerable<>)))
			{
				return lazyEnumerableExpressionOrDefault;
			}
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(ToArrayMethod.MakeGenericMethod(type), lazyEnumerableExpressionOrDefault);
		}
		ServiceDetails serviceDetails = request.GetServiceDetails();
		Type wrappedType = container.GetWrappedType(type, serviceDetails.RequiredServiceType);
		ServiceRegistrationInfo[] array = container.GetServiceRegisteredAndDynamicFactories(wrappedType).Map(wrappedType, (Type t, KV<object, Factory> x) => new ServiceRegistrationInfo(x.Value, t, x.Key));
		if (wrappedType.IsClosedGeneric())
		{
			Type genericTypeDefinition = wrappedType.GetGenericTypeDefinition();
			ServiceRegistrationInfo[] added = container.GetServiceRegisteredAndDynamicFactories(genericTypeDefinition).Map(genericTypeDefinition, wrappedType, (Type gt, Type t, KV<object, Factory> f) => new ServiceRegistrationInfo(f.Value, t, new OpenGenericTypeKey(gt, f.Key)));
			array = array.Append(added);
		}
		if (wrappedType.IsGenericType && rules.VariantGenericTypesInResolvedCollection)
		{
			ServiceRegistrationInfo[] added2 = container.GetServiceRegistrations().ToArrayOrSelf().Match(wrappedType, (Type t, ServiceRegistrationInfo x) => t.IsAssignableVariantGenericTypeFrom(x.ServiceType));
			array = array.Append(added2);
		}
		Request request2 = request.Parent;
		if (request2.FactoryType != FactoryType.Service)
		{
			request2 = request2.FirstOrDefault((Request p) => p.FactoryType == FactoryType.Service) ?? Request.Empty;
		}
		if (!request2.IsEmpty && request2.GetActualServiceType() == wrappedType)
		{
			array = array.Match(request2.FactoryID, (int pID, ServiceRegistrationInfo x) => x.Factory.FactoryID != pID);
			if (wrappedType.IsGenericType)
			{
				array = array.Match(request2.FactoryID, (int pID, ServiceRegistrationInfo x) => x.Factory.GeneratedFactories?.Enumerate().FindFirst((ImHashMapEntry<KV<Type, object>, ReflectionFactory> f) => f.Value.FactoryID == pID) == null);
			}
		}
		object serviceKey = serviceDetails.ServiceKey;
		if (serviceKey != null)
		{
			array = array.Match(serviceKey, (object key, ServiceRegistrationInfo x) => key.Equals(x.OptionalServiceKey));
		}
		string metadataKey = serviceDetails.MetadataKey;
		object metadata = serviceDetails.Metadata;
		if (metadataKey != null || metadata != null)
		{
			array = array.Match(metadataKey, metadata, (string mk, object m, ServiceRegistrationInfo x) => x.Factory.Setup.MatchesMetadata(mk, m));
		}
		if (array.IsNullOrEmpty())
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.NewArrayInit(type, ArrayTools.Empty<DryIoc.FastExpressionCompiler.LightExpression.Expression>());
		}
		Array.Sort(array);
		DryIoc.FastExpressionCompiler.LightExpression.Expression[] array2 = new DryIoc.FastExpressionCompiler.LightExpression.Expression[array.Length];
		int num = 0;
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			ServiceRegistrationInfo serviceRegistrationInfo = array[num2];
			wrappedType = serviceRegistrationInfo.ServiceType;
			ServiceInfo info = ServiceInfo.Of(type, wrappedType, IfUnresolved.ReturnDefaultIfNotRegistered, serviceRegistrationInfo.OptionalServiceKey);
			Request request3 = request.Push(info);
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression = ((wrappedType == type) ? request3.MatchGeneratedFactoryByReuseAndConditionOrNull(serviceRegistrationInfo.Factory) : container.ResolveFactory(request3.WithWrappedServiceFactory(serviceRegistrationInfo.Factory)))?.GetExpressionOrDefault(request3);
			if (expression != null)
			{
				array2[num++] = expression;
			}
		}
		if (num < array2.Length)
		{
			Array.Resize(ref array2, num);
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.NewArrayInit(type, array2);
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetLazyEnumerableExpressionOrDefault(Request request)
	{
		IContainer container = request.Container;
		Type serviceType = request.ServiceType;
		Type type = (serviceType.IsArray ? serviceType.GetElementType() : serviceType.GetGenericArguments()[0]);
		Type wrappedType = container.GetWrappedType(type, request.RequiredServiceType);
		DryIoc.FastExpressionCompiler.LightExpression.Expression rootOrSelfExpr = ResolverContext.GetRootOrSelfExpr(request);
		DryIoc.FastExpressionCompiler.LightExpression.Expression requestExpression = container.GetRequestExpression(request);
		DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression methodCallExpression = DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(rootOrSelfExpr, Resolver.ResolveManyMethod, DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(type), container.GetConstantExpression(request.ServiceKey), DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(wrappedType), requestExpression, request.GetInputArgsExpr());
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.New(typeof(LazyEnumerable<>).MakeGenericType(type).GetConstructors()[0], (type == typeof(object)) ? methodCallExpression : DryIoc.FastExpressionCompiler.LightExpression.Expression.Call(_enumerableCastMethod.MakeGenericMethod(type), methodCallExpression));
	}

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression GetLazyExpressionOrDefault(Request request, Factory serviceFactory = null)
	{
		Type actualServiceType = request.GetActualServiceType();
		Type type = actualServiceType.GetGenericArguments()[0];
		Request request2 = request.PushServiceType(type, RequestFlags.IsWrappedInFunc | RequestFlags.IsResolutionCall | RequestFlags.IsDirectlyWrappedInFunc);
		IContainer container = request.Container;
		if (!container.Rules.FuncAndLazyWithoutRegistration)
		{
			Factory factory = serviceFactory ?? container.ResolveFactory(request2);
			if (factory == null)
			{
				return null;
			}
			request2 = request2.WithResolvedFactory(factory, skipRecursiveDependencyCheck: true);
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression body = Resolver.CreateResolutionExpression(request2, openResolutionScope: false, asResolutionCall: true);
		Type type2 = typeof(Func<>).MakeGenericType(type);
		ConstructorInfo ctor = actualServiceType.Constructor(type2);
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.New(ctor, DryIoc.FastExpressionCompiler.LightExpression.Expression.Lambda(type2, body, ArrayTools.Empty<DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression>(), type));
	}

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression GetFuncOrActionExpressionOrDefault(Request request, Factory serviceFactory = null)
	{
		Type actualServiceType = request.GetActualServiceType();
		bool flag = actualServiceType == typeof(Action);
		if (!flag)
		{
			Type reference = actualServiceType.GetGenericDefinitionOrNull().ThrowIfNull();
			if (FuncTypes.IndexOfReference(reference) == -1)
			{
				Throw.If(!(flag = ActionTypes.IndexOfReference(reference) != -1));
			}
		}
		Type[] genericArguments = actualServiceType.GetGenericArguments();
		int num = (flag ? genericArguments.Length : (genericArguments.Length - 1));
		Type type = (flag ? typeof(void) : genericArguments[num]);
		DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression[] array = ArrayTools.Empty<DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression>();
		if (num != 0)
		{
			array = new DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = DryIoc.FastExpressionCompiler.LightExpression.Expression.Parameter(genericArguments[i], genericArguments[i].Name + "@" + i);
			}
			Request request2 = request;
			DryIoc.FastExpressionCompiler.LightExpression.Expression[] inputArgs = array;
			request = request2.WithInputArgs(inputArgs);
		}
		Request request3 = request.PushServiceType(type, RequestFlags.IsWrappedInFunc | RequestFlags.IsDirectlyWrappedInFunc);
		IContainer container = request.Container;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression;
		if (!flag && container.Rules.FuncAndLazyWithoutRegistration)
		{
			expression = Resolver.CreateResolutionExpression(request3, openResolutionScope: false, asResolutionCall: true);
		}
		else
		{
			Factory factory;
			if (serviceFactory == null)
			{
				factory = container.ResolveFactory(request3);
			}
			else
			{
				Type wrappedType = container.GetWrappedType(type, request.RequiredServiceType);
				factory = ((wrappedType == type) ? request3.MatchGeneratedFactoryByReuseAndConditionOrNull(serviceFactory) : container.ResolveFactory(request3.WithWrappedServiceFactory(serviceFactory)));
			}
			expression = factory?.GetExpressionOrDefault(request3);
			if (expression == null)
			{
				return null;
			}
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Lambda(actualServiceType, expression, array, type);
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetLambdaExpressionExpressionOrDefault(Request request)
	{
		request = request.PushServiceType(request.RequiredServiceType.ThrowIfNull(Error.ResolutionNeedsRequiredServiceType, request));
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = request.Container.ResolveFactory(request)?.GetExpressionOrDefault(request);
		if (expression == null)
		{
			return null;
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantOf((System.Linq.Expressions.LambdaExpression)expression.WrapInFactoryExpression().ToLambdaExpression());
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetFastExpressionCompilerLambdaExpressionExpressionOrDefault(Request request)
	{
		request = request.PushServiceType(request.RequiredServiceType.ThrowIfNull(Error.ResolutionNeedsRequiredServiceType, request));
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = request.Container.ResolveFactory(request)?.GetExpressionOrDefault(request);
		if (expression == null)
		{
			return null;
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantOf((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)expression.WrapInFactoryExpression());
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetFactoryDelegateExpressionOrDefault(Request request)
	{
		Type serviceType = request.ServiceType;
		Type type = ((serviceType == typeof(FactoryDelegate)) ? request.RequiredServiceType.ThrowIfNull(Error.ResolutionNeedsRequiredServiceType, request) : (request.RequiredServiceType ?? serviceType.GetGenericArguments()[0]));
		request = request.PushServiceType(type, RequestFlags.IsWrappedInFunc | RequestFlags.IsDirectlyWrappedInFunc);
		IContainer container = request.Container;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = container.ResolveFactory(request)?.GetExpressionOrDefault(request);
		if (expression == null)
		{
			return null;
		}
		if (!(serviceType == typeof(FactoryDelegate)))
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(expression.CompileToFactoryDelegate(serviceType, type, container.Rules.UseInterpretation), serviceType);
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(expression.CompileToFactoryDelegate(container.Rules.UseInterpretation));
	}

	private static DryIoc.FastExpressionCompiler.LightExpression.Expression GetKeyValuePairExpressionOrDefault(Request request, Factory serviceFactory = null)
	{
		Type actualServiceType = request.GetActualServiceType();
		Type[] genericArguments = actualServiceType.GetGenericArguments();
		Type type = genericArguments[0];
		object serviceKey = request.ServiceKey;
		if ((serviceKey == null && type.IsValueType) || (serviceKey != null && !type.IsAssignableFrom(serviceKey.GetType())))
		{
			return null;
		}
		Type type2 = genericArguments[1];
		Request request2 = ((serviceKey == null) ? request.PushServiceType(type2) : request.Push(type2, serviceKey));
		IContainer container = request.Container;
		Factory factory;
		if (serviceFactory == null)
		{
			factory = container.ResolveFactory(request2);
		}
		else
		{
			Type wrappedType = container.GetWrappedType(type2, request.RequiredServiceType);
			factory = ((wrappedType == type2) ? request2.MatchGeneratedFactoryByReuseAndConditionOrNull(serviceFactory) : container.ResolveFactory(request2.WithWrappedServiceFactory(serviceFactory)));
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = factory?.GetExpressionOrDefault(request2);
		if (expression == null)
		{
			return null;
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression constantExpression = request.Container.GetConstantExpression(serviceKey, type);
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.New(actualServiceType.GetConstructors()[0], constantExpression, expression);
	}

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression GetMetaExpressionOrDefault(Request request, Factory serviceFactory = null)
	{
		Type actualServiceType = request.GetActualServiceType();
		Type[] genericArguments = actualServiceType.GetGenericArguments();
		ConstructorInfo ctor = actualServiceType.GetConstructorOrNull(genericArguments).ThrowIfNull(Error.NotFoundMetaCtorWithTwoArgs, genericArguments, request);
		Type type = genericArguments[1];
		Type type2 = genericArguments[0];
		ServiceDetails serviceDetails = request.GetServiceDetails();
		object obj = serviceDetails.ServiceKey;
		IContainer container = request.Container;
		Type wrappedType = container.GetWrappedType(type2, serviceDetails.RequiredServiceType);
		if (serviceFactory != null)
		{
			if (!serviceFactory.MatchMetadataType(type))
			{
				return null;
			}
		}
		else
		{
			KV<object, Factory>[] array = container.GetAllServiceFactories(wrappedType, bothClosedAndOpenGenerics: true);
			if (array.Length == 0)
			{
				return null;
			}
			if (obj != null)
			{
				array = array.Match(obj, (object key, KV<object, Factory> f) => key.Equals(f.Key));
				if (array.Length == 0)
				{
					return null;
				}
			}
			array = array.Match(type, (Type mType, KV<object, Factory> f) => f.Value.MatchMetadataType(mType));
			if (array.Length == 0)
			{
				return null;
			}
			if (array.Length > 1)
			{
				if (serviceDetails.IfUnresolved == IfUnresolved.Throw)
				{
					Throw.It(Error.UnableToSelectFromManyRegistrationsWithMatchingMetadata, type, array, request);
				}
				return null;
			}
			KV<object, Factory> kV = array[0];
			if (kV == null)
			{
				return null;
			}
			obj = kV.Key;
			serviceFactory = kV.Value;
		}
		Request request2 = request.Push(ServiceInfo.Of(type2, obj));
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = ((wrappedType == type2) ? request2.MatchGeneratedFactoryByReuseAndConditionOrNull(serviceFactory) : container.ResolveFactory(request2.WithWrappedServiceFactory(serviceFactory)))?.GetExpressionOrDefault(request2);
		if (expression == null)
		{
			return null;
		}
		object metadataValueMatchedByMetadataType = serviceFactory.Setup.GetMetadataValueMatchedByMetadataType(type);
		DryIoc.FastExpressionCompiler.LightExpression.Expression constantExpression = container.GetConstantExpression(metadataValueMatchedByMetadataType, type);
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.New(ctor, expression, constantExpression);
	}

	public static bool MatchMetadataType(this Factory f, Type metadataType)
	{
		object metadata = f.Setup.Metadata;
		if (metadata == null)
		{
			return false;
		}
		if (metadataType == typeof(object))
		{
			return true;
		}
		if (metadata is IDictionary<string, object> dictionary)
		{
			if (metadataType == typeof(IDictionary<string, object>))
			{
				return true;
			}
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				if (metadataType.IsTypeOf(item.Value))
				{
					return true;
				}
			}
			return false;
		}
		return metadataType.IsTypeOf(metadata);
	}
}
