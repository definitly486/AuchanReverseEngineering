using Android.OS;

namespace Microsoft.Maui.Devices;

internal class DeviceInfoImplementation : IDeviceInfo
{
	public string Model => Build.Model;

	public string Manufacturer => Build.Manufacturer;

	public string VersionString => Build.VERSION.Release;

	public DevicePlatform Platform => DevicePlatform.Android;
}
