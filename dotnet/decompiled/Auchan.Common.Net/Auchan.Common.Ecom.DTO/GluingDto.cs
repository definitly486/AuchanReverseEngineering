using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class GluingDto
{
	[JsonProperty("id")]
	public int Id { get; init; }

	[JsonProperty("code")]
	public string Code { get; init; } = "";

	[JsonProperty("props")]
	public IReadOnlyList<GluingPropDto> Properties { get; init; } = Array.Empty<GluingPropDto>();
}
