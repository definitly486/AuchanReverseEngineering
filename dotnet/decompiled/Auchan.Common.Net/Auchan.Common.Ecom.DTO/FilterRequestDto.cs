using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class FilterRequestDto
{
	[JsonProperty("filters")]
	public IReadOnlyDictionary<string, object> Filters { get; }

	public FilterRequestDto(IReadOnlyDictionary<string, object> filters)
	{
		Filters = filters;
	}
}
