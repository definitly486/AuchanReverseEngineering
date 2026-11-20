using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class UploadFileResultDTO
{
	[JsonProperty("numberOfDownloads")]
	public int NumberOfDownloads { get; set; }

	[JsonProperty("realPath")]
	public string? RealPath { get; set; }

	[JsonProperty("downloadLink")]
	public string? DownloadLink { get; set; }

	[JsonProperty("size")]
	public long Size { get; set; }

	[JsonProperty("contentType")]
	public string? ContentType { get; set; }
}
