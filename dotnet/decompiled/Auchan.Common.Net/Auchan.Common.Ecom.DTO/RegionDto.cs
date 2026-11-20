using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record RegionDto
{
	[JsonProperty("id", Required = Required.Always)]
	public required long Id { get; init; }

	[JsonProperty("name", Required = Required.Always)]
	public required string Name { get; init; }

	[JsonProperty("fias_id", Required = Required.Always)]
	public required Guid FiasId { get; init; }

	[JsonProperty("type", Required = Required.Always)]
	public required string Type { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RegionDto(RegionDto original)
	{
		Id = original.Id;
		Name = original.Name;
		FiasId = original.FiasId;
		Type = original.Type;
	}

	public RegionDto()
	{
	}
}
