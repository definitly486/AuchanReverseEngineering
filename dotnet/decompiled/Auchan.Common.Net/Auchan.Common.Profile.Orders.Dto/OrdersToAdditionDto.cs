using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

internal sealed record OrdersToAdditionDto
{
	internal sealed record OrdersDto
	{
		[JsonProperty("orders")]
		public required IReadOnlyList<OrderDto> Orders { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private OrdersDto(OrdersDto original)
		{
			Orders = original.Orders;
		}

		public OrdersDto()
		{
		}
	}

	internal sealed record OrderDto
	{
		[JsonProperty("id")]
		public required long Id { get; init; }

		[JsonProperty("number")]
		public required string Number { get; init; }

		[JsonProperty("price")]
		public required decimal Price { get; init; }

		[JsonProperty("delivery_price")]
		public required decimal DeliveryPrice { get; init; }

		[JsonProperty("picking_price")]
		public required decimal PickingPrice { get; init; }

		[JsonProperty("deliveries")]
		public required IReadOnlyList<DeliveryDto> Deliveries { get; init; }

		[JsonProperty("shop_name")]
		public required string ShopName { get; init; }

		[JsonProperty("editable_till")]
		public required DateTimeOffset EditableTill { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private OrderDto(OrderDto original)
		{
			Id = original.Id;
			Number = original.Number;
			Price = original.Price;
			DeliveryPrice = original.DeliveryPrice;
			PickingPrice = original.PickingPrice;
			Deliveries = original.Deliveries;
			ShopName = original.ShopName;
			EditableTill = original.EditableTill;
		}

		public OrderDto()
		{
		}
	}

	[JsonProperty("data")]
	public required OrdersDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OrdersToAdditionDto(OrdersToAdditionDto original)
	{
		Data = original.Data;
	}

	public OrdersToAdditionDto()
	{
	}
}
