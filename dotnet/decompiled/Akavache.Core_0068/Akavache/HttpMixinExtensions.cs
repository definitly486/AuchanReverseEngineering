using System;
using System.Collections.Generic;
using System.Net.Http;
using Splat;

namespace Akavache;

public static class HttpMixinExtensions
{
	private static IAkavacheHttpMixin HttpMixin => Locator.Current.GetService<IAkavacheHttpMixin>() ?? throw new InvalidOperationException("Unable to resolve IAkavacheHttpMixin, probably Akavache is not initialized.");

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, new Uri(url), headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, url, headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, key, new Uri(url), headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, key, url, headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, HttpMethod method, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, method, new Uri(url), headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, HttpMethod method, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, method, url, headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, HttpMethod method, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, method, key, new Uri(url), headers, fetchAlways, absoluteExpiration);
	}

	public static IObservable<byte[]> DownloadUrl(this IBlobCache blobCache, HttpMethod method, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		return HttpMixin.DownloadUrl(blobCache, method, key, url, headers, fetchAlways, absoluteExpiration);
	}
}
