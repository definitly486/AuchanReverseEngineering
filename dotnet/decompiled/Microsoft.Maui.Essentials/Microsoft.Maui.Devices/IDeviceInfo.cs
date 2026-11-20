namespace Microsoft.Maui.Devices;

public interface IDeviceInfo
{
	string Model { get; }

	string Manufacturer { get; }

	string VersionString { get; }

	DevicePlatform Platform { get; }
}
