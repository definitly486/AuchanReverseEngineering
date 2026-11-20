using System;
using System.Threading.Tasks;

namespace Auchan.Common.Common;

public interface IDeviceService
{
	[Obsolete("use OperatingSystem.IsAndroid() instead")]
	bool IsAndroid => true;

	[Obsolete("use OperatingSystem.IsIOS() instead")]
	bool IsiOS => false;

	bool IsHuawei { get; }

	bool IsNetworkAvailable { get; }

	string Udid { get; }

	string IpAddress { get; }

	string BuildNumberAndOSVersion { get; }

	string AppVersionBuildNumberAndOSVersion { get; }

	string BuildVersion { get; }

	string AppUserAgent { get; }

	Task<ApplicationState> GetApplicationState();

	Task<bool> IsLocationEnabled();

	void OpenSystemLocationSettings();

	Task<bool> NotificationsEnabled();
}
