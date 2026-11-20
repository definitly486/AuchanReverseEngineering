using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record SummaryDto
{
	[JsonProperty("total_weight", Required = Required.Always)]
	public required decimal TotalWeight { get; init; }

	[JsonProperty("items_count", Required = Required.Always)]
	public required decimal ItemsCount { get; init; }

	[JsonProperty("basket_cost", Required = Required.Always)]
	public required decimal BasketCost { get; init; }

	[JsonProperty("adult_basket_cost")]
	public required decimal? AdultBasketCost { get; init; }

	[JsonProperty("non_adult_basket_cost")]
	public required decimal NonAdultBasketCost { get; init; }

	[JsonProperty("basket_price", Required = Required.Always)]
	public required decimal BasketPrice { get; init; }

	[JsonProperty("total_delivery_price", Required = Required.Always)]
	public required decimal TotalDeliveryPrice { get; init; }

	[JsonProperty("delivery_tariff")]
	public required CheckoutDataResponseDto.DeliveryTariffDto? DeliveryTariff { get; init; }

	[JsonProperty("total_price", Required = Required.Always)]
	public required decimal TotalPrice { get; init; }

	[JsonProperty("promocode_discount")]
	public required decimal? PromocodeDiscount { get; init; }

	[JsonProperty("used_points")]
	public required decimal? UsedPoints { get; init; }

	[JsonProperty("economy")]
	public required decimal? Economy { get; init; }

	[JsonProperty("used_stamps")]
	public required decimal? UsedStamps { get; init; }

	[JsonProperty("picking_price")]
	public required decimal? PickingPrice { get; init; }

	[JsonProperty("surge_amount")]
	public required decimal? SurgeAmount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SummaryDto(SummaryDto original)
	{
		TotalWeight = original.TotalWeight;
		ItemsCount = original.ItemsCount;
		BasketCost = original.BasketCost;
		AdultBasketCost = original.AdultBasketCost;
		NonAdultBasketCost = original.NonAdultBasketCost;
		BasketPrice = original.BasketPrice;
		TotalDeliveryPrice = original.TotalDeliveryPrice;
		DeliveryTariff = original.DeliveryTariff;
		TotalPrice = original.TotalPrice;
		PromocodeDiscount = original.PromocodeDiscount;
		UsedPoints = original.UsedPoints;
		Economy = original.Economy;
		UsedStamps = original.UsedStamps;
		PickingPrice = original.PickingPrice;
		SurgeAmount = original.SurgeAmount;
	}

	public SummaryDto()
	{
	}
}
