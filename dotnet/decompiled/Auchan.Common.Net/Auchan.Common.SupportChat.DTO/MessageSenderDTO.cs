using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class MessageSenderDTO
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("avatar")]
	public string Avatar { get; set; } = string.Empty;

	public MessageSenderDTO(string id, string name)
	{
		Id = id;
		Name = name;
	}
}
