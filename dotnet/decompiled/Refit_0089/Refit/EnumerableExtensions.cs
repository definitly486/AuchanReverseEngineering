using System.Collections.Generic;

namespace Refit;

internal static class EnumerableExtensions
{
	internal static EnumerablePeek TryGetSingle<T>(this IEnumerable<T> enumerable, out T? value)
	{
		value = default(T);
		using IEnumerator<T> enumerator = enumerable.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return EnumerablePeek.Empty;
		}
		value = enumerator.Current;
		if (!enumerator.MoveNext())
		{
			return EnumerablePeek.Single;
		}
		value = default(T);
		return EnumerablePeek.Many;
	}
}
