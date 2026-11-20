using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record AddtionErrorDto
{
	public enum ErrorCodeDto
	{
		Unknown,
		[EnumMember(Value = "invalid_shipment_state")]
		InvalidShipmentState,
		[EnumMember(Value = "order_not_editable")]
		OrderIsNotEditable,
		[EnumMember(Value = "sku_not_found")]
		SkuNotFound,
		[EnumMember(Value = "no_available_items")]
		NoAvailableItems,
		[EnumMember(Value = "items_count_balance_reached")]
		TooManyItems,
		[EnumMember(Value = "too_heavy")]
		TooHeavy
	}

	[JsonProperty("code")]
	[JsonConverter(typeof(EnumMemberJsonConverter<ErrorCodeDto>))]
	public required ErrorCodeDto Code { get; init; }

	[JsonProperty("message")]
	public required string Message { get; init; }

	[JsonProperty("details")]
	public string? Details { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AddtionErrorDto(AddtionErrorDto original)
	{
		Code = original.Code;
		Message = original.Message;
		Details = original.Details;
	}

	public AddtionErrorDto()
	{
	}
}
