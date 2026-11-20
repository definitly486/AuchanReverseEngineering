using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record StockDto
{
	[JsonProperty("qty")]
	public decimal? Qty { get; init; }

	[JsonProperty("storeId")]
	public int? StoreId { get; init; }

	[JsonProperty("not_available")]
	public bool NotAvailable { get; init; }

	[JsonProperty("price_from")]
	public double? PriceFrom { get; init; }

	[JsonProperty("shops")]
	public IReadOnlyList<AvailableShopsDto>? Shops { get; init; }
}
