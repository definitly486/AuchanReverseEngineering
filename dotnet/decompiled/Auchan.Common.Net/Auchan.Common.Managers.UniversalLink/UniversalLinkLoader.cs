using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Auchan.Common.Managers.UniversalLink;

public class UniversalLinkLoader
{
	private readonly ConcurrentDictionary<string, Uri> _fullLinkCache = new ConcurrentDictionary<string, Uri>();

	public Task<Uri?> TryGetFullLink(Uri initialUri)
	{
		if (initialUri.Segments.Length == 1)
		{
			string text = HttpUtility.ParseQueryString(initialUri.Query)["ref"];
			if (text == null)
			{
				return Task.FromResult<Uri>(null);
			}
			if (!_fullLinkCache.TryGetValue(text, out Uri value))
			{
				return RequestFullLink(initialUri);
			}
			return Task.FromResult(value);
		}
		return Task.FromResult(initialUri);
	}

	private async Task<Uri?> RequestFullLink(Uri shortUri)
	{
		string linkReference = HttpUtility.ParseQueryString(shortUri.Query)["ref"];
		if (linkReference == null)
		{
			return null;
		}
		Uri fullLink = null;
		HttpWebRequest httpWebRequest = WebRequest.CreateHttp(shortUri);
		httpWebRequest.Method = "HEAD";
		httpWebRequest.Timeout = 5000;
		httpWebRequest.AllowAutoRedirect = false;
		HttpWebResponse webResponse = null;
		try
		{
			webResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
			if (webResponse.StatusCode >= HttpStatusCode.MultipleChoices && webResponse.StatusCode <= (HttpStatusCode)399 && Uri.TryCreate(webResponse.Headers["Location"], UriKind.Absolute, out fullLink))
			{
				_fullLinkCache[linkReference] = fullLink;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			webResponse?.Dispose();
		}
		return fullLink;
	}
}
