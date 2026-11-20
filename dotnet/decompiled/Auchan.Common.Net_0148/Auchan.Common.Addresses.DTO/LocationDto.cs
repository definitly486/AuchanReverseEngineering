using Newtonsoft.Json;

namespace Auchan.Common.Addresses.DTO;

public class LocationDto
{
	[JsonProperty("region_fias_id")]
	public string RegionFias { get; set; }

	public LocationDto(string regionFias)
	{
		RegionFias = regionFias;
	}
}
