using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public record ProductSortTypes
{
	public required IReadOnlyList<ProductSortType> Items { get; init; }

	public static ProductSortType DefaultSort => new ProductSortType
	{
		Name = "По популярности",
		Field = "rank",
		Direction = "asc",
		SerialNumber = 1
	};

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected ProductSortTypes(ProductSortTypes original)
	{
		Items = original.Items;
	}

	public ProductSortTypes()
	{
	}
}
