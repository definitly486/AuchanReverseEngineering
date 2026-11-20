using Newtonsoft.Json;

namespace Auchan.Common.NewYearGame.DTO;

public class GameMessageWithDataDTO : GameMessageDTO
{
	[JsonProperty("data", Required = Required.Default)]
	public GameMessageDataDTO Data { get; set; }

	public GameMessageWithDataDTO(NewYearGameActionType type, GameMessageDataDTO data)
		: base(type)
	{
		Data = data;
	}
}
