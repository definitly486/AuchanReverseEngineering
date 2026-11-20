using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Addresses;

public sealed record Coordinate
{
	public float Lat { get; }

	public float Lon { get; }

	public Coordinate(float lat, float lon)
	{
		Lat = lat;
		Lon = lon;
	}

	public static Coordinate? Parse(string? latitude, string? longitude)
	{
		CultureInfo provider = ((latitude != null && latitude.Contains(",") && longitude != null && longitude.Contains(",")) ? CultureInfo.CurrentCulture : CultureInfo.InvariantCulture);
		if (!float.TryParse(latitude, NumberStyles.Float, provider, out var result) || !float.TryParse(longitude, NumberStyles.Float, provider, out var result2))
		{
			return null;
		}
		return new Coordinate(result, result2);
	}

	[return: NotNullIfNotNull("location")]
	public static implicit operator Coordinate?(Location? location)
	{
		if (location != null)
		{
			return new Coordinate(Convert.ToSingle(location.Latitude), Convert.ToSingle(location.Longitude));
		}
		return null;
	}
}
