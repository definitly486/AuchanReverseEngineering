using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record Tag
{
	[JsonProperty("id", Required = Required.Always)]
	public required long Id { get; init; }

	[JsonProperty("name", Required = Required.Always)]
	public required string Name { get; init; }

	[JsonProperty("sort", Required = Required.Always)]
	public required int Sort { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Tag(Tag original)
	{
		Id = original.Id;
		Name = original.Name;
		Sort = original.Sort;
	}

	public Tag()
	{
	}
}
