using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Akavache;

public interface IAkavacheHttpMixin
{
	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);

	IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null);
}
