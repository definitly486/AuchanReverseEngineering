using System.Collections.Generic;

namespace System.Net.NetworkInformation;

internal abstract class UnixNetworkInterface : NetworkInterface
{
	protected string _name;

	protected int _index = -1;

	protected NetworkInterfaceType _networkInterfaceType = NetworkInterfaceType.Unknown;

	internal PhysicalAddress _physicalAddress = PhysicalAddress.None;

	internal List<UnixUnicastIPAddressInformation> _unicastAddresses = new List<UnixUnicastIPAddressInformation>();

	internal List<IPAddress> _multicastAddresses;

	public int Index => _index;

	public List<UnixUnicastIPAddressInformation> UnicastAddress => _unicastAddresses;

	protected UnixNetworkInterface(string name)
	{
		_name = name;
	}

	protected void AddAddress(IPAddress ipAddress, int prefix)
	{
		if (IPAddressUtil.IsMulticast(ipAddress))
		{
			if (_multicastAddresses == null)
			{
				_multicastAddresses = new List<IPAddress>();
			}
			_multicastAddresses.Add(ipAddress);
		}
		else
		{
			_unicastAddresses.Add(new UnixUnicastIPAddressInformation(ipAddress, prefix));
		}
	}
}
