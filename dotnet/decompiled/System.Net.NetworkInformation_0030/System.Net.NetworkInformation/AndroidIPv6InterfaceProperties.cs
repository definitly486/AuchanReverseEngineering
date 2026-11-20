namespace System.Net.NetworkInformation;

internal sealed class AndroidIPv6InterfaceProperties : UnixIPv6InterfaceProperties
{
	private readonly AndroidNetworkInterface _androidNetworkInterface;

	public AndroidIPv6InterfaceProperties(AndroidNetworkInterface androidNetworkInterface)
		: base(androidNetworkInterface)
	{
		_androidNetworkInterface = androidNetworkInterface;
	}
}
