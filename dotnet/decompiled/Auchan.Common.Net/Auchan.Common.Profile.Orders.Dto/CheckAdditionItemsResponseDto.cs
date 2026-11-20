using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

internal sealed record CheckAdditionItemsResponseDto : IAdditionErrorDto
{
	public sealed record DataDto
	{
		[JsonProperty("items")]
		public required IReadOnlyList<ItemDto> Items { get; init; }

		[JsonProperty("items_unavailable")]
		public required IReadOnlyList<ItemDto> UnavailableItems { get; init; }

		[JsonProperty("summary")]
		public required SummaryDto Summary { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Items = original.Items;
			UnavailableItems = original.UnavailableItems;
			Summary = original.Summary;
		}

		public DataDto()
		{
		}
	}

	public sealed record ItemDto
	{
		[JsonProperty("offer_id")]
		public required int OfferId { get; init; }

		[JsonProperty("code")]
		public required string Code { get; init; }

		[JsonProperty("product_id")]
		public required int ProductId { get; init; }

		[JsonProperty("gica_id")]
		public required int GimaId { get; init; }

		[JsonProperty("name")]
		public required string Name { get; init; }

		[JsonProperty("qty")]
		public required decimal Qty { get; init; }

		[JsonProperty("image_url")]
		public required string ImageUrl { get; init; }

		[JsonProperty("is_adult")]
		public required bool IsAdult { get; init; }

		[JsonProperty("cost")]
		public required PriceDto Cost { get; init; }

		[JsonProperty("price")]
		public required PriceDto Price { get; init; }

		[JsonProperty("price_per_one")]
		public required PriceDto PricePerOne { get; init; }

		[JsonProperty("basket_step")]
		public required decimal BasketStep { get; init; }

		[JsonProperty("constraints")]
		public required ConstraintDto? Constraints { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ItemDto(ItemDto original)
		{
			OfferId = original.OfferId;
			Code = original.Code;
			ProductId = original.ProductId;
			GimaId = original.GimaId;
			Name = original.Name;
			Qty = original.Qty;
			ImageUrl = original.ImageUrl;
			IsAdult = original.IsAdult;
			Cost = original.Cost;
			Price = original.Price;
			PricePerOne = original.PricePerOne;
			BasketStep = original.BasketStep;
			Constraints = original.Constraints;
		}

		public ItemDto()
		{
		}
	}

	public sealed record PriceDto
	{
		[JsonProperty("value")]
		public required decimal Value { get; init; }

		[JsonProperty("currency")]
		public required string Currency { get; init; }

		[JsonProperty("per")]
		[JsonConverter(typeof(EnumMemberJsonConverter<ProductUnitType>))]
		public required ProductUnitType UnitType { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private PriceDto(PriceDto original)
		{
			Value = original.Value;
			Currency = original.Currency;
			UnitType = original.UnitType;
		}

		public PriceDto()
		{
		}
	}

	public sealed record ConstraintDto
	{
		[JsonProperty("type")]
		[JsonConverter(typeof(EnumMemberJsonConverter<ConstraintTypeDto>))]
		public required ConstraintTypeDto Type { get; init; }

		[JsonProperty("message")]
		public string? Message { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ConstraintDto(ConstraintDto original)
		{
			Type = original.Type;
			Message = original.Message;
		}

		public ConstraintDto()
		{
		}
	}

	public enum ConstraintTypeDto
	{
		Unknown,
		[EnumMember(Value = "not_available_for_adult_products")]
		Adult,
		[EnumMember(Value = "price_mismatch")]
		PriceMismatch,
		[EnumMember(Value = "stock_limit_reached")]
		StockLimitReached
	}

	public sealed record SummaryDto
	{
		[JsonProperty("available_items_count")]
		public required int AvailableItemsCount { get; init; }

		[JsonProperty("order_number")]
		public required string OrderNumber { get; init; }

		[JsonProperty("order_addition_price")]
		public required decimal OrderAdditionPrice { get; init; }

		[JsonProperty("order_price")]
		public required decimal OrderPrice { get; init; }

		[JsonProperty("order_delivery_price")]
		public required decimal OrderDeliveryPrice { get; init; }

		[JsonProperty("order_picking_price")]
		public required decimal OrderPickingPrice { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private SummaryDto(SummaryDto original)
		{
			AvailableItemsCount = original.AvailableItemsCount;
			OrderNumber = original.OrderNumber;
			OrderAdditionPrice = original.OrderAdditionPrice;
			OrderPrice = original.OrderPrice;
			OrderDeliveryPrice = original.OrderDeliveryPrice;
			OrderPickingPrice = original.OrderPickingPrice;
		}

		public SummaryDto()
		{
		}
	}

	[JsonProperty("data")]
	public required DataDto? Data { get; init; }

	[JsonProperty("errors")]
	public required IReadOnlyList<AddtionErrorDto>? Errors { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckAdditionItemsResponseDto(CheckAdditionItemsResponseDto original)
	{
		Data = original.Data;
		Errors = original.Errors;
	}

	public CheckAdditionItemsResponseDto()
	{
	}
}
