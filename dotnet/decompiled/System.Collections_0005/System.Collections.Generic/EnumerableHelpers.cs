namespace System.Collections.Generic;

internal static class EnumerableHelpers
{
	internal static IEnumerator<T> GetEmptyEnumerator<T>()
	{
		return ((IEnumerable<T>)Array.Empty<T>()).GetEnumerator();
	}
}
