using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class LocationDto
{
	[JsonProperty("lat")]
	public string Latitude { get; }

	[JsonProperty("lng")]
	public string Longitude { get; }

	public LocationDto(string latitude, string longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}
}
