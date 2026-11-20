using System.Collections;
using System.Collections.Generic;

namespace System.Security.Cryptography;

internal sealed class CryptographicAttributeObjectCollection : ICollection, IEnumerable
{
	private readonly List<CryptographicAttributeObject> _list;

	public CryptographicAttributeObject this[int index] => _list[index];

	public int Count => _list.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public CryptographicAttributeObjectCollection()
	{
		_list = new List<CryptographicAttributeObject>();
	}

	public int Add(AsnEncodedData asnEncodedData)
	{
		ArgumentNullException.ThrowIfNull(asnEncodedData, "asnEncodedData");
		return Add(new CryptographicAttributeObject(asnEncodedData.Oid, new AsnEncodedDataCollection(asnEncodedData)));
	}

	public int Add(CryptographicAttributeObject attribute)
	{
		ArgumentNullException.ThrowIfNull(attribute, "attribute");
		string value = attribute.Oid.Value;
		for (int i = 0; i < _list.Count; i++)
		{
			CryptographicAttributeObject cryptographicAttributeObject = _list[i];
			if (cryptographicAttributeObject.Values == attribute.Values)
			{
				throw new InvalidOperationException("InvalidOperation_DuplicateItemNotAllowed");
			}
			string value2 = cryptographicAttributeObject.Oid.Value;
			if (string.Equals(value, value2, StringComparison.OrdinalIgnoreCase))
			{
				if (string.Equals(value, "1.2.840.113549.1.9.5", StringComparison.OrdinalIgnoreCase))
				{
					throw new CryptographicException("Cryptography_Pkcs9_MultipleSigningTimeNotAllowed");
				}
				AsnEncodedDataEnumerator enumerator = attribute.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					AsnEncodedData current = enumerator.Current;
					cryptographicAttributeObject.Values.Add(current);
				}
				return i;
			}
		}
		int count = _list.Count;
		_list.Add(attribute);
		return count;
	}

	public CryptographicAttributeObjectEnumerator GetEnumerator()
	{
		return new CryptographicAttributeObjectEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new CryptographicAttributeObjectEnumerator(this);
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
		if (index > array.Length - Count)
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
