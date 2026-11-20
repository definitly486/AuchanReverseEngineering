using Auchan.Common.Ecom.Products;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Profile;

public class FavoritePriceDto
{
	[JsonProperty("value")]
	public decimal? Value { get; set; }

	[JsonProperty("currency")]
	public string? Currency { get; set; }

	[JsonProperty("per")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ProductUnitType? UnitType { get; set; }
}
