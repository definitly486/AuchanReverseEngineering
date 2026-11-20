using System.Collections.Generic;

namespace Auchan.Common.Ecom.ProducModels.Filters;

public sealed class ProductFilter
{
	public const string IS_ADULT = "is_adult";

	public const string BRAND = "brand";

	public required string Name { get; init; }

	public required string Code { get; init; }

	public required string? Url { get; init; }

	public required ProductFilterType Type { get; init; }

	public required bool IsFixed { get; init; }

	public required bool IsUrlContain { get; init; }

	public required int PositionInUrl { get; init; }

	public required int Sort { get; init; }

	public required int? Min { get; init; }

	public required int? Max { get; init; }

	public required bool? Disabled { get; init; }

	public required bool IsForActive { get; init; }

	public required IReadOnlyList<ProductFilterMultiItem>? Items { get; init; }

	public required string? Informer { get; init; }
}
