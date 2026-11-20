using System;
using System.Collections.Specialized;
using System.Reactive.Linq;

namespace Auchan.Common.Extensions;

public static class RxNotifyCollectionChangedExtensions
{
	public static IObservable<NotifyCollectionChangedEventArgs> CollectionChangedAsObservable<T>(this T source) where T : INotifyCollectionChanged
	{
		return Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>((Action<NotifyCollectionChangedEventArgs> h) => delegate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			h(e);
		}, delegate(NotifyCollectionChangedEventHandler h)
		{
			source.CollectionChanged += h;
		}, delegate(NotifyCollectionChangedEventHandler h)
		{
			source.CollectionChanged -= h;
		});
	}
}
