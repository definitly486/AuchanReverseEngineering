using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Splat;

public static class DependencyResolverMixins
{
	public static T? GetService<T>(this IReadonlyDependencyResolver resolver, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		return (T)resolver.GetService(typeof(T), contract);
	}

	public static IEnumerable<T> GetServices<T>(this IReadonlyDependencyResolver resolver, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		return resolver.GetServices(typeof(T), contract).Cast<T>();
	}

	public static IDisposable ServiceRegistrationCallback(this IMutableDependencyResolver resolver, Type serviceType, Action<IDisposable> callback)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		return resolver.ServiceRegistrationCallback(serviceType, null, callback);
	}

	public static IDisposable WithResolver(this IDependencyResolver resolver, bool suppressResolverCallback = true)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		IDisposable disposable = (suppressResolverCallback ? Locator.SuppressResolverCallbackChangedNotifications() : ActionDisposable.Empty);
		IDependencyResolver origResolver = Locator.GetLocator();
		Locator.SetLocator(resolver);
		return new CompositeDisposable(new ActionDisposable(delegate
		{
			Locator.SetLocator(origResolver);
		}), disposable);
	}

	public static void Register<T>(this IMutableDependencyResolver resolver, Func<T?> factory, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		factory.ThrowArgumentNullExceptionIfNull("factory");
		resolver.Register(() => factory(), typeof(T), contract);
	}

	public static void Register<TAs, T>(this IMutableDependencyResolver resolver, string? contract = null) where T : new()
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.Register(() => new T(), typeof(TAs), contract);
	}

	public static void RegisterConstant(this IMutableDependencyResolver resolver, object? value, Type? serviceType, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.Register(() => value, serviceType, contract);
	}

	public static void RegisterConstant<T>(this IMutableDependencyResolver resolver, T? value, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.RegisterConstant(value, typeof(T), contract);
	}

	public static void RegisterLazySingleton(this IMutableDependencyResolver resolver, Func<object?> valueFactory, Type? serviceType, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		Lazy<object?> val = new Lazy<object>(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
		resolver.Register(() => val.Value, serviceType, contract);
	}

	public static void RegisterLazySingleton<T>(this IMutableDependencyResolver resolver, Func<T?> valueFactory, string? contract = null)
	{
		resolver.RegisterLazySingleton(() => valueFactory(), typeof(T), contract);
	}

	public static void UnregisterCurrent<T>(this IMutableDependencyResolver resolver, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.UnregisterCurrent(typeof(T), contract);
	}

	public static void UnregisterAll<T>(this IMutableDependencyResolver resolver, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.UnregisterAll(typeof(T), contract);
	}
}
