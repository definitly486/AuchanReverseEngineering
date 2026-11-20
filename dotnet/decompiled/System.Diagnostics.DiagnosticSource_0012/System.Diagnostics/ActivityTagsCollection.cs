using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

[DefaultMember("Item")]
public class ActivityTagsCollection : IEnumerable<KeyValuePair<string, object?>>, IEnumerable
{
	public struct Enumerator : IEnumerator<KeyValuePair<string, object?>>, IEnumerator, IDisposable
	{
		private List<KeyValuePair<string, object>>.Enumerator _enumerator;

		public KeyValuePair<string, object?> Current => _enumerator.Current;

		object IEnumerator.Current => ((IEnumerator)_enumerator).Current;

		public void Dispose()
		{
			_enumerator.Dispose();
		}

		public bool MoveNext()
		{
			return _enumerator.MoveNext();
		}

		void IEnumerator.Reset()
		{
			((IEnumerator)_enumerator).Reset();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Add(KeyValuePair<string, object?> item)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Enumerator GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}
}
