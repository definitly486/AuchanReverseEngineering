using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class Data
{
	[JsonProperty("is_have_opened_chat")]
	public bool IsOpened { get; set; }
}
