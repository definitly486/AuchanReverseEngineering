using System;
using System.Threading;

namespace Splat;

public static class ResolverMixins
{
	public static IMutableDependencyResolver RegisterAnd<T>(this IMutableDependencyResolver resolver, string? contract = null) where T : new()
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.Register(() => new T(), typeof(T), contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterAnd<T>(this IMutableDependencyResolver resolver, Func<T> factory, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		factory.ThrowArgumentNullExceptionIfNull("factory");
		resolver.Register(() => factory(), typeof(T), contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterAnd<TAs, T>(this IMutableDependencyResolver resolver, string? contract = null) where T : new()
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.Register(() => new T(), typeof(TAs), contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterAnd<TAs, T>(this IMutableDependencyResolver resolver, Func<T> factory, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		factory.ThrowArgumentNullExceptionIfNull("factory");
		resolver.Register(() => factory(), typeof(TAs), contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterConstantAnd(this IMutableDependencyResolver resolver, object value, Type serviceType, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		resolver.Register(() => value, serviceType, contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterConstantAnd<T>(this IMutableDependencyResolver resolver, string? contract = null) where T : new()
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		T value = new T();
		return resolver.RegisterAnd(() => value, contract);
	}

	public static IMutableDependencyResolver RegisterConstantAnd<T>(this IMutableDependencyResolver resolver, T value, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		return resolver.RegisterAnd(() => value, contract);
	}

	public static IMutableDependencyResolver RegisterLazySingletonAnd(this IMutableDependencyResolver resolver, Func<object> valueFactory, Type serviceType, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		Lazy<object> val = new Lazy<object>(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
		resolver.Register(() => val.Value, serviceType, contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterLazySingletonAnd<T>(this IMutableDependencyResolver resolver, string? contract = null) where T : new()
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		Lazy<object> val = new Lazy<object>(() => new T(), LazyThreadSafetyMode.ExecutionAndPublication);
		resolver.Register(() => val.Value, typeof(T), contract);
		return resolver;
	}

	public static IMutableDependencyResolver RegisterLazySingletonAnd<T>(this IMutableDependencyResolver resolver, Func<T> valueFactory, string? contract = null)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		Lazy<object> val = new Lazy<object>(() => valueFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
		resolver.Register(() => val.Value, typeof(T), contract);
		return resolver;
	}
}
