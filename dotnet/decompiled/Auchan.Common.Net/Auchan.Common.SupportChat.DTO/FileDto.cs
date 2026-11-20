using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class FileDto
{
	[JsonProperty("name")]
	public string Name { get; }

	[JsonProperty("size")]
	public long Size { get; }

	[JsonProperty("url")]
	public string Url { get; }

	public FileDto(string name, long size, string url)
	{
		Name = name;
		Size = size;
		Url = url;
	}
}
