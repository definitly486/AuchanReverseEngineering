using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ShopDeliveryDto
{
	[JsonProperty("delivery_time_start")]
	public string? DeliveryTimeStart { get; set; }

	[JsonProperty("distance")]
	public long? Distance { get; set; }

	[JsonProperty("weight_max")]
	public int? WeightMax { get; set; }

	[JsonProperty("time_work", Required = Required.Always)]
	public string TimeWork { get; set; }

	[JsonProperty("standart_weight")]
	public decimal? StandardWeight { get; set; }

	[JsonProperty("overprice")]
	public decimal? OverweightPricePerKilo { get; set; }

	[JsonProperty("delivery_tariff")]
	public IReadOnlyList<ShopDeliveryTariffDto> Tariffs { get; init; } = Array.Empty<ShopDeliveryTariffDto>();
}
