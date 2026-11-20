using System.Collections.Generic;

namespace System.Net.Http;

internal sealed class PreAuthCredentialCache
{
	private Dictionary<CredentialCacheKey, NetworkCredential> _cache;

	public void Add(Uri uriPrefix, string authType, NetworkCredential cred)
	{
		CredentialCacheKey key = new CredentialCacheKey(uriPrefix, authType);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (_cache == null)
		{
			_cache = new Dictionary<CredentialCacheKey, NetworkCredential>();
		}
		_cache.Add(key, cred);
	}

	public void Remove(Uri uriPrefix, string authType)
	{
		if (_cache != null)
		{
			CredentialCacheKey key = new CredentialCacheKey(uriPrefix, authType);
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			_cache.Remove(key);
		}
	}

	public (Uri uriPrefix, NetworkCredential credential)? GetCredential(Uri uriPrefix, string authType)
	{
		if (_cache == null)
		{
			return null;
		}
		CredentialCacheHelper.TryGetCredential(_cache, uriPrefix, authType, out var mostSpecificMatchUri, out var mostSpecificMatch);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		if (mostSpecificMatch != null)
		{
			return (mostSpecificMatchUri, mostSpecificMatch);
		}
		return null;
	}
}
