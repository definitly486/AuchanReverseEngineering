using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Net;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Networking;

internal class ConnectivityImplementation : IConnectivity
{
	private class EssentialsNetworkCallback : ConnectivityManager.NetworkCallback
	{
		private readonly Intent connectivityIntent;

		public EssentialsNetworkCallback()
		{
			connectivityIntent = new Intent("com.maui.essentials.ESSENTIALS_CONNECTIVITY_CHANGED");
			connectivityIntent.SetPackage(Application.Context.PackageName);
		}

		public override void OnAvailable(Network network)
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}

		public override void OnLost(Network network)
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}

		public override void OnCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities)
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}

		public override void OnUnavailable()
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}

		public override void OnLinkPropertiesChanged(Network network, LinkProperties linkProperties)
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}

		public override void OnLosing(Network network, int maxMsToLive)
		{
			Application.Context.SendBroadcast(connectivityIntent);
		}
	}

	private NetworkAccess currentAccess;

	private List<ConnectionProfile> currentProfiles;

	private ConnectivityBroadcastReceiver conectivityReceiver;

	private EssentialsNetworkCallback networkCallback;

	private static ConnectivityManager ConnectivityManager => Application.Context.GetSystemService("connectivity") as ConnectivityManager;

	public NetworkAccess NetworkAccess
	{
		get
		{
			Permissions.EnsureDeclared<Permissions.NetworkState>();
			try
			{
				NetworkAccess currentAccess = NetworkAccess.None;
				ConnectivityManager manager = ConnectivityManager;
				Network[] allNetworks = manager.GetAllNetworks();
				if (allNetworks.Length == 0 && !OperatingSystem.IsAndroidVersionAtLeast(23))
				{
					ProcessAllNetworkInfo();
					return currentAccess;
				}
				Network[] array = allNetworks;
				foreach (Network network in array)
				{
					try
					{
						NetworkCapabilities networkCapabilities = manager.GetNetworkCapabilities(network);
						if (networkCapabilities == null)
						{
							continue;
						}
						NetworkInfo networkInfo = manager.GetNetworkInfo(network);
						if (networkInfo != null && networkInfo.IsAvailable)
						{
							if (!networkCapabilities.HasCapability(NetCapability.Internet))
							{
								currentAccess = IsBetterAccess(currentAccess, NetworkAccess.Local);
							}
							else
							{
								ProcessNetworkInfo(networkInfo);
							}
						}
					}
					catch
					{
					}
				}
				return currentAccess;
				void ProcessAllNetworkInfo()
				{
					NetworkInfo[] allNetworkInfo = manager.GetAllNetworkInfo();
					foreach (NetworkInfo info in allNetworkInfo)
					{
						ProcessNetworkInfo(info);
					}
				}
				void ProcessNetworkInfo(NetworkInfo info)
				{
					if (info != null && info.IsAvailable)
					{
						if (info.IsConnected)
						{
							currentAccess = IsBetterAccess(currentAccess, NetworkAccess.Internet);
						}
						else if (info.IsConnectedOrConnecting)
						{
							currentAccess = IsBetterAccess(currentAccess, NetworkAccess.ConstrainedInternet);
						}
					}
				}
			}
			catch (System.Exception)
			{
				return NetworkAccess.Unknown;
			}
		}
	}

	public IEnumerable<ConnectionProfile> ConnectionProfiles
	{
		get
		{
			Permissions.EnsureDeclared<Permissions.NetworkState>();
			ConnectivityManager manager = ConnectivityManager;
			Network[] allNetworks = manager.GetAllNetworks();
			Network[] array = allNetworks;
			foreach (Network network in array)
			{
				NetworkInfo info = null;
				try
				{
					info = manager.GetNetworkInfo(network);
				}
				catch
				{
				}
				ConnectionProfile? connectionProfile = ProcessNetworkInfo(info);
				if (connectionProfile.HasValue)
				{
					yield return connectionProfile.Value;
				}
			}
			static ConnectionProfile? ProcessNetworkInfo(NetworkInfo networkInfo)
			{
				if (networkInfo == null || !networkInfo.IsAvailable || !networkInfo.IsConnectedOrConnecting)
				{
					return null;
				}
				return GetConnectionType(networkInfo.Type, networkInfo.TypeName);
			}
		}
	}

	private event EventHandler<ConnectivityChangedEventArgs> ConnectivityChangedInternal;

	public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged
	{
		add
		{
			if (this.ConnectivityChangedInternal == null)
			{
				SetCurrent();
				StartListeners();
			}
			ConnectivityChangedInternal += value;
		}
		remove
		{
			ConnectivityChangedInternal -= value;
			if (this.ConnectivityChangedInternal == null)
			{
				StopListeners();
			}
		}
	}

	private void SetCurrent()
	{
		currentAccess = NetworkAccess;
		currentProfiles = new List<ConnectionProfile>(ConnectionProfiles);
	}

	private void OnConnectivityChanged(NetworkAccess access, IEnumerable<ConnectionProfile> profiles)
	{
		OnConnectivityChanged(new ConnectivityChangedEventArgs(access, profiles));
	}

	private void OnConnectivityChanged()
	{
		OnConnectivityChanged(NetworkAccess, ConnectionProfiles);
	}

	private void OnConnectivityChanged(ConnectivityChangedEventArgs e)
	{
		if (currentAccess != e.NetworkAccess || !currentProfiles.SequenceEqual(e.ConnectionProfiles))
		{
			SetCurrent();
			MainThread.BeginInvokeOnMainThread(delegate
			{
				this.ConnectivityChangedInternal?.Invoke(null, e);
			});
		}
	}

	private void StartListeners()
	{
		Permissions.EnsureDeclared<Permissions.NetworkState>();
		IntentFilter intentFilter = new IntentFilter();
		if (OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			RegisterNetworkCallback();
			intentFilter.AddAction("com.maui.essentials.ESSENTIALS_CONNECTIVITY_CHANGED");
		}
		else
		{
			intentFilter.AddAction("android.net.conn.CONNECTIVITY_CHANGE");
		}
		conectivityReceiver = new ConnectivityBroadcastReceiver(OnConnectivityChanged);
		PlatformUtils.RegisterBroadcastReceiver(conectivityReceiver, intentFilter);
	}

	private void StopListeners()
	{
		if (conectivityReceiver != null)
		{
			try
			{
				UnregisterNetworkCallback();
			}
			catch
			{
			}
			try
			{
				Application.Context.UnregisterReceiver(conectivityReceiver);
			}
			catch (IllegalArgumentException)
			{
			}
			conectivityReceiver = null;
		}
	}

	private void RegisterNetworkCallback()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			ConnectivityManager connectivityManager = ConnectivityManager;
			if (connectivityManager != null)
			{
				NetworkRequest request = new NetworkRequest.Builder().Build();
				networkCallback = new EssentialsNetworkCallback();
				connectivityManager.RegisterNetworkCallback(request, networkCallback);
			}
		}
	}

	private void UnregisterNetworkCallback()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			ConnectivityManager connectivityManager = ConnectivityManager;
			if (connectivityManager != null && networkCallback != null)
			{
				connectivityManager.UnregisterNetworkCallback(networkCallback);
				networkCallback = null;
			}
		}
	}

	private static NetworkAccess IsBetterAccess(NetworkAccess currentAccess, NetworkAccess newAccess)
	{
		if (newAccess <= currentAccess)
		{
			return currentAccess;
		}
		return newAccess;
	}

	internal static ConnectionProfile GetConnectionType(ConnectivityType connectivityType, string typeName)
	{
		switch (connectivityType)
		{
		case ConnectivityType.Ethernet:
			return ConnectionProfile.Ethernet;
		case ConnectivityType.Wifi:
			return ConnectionProfile.WiFi;
		case ConnectivityType.Bluetooth:
			return ConnectionProfile.Bluetooth;
		case ConnectivityType.Mobile:
		case ConnectivityType.MobileMms:
		case ConnectivityType.MobileDun:
		case ConnectivityType.MobileHipri:
		case ConnectivityType.Wimax:
			return ConnectionProfile.Cellular;
		case ConnectivityType.Dummy:
			return ConnectionProfile.Unknown;
		default:
			if (string.IsNullOrWhiteSpace(typeName))
			{
				return ConnectionProfile.Unknown;
			}
			if (typeName.Contains("mobile", StringComparison.OrdinalIgnoreCase))
			{
				return ConnectionProfile.Cellular;
			}
			if (typeName.Contains("wimax", StringComparison.OrdinalIgnoreCase))
			{
				return ConnectionProfile.Cellular;
			}
			if (typeName.Contains("wifi", StringComparison.OrdinalIgnoreCase))
			{
				return ConnectionProfile.WiFi;
			}
			if (typeName.Contains("ethernet", StringComparison.OrdinalIgnoreCase))
			{
				return ConnectionProfile.Ethernet;
			}
			if (typeName.Contains("bluetooth", StringComparison.OrdinalIgnoreCase))
			{
				return ConnectionProfile.Bluetooth;
			}
			return ConnectionProfile.Unknown;
		}
	}
}
