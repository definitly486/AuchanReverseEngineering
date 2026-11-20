using System.Collections;

namespace System.Security.Cryptography;

public sealed class OidCollection : ICollection, IEnumerable
{
	private Oid[] _oids;

	private int _count;

	public Oid this[int index]
	{
		get
		{
			ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual((uint)index, (uint)_count, "index");
			return _oids[index];
		}
	}

	public int Count => _count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public OidCollection()
	{
		_oids = Array.Empty<Oid>();
	}

	internal OidCollection(int initialCapacity)
	{
		_oids = ((initialCapacity == 0) ? Array.Empty<Oid>() : new Oid[initialCapacity]);
	}

	public int Add(Oid oid)
	{
		int count = _count;
		if (count == _oids.Length)
		{
			Array.Resize(ref _oids, (count == 0) ? 4 : (count * 2));
		}
		_oids[count] = oid;
		_count = count + 1;
		return count;
	}

	public OidEnumerator GetEnumerator()
	{
		return new OidEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		ArgumentNullException.ThrowIfNull(array, "array");
		if (array.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported");
		}
		if (index < 0 || index >= array.Length)
		{
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
		}
		if (index + Count > array.Length)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		for (int i = 0; i < Count; i++)
		{
			array.SetValue(this[i], index);
			index++;
		}
	}
}
