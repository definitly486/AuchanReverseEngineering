using Auchan.Common.AdminTool.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.AdminTool.DTO;

public class GameAnimationDto
{
	[JsonProperty("animation_url")]
	public string AnimationUrl { get; set; }

	[JsonProperty("position")]
	[JsonConverter(typeof(StringEnumConverter))]
	public GameAnimationPosition Position { get; set; }

	[JsonProperty("priority")]
	public int Priority { get; set; }

	[JsonProperty("close_button_enabled")]
	public bool CloseButtonEnabled { get; set; }

	[JsonProperty("close_button_position")]
	public GameAnimationClosePosition ClosePosition { get; set; }

	[JsonProperty("close_button_horizontal_offset")]
	public int CloseButtonHorizontalOffset { get; set; }

	[JsonProperty("close_button_vertical_offset")]
	public int CloseButtonVerticalOffset { get; set; }

	[JsonProperty("close_button_image_url")]
	public string CloseButtonImageUrl { get; set; }

	[JsonProperty("close_animation_url")]
	public string CloseAnimationUrl { get; set; }
}
