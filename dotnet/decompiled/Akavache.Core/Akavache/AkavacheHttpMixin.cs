using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public class AkavacheHttpMixin : IAkavacheHttpMixin
{
	private static IAkavacheHttpClientFactory HttpFactoryClient => Locator.Current.GetService<IAkavacheHttpClientFactory>() ?? throw new InvalidOperationException("Unable to resolve IAkavacheHttpClientFactory, probably Akavache is not initialized.");

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		return blobCache.DownloadUrl(url, url, headers, fetchAlways, absoluteExpiration);
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		ArgumentNullException.ThrowIfNull(url, "url");
		return blobCache.DownloadUrl(url.ToString(), url, headers, fetchAlways, absoluteExpiration);
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		IObservable<byte[]> observable = MakeWebRequest(HttpMethod.Get, new Uri(url), headers).SelectMany((HttpResponseMessage x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
			select x);
		IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch(observable));
		IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
		connectableObservable.Connect();
		return connectableObservable;
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		IObservable<byte[]> observable = MakeWebRequest(HttpMethod.Get, url, headers).SelectMany((HttpResponseMessage x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
			select x);
		IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch(observable));
		IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
		connectableObservable.Connect();
		return connectableObservable;
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		return blobCache.DownloadUrl(method, url, url, headers, fetchAlways, absoluteExpiration);
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		ArgumentNullException.ThrowIfNull(url, "url");
		return blobCache.DownloadUrl(method, url.ToString(), url, headers, fetchAlways, absoluteExpiration);
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string key, string url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		IObservable<byte[]> observable = MakeWebRequest(method, new Uri(url), headers).SelectMany((HttpResponseMessage x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
			select x);
		IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch(observable));
		IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
		connectableObservable.Connect();
		return connectableObservable;
	}

	public IObservable<byte[]> DownloadUrl(IBlobCache blobCache, HttpMethod method, string key, Uri url, IDictionary<string, string>? headers = null, bool fetchAlways = false, DateTimeOffset? absoluteExpiration = null)
	{
		ArgumentNullException.ThrowIfNull(blobCache, "blobCache");
		IObservable<byte[]> observable = MakeWebRequest(method, url, headers).SelectMany((HttpResponseMessage x) => ProcessWebResponse(x, url, absoluteExpiration)).SelectMany((byte[] x) => from _ in blobCache.Insert(key, x, absoluteExpiration)
			select x);
		IObservable<byte[]> source = (fetchAlways ? observable : blobCache.Get(key).Catch(observable));
		IConnectableObservable<byte[]> connectableObservable = source.PublishLast();
		connectableObservable.Connect();
		return connectableObservable;
	}

	private static IObservable<HttpResponseMessage> MakeWebRequest(HttpMethod method, Uri uri, IDictionary<string, string>? headers = null, int retries = 3, TimeSpan? timeout = null)
	{
		return Observable.Defer(delegate
		{
			HttpClient client = HttpFactoryClient.CreateClient("AkavacheHttpMixin");
			HttpRequestMessage request = CreateWebRequest(method, uri, headers);
			return Observable.FromAsync(() => client.SendAsync(request), BlobCache.TaskpoolScheduler);
		}).Timeout(timeout ?? TimeSpan.FromSeconds(15L), BlobCache.TaskpoolScheduler).Retry(retries);
	}

	private static HttpRequestMessage CreateWebRequest(HttpMethod method, Uri uri, IDictionary<string, string>? headers)
	{
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
		if (headers != null)
		{
			foreach (KeyValuePair<string, string> header in headers)
			{
				httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
			}
		}
		return httpRequestMessage;
	}

	private static IObservable<byte[]> ProcessWebResponse(HttpResponseMessage response, string url, DateTimeOffset? absoluteExpiration)
	{
		if (!response.IsSuccessStatusCode)
		{
			string[] obj = new string[6] { "Invalid response: ", url, " reason ", response.ReasonPhrase, " with expiry: ", null };
			DateTimeOffset? dateTimeOffset = absoluteExpiration;
			obj[5] = dateTimeOffset.ToString();
			return Observable.Throw<byte[]>(new HttpRequestException(string.Concat(obj)));
		}
		return Observable.FromAsync(() => response.Content.ReadAsByteArrayAsync());
	}

	private static IObservable<byte[]> ProcessWebResponse(HttpResponseMessage response, Uri url, DateTimeOffset? absoluteExpiration)
	{
		return ProcessWebResponse(response, url.ToString(), absoluteExpiration);
	}
}
