using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable;

[CollectionBuilder(typeof(ImmutableList), "Create")]
public interface IImmutableList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
{
	int IndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer);
}
