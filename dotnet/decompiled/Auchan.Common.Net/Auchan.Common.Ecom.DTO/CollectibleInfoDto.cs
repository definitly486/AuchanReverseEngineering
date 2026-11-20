using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record CollectibleInfoDto
{
	[JsonProperty("stamp")]
	public required int Stamps { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CollectibleInfoDto(CollectibleInfoDto original)
	{
		Stamps = original.Stamps;
	}

	public CollectibleInfoDto()
	{
	}
}
