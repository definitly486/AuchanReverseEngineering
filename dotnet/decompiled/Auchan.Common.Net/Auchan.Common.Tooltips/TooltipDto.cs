using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Tooltips;

public class TooltipDto
{
	[JsonProperty("priority")]
	public int Priority { get; set; }

	[JsonProperty("show_count")]
	public int ShowCount { get; set; }

	[JsonProperty("target")]
	[JsonConverter(typeof(EnumMemberJsonConverter<TooltipTargetType>))]
	public TooltipTargetType Target { get; set; }

	[JsonProperty("title")]
	public string Title { get; set; } = "";

	[JsonProperty("title_icon")]
	[JsonConverter(typeof(EnumMemberJsonConverter<TooltipTitleIconType>))]
	public TooltipTitleIconType TitleIcon { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; } = "";

	[JsonProperty("audience")]
	[JsonConverter(typeof(EnumMemberJsonConverter<AudienceType>))]
	public AudienceType Audience { get; set; }
}
