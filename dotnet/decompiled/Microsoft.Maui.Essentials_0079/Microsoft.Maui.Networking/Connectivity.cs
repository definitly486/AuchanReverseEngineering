using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Maui.Networking;

public static class Connectivity
{
	private static IConnectivity? currentImplementation;

	public static NetworkAccess NetworkAccess => Current.NetworkAccess;

	public static IEnumerable<ConnectionProfile> ConnectionProfiles => Current.ConnectionProfiles.Distinct();

	public static IConnectivity Current => currentImplementation ?? (currentImplementation = new ConnectivityImplementation());

	public static event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged
	{
		add
		{
			Current.ConnectivityChanged += value;
		}
		remove
		{
			Current.ConnectivityChanged -= value;
		}
	}
}
