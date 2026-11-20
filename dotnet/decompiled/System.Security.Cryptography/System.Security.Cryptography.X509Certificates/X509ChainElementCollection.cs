using System.Collections;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509ChainElementCollection : ICollection, IEnumerable, IEnumerable<X509ChainElement>
{
	private readonly X509ChainElement[] _elements;

	public int Count => _elements.Length;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public X509ChainElement this[int index]
	{
		get
		{
			if (index < 0)
			{
				throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
			}
			if (index >= _elements.Length)
			{
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
			}
			return _elements[index];
		}
	}

	internal X509ChainElementCollection()
	{
		_elements = Array.Empty<X509ChainElement>();
	}

	internal X509ChainElementCollection(X509ChainElement[] chainElements)
	{
		_elements = chainElements;
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

	public X509ChainElementEnumerator GetEnumerator()
	{
		return new X509ChainElementEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new X509ChainElementEnumerator(this);
	}

	IEnumerator<X509ChainElement> IEnumerable<X509ChainElement>.GetEnumerator()
	{
		return GetEnumerator();
	}
}
