using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Common;

public abstract class BaseDeviceService : IDeviceService
{
	private const string DefaultIpAddress = "127.0.0.1";

	private const string UdidKey = "udid_key";

	private string? _ipAddress;

	public virtual bool IsHuawei => false;

	public string Udid
	{
		get
		{
			string text = Preferences.Get("udid_key", null);
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Guid.NewGuid().ToString();
				Preferences.Set("udid_key", text);
			}
			return text;
		}
	}

	public string IpAddress
	{
		get
		{
			if (!IsNetworkAvailable)
			{
				return "127.0.0.1";
			}
			string text = _ipAddress;
			if (text == null)
			{
				string? obj = GetIpAddress() ?? "127.0.0.1";
				string text2 = obj;
				_ipAddress = obj;
				text = text2;
			}
			return text;
		}
	}

	public bool IsNetworkAvailable => Connectivity.NetworkAccess == NetworkAccess.Internet;

	public string BuildNumberAndOSVersion
	{
		get
		{
			if (1 == 0)
			{
			}
			return "auchan/" + AppInfo.BuildString + " android/" + DeviceInfo.VersionString;
		}
	}

	public string AppVersionBuildNumberAndOSVersion
	{
		get
		{
			if (1 == 0)
			{
			}
			return $"auchan/{AppInfo.VersionString} ({AppInfo.BuildString}) android/{DeviceInfo.VersionString}";
		}
	}

	public string BuildVersion => AppInfo.BuildString;

	public string AppUserAgent { get; } = GetAppVersion();

	protected BaseDeviceService()
	{
		Connectivity.ConnectivityChanged += OnConnectivityChanged;
	}

	public abstract Task<bool> IsLocationEnabled();

	public abstract void OpenSystemLocationSettings();

	public abstract Task<ApplicationState> GetApplicationState();

	protected abstract string? GetIpAddress();

	private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
	{
		string ipAddress = GetIpAddress();
		_ipAddress = (string.IsNullOrWhiteSpace(ipAddress) ? "127.0.0.1" : ipAddress);
	}

	public abstract Task<bool> NotificationsEnabled();

	private static string GetAppVersion()
	{
		_ = 1;
		string versionString = AppInfo.VersionString;
		string value = DeviceInfo.Platform.ToString().ToLowerInvariant();
		string versionString2 = DeviceInfo.VersionString;
		string manufacturer = DeviceInfo.Manufacturer;
		string model = DeviceInfo.Model;
		return $"{Escape(versionString)}/{Escape(value)}/{Escape(versionString2)}/{Escape(manufacturer)}/{Escape(model)}";
		static string Escape(string text)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				return Uri.EscapeDataString(text.Replace(" ", "_"));
			}
			return "unknown";
		}
	}
}
