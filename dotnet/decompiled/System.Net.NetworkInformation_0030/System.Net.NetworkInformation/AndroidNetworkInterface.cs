using System.Runtime.CompilerServices;

namespace System.Net.NetworkInformation;

internal sealed class AndroidNetworkInterface : UnixNetworkInterface
{
	internal readonly int _mtu;

	private readonly AndroidIPInterfaceProperties _ipProperties;

	[CompilerGenerated]
	private readonly bool _003CSupportsMulticast_003Ek__BackingField;

	[CompilerGenerated]
	private readonly OperationalStatus _003COperationalStatus_003Ek__BackingField;

	[CompilerGenerated]
	private readonly NetworkInterfaceType _003CNetworkInterfaceType_003Ek__BackingField;

	[CompilerGenerated]
	private readonly long _003CSpeed_003Ek__BackingField;

	internal unsafe AndroidNetworkInterface(string name, global::Interop.Sys.NetworkInterfaceInfo* networkInterfaceInfo)
		: base(name)
	{
		_index = networkInterfaceInfo->InterfaceIndex;
		if (networkInterfaceInfo->NumAddressBytes > 0)
		{
			_physicalAddress = new PhysicalAddress(new ReadOnlySpan<byte>(networkInterfaceInfo->AddressBytes, networkInterfaceInfo->NumAddressBytes).ToArray());
		}
		_mtu = networkInterfaceInfo->Mtu;
		_ipProperties = new AndroidIPInterfaceProperties(this);
		_003COperationalStatus_003Ek__BackingField = (OperationalStatus)networkInterfaceInfo->OperationalState;
		_003CSpeed_003Ek__BackingField = networkInterfaceInfo->Speed;
		_003CSupportsMulticast_003Ek__BackingField = networkInterfaceInfo->SupportsMulticast != 0;
		_003CNetworkInterfaceType_003Ek__BackingField = (NetworkInterfaceType)networkInterfaceInfo->HardwareType;
	}

	internal unsafe void AddAddress(global::Interop.Sys.IpAddressInfo* addressInfo)
	{
		IPAddress iPAddress = new IPAddress(new ReadOnlySpan<byte>(addressInfo->AddressBytes, addressInfo->NumAddressBytes));
		if (iPAddress.IsIPv6LinkLocal)
		{
			iPAddress.ScopeId = addressInfo->InterfaceIndex;
		}
		AddAddress(iPAddress, addressInfo->PrefixLength);
	}

	public override IPInterfaceProperties GetIPProperties()
	{
		return _ipProperties;
	}
}
