using System.Collections;
using System.Collections.Generic;

namespace DryIoc;

public sealed class LazyEnumerable<TService> : IEnumerable<TService>, IEnumerable
{
	public readonly IEnumerable<TService> Items;

	public LazyEnumerable(IEnumerable<TService> items)
	{
		Items = items.ThrowIfNull();
	}

	public IEnumerator<TService> GetEnumerator()
	{
		return Items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
