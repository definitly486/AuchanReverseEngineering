namespace System.Net.NetworkInformation;

internal sealed class AndroidIPInterfaceProperties : UnixIPInterfaceProperties
{
	private readonly AndroidIPv4InterfaceProperties _ipv4Properties;

	private readonly AndroidIPv6InterfaceProperties _ipv6Properties;

	public AndroidIPInterfaceProperties(AndroidNetworkInterface ani)
		: base(ani, globalConfig: true)
	{
		_ipv4Properties = new AndroidIPv4InterfaceProperties(ani);
		_ipv6Properties = new AndroidIPv6InterfaceProperties(ani);
	}
}
