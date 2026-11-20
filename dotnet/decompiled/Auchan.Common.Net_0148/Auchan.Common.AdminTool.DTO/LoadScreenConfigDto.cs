using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class LoadScreenConfigDto
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("load_screen_animation")]
	public string LoadScreenAnimationUrl { get; set; }
}
