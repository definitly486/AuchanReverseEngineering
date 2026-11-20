using System.Collections;
using System.Collections.Generic;

namespace NLog.Targets;

[Target("Memory")]
public sealed class MemoryTarget : TargetWithLayoutHeaderAndFooter
{
	private sealed class ThreadSafeList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly List<T> _list = new List<T>();

		public T this[int index]
		{
			get
			{
				lock (_list)
				{
					return _list[index];
				}
			}
			set
			{
				lock (_list)
				{
					_list[index] = value;
				}
			}
		}

		public int Count => _list.Count;

		bool ICollection<T>.IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

		public void Add(T item)
		{
			lock (_list)
			{
				_list.Add(item);
			}
		}

		public void Add(T item, int maxListCount)
		{
			lock (_list)
			{
				if (maxListCount > 0 && _list.Count >= maxListCount)
				{
					_list.RemoveAt(0);
				}
				_list.Add(item);
			}
		}

		void ICollection<T>.Clear()
		{
			lock (_list)
			{
				_list.Clear();
			}
		}

		bool ICollection<T>.Contains(T item)
		{
			lock (_list)
			{
				return _list.Contains(item);
			}
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			lock (_list)
			{
				_list.CopyTo(array, arrayIndex);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			lock (_list)
			{
				foreach (T item in _list)
				{
					yield return item;
				}
			}
		}

		public int IndexOf(T item)
		{
			lock (_list)
			{
				return _list.IndexOf(item);
			}
		}

		public void Insert(int index, T item)
		{
			lock (_list)
			{
				_list.Insert(index, item);
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			lock (_list)
			{
				return _list.Remove(item);
			}
		}

		public void RemoveAt(int index)
		{
			lock (_list)
			{
				_list.RemoveAt(index);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			lock (_list)
			{
				foreach (T item in _list)
				{
					yield return item;
				}
			}
		}
	}

	private readonly ThreadSafeList<string> _logs = new ThreadSafeList<string>();

	public IList<string> Logs => _logs;

	public int MaxLogsCount { get; set; }

	public MemoryTarget()
	{
	}

	public MemoryTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (base.Header != null)
		{
			_logs.Add(RenderLogEvent(base.Header, LogEventInfo.CreateNullEvent()));
		}
	}

	protected override void CloseTarget()
	{
		if (base.Footer != null)
		{
			_logs.Add(RenderLogEvent(base.Footer, LogEventInfo.CreateNullEvent()));
		}
		base.CloseTarget();
	}

	protected override void Write(LogEventInfo logEvent)
	{
		_logs.Add(RenderLogEvent(Layout, logEvent), MaxLogsCount);
	}
}
