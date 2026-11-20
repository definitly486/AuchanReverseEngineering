using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public class WSDataDTO
{
	[JsonProperty("out_seq", NullValueHandling = NullValueHandling.Ignore)]
	public int? OutSeq;

	[JsonProperty("channel_id")]
	public string ChannelId { get; set; }

	[JsonProperty("receiver_id")]
	public string ReceiverId { get; set; }

	[JsonProperty("type")]
	[JsonConverter(typeof(EnumMemberJsonConverter<WSDataContentType>))]
	public WSDataContentType Type { get; set; }

	[JsonProperty("content")]
	public WSDataContentDTO Content { get; set; } = new WSDataContentDTO();
}
