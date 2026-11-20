using System;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class TestReceiveMessageDTO
{
	[JsonProperty("cmd_id")]
	public string Id { get; set; } = Guid.NewGuid().ToString();

	[JsonProperty("message")]
	public WSDataDTO Message { get; set; }

	[JsonProperty("queue")]
	public bool UseQueue { get; set; }

	public TestReceiveMessageDTO(WSDataDTO message)
	{
		Message = message;
	}
}
