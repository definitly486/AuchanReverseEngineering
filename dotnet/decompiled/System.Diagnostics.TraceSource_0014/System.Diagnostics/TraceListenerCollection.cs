using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Diagnostics;

[DefaultMember("Item")]
public class TraceListenerCollection : IList, ICollection, IEnumerable
{
	private readonly List<TraceListener> _list;

	public int Count => _list.Count;

	object? IList.this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			if (!(value is TraceListener traceListener))
			{
				throw new ArgumentException("MustAddListener", "value");
			}
			InitializeListener(traceListener);
			_list[index] = traceListener;
		}
	}

	bool IList.IsReadOnly => false;

	bool IList.IsFixedSize => false;

	object ICollection.SyncRoot => this;

	bool ICollection.IsSynchronized => true;

	internal TraceListenerCollection()
	{
		_list = new List<TraceListener>(1);
	}

	public int Add(TraceListener listener)
	{
		InitializeListener(listener);
		lock (TraceInternal.critSec)
		{
			return ((IList)_list).Add((object?)listener);
		}
	}

	public void Clear()
	{
		_list.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	internal static void InitializeListener(TraceListener listener)
	{
		ArgumentNullException.ThrowIfNull(listener, "listener");
		listener.IndentSize = TraceInternal.IndentSize;
		listener.IndentLevel = TraceInternal.IndentLevel;
	}

	public void RemoveAt(int index)
	{
		lock (TraceInternal.critSec)
		{
			_list.RemoveAt(index);
		}
	}

	int IList.Add(object value)
	{
		InitializeListener((value as TraceListener) ?? throw new ArgumentException("MustAddListener", "value"));
		lock (TraceInternal.critSec)
		{
			return ((IList)_list).Add(value);
		}
	}

	bool IList.Contains(object value)
	{
		return _list.Contains((TraceListener)value);
	}

	int IList.IndexOf(object value)
	{
		return _list.IndexOf((TraceListener)value);
	}

	void IList.Insert(int index, object value)
	{
		InitializeListener((value as TraceListener) ?? throw new ArgumentException("MustAddListener", "value"));
		lock (TraceInternal.critSec)
		{
			_list.Insert(index, (TraceListener)value);
		}
	}

	void IList.Remove(object value)
	{
		lock (TraceInternal.critSec)
		{
			_list.Remove((TraceListener)value);
		}
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)_list).CopyTo(array, index);
	}
}
