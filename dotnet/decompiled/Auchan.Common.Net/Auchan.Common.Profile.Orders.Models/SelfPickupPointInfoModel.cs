using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record SelfPickupPointInfoModel
{
	public required string Description { get; init; }

	public required string? ImageUrl { get; init; }

	public required int Position { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SelfPickupPointInfoModel(SelfPickupPointInfoModel original)
	{
		Description = original.Description;
		ImageUrl = original.ImageUrl;
		Position = original.Position;
	}

	public SelfPickupPointInfoModel()
	{
	}
}
