using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Linq;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using EBind;

namespace Auchan.Android.Extensions;

public static class ObservableExtensions
{
	public static void SafeSubscribe<T>(this IObservable<T> observable, Action<T> action, ILifecycleOwner lifecycleOwner)
	{
		observable.ObserveOn(MainThread.Scheduler).Subscribe(action).AutoDisposeOnDestroy(lifecycleOwner);
	}

	public static void SafeSubscribeToCollectionChanged<TItem>(this ObservableRangeCollection<TItem> observableRangeCollection, Action<NotifyCollectionChangedEventArgs> action, ILifecycleOwner lifecycleOwner)
	{
		RxTaskExtensions.StartWithDefault(observableRangeCollection.CollectionChangedAsObservable()).ObserveOn(MainThread.Scheduler).Subscribe(action)
			.AutoDisposeOnDestroy(lifecycleOwner);
	}

	public static void SafeSubscribe<T>(this IObservable<T> observable, Action<T> action, ICollection<IDisposable> disposables)
	{
		observable.ObserveOn(MainThread.Scheduler).Subscribe(action).AddTo(disposables);
	}

	public static void SubscribeToCollectionChanged<TItem>(this ObservableCollection<TItem> collection, Action<NotifyCollectionChangedEventArgs> action, ILifecycleOwner lifecycleOwner)
	{
		collection.CollectionChanged += new DisposableDelegate<NotifyCollectionChangedEventHandler>(delegate(object? o, NotifyCollectionChangedEventArgs e)
		{
			action(e);
		}, delegate(NotifyCollectionChangedEventHandler eh)
		{
			collection.CollectionChanged -= eh;
		}).AutoDisposeOnDestroy(lifecycleOwner);
	}
}
