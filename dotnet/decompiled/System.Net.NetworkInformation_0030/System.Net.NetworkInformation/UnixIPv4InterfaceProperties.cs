namespace System.Net.NetworkInformation;

internal abstract class UnixIPv4InterfaceProperties : IPv4InterfaceProperties
{
	private readonly UnixNetworkInterface _uni;

	public UnixIPv4InterfaceProperties(UnixNetworkInterface uni)
	{
		_uni = uni;
	}
}
