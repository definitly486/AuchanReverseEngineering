using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class GameConfigDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("game_enabled")]
	public bool GameEnabled { get; set; }

	[JsonProperty("begins_on")]
	public DateTime BeginsOn { get; set; }

	[JsonProperty("ends_on")]
	public DateTime EndsOn { get; set; }

	[JsonProperty("url")]
	public string Url { get; set; }

	[JsonProperty("animations")]
	public List<GameAnimationDto> Animations { get; set; }

	[JsonProperty("play_button_text")]
	public string ButtonText { get; set; }

	[JsonProperty("popup_text")]
	public string PopupText { get; set; }
}
