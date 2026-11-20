namespace System.Net.Sockets;

public class IPv6MulticastOption
{
	private IPAddress _group;

	private long _interface;

	public long InterfaceIndex
	{
		set
		{
			ArgumentOutOfRangeException.ThrowIfNegative(value, "value");
			ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 4294967295L, "value");
			_interface = value;
		}
	}

	public IPv6MulticastOption(IPAddress group, long ifindex)
	{
		ArgumentNullException.ThrowIfNull(group, "group");
		ArgumentOutOfRangeException.ThrowIfNegative(ifindex, "ifindex");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(ifindex, 4294967295L, "ifindex");
		_group = group;
		InterfaceIndex = ifindex;
	}
}
