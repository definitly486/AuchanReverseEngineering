using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record AvailableShopsDto
{
	[JsonProperty("id")]
	public required int? Id { get; init; }

	[JsonProperty("name")]
	public required string? Name { get; init; }

	[JsonProperty("address_string")]
	public required string? AddressString { get; init; }

	[JsonProperty("applied", Required = Required.Always)]
	public required bool Applied { get; init; }

	[JsonProperty("qty")]
	public required decimal? Qty { get; init; }

	[JsonProperty("working")]
	public required string? Working { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AvailableShopsDto(AvailableShopsDto original)
	{
		Id = original.Id;
		Name = original.Name;
		AddressString = original.AddressString;
		Applied = original.Applied;
		Qty = original.Qty;
		Working = original.Working;
	}

	public AvailableShopsDto()
	{
	}
}
