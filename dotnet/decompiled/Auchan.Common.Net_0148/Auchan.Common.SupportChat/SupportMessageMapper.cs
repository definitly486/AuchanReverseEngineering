using System;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat;

public static class SupportMessageMapper
{
	private const long INVALID_UPLOAD_RESULT_SIZE = -1L;

	public static CacheMessage ToModel(this CacheMessageDTO dto)
	{
		return new CacheMessage
		{
			Id = dto.Id,
			Status = dto.Status,
			Type = dto.Type,
			DataContentType = dto.DataContentType,
			SendTime = new DateTime(dto.SendTime.Year, dto.SendTime.Month, dto.SendTime.Day, dto.SendTime.Hour, dto.SendTime.Minute, dto.SendTime.Second, DateTimeKind.Utc).ToLocalTime(),
			Text = dto.Text,
			UploadFileResult = ((dto.Size == -1) ? null : new UploadFileResult(0, dto.FileName, dto.AttachmentUrl, dto.Size, dto.AttachmentContentType)),
			OperatorIconUrl = dto.OperatorIconUrl,
			SenderName = dto.OperatorName,
			SequenceNumber = dto.SequenceNumber
		};
	}

	public static CacheMessageDTO ToDTO(this CacheMessage message)
	{
		return new CacheMessageDTO
		{
			Type = message.Type,
			DataContentType = message.DataContentType,
			Id = message.Id,
			Status = message.Status,
			Text = message.Text,
			SendTime = message.SendTime.ToUniversalTime(),
			AttachmentUrl = message.UploadFileResult?.DownloadLink,
			AttachmentContentType = message.UploadFileResult?.ContentType,
			FileName = message.UploadFileResult?.RealPath,
			Size = (message.UploadFileResult?.Size ?? (-1)),
			OperatorIconUrl = message.OperatorIconUrl,
			OperatorName = message.SenderName,
			SequenceNumber = message.SequenceNumber
		};
	}

	public static MessageDTO ToMessageDTO(this CacheMessage cacheMessage, string cmdId)
	{
		return new MessageDTO(cacheMessage.Id, cacheMessage.SenderName ?? string.Empty, cacheMessage.Text, cmdId, cacheMessage.UploadFileResult?.MessageType ?? MessageType.Text, cacheMessage.UploadFileResult);
	}
}
