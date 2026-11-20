using System.Net.Sockets;

namespace System.Net.NetworkInformation;

internal static class IPAddressUtil
{
	public static bool IsMulticast(IPAddress address)
	{
		if (address.AddressFamily == AddressFamily.InterNetworkV6)
		{
			return address.IsIPv6Multicast;
		}
		byte b = (byte)address.Address;
		if (b >= 224)
		{
			return b <= 239;
		}
		return false;
	}
}
