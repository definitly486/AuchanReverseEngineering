namespace Microsoft.Maui.Devices;

internal abstract class DeviceDisplayImplementationBase : IDeviceDisplay
{
	public DisplayInfo MainDisplayInfo => GetMainDisplayInfo();

	protected abstract DisplayInfo GetMainDisplayInfo();
}
