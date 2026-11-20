using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class BrandResponseDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("categories")]
	public List<CategoryDto>? Categories { get; set; }
}
