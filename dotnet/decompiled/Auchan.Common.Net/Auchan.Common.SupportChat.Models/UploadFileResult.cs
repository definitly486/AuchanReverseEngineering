using System.IO;
using Auchan.Common.SupportChat.DTO;

namespace Auchan.Common.SupportChat.Models;

public sealed class UploadFileResult
{
	public int NumberOfDownloads { get; }

	public string RealPath { get; }

	public string DownloadLink { get; }

	public long Size { get; }

	public string? ContentType { get; }

	public MessageType MessageType
	{
		get
		{
			string? contentType = ContentType;
			if (contentType != null && contentType.StartsWith("image/"))
			{
				return MessageType.Image;
			}
			return MessageType.File;
		}
	}

	public UploadFileResult(int numberOfDownloads, string realPath, string downloadLink, long size, string? contentType)
	{
		NumberOfDownloads = numberOfDownloads;
		RealPath = realPath;
		DownloadLink = downloadLink;
		Size = size;
		ContentType = contentType;
	}

	public static UploadFileResult Invalid()
	{
		return new UploadFileResult(-1, "", "", -1L, "");
	}

	public AttachmentDto ToAttachment()
	{
		string fileName = Path.GetFileName(RealPath);
		if (MessageType != MessageType.Image)
		{
			return new AttachmentDto(null, null, new FileDto(fileName, Size, DownloadLink));
		}
		return new AttachmentDto(DownloadLink, null, null);
	}

	public override string ToString()
	{
		return $"{"NumberOfDownloads"} {NumberOfDownloads}, {"RealPath"} {RealPath}, {"DownloadLink"} {DownloadLink}, {"Size"} {Size}, {"ContentType"} {ContentType}";
	}
}
