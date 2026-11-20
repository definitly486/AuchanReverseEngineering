using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using DryIoc.ImTools;

namespace DryIoc;

public static class Registrator
{
	internal sealed class Disposer<T> : IDisposable
	{
		private readonly Action<T> _dispose;

		private int _state;

		private const int TRACKED = 1;

		private const int DISPOSED = 2;

		private T _item;

		public Disposer(Action<T> dispose)
		{
			_dispose = dispose;
		}

		public S TrackForDispose<S>(S item) where S : T
		{
			if (Interlocked.CompareExchange(ref _state, 1, 0) != 0)
			{
				Throw.It(Error.DisposerTrackForDisposeError, (_state == 1) ? " tracked" : "disposed");
			}
			_item = (T)(object)item;
			return item;
		}

		public void Dispose()
		{
			if (Interlocked.CompareExchange(ref _state, 2, 1) == 1)
			{
				T item = _item;
				if (item != null)
				{
					_dispose(item);
					_item = default(T);
				}
			}
		}
	}

	public static Func<Type, bool> Interfaces = (Type x) => x.IsInterface;

	private const string InvokeMethodName = "Invoke";

	private static readonly MethodInfo _initializerMethod = typeof(Registrator).SingleMethod("Initializer", includeNonPublic: true);

	public static void Register(this IRegistrator registrator, Type serviceType, Factory factory, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register(factory, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Register(this IRegistrator registrator, Type serviceType, Type implementationType, IReuse reuse)
	{
		registrator.Register(ReflectionFactory.Of(implementationType, reuse), serviceType, null, null, isStaticallyChecked: false);
	}

	public static void Register(this IRegistrator registrator, Type serviceType, Type implementationType, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register(ReflectionFactory.Of(implementationType, reuse, made, setup), serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: false);
	}

	public static void Register(this IRegistrator registrator, Type serviceAndMayBeImplementationType, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register(ReflectionFactory.Of(serviceAndMayBeImplementationType, reuse, made, setup), serviceAndMayBeImplementationType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: false);
	}

	public static void Register<TService, TImplementation>(this IRegistrator registrator, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null) where TImplementation : TService
	{
		registrator.Register(ReflectionFactory.Of(typeof(TImplementation), reuse, made, setup), typeof(TService), serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
	}

	public static void Register<TImplementation>(this IRegistrator registrator, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register<TImplementation, TImplementation>(reuse, made, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void Register<TService, TMadeResult>(this IRegistrator registrator, Made.TypedMade<TMadeResult> made, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null) where TMadeResult : TService
	{
		registrator.Register(ReflectionFactory.Of((Type)null, reuse, (Made)made, setup), typeof(TService), serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
	}

	public static void Register<TService>(this IRegistrator registrator, Made.TypedMade<TService> made, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register<TService, TService>(made, reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterInstance(this IRegistrator registrator, bool isChecked, Type serviceType, object instance, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		registrator.Register(InstanceFactory.Of(instance, setup), serviceType, serviceKey, ifAlreadyRegistered, isChecked);
		registrator.TrackDisposable(instance, setup);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TrackDisposable(this IRegistrator registrator, object instance)
	{
		if (instance is IDisposable disposable)
		{
			((IResolverContext)registrator).SingletonScope.TrackDisposable(disposable);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TrackDisposable(this IRegistrator registrator, object instance, Setup setup)
	{
		if (instance is IDisposable disposable && (setup == null || (!setup.PreventDisposal && !setup.WeaklyReferenced)))
		{
			((IResolverContext)registrator).SingletonScope.TrackDisposable(disposable);
		}
	}

	public static void RegisterInstance(this IRegistrator registrator, Type serviceType, object instance, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		registrator.RegisterInstance(isChecked: false, serviceType, instance, ifAlreadyRegistered, setup, serviceKey);
	}

	public static void RegisterInstance<T>(this IRegistrator registrator, T instance, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		registrator.RegisterInstance(isChecked: true, typeof(T), instance, ifAlreadyRegistered, setup, serviceKey);
	}

	public static void RegisterInstanceMany(this IRegistrator registrator, Type implType, object instance, bool nonPublicServiceTypes = false, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		instance.ThrowIfNull();
		if (implType != null)
		{
			instance.ThrowIfNotInstanceOf(implType);
		}
		else
		{
			implType = instance.GetType();
		}
		Type[] implementedServiceTypes = implType.GetImplementedServiceTypes(nonPublicServiceTypes);
		if (implementedServiceTypes.Length == 0)
		{
			Throw.It(Error.NoServicesWereRegisteredByRegisterMany, implType.One());
		}
		InstanceFactory factory = InstanceFactory.Of(instance, setup);
		Type[] array = implementedServiceTypes;
		foreach (Type serviceType in array)
		{
			registrator.Register(factory, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
		}
		if (instance is IDisposable disposable && (setup == null || (!setup.PreventDisposal && !setup.WeaklyReferenced)))
		{
			(registrator as IResolverContext)?.SingletonScope.TrackDisposable(disposable);
		}
	}

	public static void RegisterInstanceMany<T>(this IRegistrator registrator, T instance, bool nonPublicServiceTypes = false, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		registrator.RegisterInstanceMany(instance.GetType(), instance, nonPublicServiceTypes, ifAlreadyRegistered, setup, serviceKey);
	}

	public static void RegisterInstanceMany(this IRegistrator registrator, Type[] serviceTypes, object instance, IfAlreadyRegistered? ifAlreadyRegistered = null, Setup setup = null, object serviceKey = null)
	{
		Type type = instance.GetType();
		if (serviceTypes.IsNullOrEmpty())
		{
			Throw.It(Error.NoServicesWereRegisteredByRegisterMany, instance);
		}
		InstanceFactory factory = InstanceFactory.Of(instance, setup);
		foreach (Type type2 in serviceTypes)
		{
			type2.ThrowIfNotImplementedBy(type);
			registrator.Register(factory, type2, serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
		}
		if (instance is IDisposable disposable && (setup == null || (!setup.PreventDisposal && !setup.WeaklyReferenced)))
		{
			(registrator as IResolverContext)?.SingletonScope.TrackDisposable(disposable);
		}
	}

	public static bool IsExcludedGeneralPurposeServiceType(this Type type)
	{
		if (type == typeof(object))
		{
			return true;
		}
		if (type == typeof(string))
		{
			return true;
		}
		if (type == typeof(IDisposable))
		{
			return true;
		}
		if (type == typeof(IComparable))
		{
			return true;
		}
		if (type.IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition == typeof(IEquatable<>))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsServiceType(this Type type)
	{
		if (!type.IsPrimitive() && !type.IsExcludedGeneralPurposeServiceType())
		{
			return !type.IsCompilerGenerated();
		}
		return false;
	}

	public static bool IsImplementationType(this Type type)
	{
		if (type.IsClass && !type.IsAbstract)
		{
			return !type.IsCompilerGenerated();
		}
		return false;
	}

	public static Type[] GetImplementedServiceTypes(this Type type, bool nonPublicServiceTypes = false)
	{
		Type[] implementedTypes = type.GetImplementedTypes(ReflectionTools.AsImplementedType.SourceType);
		Type[] array = (nonPublicServiceTypes ? implementedTypes.Match((Type t) => t.IsServiceType()) : implementedTypes.Match((Type t) => t.IsPublicOrNestedPublic() && t.IsServiceType()));
		if (type.IsGenericTypeDefinition)
		{
			array = array.Match(type.GetGenericArguments(), (Type[] paramsAndArgs, Type x) => x.ContainsAllGenericTypeParameters(paramsAndArgs), (Type[] _, Type x) => x.GetGenericDefinitionOrNull());
		}
		return array;
	}

	public static bool IsImplementingServiceType(this Type type, Type serviceType)
	{
		if (serviceType == type || serviceType == typeof(object))
		{
			return true;
		}
		if (!type.IsGenericTypeDefinition)
		{
			if (serviceType.IsInterface)
			{
				Type[] interfaces = type.GetInterfaces();
				foreach (Type type2 in interfaces)
				{
					if (type2 == serviceType)
					{
						return true;
					}
				}
			}
			else
			{
				Type baseType = type.BaseType;
				while (baseType != null && baseType != typeof(object))
				{
					if (serviceType == baseType)
					{
						return true;
					}
					baseType = baseType.BaseType;
				}
			}
		}
		else if (serviceType.IsGenericTypeDefinition)
		{
			Type[] genericArguments = type.GetGenericArguments();
			if (serviceType.IsInterface)
			{
				Type[] interfaces2 = type.GetInterfaces();
				foreach (Type type3 in interfaces2)
				{
					if (type3.IsGenericType && type3.GetGenericTypeDefinition() == serviceType && type3.ContainsAllGenericTypeParameters(genericArguments))
					{
						return true;
					}
				}
			}
			else
			{
				Type baseType2 = type.BaseType;
				while (baseType2 != null && baseType2 != typeof(object))
				{
					if (baseType2.IsGenericType && baseType2.GetGenericTypeDefinition() == serviceType && baseType2.ContainsAllGenericTypeParameters(genericArguments))
					{
						return true;
					}
					baseType2 = baseType2.BaseType;
				}
			}
		}
		return false;
	}

	public static Type[] GetRegisterManyImplementedServiceTypes(this Type type, bool nonPublicServiceTypes = false)
	{
		return type.GetImplementedServiceTypes(nonPublicServiceTypes).Match((Type t) => !t.IsGenericTypeDefinition || WrappersSupport.SupportedCollectionTypes.IndexOfReference(t) == -1);
	}

	public static IEnumerable<Type> GetImplementationTypes(this Assembly assembly)
	{
		return Portable.GetAssemblyTypes(assembly).Where(IsImplementationType);
	}

	public static IEnumerable<Type> GetImplementationTypes(this Assembly assembly, Func<Type, bool> condition)
	{
		return from t in Portable.GetAssemblyTypes(assembly)
			where condition(t) && t.IsImplementationType()
			select t;
	}

	public static bool ImplementsServiceType(this Type type, Type serviceType)
	{
		if (type.IsImplementationType())
		{
			return type.IsImplementingServiceType(serviceType);
		}
		return false;
	}

	public static bool ImplementsServiceType<TService>(this Type type)
	{
		return type.ImplementsServiceType(typeof(TService));
	}

	public static ReflectionFactory ToFactory(this Type implType)
	{
		return ReflectionFactory.Of(implType);
	}

	public static ReflectionFactory ToFactory(this Type implType, IReuse reuse = null, Made made = null, Setup setup = null)
	{
		return ReflectionFactory.Of(implType, reuse, made, setup);
	}

	public static void RegisterMany(this IRegistrator registrator, IEnumerable<Type> implTypes, Func<Type, Type[]> getServiceTypes, Func<Type, Factory> getImplFactory = null, Func<Type, Type, object> getServiceKey = null, IfAlreadyRegistered? ifAlreadyRegistered = null)
	{
		getImplFactory = getImplFactory ?? new Func<Type, Factory>(ToFactory);
		Rules rules = registrator.Rules;
		bool flag = false;
		bool flag2 = false;
		foreach (Type implType in implTypes)
		{
			flag2 = true;
			Type[] array = getServiceTypes(implType);
			if (array.IsNullOrEmpty())
			{
				continue;
			}
			Factory factory = getImplFactory(implType);
			foreach (Type type in array)
			{
				object serviceKey = getServiceKey?.Invoke(implType, type);
				if (factory.ValidateAndNormalizeRegistration(type, serviceKey, isStaticallyChecked: false, rules, throwIfInvalid: false))
				{
					registrator.Register(type, factory, ifAlreadyRegistered, serviceKey);
					flag = true;
				}
			}
		}
		if (flag2 && !flag)
		{
			Throw.It(Error.NoServicesWereRegisteredByRegisterMany, implTypes);
		}
	}

	public static void RegisterManyIgnoreNoServicesWereRegistered(this IRegistrator registrator, IEnumerable<Type> implTypes, Func<Type, Type[]> getServiceTypes, Func<Type, Factory> getImplFactory = null, Func<Type, Type, object> getServiceKey = null, IfAlreadyRegistered? ifAlreadyRegistered = null)
	{
		getImplFactory = getImplFactory ?? new Func<Type, Factory>(ToFactory);
		foreach (Type implType in implTypes)
		{
			Type[] array = getServiceTypes(implType);
			if (!array.IsNullOrEmpty())
			{
				Factory factory = getImplFactory(implType);
				foreach (Type type in array)
				{
					registrator.Register(type, factory, ifAlreadyRegistered, getServiceKey?.Invoke(implType, type));
				}
			}
		}
	}

	public static void RegisterMany(this IRegistrator registrator, Type[] serviceTypes, Type implType, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.RegisterMany(new Type[1] { implType }, serviceTypes.ToFunc<Type, Type[]>, (Type t) => t.ToFactory(reuse, made, setup), (Type _, Type __) => serviceKey, ifAlreadyRegistered);
	}

	public static void RegisterMany(this IRegistrator registrator, IEnumerable<Assembly> implTypeAssemblies, Func<Type, Type[]> getServiceTypes, Func<Type, Factory> getImplFactory = null, Func<Type, Type, object> getServiceKey = null, IfAlreadyRegistered? ifAlreadyRegistered = null)
	{
		registrator.RegisterMany(implTypeAssemblies.ThrowIfNull().SelectMany(GetImplementationTypes), getServiceTypes, getImplFactory, getServiceKey, ifAlreadyRegistered);
	}

	public static void RegisterMany(this IRegistrator registrator, IEnumerable<Assembly> implTypeAssemblies, Func<Type, bool> serviceTypeCondition, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, bool nonPublicServiceTypes = false, object serviceKey = null)
	{
		registrator.RegisterMany(implTypeAssemblies.ThrowIfNull().SelectMany(GetImplementationTypes), reuse, made, setup, ifAlreadyRegistered, serviceTypeCondition, nonPublicServiceTypes, serviceKey);
	}

	public static void RegisterMany(this IRegistrator registrator, IEnumerable<Type> implTypes, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, Func<Type, bool> serviceTypeCondition = null, bool nonPublicServiceTypes = false, object serviceKey = null)
	{
		registrator.RegisterMany(implTypes, (Type t) => t.GetRegisterManyImplementedServiceTypes(nonPublicServiceTypes).Match(serviceTypeCondition ?? new Func<Type, bool>(Fun.Always)), (reuse == null && made == null && setup == null) ? null : ((Func<Type, Factory>)((Type t) => t.ToFactory(reuse, made, setup))), (serviceKey == null) ? null : ((Func<Type, Type, object>)((Type i, Type s) => serviceKey)), ifAlreadyRegistered);
	}

	public static void RegisterMany<TImplementation>(this IRegistrator registrator, IReuse reuse = null, Made made = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, Func<Type, bool> serviceTypeCondition = null, bool nonPublicServiceTypes = false, object serviceKey = null)
	{
		registrator.RegisterMany(ArrayTools.One(typeof(TImplementation)), reuse, made, setup, ifAlreadyRegistered, serviceTypeCondition, nonPublicServiceTypes, serviceKey);
	}

	public static void RegisterMany<TMadeResult>(this IRegistrator registrator, Made.TypedMade<TMadeResult> made, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, Func<Type, bool> serviceTypeCondition = null, bool nonPublicServiceTypes = false, object serviceKey = null)
	{
		registrator.RegisterMany<TMadeResult>(reuse, made.ThrowIfNull(), setup, ifAlreadyRegistered, serviceTypeCondition, nonPublicServiceTypes, serviceKey);
	}

	public static object ToFactoryDelegate<TService>(this Func<IResolverContext, TService> f, IResolverContext r)
	{
		return f(r);
	}

	public static object ToFactoryDelegate(this object result, IResolverContext _)
	{
		return result;
	}

	public static void RegisterDelegate<TService>(this IRegistrator registrator, Func<IResolverContext, TService> factoryDelegate, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register(DelegateFactory.Of(factoryDelegate.ToFactoryDelegate, reuse, setup), typeof(TService), serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
	}

	private static object ToFuncWithObjResult<TService>(this Func<TService> f)
	{
		return f();
	}

	private static object ToFuncWithObjParams<D1, TService>(this Func<D1, TService> f, object d1)
	{
		return f((D1)d1);
	}

	private static object ToFuncWithObjParams<D1, D2, TService>(this Func<D1, D2, TService> f, object d1, object d2)
	{
		return f((D1)d1, (D2)d2);
	}

	private static object ToFuncWithObjParams<D1, D2, D3, TService>(this Func<D1, D2, D3, TService> f, object d1, object d2, object d3)
	{
		return f((D1)d1, (D2)d2, (D3)d3);
	}

	private static object ToFuncWithObjParams<D1, D2, D3, D4, TService>(this Func<D1, D2, D3, D4, TService> f, object d1, object d2, object d3, object d4)
	{
		return f((D1)d1, (D2)d2, (D3)d3, (D4)d4);
	}

	private static object ToFuncWithObjParams<D1, D2, D3, D4, D5, TService>(this Func<D1, D2, D3, D4, D5, TService> f, object d1, object d2, object d3, object d4, object d5)
	{
		return f((D1)d1, (D2)d2, (D3)d3, (D4)d4, (D5)d5);
	}

	private static object ToFuncWithObjParams<D1, D2, D3, D4, D5, D6, TService>(this Func<D1, D2, D3, D4, D5, D6, TService> f, object d1, object d2, object d3, object d4, object d5, object d6)
	{
		return f((D1)d1, (D2)d2, (D3)d3, (D4)d4, (D5)d5, (D6)d6);
	}

	private static object ToFuncWithObjParams<D1, D2, D3, D4, D5, D6, D7, TService>(this Func<D1, D2, D3, D4, D5, D6, D7, TService> f, object d1, object d2, object d3, object d4, object d5, object d6, object d7)
	{
		return f((D1)d1, (D2)d2, (D3)d3, (D4)d4, (D5)d5, (D6)d6, (D7)d7);
	}

	private static void RegisterFunc(this IRegistrator r, Type serviceType, Type sourceFuncType, Delegate funcWithObjParams, IReuse reuse, Setup setup, IfAlreadyRegistered? ifAlreadyRegistered, object serviceKey)
	{
		Made made = new Made(new FactoryMethod.WithFunc(sourceFuncType.GetMethod("Invoke"), funcWithObjParams));
		ReflectionFactory factory = ReflectionFactory.OfTypeAndMadeNoValidation(serviceType, made, reuse, setup);
		r.Register(factory, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
	}

	public static void RegisterDelegate<TService>(this IRegistrator r, Func<TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TService>), new Func<object>(factory.ToFuncWithObjResult), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TService>(this IRegistrator r, Func<TDep1, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TService>), new Func<object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1>(this IRegistrator r, Type serviceType, Func<TDep1, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, object>), new Func<object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type depType, Func<object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, >).MakeGenericType(depType, typeof(object)), new Func<object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TService>(this IRegistrator r, Func<TDep1, TDep2, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TService>), new Func<object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, object>), new Func<object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Func<object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , >).MakeGenericType(dep1Type, dep2Type, typeof(object)), new Func<object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TService>(this IRegistrator r, Func<TDep1, TDep2, TDep3, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TDep3, TService>), new Func<object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, TDep3, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, TDep3, object>), new Func<object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Type dep3Type, Func<object, object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , , >).MakeGenericType(dep1Type, dep2Type, dep3Type, typeof(object)), new Func<object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TService>(this IRegistrator r, Func<TDep1, TDep2, TDep3, TDep4, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TDep3, TDep4, TService>), new Func<object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, TDep3, TDep4, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, TDep3, TDep4, object>), new Func<object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Type dep3Type, Type dep4Type, Func<object, object, object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , , >).MakeGenericType(dep1Type, dep2Type, dep3Type, dep4Type, typeof(object)), new Func<object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5, TService>(this IRegistrator r, Func<TDep1, TDep2, TDep3, TDep4, TDep5, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, TService>), new Func<object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, TDep3, TDep4, TDep5, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, object>), new Func<object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Type dep3Type, Type dep4Type, Type dep5Type, Func<object, object, object, object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , , >).MakeGenericType(dep1Type, dep2Type, dep3Type, dep4Type, dep5Type, typeof(object)), new Func<object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TService>(this IRegistrator r, Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TService>), new Func<object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, object>), new Func<object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Type dep3Type, Type dep4Type, Type dep5Type, Type dep6Type, Func<object, object, object, object, object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , , >).MakeGenericType(dep1Type, dep2Type, dep3Type, dep4Type, dep5Type, dep6Type, typeof(object)), new Func<object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7, TService>(this IRegistrator r, Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7, TService> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(typeof(TService), typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7, TService>), new Func<object, object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7>(this IRegistrator r, Type serviceType, Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<TDep1, TDep2, TDep3, TDep4, TDep5, TDep6, TDep7, object>), new Func<object, object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator r, Type serviceType, Type dep1Type, Type dep2Type, Type dep3Type, Type dep4Type, Type dep5Type, Type dep6Type, Type dep7Type, Func<object, object, object, object, object, object, object, object> factory, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		r.RegisterFunc(serviceType, typeof(Func<, , , >).MakeGenericType(dep1Type, dep2Type, dep3Type, dep4Type, dep5Type, dep6Type, dep7Type, typeof(object)), new Func<object, object, object, object, object, object, object, object>(factory.ToFuncWithObjParams), reuse, setup, ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterDelegate(this IRegistrator registrator, Type serviceType, Func<IResolverContext, object> factoryDelegate, IReuse reuse = null, Setup setup = null, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		if (serviceType.IsOpenGeneric())
		{
			Throw.It(Error.ImpossibleToRegisterOpenGenericWithRegisterDelegate, serviceType);
		}
		FactoryDelegate factoryDelegate2 = (IResolverContext r) => factoryDelegate(r).ThrowIfNotInstanceOf(serviceType, Error.RegisteredDelegateResultIsNotOfServiceType);
		DelegateFactory factory = DelegateFactory.Of(factoryDelegate2, reuse, setup);
		registrator.Register(factory, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: false);
	}

	public static void RegisterDelegateDecorator<TService>(this IRegistrator registrator, Func<IResolverContext, Func<TService, TService>> getDecorator, Func<Request, bool> condition = null)
	{
		getDecorator.ThrowIfNull();
		registrator.RegisterDelegate((IResolverContext r, TService service) => getDecorator(r)(service), null, (condition == null) ? Setup.DecoratorWith(null, 0, useDecorateeReuse: true) : Setup.DecoratorWith(condition, 0, useDecorateeReuse: true));
	}

	public static void Use<TService>(this IResolverContext r, Func<IResolverContext, TService> factory)
	{
		r.Use(typeof(TService), new FactoryDelegate(factory.ToFactoryDelegate));
	}

	public static void Use(this IResolverContext r, Type serviceType, FactoryDelegate factory)
	{
		r.Use(serviceType, factory);
	}

	public static void Use<TService>(this IResolverContext r, FactoryDelegate factory)
	{
		r.Use(typeof(TService), factory);
	}

	public static void Use(this IResolverContext r, Type serviceType, object instance)
	{
		r.Use(serviceType, instance);
	}

	public static void Use<TService>(this IResolverContext r, TService instance)
	{
		r.Use(typeof(TService), instance);
	}

	public static void Use<TService>(this IRegistrator r, Func<IResolverContext, TService> factory)
	{
		r.Use(typeof(TService), new FactoryDelegate(factory.ToFactoryDelegate));
	}

	public static void Use<TService>(this IRegistrator r, FactoryDelegate factory)
	{
		r.Use(typeof(TService), factory);
	}

	public static void Use(this IRegistrator r, Type serviceType, FactoryDelegate factory)
	{
		r.Use(serviceType, factory);
	}

	public static void Use(this IRegistrator r, Type serviceType, object instance)
	{
		r.Use(serviceType, instance);
	}

	public static void Use<TService>(this IRegistrator r, TService instance)
	{
		r.Use(typeof(TService), instance);
	}

	public static void Use<TService>(this IContainer c, Func<IResolverContext, TService> factory)
	{
		((IResolverContext)c).Use(typeof(TService), (object)new FactoryDelegate(factory.ToFactoryDelegate));
	}

	public static void Use<TService>(this IContainer c, FactoryDelegate factory)
	{
		((IResolverContext)c).Use(typeof(TService), (object)factory);
	}

	public static void Use(this IContainer c, Type serviceType, FactoryDelegate factory)
	{
		((IResolverContext)c).Use(serviceType, (object)factory);
	}

	public static void Use(this IContainer c, Type serviceType, object instance)
	{
		((IResolverContext)c).Use(serviceType, instance);
	}

	public static void Use<TService>(this IContainer c, TService instance)
	{
		((IResolverContext)c).Use(typeof(TService), (object)instance);
	}

	public static void RegisterInitializer<TTarget>(this IRegistrator registrator, Action<TTarget, IResolverContext> initialize, Func<Request, bool> condition = null)
	{
		registrator.RegisterInitializer(initialize, null, condition);
	}

	public static void RegisterInitializer<TTarget>(this IRegistrator registrator, Action<TTarget, IResolverContext> initialize, IReuse reuse, Func<Request, bool> condition = null)
	{
		initialize.ThrowIfNull();
		registrator.Register<object>(reuse, Made.Of((Func<Request, MemberInfo>)((Request r) => _initializerMethod.MakeGenericMethod(typeof(TTarget), r.ServiceType)), (ServiceInfo)null, Parameters.Of.Type(initialize.ToFunc<Request, Action<TTarget, IResolverContext>>), (PropertiesAndFieldsSelector)null), Setup.DecoratorWith((Request r) => r.FactoryType != FactoryType.Wrapper && typeof(TTarget).IsAssignableFrom(r.ServiceType) && (condition == null || condition(r)), 0, useDecorateeReuse: true, openResolutionScope: false, asResolutionCall: false, preventDisposal: true));
	}

	internal static TService Initializer<TTarget, TService>(TService service, IResolverContext resolver, Action<TTarget, IResolverContext> initialize) where TService : TTarget
	{
		initialize((TTarget)(object)service, resolver);
		return service;
	}

	public static void RegisterDisposer<TService>(this IRegistrator registrator, Action<TService> dispose, Func<Request, bool> condition = null)
	{
		dispose.ThrowIfNull();
		object obj = new object();
		Func<IResolverContext, Disposer<TService>> factoryDelegate = (IResolverContext _) => new Disposer<TService>(dispose);
		object serviceKey = obj;
		registrator.RegisterDelegate(factoryDelegate, null, Setup.With(null, null, openResolutionScope: false, asResolutionCall: false, asResolutionRoot: false, preventDisposal: false, weaklyReferenced: false, allowDisposableTransient: false, trackDisposableTransient: true), null, serviceKey);
		Type disposerType = typeof(Disposer<>).MakeGenericType(typeof(TService));
		registrator.Register<object>(null, Made.Of((Request r) => disposerType.SingleMethod("TrackForDispose").MakeGenericMethod(r.ServiceType), ServiceInfo.Of(disposerType, obj)), Setup.DecoratorWith((Request r) => typeof(TService).IsAssignableFrom(r.ServiceType) && (condition == null || condition(r)), 0, useDecorateeReuse: true));
	}

	public static bool IsRegistered(this IRegistrator registrator, Type serviceType, object serviceKey = null, FactoryType factoryType = FactoryType.Service, Func<Factory, bool> condition = null)
	{
		return registrator.IsRegistered(serviceType, serviceKey, factoryType, condition);
	}

	public static bool IsRegistered<TService>(this IRegistrator registrator, object serviceKey = null, FactoryType factoryType = FactoryType.Service, Func<Factory, bool> condition = null)
	{
		return registrator.IsRegistered(typeof(TService), serviceKey, factoryType, condition);
	}

	public static void Unregister(this IRegistrator registrator, Type serviceType, object serviceKey = null, FactoryType factoryType = FactoryType.Service, Func<Factory, bool> condition = null)
	{
		registrator.Unregister(serviceType, serviceKey, factoryType, condition);
	}

	public static void Unregister<TService>(this IRegistrator registrator, object serviceKey = null, FactoryType factoryType = FactoryType.Service, Func<Factory, bool> condition = null)
	{
		registrator.Unregister(typeof(TService), serviceKey, factoryType, condition);
	}

	public static void RegisterMapping(this IRegistrator registrator, Type serviceType, Type registeredServiceType, IfAlreadyRegistered? ifAlreadyRegistered, object serviceKey = null, object registeredServiceKey = null, FactoryType factoryType = FactoryType.Service)
	{
		Factory[] registeredFactories = registrator.GetRegisteredFactories(registeredServiceType, registeredServiceKey, factoryType);
		if (registeredFactories.IsNullOrEmpty())
		{
			Throw.It(Error.RegisterMappingNotFoundRegisteredService, registeredServiceType, registeredServiceKey);
		}
		if (registeredFactories.Length > 1)
		{
			Throw.It(Error.RegisterMappingUnableToSelectFromMultipleFactories, serviceType, serviceKey, registeredFactories);
		}
		registrator.Register(registeredFactories[0], serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: false);
	}

	public static void RegisterMapping(this IRegistrator registrator, Type serviceType, Type registeredServiceType, object serviceKey = null, object registeredServiceKey = null, FactoryType factoryType = FactoryType.Service)
	{
		registrator.RegisterMapping(serviceType, registeredServiceType, null, serviceKey, registeredServiceKey, factoryType);
	}

	public static void RegisterMapping<TService, TRegisteredService>(this IRegistrator registrator, object serviceKey = null, object registeredServiceKey = null, FactoryType factoryType = FactoryType.Service)
	{
		registrator.RegisterMapping(typeof(TService), typeof(TRegisteredService), null, serviceKey, registeredServiceKey);
	}

	public static void RegisterPlaceholder(this IRegistrator registrator, Type serviceType, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.Register(FactoryPlaceholder.Default, serviceType, serviceKey, ifAlreadyRegistered, isStaticallyChecked: true);
	}

	public static void RegisterPlaceholder<TService>(this IRegistrator registrator, IfAlreadyRegistered? ifAlreadyRegistered = null, object serviceKey = null)
	{
		registrator.RegisterPlaceholder(typeof(TService), ifAlreadyRegistered, serviceKey);
	}

	public static void RegisterMapping<TService, TRegisteredService>(this IContainer container, IfAlreadyRegistered ifAlreadyRegistered, object serviceKey = null, object registeredServiceKey = null)
	{
		container.RegisterMapping(typeof(TService), typeof(TRegisteredService), ifAlreadyRegistered, serviceKey, registeredServiceKey);
	}
}
