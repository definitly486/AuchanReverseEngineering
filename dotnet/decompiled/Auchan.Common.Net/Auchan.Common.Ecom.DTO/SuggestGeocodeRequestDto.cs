using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Addresses;
using Auchan.Common.Ecom.Address.Models;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class SuggestGeocodeRequestDto
{
	[JsonProperty("fias_id", NullValueHandling = NullValueHandling.Ignore)]
	public string? FiasId { get; }

	[JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
	public string? Query { get; }

	[JsonProperty("address_string", NullValueHandling = NullValueHandling.Ignore)]
	public string? Address { get; }

	[JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
	public string? Uri { get; }

	[JsonProperty("geo_lat", NullValueHandling = NullValueHandling.Ignore)]
	public string? Latitude { get; }

	[JsonProperty("geo_lon", NullValueHandling = NullValueHandling.Ignore)]
	public string? Longitude { get; }

	public SuggestGeocodeRequestDto(City city, string query)
	{
		List<string> list = new List<string>();
		list.Add(city.FiasId);
		list.AddRange(city.ChildFiasIds.Where((string i) => i != city.FiasId));
		FiasId = string.Join(';', new _003C_003Ez__ReadOnlyList<string>(list));
		Query = query;
	}

	public SuggestGeocodeRequestDto(string address, Coordinate? coordinate, string? uri)
	{
		Address = address;
		Uri = uri;
		Latitude = coordinate?.Lat.ToString("G20");
		Longitude = coordinate?.Lon.ToString("G20");
	}

	public SuggestGeocodeRequestDto(Coordinate coordinate)
	{
		Latitude = coordinate.Lat.ToString("G20");
		Longitude = coordinate.Lon.ToString("G20");
	}
}
