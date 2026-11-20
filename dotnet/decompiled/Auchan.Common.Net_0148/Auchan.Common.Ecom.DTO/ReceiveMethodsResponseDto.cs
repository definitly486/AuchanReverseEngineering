using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.AddressStoreSelection;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ReceiveMethodsResponseDto
{
	public sealed class Content
	{
		[JsonProperty("current_region_id")]
		public int? CurrentRegionId { get; init; }

		[JsonProperty("current_merchant_id")]
		public int? CurrentMerchantId { get; init; }

		[JsonProperty("current_address")]
		public SavedAddressDto? CurrentAddress { get; init; }

		[JsonProperty("current_pickup_shop")]
		public PickupShopDto? CurrentPickupShop { get; init; }

		[JsonProperty("current_car_pickup_shop")]
		public PickupShopDto? CurrentCarPickupShop { get; init; }

		[JsonProperty("current_delivery_method")]
		public ReceivingMethod? CurrentDeliveryMethod { get; init; }

		[JsonProperty("addresses")]
		public IReadOnlyList<SavedAddressDto> Addresses { get; init; } = Array.Empty<SavedAddressDto>();

		[JsonProperty("pickup_shops")]
		public IReadOnlyList<PickupShopDto> PickupShops { get; init; } = Array.Empty<PickupShopDto>();

		[JsonProperty("car_pickup_shops")]
		public IReadOnlyList<PickupShopDto> CarPickupShops { get; init; } = Array.Empty<PickupShopDto>();
	}

	[JsonProperty("data")]
	public Content? Data { get; init; }
}
