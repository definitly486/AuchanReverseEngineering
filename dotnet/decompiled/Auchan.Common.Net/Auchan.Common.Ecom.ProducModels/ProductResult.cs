using System.Collections.Generic;

namespace Auchan.Common.Ecom.ProducModels;

public class ProductResult
{
	public required IReadOnlyList<Product> Items { get; init; }

	public int TotalCount { get; set; }

	public bool IsAdult { get; set; }
}
