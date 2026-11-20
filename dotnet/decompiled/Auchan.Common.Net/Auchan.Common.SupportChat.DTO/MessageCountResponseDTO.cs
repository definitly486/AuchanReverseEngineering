using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class MessageCountResponseDTO
{
	public sealed class DataDto
	{
		[JsonProperty("countMsg")]
		public int MessageCount { get; set; }
	}

	[JsonProperty("data")]
	public DataDto Data { get; set; } = new DataDto();
}
