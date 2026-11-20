using System.Collections.Generic;
using System.Reflection;

namespace System.Net.NetworkInformation;

[DefaultMember("Item")]
internal sealed class InternalIPAddressCollection : IPAddressCollection
{
	private readonly List<IPAddress> _addresses;

	public override int Count => _addresses.Count;

	public override bool IsReadOnly => true;

	internal InternalIPAddressCollection()
	{
		_addresses = new List<IPAddress>();
	}

	internal InternalIPAddressCollection(List<IPAddress> addresses)
	{
		_addresses = addresses;
	}

	public override void CopyTo(IPAddress[] array, int offset)
	{
		_addresses.CopyTo(array, offset);
	}

	public override void Add(IPAddress address)
	{
		throw new NotSupportedException("net_collection_readonly");
	}

	public override bool Contains(IPAddress address)
	{
		return _addresses.Contains(address);
	}

	public override IEnumerator<IPAddress> GetEnumerator()
	{
		return _addresses.GetEnumerator();
	}
}
