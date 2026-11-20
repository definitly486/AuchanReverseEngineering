using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ProductRequestDto
{
	[JsonProperty("filter")]
	public IReadOnlyDictionary<string, object> Filters { get; }

	public ProductRequestDto(IReadOnlyDictionary<string, object> filters)
	{
		Filters = filters;
	}
}
