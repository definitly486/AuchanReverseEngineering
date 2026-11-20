using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record ShopInfoModel
{
	public required string Name { get; init; }

	public required string Address { get; init; }

	public required string PickupDescription { get; init; }

	public required IReadOnlyList<string> PickupPhotoUrls { get; init; }

	public required bool? CollectOrder { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ShopInfoModel(ShopInfoModel original)
	{
		Name = original.Name;
		Address = original.Address;
		PickupDescription = original.PickupDescription;
		PickupPhotoUrls = original.PickupPhotoUrls;
		CollectOrder = original.CollectOrder;
	}

	public ShopInfoModel()
	{
	}
}
