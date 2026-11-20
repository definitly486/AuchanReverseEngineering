using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
{
	private static volatile EqualityComparer<T> defaultComparer;

	public static EqualityComparer<T> Default
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			EqualityComparer<T> equalityComparer = defaultComparer;
			if (equalityComparer == null)
			{
				Interlocked.CompareExchange(ref defaultComparer, CreateComparer(), null);
				equalityComparer = defaultComparer;
			}
			return equalityComparer;
		}
	}

	private static EqualityComparer<T> CreateComparer()
	{
		RuntimeType runtimeType = (RuntimeType)typeof(T);
		if (runtimeType == typeof(string))
		{
			return (EqualityComparer<T>)(object)new StringEqualityComparer();
		}
		if (typeof(IEquatable<T>).IsAssignableFrom(runtimeType))
		{
			return (EqualityComparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(GenericEqualityComparer<>), runtimeType);
		}
		if (runtimeType.IsGenericType && runtimeType.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			RuntimeType genericArgument = (RuntimeType)runtimeType.GetGenericArguments()[0];
			return (EqualityComparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(NullableEqualityComparer<>), genericArgument);
		}
		if (runtimeType.IsEnum)
		{
			return (EqualityComparer<T>)RuntimeType.CreateInstanceForAnotherGenericParameter(typeof(EnumEqualityComparer<>), runtimeType);
		}
		return new ObjectEqualityComparer<T>();
	}

	public static EqualityComparer<T> Create(Func<T?, T?, bool> equals, Func<T, int>? getHashCode = null)
	{
		ArgumentNullException.ThrowIfNull(equals, "equals");
		if (getHashCode == null)
		{
			getHashCode = delegate
			{
				throw new NotSupportedException();
			};
		}
		return new DelegateEqualityComparer<T>(equals, getHashCode);
	}

	public abstract bool Equals(T? x, T? y);

	public abstract int GetHashCode([DisallowNull] T obj);

	int IEqualityComparer.GetHashCode(object obj)
	{
		if (obj == null)
		{
			return 0;
		}
		if (obj is T)
		{
			return GetHashCode((T)obj);
		}
		ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
		return 0;
	}

	bool IEqualityComparer.Equals(object x, object y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		if (x is T && y is T)
		{
			return Equals((T)x, (T)y);
		}
		ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
		return false;
	}

	internal virtual int IndexOf(T[] array, T value, int startIndex, int count)
	{
		int num = startIndex + count;
		for (int i = startIndex; i < num; i++)
		{
			if (Equals(array[i], value))
			{
				return i;
			}
		}
		return -1;
	}

	internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count)
	{
		int num = startIndex - count + 1;
		for (int num2 = startIndex; num2 >= num; num2--)
		{
			if (Equals(array[num2], value))
			{
				return num2;
			}
		}
		return -1;
	}
}
