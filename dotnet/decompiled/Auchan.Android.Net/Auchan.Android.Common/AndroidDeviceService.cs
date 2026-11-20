using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Net.Wifi;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Core.Location;
using AndroidX.Lifecycle;
using Auchan.Android.Helpers;
using Auchan.Common.Common;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

public class AndroidDeviceService : BaseDeviceService
{
	public override bool IsHuawei => true;

	public override Task<ApplicationState> GetApplicationState()
	{
		if (!(Platform.CurrentActivity is AppCompatActivity appCompatActivity))
		{
			return Task.FromResult(ApplicationState.Background);
		}
		if (appCompatActivity.Lifecycle.CurrentState.IsAtLeast(Lifecycle.State.Started))
		{
			return Task.FromResult(ApplicationState.Foreground);
		}
		return Task.FromResult(ApplicationState.Background);
	}

	public override Task<bool> IsLocationEnabled()
	{
		return Task.FromResult(LocationManagerCompat.IsLocationEnabled(LocationManager.FromContext(Application.Context)));
	}

	public override void OpenSystemLocationSettings()
	{
		Platform.CurrentActivity?.StartActivity(new Intent("android.settings.LOCATION_SOURCE_SETTINGS"));
	}

	public override Task<bool> NotificationsEnabled()
	{
		Context context = Application.Context;
		if (!GooglePlayHelper.PlayServicesAvailable(context, out var _))
		{
			return Task.FromResult(result: false);
		}
		return Task.FromResult(NotificationManagerCompat.From(context)?.AreNotificationsEnabled() ?? false);
	}

	protected override string? GetIpAddress()
	{
		try
		{
			WifiManager wifiManager = WifiManager.FromContext(Application.Context);
			WifiInfo wifiInfo = wifiManager?.ConnectionInfo;
			if (wifiInfo != null && wifiManager.IsWifiEnabled)
			{
				int ipAddress = wifiInfo.IpAddress;
				return (ipAddress & 0xFF) + "." + ((ipAddress >> 8) & 0xFF) + "." + ((ipAddress >> 16) & 0xFF) + "." + ((ipAddress >> 24) & 0xFF);
			}
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return iPAddress.ToString();
				}
			}
			return hostAddresses.FirstOrDefault()?.ToString();
		}
		catch (Exception)
		{
		}
		return null;
	}
}
