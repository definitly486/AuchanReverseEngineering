using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record RegionBundleDto
{
	public sealed record CoordinateDto
	{
		[JsonProperty("lon")]
		public string? Longitude { get; init; }

		[JsonProperty("lat")]
		public string? Latitude { get; init; }
	}

	[JsonProperty("id", Required = Required.Always)]
	public required long Id { get; init; }

	[JsonProperty("name", Required = Required.Always)]
	public required string Name { get; init; }

	[JsonProperty("fias_id", Required = Required.Always)]
	public required Guid FiasId { get; init; }

	[JsonProperty("default", Required = Required.Always)]
	public required bool Default { get; init; }

	[JsonProperty("fias", Required = Required.Default)]
	public required IReadOnlyList<RegionDto>? childRegions { get; init; }

	[JsonProperty("in_loyalty")]
	public required bool InLoyalty { get; init; }

	[JsonProperty("ll")]
	public required CoordinateDto? RegionCoordinate { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RegionBundleDto(RegionBundleDto original)
	{
		Id = original.Id;
		Name = original.Name;
		FiasId = original.FiasId;
		Default = original.Default;
		childRegions = original.childRegions;
		InLoyalty = original.InLoyalty;
		RegionCoordinate = original.RegionCoordinate;
	}

	public RegionBundleDto()
	{
	}
}
