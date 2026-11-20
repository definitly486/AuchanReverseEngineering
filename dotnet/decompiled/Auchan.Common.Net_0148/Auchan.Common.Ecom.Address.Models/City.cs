using System.Collections.Generic;
using Auchan.Common.Addresses;

namespace Auchan.Common.Ecom.Address.Models;

public class City
{
	public required long EcomId { get; init; }

	public required string FiasId { get; init; }

	public required string Name { get; init; }

	public required bool IsDefault { get; init; }

	public required IReadOnlyList<string> ChildFiasIds { get; init; }

	public required bool IsInLoyalty { get; init; }

	public Coordinate? Coordinate { get; init; }

	public override int GetHashCode()
	{
		return FiasId.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is City city))
		{
			return false;
		}
		return city.FiasId == FiasId;
	}
}
