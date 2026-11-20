using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public record Money
{
	[JsonProperty("value", Required = Required.Always)]
	public required decimal Value { get; init; }

	[JsonProperty("currency", Required = Required.Always)]
	public required string Currency { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected Money(Money original)
	{
		Value = original.Value;
		Currency = original.Currency;
	}

	public Money()
	{
	}
}
