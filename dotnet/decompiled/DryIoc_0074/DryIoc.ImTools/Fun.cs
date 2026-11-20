using System;
using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public static class Fun
{
	public static bool Always<T>(T _)
	{
		return true;
	}

	public static T Id<T>(T x)
	{
		return x;
	}

	public static R To<T, R>(this T x, Func<T, R> map)
	{
		return map(x);
	}

	public static R To<T, S, R>(this T x, S state, Func<T, S, R> map)
	{
		return map(x, state);
	}

	public static R To<R>(this object x)
	{
		return (R)x;
	}

	public static T Do<T>(this T x, Action<T> effect)
	{
		effect(x);
		return x;
	}

	public static T Do<T, S>(this T x, S state, Action<T, S> effect)
	{
		effect(x, state);
		return x;
	}

	public static R ToFunc<T, R>(this R result, T ignoredArg)
	{
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}
}
