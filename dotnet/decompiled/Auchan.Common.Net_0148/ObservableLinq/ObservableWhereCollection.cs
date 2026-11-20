using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using _003C_003EWeakEventHandler;

namespace ObservableLinq;

internal class ObservableWhereCollection<T> : ObservableCollection<T>, IWeakEventHandlerFodyWeakEventTarget
{
	private readonly List<int> _addedPositions = new List<int>();

	private readonly Func<T, bool> _predicate;

	private readonly IList<T> _source;

	[NonSerialized]
	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private readonly WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableWhereCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler> _003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter;

	protected new List<T> Items => (List<T>)base.Items;

	public unsafe ObservableWhereCollection(ObservableCollection<T> source, Func<T, bool> predicate)
		: this((IList<T>)source, predicate)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableWhereCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableWhereCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableWhereCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	public unsafe ObservableWhereCollection(ReadOnlyObservableCollection<T> source, Func<T, bool> predicate)
		: this((IList<T>)source, predicate)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableWhereCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableWhereCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableWhereCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	private unsafe ObservableWhereCollection(IList<T> collectionChangedSource, Func<T, bool> predicate)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableWhereCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableWhereCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableWhereCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
		_predicate = predicate;
		_source = collectionChangedSource;
		RefillFromSource();
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Subscribe((INotifyCollectionChanged)_source);
	}

	private int AdjustCount(int newStartingIndex, int count)
	{
		return _addedPositions.SkipWhile((int i) => i < newStartingIndex).TakeWhile((int i) => i < newStartingIndex + count).Count();
	}

	private int AdjustIndex(int startingIndex)
	{
		return _addedPositions.TakeWhile((int i) => i <= startingIndex).Count();
	}

	private void RefillFromSource()
	{
		Items.Clear();
		_addedPositions.Clear();
		for (int i = 0; i < _source.Count; i++)
		{
			if (_predicate(_source[i]))
			{
				Items.Add(_source[i]);
				_addedPositions.Add(i);
			}
		}
	}

	private (List<T> FilteredItems, List<int> FilteredPositions) FilterItems(IList items, int positionsOffset = 0)
	{
		List<T> list = new List<T>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < items.Count; i++)
		{
			T val = (T)items[i];
			if (_predicate(val))
			{
				list.Add(val);
				list2.Add(i + positionsOffset);
			}
		}
		return (FilteredItems: list, FilteredPositions: list2);
	}

	private void OnSourceCollectionAddEvent(NotifyCollectionChangedEventArgs e)
	{
		(List<T> FilteredItems, List<int> FilteredPositions) tuple = FilterItems(e.NewItems, e.NewStartingIndex);
		List<T> item = tuple.FilteredItems;
		List<int> item2 = tuple.FilteredPositions;
		int num = AdjustIndex(e.NewStartingIndex);
		Items.InsertRange(num, item);
		ShiftRange(_addedPositions, e.NewItems.Count, num);
		_addedPositions.InsertRange(num, item2);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, num));
	}

	private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			OnSourceCollectionAddEvent(e);
			break;
		case NotifyCollectionChangedAction.Remove:
			OnSourceCollectionRemoveEvent(e);
			break;
		case NotifyCollectionChangedAction.Replace:
			OnSourceCollectionReplaceEvent(e);
			break;
		case NotifyCollectionChangedAction.Move:
			OnSourceCollectionMoveEvent(e);
			break;
		case NotifyCollectionChangedAction.Reset:
			OnSourceCollectionResetEvent();
			break;
		}
	}

	private void OnSourceCollectionMoveEvent(NotifyCollectionChangedEventArgs e)
	{
		int num = AdjustIndex(e.OldStartingIndex);
		int count = AdjustCount(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		int num2 = AdjustIndex(e.NewStartingIndex);
		List<T> range = Items.GetRange(num, count);
		List<int> range2 = _addedPositions.GetRange(num, count);
		int byNumber = e.NewStartingIndex - e.OldStartingIndex;
		Items.RemoveRange(num, count);
		Items.InsertRange(num, range);
		_addedPositions.RemoveRange(num, count);
		ShiftRange(_addedPositions, -(e.OldItems?.Count ?? 0), num);
		ShiftRange(range2, byNumber);
		ShiftRange(_addedPositions, e.OldItems?.Count ?? 0, num2);
		_addedPositions.InsertRange(num, range2);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, range, num2, num));
	}

	private void OnSourceCollectionRemoveEvent(NotifyCollectionChangedEventArgs e)
	{
		int num = AdjustIndex(e.OldStartingIndex);
		int count = AdjustCount(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		List<T> range = Items.GetRange(num, count);
		Items.RemoveRange(num, count);
		_addedPositions.RemoveRange(num, count);
		ShiftRange(_addedPositions, -(e.OldItems?.Count ?? 0), num);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, range, num));
	}

	private void OnSourceCollectionReplaceEvent(NotifyCollectionChangedEventArgs e)
	{
		int num = AdjustIndex(e.OldStartingIndex);
		int count = AdjustCount(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		(List<T> FilteredItems, List<int> FilteredPositions) tuple = FilterItems(e.NewItems, e.NewStartingIndex);
		List<T> item = tuple.FilteredItems;
		List<int> item2 = tuple.FilteredPositions;
		List<T> range = Items.GetRange(num, count);
		int valueOrDefault = (e.NewItems.Count - e.OldItems?.Count).GetValueOrDefault();
		Items.RemoveRange(num, count);
		Items.InsertRange(num, item);
		_addedPositions.RemoveRange(num, count);
		ShiftRange(_addedPositions, valueOrDefault, num);
		_addedPositions.InsertRange(num, item2);
		if (valueOrDefault != 0)
		{
			OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		}
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, range, num));
	}

	private void OnSourceCollectionResetEvent()
	{
		int count = Items.Count;
		RefillFromSource();
		if (Items.Count != count)
		{
			OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		}
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	}

	private void ShiftRange(List<int> items, int byNumber, int startingIndex = 0)
	{
		int num = items.Count - 1;
		while (num >= 0 && items[num] >= startingIndex)
		{
			items[num] += byNumber;
			num--;
		}
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

	~ObservableWhereCollection()
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
