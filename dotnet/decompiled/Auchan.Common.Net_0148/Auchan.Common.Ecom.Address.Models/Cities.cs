using System.Collections;
using System.Collections.Generic;
using Auchan.Common.Networking;

namespace Auchan.Common.Ecom.Address.Models;

public sealed class Cities : IReadOnlyList<City>, IEnumerable<City>, IEnumerable, IReadOnlyCollection<City>
{
	public required IReadOnlyList<City> List { get; init; }

	public required VpnState VpnState { get; init; }

	public City this[int index] => List[index];

	public int Count => List.Count;

	public IEnumerator<City> GetEnumerator()
	{
		return List.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)List).GetEnumerator();
	}
}
