namespace Auchan.Common.Ecom.Search.Models;

public class SearchFilterMultiItem
{
	public required string Name { get; init; }

	public required string Code { get; init; }

	public required bool Disabled { get; init; }

	public required int Counter { get; init; }
}
