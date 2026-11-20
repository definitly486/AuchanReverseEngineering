using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class Comparer<T> : IComparer, IComparer<T>
{
	private static volatile Comparer<T> defaultComparer;

	public static Comparer<T> Default
	{
		get
		{
			Comparer<T> comparer = defaultComparer;
			if (comparer == null)
			{
				Interlocked.CompareExchange(ref defaultComparer, CreateComparer(), null);
				comparer = defaultComparer;
			}
			return comparer;
		}
	}

	private static Comparer<T> CreateComparer()
	{
		RuntimeType runtimeType = (RuntimeType)typeof(T);
		if (typeof(IComparable<T>).IsAssignableFrom(runtimeType))
		{
			return (Comparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(GenericComparer<>), runtimeType);
		}
		if (runtimeType.IsGenericType && runtimeType.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			RuntimeType genericArgument = (RuntimeType)runtimeType.GetGenericArguments()[0];
			return (Comparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(NullableComparer<>), genericArgument);
		}
		if (runtimeType.IsEnum)
		{
			return (Comparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(EnumComparer<>), runtimeType);
		}
		return new ObjectComparer<T>();
	}

	public static Comparer<T> Create(Comparison<T> comparison)
	{
		ArgumentNullException.ThrowIfNull(comparison, "comparison");
		return new ComparisonComparer<T>(comparison);
	}

	public abstract int Compare(T? x, T? y);

	int IComparer.Compare(object x, object y)
	{
		if (x == null)
		{
			if (y != null)
			{
				return -1;
			}
			return 0;
		}
		if (y == null)
		{
			return 1;
		}
		if (x is T && y is T)
		{
			return Compare((T)x, (T)y);
		}
		ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
		return 0;
	}
}
