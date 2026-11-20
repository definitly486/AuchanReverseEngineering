using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Akavache;

internal static class ExceptionHelper
{
	public static IObservable<T> ObservableThrowKeyNotFoundException<T>(string key, Exception? innerException = null)
	{
		return Observable.Throw<T>(new KeyNotFoundException("The given key '" + key + "' was not present in the cache.", innerException));
	}

	public static IObservable<T> ObservableThrowObjectDisposedException<T>(string obj, Exception? innerException = null)
	{
		return Observable.Throw<T>(new ObjectDisposedException("The cache '" + obj + "' was disposed.", innerException));
	}
}
