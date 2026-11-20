namespace Microsoft.Maui.Devices;

public static class DeviceDisplay
{
	private static IDeviceDisplay? currentImplementation;

	public static DisplayInfo MainDisplayInfo => Current.MainDisplayInfo;

	public static IDeviceDisplay Current => currentImplementation ?? (currentImplementation = new DeviceDisplayImplementation());
}
