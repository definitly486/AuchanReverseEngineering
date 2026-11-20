using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class SectionDto
{
	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("visible")]
	public bool Visible { get; set; }

	[JsonProperty("text")]
	public string Name { get; set; } = string.Empty;
}
