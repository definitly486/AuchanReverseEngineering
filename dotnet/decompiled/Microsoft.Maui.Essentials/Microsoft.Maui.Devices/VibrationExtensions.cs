using System;

namespace Microsoft.Maui.Devices;

public static class VibrationExtensions
{
	public static void Vibrate(this IVibration vibration, double duration)
	{
		vibration.Vibrate(TimeSpan.FromMilliseconds(duration));
	}
}
