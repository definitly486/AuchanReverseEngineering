using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Address.Models;

public sealed record SavedStore : IEquatable<Store>
{
	public required int Id { get; init; }

	public required bool IsLastSaved { get; init; }

	public required int MerchantId { get; init; }

	public required int RegionId { get; init; }

	public required string Name { get; init; }

	public required string Address { get; init; }

	public required string? Latitude { get; init; }

	public required string? Longitude { get; init; }

	public bool Equals(Store? other)
	{
		if (other == null)
		{
			return false;
		}
		return MerchantId == other.Id;
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SavedStore(SavedStore original)
	{
		Id = original.Id;
		IsLastSaved = original.IsLastSaved;
		MerchantId = original.MerchantId;
		RegionId = original.RegionId;
		Name = original.Name;
		Address = original.Address;
		Latitude = original.Latitude;
		Longitude = original.Longitude;
	}

	public SavedStore()
	{
	}
}
