namespace Auchan.Common.Ecom.ProducModels.Filters;

public sealed class ProductFilterMultiItem
{
	public required string Name { get; init; }

	public required string Code { get; init; }

	public required bool Disabled { get; init; }

	public required bool IsForActive { get; init; }

	public required int Counter { get; init; }
}
