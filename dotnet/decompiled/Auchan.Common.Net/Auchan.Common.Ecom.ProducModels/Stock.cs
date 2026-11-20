using System.Collections.Generic;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record Stock
{
	public decimal Qty { get; set; }

	public int StoreId { get; set; }

	public bool NotAvailable { get; set; }

	public double? PriceFrom { get; set; }

	public IReadOnlyList<AvailableShop>? Shops { get; set; }
}
