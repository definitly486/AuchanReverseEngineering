namespace System.Net.Sockets;

public class MulticastOption
{
	private IPAddress _group;

	private IPAddress _localAddress;

	private int _ifIndex;

	public IPAddress? LocalAddress
	{
		set
		{
			_ifIndex = 0;
			_localAddress = value;
		}
	}

	public int InterfaceIndex
	{
		set
		{
			ArgumentOutOfRangeException.ThrowIfNegative(value, "value");
			ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 16777215, "value");
			_localAddress = null;
			_ifIndex = value;
		}
	}

	public MulticastOption(IPAddress group, IPAddress mcint)
	{
		ArgumentNullException.ThrowIfNull(group, "group");
		ArgumentNullException.ThrowIfNull(mcint, "mcint");
		_group = group;
		LocalAddress = mcint;
	}
}
