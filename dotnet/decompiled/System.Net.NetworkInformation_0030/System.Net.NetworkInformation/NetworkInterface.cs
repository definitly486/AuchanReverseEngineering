using System.Runtime.Versioning;

namespace System.Net.NetworkInformation;

public abstract class NetworkInterface
{
	[UnsupportedOSPlatform("illumos")]
	[UnsupportedOSPlatform("solaris")]
	public static NetworkInterface[] GetAllNetworkInterfaces()
	{
		return NetworkInterfacePal.GetAllNetworkInterfaces();
	}

	[UnsupportedOSPlatform("illumos")]
	[UnsupportedOSPlatform("solaris")]
	public static bool GetIsNetworkAvailable()
	{
		return NetworkInterfacePal.GetIsNetworkAvailable();
	}

	public virtual IPInterfaceProperties GetIPProperties()
	{
		throw System.NotImplemented.ByDesignWithMessage("net_MethodNotImplementedException");
	}
}
