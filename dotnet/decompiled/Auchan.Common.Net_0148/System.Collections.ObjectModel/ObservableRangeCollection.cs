using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Auchan.Common.Net;

namespace System.Collections.ObjectModel;

public class ObservableRangeCollection<T> : ObservableCollection<T>
{
	private sealed class DeferredEventsCollection : List<NotifyCollectionChangedEventArgs>, IDisposable
	{
		private readonly ObservableRangeCollection<T> _collection;

		public DeferredEventsCollection(ObservableRangeCollection<T> collection)
		{
			_collection = collection;
			_collection._deferredEvents = this;
		}

		public void Dispose()
		{
			_collection._deferredEvents = null;
			using List<NotifyCollectionChangedEventArgs>.Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				NotifyCollectionChangedEventArgs current = enumerator.Current;
				_collection.OnCollectionChanged(current);
			}
		}
	}

	private sealed class DummyDisposable : IDisposable
	{
		public void Dispose()
		{
		}
	}

	[NonSerialized]
	private DeferredEventsCollection? _deferredEvents;

	protected new List<T> Items => (List<T>)base.Items;

	public bool ShouldDeferEvents
	{
		[CompilerGenerated]
		get
		{
			return _003CShouldDeferEvents_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CShouldDeferEvents_003Ek__BackingField != value)
			{
				_003CShouldDeferEvents_003Ek__BackingField = value;
				OnPropertyChanged(_003C_003EPropertyChangedEventArgs.ShouldDeferEvents);
			}
		}
	} = true;

	public ObservableRangeCollection()
	{
	}

	public ObservableRangeCollection(IEnumerable<T> collection)
		: base(collection)
	{
	}

	public ObservableRangeCollection(List<T> list)
		: base(list)
	{
	}

	public void AddRange(IEnumerable<T> collection)
	{
		InsertRange(base.Count, collection);
	}

	public void ForceNotifyItemChanged(T item)
	{
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, item, IndexOf(item)));
	}

	public void ForceNotifyItemChanged(int itemPosition)
	{
		T val = base[itemPosition];
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, val, val, itemPosition));
	}

	public void InsertRange(int index, IEnumerable<T> collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (index > base.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (collection is ICollection<T> collection2)
		{
			if (collection2.Count == 0)
			{
				return;
			}
		}
		else if (!ContainsAny(collection))
		{
			return;
		}
		CheckReentrancy();
		Items.InsertRange(index, collection);
		OnEssentialPropertiesChanged();
		IList list = collection as IList;
		if (list == null)
		{
			list = new List<T>(collection);
		}
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, index));
	}

	public void MoveRange(int oldPosition, int newPosition, int count)
	{
		if (oldPosition < 0)
		{
			throw new ArgumentOutOfRangeException("oldPosition");
		}
		if (newPosition < 0)
		{
			throw new ArgumentOutOfRangeException("newPosition");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (oldPosition + count > base.Count)
		{
			throw new ArgumentOutOfRangeException("count", $"Collection does not contain {count} items from position {oldPosition}");
		}
		if (newPosition > base.Count - count)
		{
			throw new ArgumentOutOfRangeException("newPosition", $"Cannot move {count} items further than the count of items remaining: {base.Count - count}");
		}
		List<T> range = Items.GetRange(oldPosition, count);
		CheckReentrancy();
		Items.RemoveRange(oldPosition, count);
		Items.InsertRange(newPosition, range);
		OnIndexerPropertyChanged();
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, range, newPosition, oldPosition));
	}

	public int RemoveAll(Func<T, bool> match)
	{
		return RemoveAll(0, base.Count, match);
	}

	public int RemoveAll(int index, int count, Func<T, bool> match)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (index + count > base.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		if (base.Count == 0)
		{
			return 0;
		}
		List<T> list = null;
		int num = -1;
		int num2 = 0;
		using (BlockReentrancy())
		{
			using (DeferEvents())
			{
				int num3 = 0;
				while (num3 < count)
				{
					T val = Items[index];
					if (match(val))
					{
						Items.RemoveAt(index);
						num2++;
						if (num == index)
						{
							list.Add(val);
						}
						else
						{
							list = new List<T> { val };
							num = index;
						}
						index--;
					}
					else if (num > -1)
					{
						OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list, num));
						num = -1;
						list = null;
					}
					num3++;
					index++;
				}
				if (num > -1)
				{
					OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list, num));
				}
			}
		}
		if (num2 > 0)
		{
			OnEssentialPropertiesChanged();
		}
		return num2;
	}

	public void RemoveRange(IEnumerable<T> collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		if (base.Count == 0)
		{
			return;
		}
		if (collection is ICollection<T> collection2)
		{
			if (collection2.Count == 0)
			{
				return;
			}
			if (collection2.Count == 1)
			{
				using (IEnumerator<T> enumerator = collection2.GetEnumerator())
				{
					enumerator.MoveNext();
					Remove(enumerator.Current);
					return;
				}
			}
		}
		else if (!ContainsAny(collection))
		{
			return;
		}
		CheckReentrancy();
		Dictionary<int, List<T>> dictionary = new Dictionary<int, List<T>>();
		int num = -1;
		List<T> list = null;
		foreach (T item in collection)
		{
			int num2 = IndexOf(item);
			if (num2 >= 0)
			{
				Items.RemoveAt(num2);
				if (num == num2 && list != null)
				{
					list.Add(item);
					continue;
				}
				int key = (num = num2);
				List<T> obj = new List<T> { item };
				list = obj;
				dictionary[key] = obj;
			}
		}
		OnEssentialPropertiesChanged();
		if (base.Count == 0)
		{
			OnCollectionReset();
			return;
		}
		foreach (KeyValuePair<int, List<T>> item2 in dictionary)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item2.Value, item2.Key));
		}
	}

	public void RemoveRange(int index, int count)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (index + count > base.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		switch (count)
		{
		case 0:
			return;
		case 1:
			RemoveItem(index);
			return;
		}
		List<T> range = Items.GetRange(index, count);
		CheckReentrancy();
		Items.RemoveRange(index, count);
		OnEssentialPropertiesChanged();
		if (base.Count == 0)
		{
			OnCollectionReset();
		}
		else
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, range, index));
		}
	}

	public void ReplaceRange(IEnumerable<T> collection)
	{
		ReplaceRange(0, base.Count, collection, EqualityComparer<T>.Default);
	}

	public void ReplaceRange(IEnumerable<T> collection, IEqualityComparer<T> comparer)
	{
		ReplaceRange(0, base.Count, collection, comparer);
	}

	public void ReplaceRange(int index, int count, IEnumerable<T> collection)
	{
		ReplaceRange(index, count, collection, EqualityComparer<T>.Default);
	}

	public void ReplaceRange(int index, int count, IEnumerable<T> collection, IEqualityComparer<T> comparer)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (index + count > base.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (collection == null)
		{
			throw new ArgumentNullException("collection");
		}
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		if (collection is ICollection<T> collection2)
		{
			if (collection2.Count == 0)
			{
				RemoveRange(index, count);
				return;
			}
		}
		else if (!ContainsAny(collection))
		{
			RemoveRange(index, count);
			return;
		}
		if (index + count == 0)
		{
			InsertRange(0, collection);
			return;
		}
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = new List<T>(collection);
		}
		using (BlockReentrancy())
		{
			using (DeferEvents())
			{
				int count2 = list.Count;
				int num = Math.Min(count2, count);
				if (count2 > num)
				{
					T[] array = new T[count2 - num];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = list[num + i];
					}
					Items.InsertRange(index + num, array);
					OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, array, index + num));
					OnEssentialPropertiesChanged();
				}
				else if (count > num)
				{
					int count3 = count - count2;
					List<T> range = Items.GetRange(index + num, count3);
					Items.RemoveRange(index + num, count3);
					OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, range, index + num));
					OnEssentialPropertiesChanged();
				}
				if (num == 0)
				{
					return;
				}
				bool flag = false;
				List<T> list2 = null;
				List<T> list3 = null;
				int j;
				for (j = index; j < index + num; j++)
				{
					T val = base[j];
					T val2 = list[j - index];
					if (comparer.Equals(val, val2))
					{
						OnRangeReplaced(j, list2, list3);
						continue;
					}
					Items[j] = val2;
					if (list2 == null)
					{
						list2 = new List<T> { val2 };
						list3 = new List<T> { val };
					}
					else
					{
						list2.Add(val2);
						list3.Add(val);
					}
					flag = true;
				}
				OnRangeReplaced(j, list2, list3);
				if (flag)
				{
					OnIndexerPropertyChanged();
				}
			}
		}
	}

	protected override void ClearItems()
	{
		if (base.Count != 0)
		{
			CheckReentrancy();
			base.ClearItems();
			OnEssentialPropertiesChanged();
			OnCollectionReset();
		}
	}

	protected virtual IDisposable DeferEvents()
	{
		if (!ShouldDeferEvents)
		{
			return new DummyDisposable();
		}
		return new DeferredEventsCollection(this);
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (_deferredEvents != null)
		{
			_deferredEvents.Add(e);
		}
		else
		{
			base.OnCollectionChanged(e);
		}
	}

	protected void OnCollectionChanged(NotifyCollectionChangedAction action, object oldItem, object newItem, int index)
	{
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, newItem, oldItem, index));
	}

	protected void OnCollectionReset()
	{
		OnCollectionChanged(System.Collections.ObjectModel.EventArgsCache.ResetCollectionChanged);
	}

	protected void OnEssentialPropertiesChanged()
	{
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		OnIndexerPropertyChanged();
	}

	protected void OnIndexerPropertyChanged()
	{
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
	}

	protected override void SetItem(int index, T item)
	{
		if (!object.Equals(base[index], item))
		{
			CheckReentrancy();
			T val = base[index];
			base.SetItem(index, item);
			OnIndexerPropertyChanged();
			OnCollectionChanged(NotifyCollectionChangedAction.Replace, val, item, index);
		}
	}

	private static bool ContainsAny(IEnumerable<T> collection)
	{
		using IEnumerator<T> enumerator = collection.GetEnumerator();
		return enumerator.MoveNext();
	}

	private void OnRangeReplaced(int followingItemIndex, ICollection<T> newCluster, ICollection<T> oldCluster)
	{
		if (oldCluster != null && oldCluster.Count != 0)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new List<T>(newCluster), new List<T>(oldCluster), followingItemIndex - oldCluster.Count));
			oldCluster.Clear();
			newCluster.Clear();
		}
	}
}
