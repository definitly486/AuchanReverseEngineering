using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;

namespace Auchan.Common.HardUpdate;

public static class ApplicationStoreHelper
{
	public static string GetStoreId()
	{
		DevicePlatform platform = DeviceInfo.Platform;
		if (platform == DevicePlatform.Android)
		{
			return AppInfo.PackageName;
		}
		if (platform == DevicePlatform.iOS)
		{
			return "id1566122910";
		}
		return "";
	}
}
