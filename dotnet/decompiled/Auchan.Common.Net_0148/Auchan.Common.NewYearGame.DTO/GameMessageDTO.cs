using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.NewYearGame.DTO;

public class GameMessageDTO
{
	[JsonProperty("action")]
	[JsonConverter(typeof(EnumMemberJsonConverter<NewYearGameActionType>))]
	public NewYearGameActionType Type { get; set; }

	[JsonProperty("text")]
	public string? ClipboardContent { get; set; }

	public GameMessageDTO(NewYearGameActionType type, string? clipboardContent = null)
	{
		Type = type;
		ClipboardContent = clipboardContent;
	}
}
