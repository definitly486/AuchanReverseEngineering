using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record ProgressDiscountDto
{
	[JsonProperty("value")]
	public required double Value { get; init; }

	[JsonProperty("quantity")]
	public required double Quantity { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProgressDiscountDto(ProgressDiscountDto original)
	{
		Value = original.Value;
		Quantity = original.Quantity;
	}

	public ProgressDiscountDto()
	{
	}
}
