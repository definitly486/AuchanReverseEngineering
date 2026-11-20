using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class SectionVisibleDto
{
	[JsonProperty("sections")]
	public List<SectionDto> Sections { get; set; } = new List<SectionDto>();

	[JsonProperty("Collectible")]
	public CollectibleDto? Collectible { get; set; }
}
