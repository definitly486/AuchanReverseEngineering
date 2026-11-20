using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.SupportChat.DTO;

public class CacheMessageDTO
{
	[JsonProperty("type")]
	[JsonConverter(typeof(StringEnumConverter))]
	public CacheMessageType Type { get; set; }

	[JsonProperty("dataContentType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public WSDataContentType DataContentType { get; set; }

	[JsonProperty("id")]
	public Guid Id { get; set; }

	[JsonProperty("message")]
	public string Text { get; set; } = "";

	[JsonProperty("sendTime")]
	public DateTime SendTime { get; set; }

	[JsonProperty("status")]
	[JsonConverter(typeof(StringEnumConverter))]
	public MessageStatusType Status { get; set; }

	[JsonProperty("fileName")]
	public string? FileName { get; set; }

	[JsonProperty("lat")]
	public string? Latitude { get; set; }

	[JsonProperty("lng")]
	public string? Longitude { get; set; }

	[JsonProperty("size")]
	public long Size { get; set; }

	[JsonProperty("attachmentUrl")]
	public string? AttachmentUrl { get; set; }

	[JsonProperty("sequenceNumber")]
	public int? SequenceNumber { get; set; }

	[JsonProperty("attachmentContentType")]
	public string? AttachmentContentType { get; set; }

	[JsonProperty("operatorIconUrl")]
	public string? OperatorIconUrl { get; set; }

	[JsonProperty("operatorName")]
	public string? OperatorName { get; set; }
}
