using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record SelectedModificationDto
{
	[JsonProperty("code")]
	public required string Code { get; init; }

	[JsonProperty("value")]
	public required string Value { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SelectedModificationDto(SelectedModificationDto original)
	{
		Code = original.Code;
		Value = original.Value;
	}

	public SelectedModificationDto()
	{
	}
}
