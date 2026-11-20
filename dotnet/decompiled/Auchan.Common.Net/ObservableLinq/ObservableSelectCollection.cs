using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using _003C_003EWeakEventHandler;

namespace ObservableLinq;

internal class ObservableSelectCollection<TSource, TResult> : ObservableCollection<TResult>, IWeakEventHandlerFodyWeakEventTarget
{
	private readonly Func<TSource, TResult> _selector;

	private readonly IList<TSource> _source;

	[NonSerialized]
	[GeneratedCode("WeakEventHandler.Fody", "1.0")]
	private readonly WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableSelectCollection<TSource, TResult>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler> _003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter;

	protected new List<TResult> Items => (List<TResult>)base.Items;

	public unsafe ObservableSelectCollection(ObservableCollection<TSource> source, Func<TSource, TResult> selector)
		: this((IList<TSource>)source, selector)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableSelectCollection<TSource, TResult>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableSelectCollection<TSource, TResult>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableSelectCollection<TSource, TResult>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	public unsafe ObservableSelectCollection(ReadOnlyObservableCollection<TSource> source, Func<TSource, TResult> selector)
		: this((IList<TSource>)source, selector)
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableSelectCollection<TSource, TResult>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableSelectCollection<TSource, TResult>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableSelectCollection<TSource, TResult>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
	}

	private unsafe ObservableSelectCollection(IList<TSource> collectionChangedSource, Func<TSource, TResult> selector)
		: base(collectionChangedSource.Select(selector))
	{
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter = new WeakEventHandlerFodyWeakEventAdapter<INotifyCollectionChanged, ObservableSelectCollection<TSource, TResult>, NotifyCollectionChangedEventArgs, NotifyCollectionChangedEventHandler>(this, new Action<ObservableSelectCollection<TSource, TResult>, object, NotifyCollectionChangedEventArgs>(null, (nint)__ldftn(ObservableSelectCollection<TSource, TResult>.OnSourceCollectionChanged)), _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003EAdd, _003ECollectionChanged_003EOnSourceCollectionChanged_0021_003ERemove);
		_selector = selector;
		_source = collectionChangedSource;
		_003ECollectionChanged_003EOnSourceCollectionChanged_003EAdapter.Subscribe((INotifyCollectionChanged)_source);
	}

	private void OnSourceCollectionAddEvent(NotifyCollectionChangedEventArgs e)
	{
		List<TResult> list = e.NewItems.Cast<TSource>().Select(_selector).ToList();
		Items.InsertRange(e.NewStartingIndex, list);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list, e.NewStartingIndex));
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
		List<TResult> range = Items.GetRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		Items.RemoveRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		Items.InsertRange(e.NewStartingIndex, range);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, range, e.NewStartingIndex, e.OldStartingIndex));
	}

	private void OnSourceCollectionRemoveEvent(NotifyCollectionChangedEventArgs e)
	{
		List<TResult> range = Items.GetRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		Items.RemoveRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, range, e.OldStartingIndex));
	}

	private void OnSourceCollectionReplaceEvent(NotifyCollectionChangedEventArgs e)
	{
		List<TResult> range = Items.GetRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		List<TResult> list = e.NewItems.Cast<TSource>().Select(_selector).ToList();
		Items.RemoveRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
		Items.InsertRange(e.OldStartingIndex, list);
		if (e.OldItems?.Count != e.NewItems.Count)
		{
			OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		}
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, list, range, e.OldStartingIndex));
	}

	private void OnSourceCollectionResetEvent()
	{
		bool num = Items.Count != _source.Count;
		Items.Clear();
		Items.AddRange(_source.Select(_selector));
		if (num)
		{
			OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.CountPropertyChanged);
		}
		OnPropertyChanged(System.Collections.ObjectModel.EventArgsCache.IndexerPropertyChanged);
		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
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

	~ObservableSelectCollection()
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
