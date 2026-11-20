using System;
using Auchan.Common.NewYearGame.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.NewYearGame;

public static class NewYearGameMessageHelper
{
	public static string GetMessage(NewYearGameActionType type, string? sessionId = null)
	{
		if (type == NewYearGameActionType.UserData)
		{
			return JsonConvert.SerializeObject(new GameMessageWithDataDTO(NewYearGameActionType.UserData, new GameMessageDataDTO(sessionId ?? throw new ArgumentNullException(), "M")), Formatting.None);
		}
		return JsonConvert.SerializeObject(new GameMessageDTO(type), Formatting.None);
	}

	public static GameMessageDTO? GetDTO(string message)
	{
		try
		{
			return JsonConvert.DeserializeObject<GameMessageDTO>(message);
		}
		catch (JsonException)
		{
		}
		return null;
	}
}
