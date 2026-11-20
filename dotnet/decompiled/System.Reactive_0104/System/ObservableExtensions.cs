using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;

namespace System;

public static class ObservableExtensions
{
	public static IDisposable Subscribe<T>(this IObservable<T> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return source.Subscribe(new AnonymousObserver<T>(Stubs<T>.Ignore, Stubs.Throw, Stubs.Nop));
	}

	public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (onNext == null)
		{
			throw new ArgumentNullException("onNext");
		}
		return source.Subscribe(new AnonymousObserver<T>(onNext, Stubs.Throw, Stubs.Nop));
	}

	public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (onNext == null)
		{
			throw new ArgumentNullException("onNext");
		}
		if (onError == null)
		{
			throw new ArgumentNullException("onError");
		}
		if (onCompleted == null)
		{
			throw new ArgumentNullException("onCompleted");
		}
		return source.Subscribe(new AnonymousObserver<T>(onNext, onError, onCompleted));
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static IDisposable SubscribeSafe<T>(this IObservable<T> source, IObserver<T> observer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (observer == null)
		{
			throw new ArgumentNullException("observer");
		}
		if (source is ObservableBase<T>)
		{
			return source.Subscribe(observer);
		}
		if (source is IProducer<T> producer)
		{
			return producer.SubscribeRaw(observer, enableSafeguard: false);
		}
		IDisposable result = Disposable.Empty;
		try
		{
			result = source.Subscribe(observer);
		}
		catch (Exception error)
		{
			observer.OnError(error);
		}
		return result;
	}
}
