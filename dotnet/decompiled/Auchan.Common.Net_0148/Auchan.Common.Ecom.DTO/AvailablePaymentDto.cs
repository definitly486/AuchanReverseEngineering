using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record AvailablePaymentDto
{
	[JsonProperty("code", Required = Required.Always)]
	public required CheckoutDataResponseDto.PaymentCodeDto Code { get; init; }

	[JsonProperty("is_available", Required = Required.Always)]
	public required bool IsAvailable { get; init; }

	[JsonProperty("items_count", Required = Required.Always)]
	public required int ItemsCount { get; init; }

	[JsonProperty("sum", Required = Required.Always)]
	public required decimal Sum { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AvailablePaymentDto(AvailablePaymentDto original)
	{
		Code = original.Code;
		IsAvailable = original.IsAvailable;
		ItemsCount = original.ItemsCount;
		Sum = original.Sum;
	}

	public AvailablePaymentDto()
	{
	}
}
