using Newtonsoft.Json;

namespace Auchan.Common.InfoPages.DTO;

public class TutorialDto
{
	[JsonProperty("show_type", Required = Required.Always)]
	public TutorialContentType ContentType { get; set; }

	[JsonProperty("name", Required = Required.Always)]
	public string Title { get; set; }

	[JsonProperty("description", Required = Required.Default)]
	public string Description { get; set; } = "";

	[JsonProperty("url", Required = Required.Default)]
	public string Url { get; set; } = "";

	[JsonProperty("bannerUrl", Required = Required.Default)]
	public string? BannerUrl { get; set; }
}
