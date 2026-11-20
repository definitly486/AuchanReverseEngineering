using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Badges;

public sealed record BadgeModel
{
	public required BadgeType BadgeType { get; init; }

	public required int Rank { get; init; }

	public required string? ImageUrl { get; init; }

	public string? DisplayValue { get; init; }

	public string? ShortDisplayValue { get; init; }

	public string? SecondLine { get; init; }

	public required string? Description { get; init; }

	public override string ToString()
	{
		return $"{Rank} {BadgeType}";
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private BadgeModel(BadgeModel original)
	{
		BadgeType = original.BadgeType;
		Rank = original.Rank;
		ImageUrl = original.ImageUrl;
		DisplayValue = original.DisplayValue;
		ShortDisplayValue = original.ShortDisplayValue;
		SecondLine = original.SecondLine;
		Description = original.Description;
	}

	public BadgeModel()
	{
	}
}
