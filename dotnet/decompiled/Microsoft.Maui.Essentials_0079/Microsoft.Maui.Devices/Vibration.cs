namespace Microsoft.Maui.Devices;

public static class Vibration
{
	private static IVibration? defaultImplementation;

	private static IVibration Current => Default;

	public static IVibration Default => defaultImplementation ?? (defaultImplementation = new VibrationImplementation());

	public static void Vibrate()
	{
		Current.Vibrate();
	}

	public static void Vibrate(double duration)
	{
		Current.Vibrate(duration);
	}
}
