using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CategoriesPreviewItemDto
{
	[JsonProperty("category")]
	public CategoryDto Category { get; set; }
}
