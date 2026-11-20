using System;
using System.Collections.Generic;

namespace Microsoft.Maui.Networking;

public interface IConnectivity
{
	IEnumerable<ConnectionProfile> ConnectionProfiles { get; }

	NetworkAccess NetworkAccess { get; }

	event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
}
