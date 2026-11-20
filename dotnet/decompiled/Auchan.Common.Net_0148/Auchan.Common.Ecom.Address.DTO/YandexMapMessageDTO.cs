using System.Text.Json.Serialization;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Ecom.Address.DTO;

internal sealed record YandexMapMessageDTO
{
	[JsonPropertyName("focus")]
	public int? Focus { get; set; }

	[JsonPropertyName("fias_id")]
	public string? FiasId { get; init; }

	[JsonPropertyName("delivery_method")]
	public ReceivingMethod? ReceivingMethod { get; set; }

	[JsonPropertyName("merchant_id")]
	public int? MerchantId { get; set; }

	[JsonPropertyName("geo_lat")]
	public string? Latitude { get; set; }

	[JsonPropertyName("geo_lon")]
	public string? Longitude { get; set; }

	[JsonPropertyName("isNeedSwitching")]
	public bool DontShowDeliveryHereText { get; set; }

	[JsonPropertyName("___echo_mark")]
	public string? EchoMark { get; init; }
}
