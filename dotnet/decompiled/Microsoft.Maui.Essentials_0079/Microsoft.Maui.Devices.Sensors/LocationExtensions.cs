using System;
using Android.Locations;

namespace Microsoft.Maui.Devices.Sensors;

public static class LocationExtensions
{
	private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	internal static Location ToLocation(this global::Android.Locations.Location location)
	{
		return new Location
		{
			Latitude = location.Latitude,
			Longitude = location.Longitude,
			Altitude = (location.HasAltitude ? new double?(location.Altitude) : ((double?)null)),
			Timestamp = location.GetTimestamp().ToUniversalTime(),
			Accuracy = (location.HasAccuracy ? new float?(location.Accuracy) : ((float?)null)),
			VerticalAccuracy = ((OperatingSystem.IsAndroidVersionAtLeast(26) && location.HasVerticalAccuracy) ? new double?(location.VerticalAccuracyMeters) : ((double?)null)),
			ReducedAccuracy = false,
			Course = (location.HasBearing ? new double?(location.Bearing) : ((double?)null)),
			Speed = (location.HasSpeed ? new double?(location.Speed) : ((double?)null)),
			IsFromMockProvider = (OperatingSystem.IsAndroidVersionAtLeast(31) ? location.Mock : location.IsFromMockProvider),
			AltitudeReferenceSystem = AltitudeReferenceSystem.Ellipsoid
		};
	}

	internal static DateTimeOffset GetTimestamp(this global::Android.Locations.Location location)
	{
		try
		{
			return new DateTimeOffset(epoch.AddMilliseconds(location.Time));
		}
		catch (Exception)
		{
			return new DateTimeOffset(epoch);
		}
	}
}
