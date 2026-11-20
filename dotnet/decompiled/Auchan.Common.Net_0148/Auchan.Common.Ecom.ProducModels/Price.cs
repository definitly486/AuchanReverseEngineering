using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record Price
{
	public decimal Value { get; init; }

	public string? Currency { get; init; }

	public ProductUnitType UnitType { get; init; }
}
