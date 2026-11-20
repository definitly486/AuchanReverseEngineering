using System.Collections.Generic;

namespace Auchan.Common.Ecom.Search.Models;

public class SearchFilter
{
	public required string Name { get; init; }

	public required string Code { get; init; }

	public required SearchFilterType Type { get; init; }

	public required int Sort { get; init; }

	public required int? Min { get; init; }

	public required int? Max { get; init; }

	public required bool? Disabled { get; init; }

	public required IReadOnlyList<SearchFilterMultiItem>? Items { get; init; }

	public required string? Informer { get; init; }
}
