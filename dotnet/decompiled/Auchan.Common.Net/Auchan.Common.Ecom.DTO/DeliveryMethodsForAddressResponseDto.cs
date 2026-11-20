using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record DeliveryMethodsForAddressResponseDto
{
	public sealed record DataDto
	{
		[JsonProperty("delivery_available")]
		public bool IsDeliveryAvailable { get; init; }

		[JsonProperty("region_id")]
		public long? RegionId { get; init; }

		[JsonProperty("delivery")]
		public DeliveryDto? StandardDelivery { get; init; }

		[JsonProperty("express_delivery")]
		public DeliveryDto? ExpressDelivery { get; init; }

		[JsonProperty("express_delivery_unavailable")]
		public ExpressDeliveryUnavailableDto? ExpressDeliveryUnavailable { get; init; }
	}

	public sealed record ExpressDeliveryUnavailableDto
	{
		[JsonProperty("unavailable_hint")]
		public string? UnavailableHint { get; init; }
	}

	public sealed record DeliveryDto
	{
		[JsonProperty("merchant_id")]
		public int MerchantId { get; init; }

		[JsonProperty("cost_free")]
		public decimal? CostFreeFrom { get; init; }

		[JsonProperty("cost_min")]
		public int CostMin { get; init; }

		[JsonProperty("delivery_starts_at")]
		public string? DeliveryStartsAt { get; init; }

		[JsonProperty("delivery_time_hint")]
		public string? DeliveryTimeHint { get; init; }

		[JsonProperty("is_default")]
		public bool IsDefault { get; init; }
	}

	[JsonProperty("data")]
	public DataDto? Data { get; init; }
}
