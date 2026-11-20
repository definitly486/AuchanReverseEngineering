using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

internal sealed record AddGoodsToOrderResposeDto : IAdditionErrorDto
{
	public sealed record DataDto
	{
		[JsonProperty("order_id")]
		public required long OrderId { get; init; }

		[JsonProperty("order_number")]
		public required string OrderNumber { get; init; }

		[JsonProperty("order_created_at")]
		public required DateTime OrderCreatedAt { get; init; }

		[JsonProperty("order_status_for_customer")]
		public required CustomerStatus Status { get; init; }

		[JsonProperty("order_price")]
		public required decimal OrderPrice { get; init; }

		[JsonProperty("order_addition_price")]
		public required decimal OrderAdditionPrice { get; init; }

		[JsonProperty("deliveries")]
		public required IReadOnlyList<DeliveryDto> Deliveries { get; init; }

		[JsonProperty("products")]
		public required IReadOnlyList<ProductDto> Products { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			OrderId = original.OrderId;
			OrderNumber = original.OrderNumber;
			OrderCreatedAt = original.OrderCreatedAt;
			Status = original.Status;
			OrderPrice = original.OrderPrice;
			OrderAdditionPrice = original.OrderAdditionPrice;
			Deliveries = original.Deliveries;
			Products = original.Products;
		}

		public DataDto()
		{
		}
	}

	public sealed record DeliveryDto
	{
		[JsonProperty("delivery_date")]
		public required DateTimeOffset DeliveryDate { get; init; }

		[JsonProperty("delivery_time")]
		public required string DeliveryTime { get; init; }

		[JsonProperty("delivery_method")]
		public required int DeliveryMethod { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DeliveryDto(DeliveryDto original)
		{
			DeliveryDate = original.DeliveryDate;
			DeliveryTime = original.DeliveryTime;
			DeliveryMethod = original.DeliveryMethod;
		}

		public DeliveryDto()
		{
		}
	}

	public sealed record ProductDto
	{
		[JsonProperty("product_id")]
		public required int Id { get; init; }

		[JsonProperty("product_name")]
		public required string Name { get; init; }

		[JsonProperty("image_url")]
		public required string ImageUrl { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ProductDto(ProductDto original)
		{
			Id = original.Id;
			Name = original.Name;
			ImageUrl = original.ImageUrl;
		}

		public ProductDto()
		{
		}
	}

	[JsonProperty("data")]
	public required DataDto? Data { get; init; }

	[JsonProperty("errors")]
	public required IReadOnlyList<AddtionErrorDto>? Errors { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AddGoodsToOrderResposeDto(AddGoodsToOrderResposeDto original)
	{
		Data = original.Data;
		Errors = original.Errors;
	}

	public AddGoodsToOrderResposeDto()
	{
	}
}
