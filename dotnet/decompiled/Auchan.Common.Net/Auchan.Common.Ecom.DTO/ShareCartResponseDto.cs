using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ShareCartResponseDto
{
	public sealed class DataDto
	{
		[JsonProperty("token", Required = Required.Always)]
		public required string Token { get; init; }

		[JsonProperty("title_url", Required = Required.Always)]
		public required string Title { get; init; }
	}

	[JsonProperty("data", Required = Required.Always)]
	public required DataDto Data { get; init; }
}
