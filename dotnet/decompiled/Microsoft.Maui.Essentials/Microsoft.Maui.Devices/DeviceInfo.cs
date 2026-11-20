namespace Microsoft.Maui.Devices;

public static class DeviceInfo
{
	private static IDeviceInfo? currentImplementation;

	public static string Model => Current.Model;

	public static string Manufacturer => Current.Manufacturer;

	public static string VersionString => Current.VersionString;

	public static DevicePlatform Platform => Current.Platform;

	public static IDeviceInfo Current => currentImplementation ?? (currentImplementation = new DeviceInfoImplementation());
}
