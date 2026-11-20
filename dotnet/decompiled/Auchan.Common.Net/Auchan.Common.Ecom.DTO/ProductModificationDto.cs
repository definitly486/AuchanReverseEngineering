using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.Products.Modifications;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record ProductModificationDto
{
	[JsonProperty("code")]
	public required string Code { get; init; } = string.Empty;

	[JsonProperty("name")]
	public required string Name { get; init; } = string.Empty;

	[JsonProperty("view_type")]
	public required ModificationValueType ViewType { get; init; } = ModificationValueType.Enum;

	[JsonProperty("values")]
	public IReadOnlyList<ProductModificationValueDto> Values { get; init; } = Array.Empty<ProductModificationValueDto>();

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductModificationDto(ProductModificationDto original)
	{
		Code = original.Code;
		Name = original.Name;
		ViewType = original.ViewType;
		Values = original.Values;
	}

	public ProductModificationDto()
	{
	}
}
