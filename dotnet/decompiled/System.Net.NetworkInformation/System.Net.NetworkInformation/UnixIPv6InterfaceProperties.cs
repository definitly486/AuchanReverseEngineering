namespace System.Net.NetworkInformation;

internal abstract class UnixIPv6InterfaceProperties : IPv6InterfaceProperties
{
	private readonly UnixNetworkInterface _uni;

	public UnixIPv6InterfaceProperties(UnixNetworkInterface uni)
	{
		_uni = uni;
	}
}
