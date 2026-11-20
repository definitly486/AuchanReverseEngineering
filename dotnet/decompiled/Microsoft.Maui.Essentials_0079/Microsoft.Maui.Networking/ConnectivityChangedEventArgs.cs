using System;
using System.Collections.Generic;

namespace Microsoft.Maui.Networking;

public class ConnectivityChangedEventArgs : EventArgs
{
	public NetworkAccess NetworkAccess { get; }

	public IEnumerable<ConnectionProfile> ConnectionProfiles { get; }

	public ConnectivityChangedEventArgs(NetworkAccess access, IEnumerable<ConnectionProfile> connectionProfiles)
	{
		NetworkAccess = access;
		ConnectionProfiles = connectionProfiles;
	}

	public override string ToString()
	{
		return $"{"NetworkAccess"}: {NetworkAccess}, {"ConnectionProfiles"}: [{string.Join(", ", ConnectionProfiles)}]";
	}
}
