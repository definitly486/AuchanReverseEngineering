using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class AttachmentDto
{
	[JsonProperty("image")]
	public string? ImageUrl { get; }

	[JsonProperty("location")]
	public LocationDto? Location { get; }

	[JsonProperty("file")]
	public FileDto? File { get; }

	public AttachmentDto(string? imageUrl, LocationDto? location, FileDto? file)
	{
		ImageUrl = imageUrl;
		Location = location;
		File = file;
	}
}
