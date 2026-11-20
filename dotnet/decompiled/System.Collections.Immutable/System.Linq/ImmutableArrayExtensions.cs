using System.Collections.Immutable;

namespace System.Linq;

public static class ImmutableArrayExtensions
{
	public static bool Any<T>(this ImmutableArray<T> immutableArray)
	{
		return immutableArray.Length > 0;
	}

	public static bool Any<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
	{
		immutableArray.ThrowNullRefIfNotInitialized();
		Requires.NotNull(predicate, "predicate");
		T[] array = immutableArray.array;
		foreach (T arg in array)
		{
			if (predicate(arg))
			{
				return true;
			}
		}
		return false;
	}

	public static T First<T>(this ImmutableArray<T> immutableArray)
	{
		if (immutableArray.Length <= 0)
		{
			return immutableArray.array.First();
		}
		return immutableArray[0];
	}

	public static T? FirstOrDefault<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
	{
		Requires.NotNull(predicate, "predicate");
		T[] array = immutableArray.array;
		foreach (T val in array)
		{
			if (predicate(val))
			{
				return val;
			}
		}
		return default(T);
	}
}
