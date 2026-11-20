using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Net.NetworkInformation;

[DefaultMember("Item")]
public class IPAddressCollection : ICollection<IPAddress>, IEnumerable<IPAddress>, IEnumerable
{
	public virtual int Count
	{
		get
		{
			throw System.NotImplemented.ByDesign;
		}
	}

	public virtual bool IsReadOnly => true;

	protected internal IPAddressCollection()
	{
	}

	public virtual void CopyTo(IPAddress[] array, int offset)
	{
		throw System.NotImplemented.ByDesign;
	}

	public virtual void Add(IPAddress address)
	{
		throw new NotSupportedException("net_collection_readonly");
	}

	public virtual bool Contains(IPAddress address)
	{
		throw System.NotImplemented.ByDesign;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public virtual IEnumerator<IPAddress> GetEnumerator()
	{
		throw System.NotImplemented.ByDesign;
	}

	public virtual bool Remove(IPAddress address)
	{
		throw new NotSupportedException("net_collection_readonly");
	}

	public virtual void Clear()
	{
		throw new NotSupportedException("net_collection_readonly");
	}
}
