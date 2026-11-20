using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CategoriesPreviewDto
{
	[JsonProperty("subCategories")]
	public List<CategoriesPreviewItemDto> SubCategories { get; set; }
}
