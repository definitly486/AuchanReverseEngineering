using System;
using Auchan.Common.SupportChat.DTO;

namespace Auchan.Common.SupportChat.Models;

public class CacheMessage
{
	public CacheMessageType Type { get; set; }

	public WSDataContentType DataContentType { get; set; }

	public Guid Id { get; set; }

	public string Text { get; set; }

	public DateTime SendTime { get; set; }

	public MessageStatusType Status { get; set; }

	public UploadFileResult? UploadFileResult { get; set; }

	public string? SenderName { get; set; }

	public string? OperatorIconUrl { get; set; }

	public int? SequenceNumber { get; set; }

	public override string ToString()
	{
		return $"{"Type"} {Type}, {"Id"} {Id}, {"Text"} {Text}, {"SendTime"} {SendTime}, {"Status"} {Status}, {"UploadFileResult"} {UploadFileResult}, {"SenderName"} {SenderName}, {"OperatorIconUrl"} {OperatorIconUrl}";
	}
}
