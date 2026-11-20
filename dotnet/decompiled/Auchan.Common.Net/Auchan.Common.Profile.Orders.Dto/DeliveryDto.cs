using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record DeliveryDto
{
	[JsonProperty("delivery_date")]
	public DateTimeOffset DeliveryDate { get; init; }

	[JsonProperty("delivery_time")]
	public string? DeliveryTime { get; init; }

	[JsonProperty("delivery_to_time")]
	public string? DeliveryToTime { get; init; }

	[JsonProperty("delivery_address")]
	public DeliveryAddressDto? AddressInfo { get; init; }

	[JsonProperty("delivery_method")]
	public DeliveryMethod DeliveryMethod { get; init; }

	[JsonProperty("courier_phone_number")]
	public string? CourierPhoneNumber { get; init; }

	[JsonProperty("products")]
	public required IReadOnlyList<ProductDto> Products { get; init; } = Array.Empty<ProductDto>();

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DeliveryDto(DeliveryDto original)
	{
		DeliveryDate = original.DeliveryDate;
		DeliveryTime = original.DeliveryTime;
		DeliveryToTime = original.DeliveryToTime;
		AddressInfo = original.AddressInfo;
		DeliveryMethod = original.DeliveryMethod;
		CourierPhoneNumber = original.CourierPhoneNumber;
		Products = original.Products;
	}

	public DeliveryDto()
	{
	}
}
