using System;

namespace Microsoft.Maui.Media;

public static class UnitConverters
{
	public static double KilometersToMiles(double kilometers)
	{
		return kilometers * 0.621371192237334;
	}

	public static double DegreesToRadians(double degrees)
	{
		return degrees * (Math.PI / 180.0);
	}

	public static double CoordinatesToMiles(double lat1, double lon1, double lat2, double lon2)
	{
		return KilometersToMiles(CoordinatesToKilometers(lat1, lon1, lat2, lon2));
	}

	public static double CoordinatesToKilometers(double lat1, double lon1, double lat2, double lon2)
	{
		if (lat1 == lat2 && lon1 == lon2)
		{
			return 0.0;
		}
		double num = DegreesToRadians(lat2 - lat1);
		double num2 = DegreesToRadians(lon2 - lon1);
		lat1 = DegreesToRadians(lat1);
		lat2 = DegreesToRadians(lat2);
		double num3 = Math.Sin(num / 2.0) * Math.Sin(num / 2.0);
		double num4 = Math.Sin(num2 / 2.0) * Math.Sin(num2 / 2.0);
		double d = num3 + num4 * Math.Cos(lat1) * Math.Cos(lat2);
		double num5 = 2.0 * Math.Asin(Math.Sqrt(d));
		return 6371.0 * num5;
	}
}
