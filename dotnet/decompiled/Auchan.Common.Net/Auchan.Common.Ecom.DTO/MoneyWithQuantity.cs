using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record MoneyWithQuantity : Money
{
	[JsonProperty("items_count")]
	public required int Quntity { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private MoneyWithQuantity(MoneyWithQuantity original)
		: base(original)
	{
		Quntity = original.Quntity;
	}

	public MoneyWithQuantity()
	{
	}
}
