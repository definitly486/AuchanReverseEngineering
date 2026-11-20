using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using _003C_003EWeakEventHandler;

namespace ObservableLinq;

internal class ObservableGroupCollection<TKey, TElement> : ObservableRangeCollection<IObservableGrouping<TKey, TElement>>, IWeakEventHandlerFodyWeakEventTarget
{
	private readonly Func<TElement, TKey> _keySelector;

	private readonly IList<TElement> _source;

	[NonSerialized]
	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private readonly WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableGroupCollection<TKey, TElement>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler> _003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter;

	public unsafe ObservableGroupCollection(ObservableCollection<TElement> source, Func<TElement, TKey> keySelector)
		: this((IList<TElement>)source, keySelector)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableGroupCollection<TKey, TElement>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableGroupCollection<TKey, TElement>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableGroupCollection<TKey, TElement>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	public unsafe ObservableGroupCollection(ReadOnlyObservableCollection<TElement> source, Func<TElement, TKey> keySelector)
		: this((IList<TElement>)source, keySelector)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableGroupCollection<TKey, TElement>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableGroupCollection<TKey, TElement>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableGroupCollection<TKey, TElement>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	private unsafe ObservableGroupCollection(IList<TElement> collectionChangedSource, Func<TElement, TKey> keySelector)
		: base((IEnumerable<IObservableGrouping<TKey, TElement>>)collectionChangedSource.GroupBy(keySelector, (TKey key, IEnumerable<TElement> elements) => new ObservableGrouping<TKey, TElement>(key, elements)))
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableGroupCollection<TKey, TElement>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableGroupCollection<TKey, TElement>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableGroupCollection<TKey, TElement>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
		_source = collectionChangedSource;
		_keySelector = keySelector;
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Subscribe((INotifyCollectionChanged)_source);
		UpdateGroupStartIndexes();
	}

	private void UpdateGroupStartIndexes()
	{
		foreach (IObservableGrouping<TKey, TElement> item in base.Items)
		{
			((ObservableGrouping<TKey, TElement>)item).StartIndex = _source.IndexOf(item[0]);
		}
	}

	private int FindInsertPositionForGrouping(IEnumerable<TElement> groupingToAdd)
	{
		int num = _source.IndexOf(groupingToAdd.First());
		for (int i = 0; i < base.Items.Count; i++)
		{
			TElement item = base.Items[i][0];
			if (_source.IndexOf(item) >= num)
			{
				return i;
			}
		}
		return base.Items.Count;
	}

	private int FindInsertPositionInGrouping(IObservableGrouping<TKey, TElement> existingGrouping, int sourceIndex)
	{
		int result = existingGrouping.Count;
		int num = existingGrouping.Count - 1;
		while (num >= 0 && _source.IndexOf(existingGrouping[num]) >= sourceIndex)
		{
			result = num;
			num--;
		}
		return result;
	}

	private int FindNewInnerGroupPosition(TElement item, ICollection<TElement> existingGrouping)
	{
		return _source.TakeWhile(delegate(TElement x)
		{
			ref TElement reference = ref x;
			TElement val = default(TElement);
			int num;
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					num = 0;
					goto IL_003c;
				}
			}
			object obj = item;
			num = (reference.Equals(obj) ? 1 : 0);
			goto IL_003c;
			IL_003c:
			return num == 0;
		}).Count(existingGrouping.Contains);
	}

	private bool TryMoveItemsWithinTheGroup(IEnumerable<TElement> movingItems, ObservableGrouping<TKey, TElement> itemsGroup)
	{
		TElement item = movingItems.First();
		int num = itemsGroup.IndexOf(item);
		int num2 = FindNewInnerGroupPosition(item, itemsGroup);
		if (num == num2)
		{
			return false;
		}
		itemsGroup.MoveRange(num, num2, movingItems.Count());
		return true;
	}

	private void OnSourceCollectionAddEvent(NotifyCollectionChangedEventArgs e)
	{
		IEnumerable<IGrouping<TKey, TElement>> enumerable = e.NewItems.Cast<TElement>().GroupBy(_keySelector);
		List<ObservableGrouping<TKey, TElement>> list = new List<ObservableGrouping<TKey, TElement>>();
		foreach (IGrouping<TKey, TElement> newGrouping in enumerable)
		{
			IObservableGrouping<TKey, TElement> observableGrouping = base.Items.Find(delegate(IObservableGrouping<TKey, TElement> g)
			{
				TKey key = g.Key;
				if (key == null)
				{
					return false;
				}
				object obj = newGrouping.Key;
				return key.Equals(obj);
			});
			if (observableGrouping is ObservableGrouping<TKey, TElement> observableGrouping2)
			{
				int index = FindInsertPositionInGrouping(observableGrouping, e.NewStartingIndex);
				observableGrouping2.InsertRange(index, newGrouping);
			}
			else
			{
				list.Add(new ObservableGrouping<TKey, TElement>(newGrouping));
			}
		}
		if (list.Count > 0)
		{
			int num = 0;
			{
				foreach (IGrouping<int, ObservableGrouping<TKey, TElement>> item in list.GroupBy(FindInsertPositionForGrouping))
				{
					InsertRange(item.Key + num, item);
					num += item.Count();
				}
				return;
			}
		}
		OnIndexerPropertyChanged();
	}

	private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			OnSourceCollectionAddEvent(e);
			break;
		case NotifyCollectionChangedAction.Move:
			OnSourceCollectionMoveEvent(e);
			break;
		case NotifyCollectionChangedAction.Remove:
			OnSourceCollectionRemoveEvent(e);
			break;
		case NotifyCollectionChangedAction.Replace:
			OnSourceCollectionReplaceEvent(e);
			break;
		case NotifyCollectionChangedAction.Reset:
			OnSourceCollectionResetEvent(e);
			break;
		}
	}

	private void OnSourceCollectionMoveEvent(NotifyCollectionChangedEventArgs e)
	{
		bool flag = false;
		foreach (IGrouping<IObservableGrouping<TKey, TElement>, TElement> item in from TElement x in e.OldItems
			group x by base.Items.Find((IObservableGrouping<TKey, TElement> g) => g.Contains(x)))
		{
			ObservableGrouping<TKey, TElement> observableGrouping = (ObservableGrouping<TKey, TElement>)item.Key;
			if (TryMoveItemsWithinTheGroup(item, observableGrouping))
			{
				flag = true;
			}
			if (TryMoveGroup(observableGrouping))
			{
				flag = false;
			}
		}
		if (flag)
		{
			OnIndexerPropertyChanged();
		}
	}

	private bool TryMoveGroup(ObservableGrouping<TKey, TElement> existingGrouping)
	{
		int startIndex = existingGrouping.StartIndex;
		int num = _source.IndexOf(existingGrouping[0]);
		if (num == startIndex)
		{
			return false;
		}
		int num2 = base.Items.IndexOf(existingGrouping);
		int num3 = num2;
		if (num < startIndex)
		{
			for (int i = 0; i < num2; i++)
			{
				int num4 = num2 - i;
				ObservableGrouping<TKey, TElement> observableGrouping = (ObservableGrouping<TKey, TElement>)base.Items[num4];
				if (num > observableGrouping.StartIndex)
				{
					break;
				}
				num3 = num4;
			}
		}
		else if (num > startIndex)
		{
			for (int j = num2; j < base.Items.Count; j++)
			{
				ObservableGrouping<TKey, TElement> observableGrouping2 = (ObservableGrouping<TKey, TElement>)base.Items[j];
				if (num < observableGrouping2.StartIndex)
				{
					break;
				}
				num3 = j;
			}
		}
		if (num3 != num2)
		{
			MoveItem(num2, num3);
			existingGrouping.StartIndex = num3;
			return true;
		}
		return false;
	}

	private void OnSourceCollectionRemoveEvent(NotifyCollectionChangedEventArgs e)
	{
		IEnumerable<IGrouping<IObservableGrouping<TKey, TElement>?, TElement>> enumerable = from TElement x in e.OldItems
			group x by base.Items.Find((IObservableGrouping<TKey, TElement> g) => g.Contains(x));
		List<IObservableGrouping<TKey, TElement>> list = new List<IObservableGrouping<TKey, TElement>>();
		foreach (IGrouping<IObservableGrouping<TKey, TElement>, TElement> item in enumerable)
		{
			ObservableGrouping<TKey, TElement> observableGrouping = (ObservableGrouping<TKey, TElement>)item.Key;
			if (observableGrouping != null)
			{
				observableGrouping.RemoveRange(item);
				if (observableGrouping.Count == 0)
				{
					list.Add(observableGrouping);
				}
			}
		}
		if (list.Count > 0)
		{
			RemoveRange(list);
		}
		else
		{
			OnIndexerPropertyChanged();
		}
	}

	private void OnSourceCollectionReplaceEvent(NotifyCollectionChangedEventArgs e)
	{
		List<IGrouping<IObservableGrouping<TKey, TElement>?, TElement>> list = (from TElement x in e.OldItems
			group x by base.Items.Find((IObservableGrouping<TKey, TElement> g) => g.Contains(x))).ToList();
		List<IGrouping<TKey, TElement>> list2 = e.NewItems.Cast<TElement>().GroupBy(_keySelector).ToList();
		List<ObservableGrouping<TKey, TElement>> list3 = new List<ObservableGrouping<TKey, TElement>>();
		foreach (IGrouping<IObservableGrouping<TKey, TElement>, TElement> item in list)
		{
			ObservableGrouping<TKey, TElement> existingGrouping = (ObservableGrouping<TKey, TElement>)item.Key;
			if (existingGrouping == null)
			{
				continue;
			}
			int count = item.Count();
			IGrouping<TKey, TElement> grouping = list2.Find(delegate(IGrouping<TKey, TElement> x)
			{
				TKey key = x.Key;
				if (key == null)
				{
					return false;
				}
				object obj = existingGrouping.Key;
				return key.Equals(obj);
			});
			if (grouping.Any())
			{
				int index = existingGrouping.IndexOf(item.First());
				existingGrouping.ReplaceRange(index, count, grouping);
				list2.Remove(grouping);
				continue;
			}
			existingGrouping.RemoveRange(item);
			if (existingGrouping.Count == 0)
			{
				list3.Add(existingGrouping);
			}
		}
		if (list3.Count == 0 && list2.Count == 0)
		{
			OnIndexerPropertyChanged();
			return;
		}
		if (list3.Count > 0)
		{
			RemoveRange(list3);
		}
		if (list2.Count <= 0)
		{
			return;
		}
		int num = 0;
		foreach (IGrouping<int, ObservableGrouping<TKey, TElement>> item2 in list2.GroupBy((IGrouping<TKey, TElement> x) => FindInsertPositionForGrouping(x), (IGrouping<TKey, TElement> v) => new ObservableGrouping<TKey, TElement>(v)))
		{
			InsertRange(item2.Key + num, item2);
			num += item2.Count();
		}
	}

	private void OnSourceCollectionResetEvent(NotifyCollectionChangedEventArgs e)
	{
		IEnumerable<ObservableGrouping<TKey, TElement>> enumerable = e.NewItems?.Cast<TElement>().GroupBy(_keySelector, (TKey key, IEnumerable<TElement> elements) => new ObservableGrouping<TKey, TElement>(key, elements)) ?? Enumerable.Empty<ObservableGrouping<TKey, TElement>>();
		bool num = base.Items.Count != enumerable.Count();
		base.Items.Clear();
		base.Items.AddRange(enumerable);
		UpdateGroupStartIndexes();
		if (num)
		{
			OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		}
		OnIndexerPropertyChanged();
		OnCollectionReset();
	}

	private void _003EWeakEvents_003EUnsubscribe()
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Release();
	}

	void IWeakEventHandlerFodyWeakEventTarget.Unsubscribe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in >WeakEvents>Unsubscribe
		this._003EWeakEvents_003EUnsubscribe();
	}

	~ObservableGroupCollection()
	{
		((IWeakEventHandlerFodyWeakEventTarget)this).Unsubscribe();
	}

	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private static void _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd([In] INotifyCollectionChanged source, [In] NotifyCollectionChangedEventHandler handler)
	{
		source.CollectionChanged += handler;
	}

	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private static void _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove([In] INotifyCollectionChanged source, [In] NotifyCollectionChangedEventHandler handler)
	{
		source.CollectionChanged -= handler;
	}
}
