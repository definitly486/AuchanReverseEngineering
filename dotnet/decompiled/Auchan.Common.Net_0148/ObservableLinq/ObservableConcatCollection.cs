using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using _003C_003EWeakEventHandler;

namespace ObservableLinq;

internal class ObservableConcatCollection<T> : ObservableCollection<T>, IWeakEventHandlerFodyWeakEventTarget
{
	private readonly Dictionary<IList<T>, int> _lastCounts = new Dictionary<IList<T>, int>();

	private readonly IList<T>[] _sources;

	[NonSerialized]
	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private readonly WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableConcatCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler> _003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter;

	[NonSerialized]
	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private readonly WeakEventHandlerFodyWeakEventAdapter<INotifyPropertyChanged, ObservableConcatCollection<T>, PropertyChangedEventArgs, PropertyChangedEventHandler> _003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter;

	protected new List<T> Items => (List<T>)base.Items;

	public unsafe ObservableConcatCollection(IEnumerable<ObservableCollection<T>> sources)
		: this((IEnumerable<IList<T>>)(IList<T>[])sources)
	{
		_003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyPropertyChanged, ObservableConcatCollection<T>, PropertyChangedEventArgs, PropertyChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, PropertyChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourcePropertyChanged)), _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003EAdd, _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003ERemove);
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableConcatCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	public unsafe ObservableConcatCollection(IEnumerable<ReadOnlyObservableCollection<T>> sources)
		: this((IEnumerable<IList<T>>)(IList<T>[])sources)
	{
		_003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyPropertyChanged, ObservableConcatCollection<T>, PropertyChangedEventArgs, PropertyChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, PropertyChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourcePropertyChanged)), _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003EAdd, _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003ERemove);
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableConcatCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	private unsafe ObservableConcatCollection(IEnumerable<IList<T>> collectionChangedSources)
	{
		_003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyPropertyChanged, ObservableConcatCollection<T>, PropertyChangedEventArgs, PropertyChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, PropertyChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourcePropertyChanged)), _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003EAdd, _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003ERemove);
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableConcatCollection<T>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableConcatCollection<T>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableConcatCollection<T>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
		_sources = collectionChangedSources.ToArray();
		IList<T>[] sources = _sources;
		foreach (IList<T> list in sources)
		{
			Items.AddRange(list);
			_lastCounts[list] = list.Count;
			_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Subscribe((INotifyCollectionChanged)list);
			_003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter.Subscribe((INotifyPropertyChanged)list);
		}
	}

	private int GetCollectionOffset(IList<T> collection)
	{
		return _sources.TakeWhile((IList<T> c) => c != collection).Sum((IList<T> c) => c.Count);
	}

	private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		IList<T> list = (IList<T>)sender;
		int collectionOffset = GetCollectionOffset(list);
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			Items.InsertRange(e.NewStartingIndex + collectionOffset, e.NewItems.Cast<T>());
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, e.NewItems, e.NewStartingIndex + collectionOffset));
			break;
		case NotifyCollectionChangedAction.Remove:
			Items.RemoveRange(e.OldStartingIndex + collectionOffset, e.OldItems?.Count ?? 0);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, e.OldItems, e.OldStartingIndex + collectionOffset));
			break;
		case NotifyCollectionChangedAction.Replace:
			Items.RemoveRange(e.OldStartingIndex + collectionOffset, e.OldItems?.Count ?? 0);
			Items.InsertRange(e.OldStartingIndex + collectionOffset, e.NewItems.Cast<T>());
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, e.NewItems, e.OldItems, e.OldStartingIndex + collectionOffset));
			break;
		case NotifyCollectionChangedAction.Move:
			Items.RemoveRange(e.OldStartingIndex + collectionOffset, e.OldItems?.Count ?? 0);
			Items.InsertRange(e.NewStartingIndex + collectionOffset, e.OldItems.Cast<T>());
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, e.OldItems, e.NewStartingIndex + collectionOffset, e.OldStartingIndex + collectionOffset));
			break;
		case NotifyCollectionChangedAction.Reset:
		{
			bool flag = _lastCounts[list] > 0;
			bool flag2 = list.Count > 0;
			List<T> oldItem = null;
			if (flag)
			{
				oldItem = Items.GetRange(collectionOffset, _lastCounts[list]);
				Items.RemoveRange(collectionOffset, _lastCounts[list]);
			}
			if (flag2)
			{
				Items.InsertRange(collectionOffset, list);
			}
			if (Items.Count == list.Count)
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
			else if (flag && flag2)
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, list, oldItem, collectionOffset));
			}
			else if (flag)
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list, collectionOffset));
			}
			else if (flag2)
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, collectionOffset));
			}
			break;
		}
		}
	}

	private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Count")
		{
			IList<T> list = (IList<T>)sender;
			_lastCounts[list] = list.Count;
		}
		OnPropertyChanged(e);
	}

	private void _003EWeakEvents_003EUnsubscribe()
	{
		_003EPropertyChanged_003EOnSourcePropertyChanged_003EAdapter.Release();
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Release();
	}

	void IWeakEventHandlerFodyWeakEventTarget.Unsubscribe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in >WeakEvents>Unsubscribe
		this._003EWeakEvents_003EUnsubscribe();
	}

	~ObservableConcatCollection()
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

	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private static void _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003EAdd([In] INotifyPropertyChanged source, [In] PropertyChangedEventHandler handler)
	{
		source.PropertyChanged += handler;
	}

	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private static void _003EPropertyChanged_003EOnSourcePropertyChanged_0021_003ERemove([In] INotifyPropertyChanged source, [In] PropertyChangedEventHandler handler)
	{
		source.PropertyChanged -= handler;
	}
}
