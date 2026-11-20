using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record RecalculateResponseDto
{
	public sealed class DataDto
	{
		[JsonProperty("dates")]
		public required IReadOnlyList<CheckoutDataResponseDto.DateDto>? Dates { get; init; }

		[JsonProperty("min_slot_price")]
		public required decimal? MinSlotPrice { get; init; }

		[JsonProperty("additional_benefit")]
		public required AdditionalBenefitDto AdditionalBenefit { get; init; }

		[JsonProperty("summary")]
		public required SummaryDto Summary { get; init; }

		[JsonProperty("available_payments", Required = Required.Always)]
		public required IReadOnlyList<AvailablePaymentDto> AvailablePayments { get; init; }
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RecalculateResponseDto(RecalculateResponseDto original)
	{
		Data = original.Data;
	}

	public RecalculateResponseDto()
	{
	}
}
