using System.Collections;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509ExtensionCollection : ICollection, IEnumerable, IEnumerable<X509Extension>
{
	private readonly List<X509Extension> _list = new List<X509Extension>();

	public int Count => _list.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public X509Extension this[int index]
	{
		get
		{
			if (index < 0)
			{
				throw new InvalidOperationException("InvalidOperation_EnumNotStarted");
			}
			if (index >= _list.Count)
			{
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
			}
			return _list[index];
		}
	}

	public int Add(X509Extension extension)
	{
		ArgumentNullException.ThrowIfNull(extension, "extension");
		_list.Add(extension);
		return _list.Count - 1;
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

	public X509ExtensionEnumerator GetEnumerator()
	{
		return new X509ExtensionEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new X509ExtensionEnumerator(this);
	}

	IEnumerator<X509Extension> IEnumerable<X509Extension>.GetEnumerator()
	{
		return GetEnumerator();
	}
}
