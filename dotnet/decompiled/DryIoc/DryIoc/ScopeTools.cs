using System;
using System.Runtime.CompilerServices;

namespace DryIoc;

public static class ScopeTools
{
	public static IScope Clone(this IScope s)
	{
		return s.Clone(withDisposables: true);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsUsed(this IScope s, Type serviceType)
	{
		object instance;
		return s.TryGetUsed(RuntimeHelpers.GetHashCode(serviceType), serviceType, out instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UseFactory(this IScope s, Type type, FactoryDelegate factory)
	{
		s.SetUsed(RuntimeHelpers.GetHashCode(type), type, factory);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UseFactory<T>(this IScope s, FactoryDelegate factory)
	{
		s.UseFactory(typeof(T), factory);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Use(this IScope s, Type type, object instance)
	{
		s.SetUsed(RuntimeHelpers.GetHashCode(type), type, instance);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Use<T>(this IScope s, object instance)
	{
		s.Use(typeof(T), instance);
	}
}
