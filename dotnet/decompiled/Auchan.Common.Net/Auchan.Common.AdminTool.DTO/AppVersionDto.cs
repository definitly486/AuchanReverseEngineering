using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class AppVersionDto
{
	[JsonProperty("current")]
	public string Current { get; set; }

	[JsonProperty("new")]
	public string New { get; set; }

	[JsonProperty("update_id")]
	public string UpdateId { get; set; }

	[JsonProperty("banner_message")]
	public string BannerMessage { get; set; }

	[JsonProperty("title")]
	public string PopupTitle { get; set; }

	[JsonProperty("message")]
	public string PopupMessage { get; set; }

	[JsonProperty("notification")]
	public bool IsPopupAutoFirstShown { get; set; }
}
