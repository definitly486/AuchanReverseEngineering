using System;
using System.Collections.Generic;
using System.Reactive;

namespace Akavache;

public static class RelativeTimeMixin
{
	public static IObservable<Unit> Insert(this IBlobCache blobCache, string key, byte[] data, TimeSpan expiration)
	{
		if (blobCache != null)
		{
			return blobCache.Insert(key, data, blobCache.Scheduler.Now + expiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> InsertObject<T>(this IBlobCache blobCache, string key, T value, TimeSpan expiration)
	{
		if (blobCache != null)
		{
			return blobCache.InsertObject(key, value, blobCache.Scheduler.Now + expiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string url, TimeSpan expiration, Dictionary<string, string>? headers = null, bool fetchAlways = false)
	{
		if (blobCache != null)
		{
			return blobCache.DownloadUrl(url, headers, fetchAlways, blobCache.Scheduler.Now + expiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, Uri url, TimeSpan expiration, Dictionary<string, string>? headers = null, bool fetchAlways = false)
	{
		if (blobCache != null)
		{
			return blobCache.DownloadUrl(url, headers, fetchAlways, blobCache.Scheduler.Now + expiration);
		}
		throw new ArgumentNullException("blobCache");
	}

	public static IObservable<Unit> SaveLogin(this ISecureBlobCache blobCache, string user, string password, string host, TimeSpan expiration)
	{
		if (blobCache != null)
		{
			return blobCache.SaveLogin(user, password, host, blobCache.Scheduler.Now + expiration);
		}
		throw new ArgumentNullException("blobCache");
	}
}
