using System.Collections.Generic;
using System.Net.Http;

namespace Auchan.Common.Networking;

public static class HeaderInjectorExtensions
{
	public static void Inject(this IHeaderInjector injector, HttpRequestMessage request)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = request.RequestUri?.AbsoluteUri;
		if (string.IsNullOrEmpty(text) || !injector.Inject(text, dictionary))
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			request.Headers.Add(item.Key, item.Value);
		}
	}

	public static void Inject(this IHeaderInjector2 injector, HttpRequestMessage request)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string url = request.RequestUri?.AbsoluteUri;
		injector.Inject(url, dictionary);
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			request.Headers.Add(item.Key, item.Value);
		}
	}
}
