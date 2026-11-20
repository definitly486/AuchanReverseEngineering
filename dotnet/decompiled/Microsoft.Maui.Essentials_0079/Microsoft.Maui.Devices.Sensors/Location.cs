using System;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Media;

namespace Microsoft.Maui.Devices.Sensors;

public class Location
{
	[CompilerGenerated]
	private bool _003CReducedAccuracy_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFromMockProvider_003Ek__BackingField;

	[CompilerGenerated]
	private AltitudeReferenceSystem _003CAltitudeReferenceSystem_003Ek__BackingField;

	public DateTimeOffset Timestamp { get; set; }

	public double Latitude { get; set; }

	public double Longitude { get; set; }

	public double? Altitude { get; set; }

	public double? Accuracy { get; set; }

	public double? VerticalAccuracy { get; set; }

	public bool ReducedAccuracy
	{
		[CompilerGenerated]
		set
		{
			_003CReducedAccuracy_003Ek__BackingField = value;
		}
	}

	public double? Speed { get; set; }

	public double? Course { get; set; }

	public bool IsFromMockProvider
	{
		[CompilerGenerated]
		set
		{
			_003CIsFromMockProvider_003Ek__BackingField = value;
		}
	}

	public AltitudeReferenceSystem AltitudeReferenceSystem
	{
		[CompilerGenerated]
		set
		{
			_003CAltitudeReferenceSystem_003Ek__BackingField = value;
		}
	}

	public Location()
	{
	}

	public Location(double latitude, double longitude)
		: this(latitude, longitude, DateTimeOffset.UtcNow)
	{
	}

	public Location(double latitude, double longitude, DateTimeOffset timestamp)
	{
		if (Math.Abs(latitude) > 90.0)
		{
			throw new ArgumentOutOfRangeException("latitude");
		}
		Latitude = latitude;
		if (Math.Abs(longitude) > 180.0)
		{
			throw new ArgumentOutOfRangeException("longitude");
		}
		Longitude = longitude;
		Timestamp = timestamp;
	}

	public static double CalculateDistance(Location locationStart, Location locationEnd, DistanceUnits units)
	{
		return CalculateDistance(locationStart.Latitude, locationStart.Longitude, locationEnd.Latitude, locationEnd.Longitude, units);
	}

	public static double CalculateDistance(double latitudeStart, double longitudeStart, double latitudeEnd, double longitudeEnd, DistanceUnits units)
	{
		return units switch
		{
			DistanceUnits.Kilometers => UnitConverters.CoordinatesToKilometers(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd), 
			DistanceUnits.Miles => UnitConverters.CoordinatesToMiles(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd), 
			_ => throw new ArgumentOutOfRangeException("units"), 
		};
	}

	public override string ToString()
	{
		return $"{"Latitude"}: {Latitude}, {"Longitude"}: {Longitude}, {"Altitude"}: {Altitude}, {"Accuracy"}: {Accuracy}, {"VerticalAccuracy"}: {VerticalAccuracy}, {"Speed"}: {Speed}, {"Course"}: {Course}, {"Timestamp"}: {Timestamp}";
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		Location location = (Location)obj;
		if (Latitude == location.Latitude)
		{
			return Longitude == location.Longitude;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = Latitude.GetHashCode();
		return (hashCode * 397) ^ Longitude.GetHashCode();
	}

	public static bool operator ==(Location left, Location right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Location left, Location right)
	{
		return !object.Equals(left, right);
	}
}
