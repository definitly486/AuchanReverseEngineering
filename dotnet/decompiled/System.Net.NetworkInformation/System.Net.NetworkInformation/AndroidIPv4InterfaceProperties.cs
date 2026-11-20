using System.Runtime.CompilerServices;

namespace System.Net.NetworkInformation;

internal sealed class AndroidIPv4InterfaceProperties : UnixIPv4InterfaceProperties
{
	[CompilerGenerated]
	private readonly int _003CMtu_003Ek__BackingField;

	public AndroidIPv4InterfaceProperties(AndroidNetworkInterface androidNetworkInterface)
		: base(androidNetworkInterface)
	{
		_003CMtu_003Ek__BackingField = androidNetworkInterface._mtu;
	}
}
