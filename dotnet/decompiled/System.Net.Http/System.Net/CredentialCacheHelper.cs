using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Net;

internal static class CredentialCacheHelper
{
	public static bool TryGetCredential(Dictionary<CredentialCacheKey, NetworkCredential> cache, Uri uriPrefix, string authType, [NotNullWhen(true)] out Uri mostSpecificMatchUri, [NotNullWhen(true)] out NetworkCredential mostSpecificMatch)
	{
		int num = -1;
		mostSpecificMatch = null;
		mostSpecificMatchUri = null;
		if (cache.Count == 0)
		{
			return false;
		}
		int num2 = uriPrefix.AbsolutePath.LastIndexOf('/');
		foreach (KeyValuePair<CredentialCacheKey, NetworkCredential> item in cache)
		{
			item.Deconstruct(out var key, out var value);
			CredentialCacheKey credentialCacheKey = key;
			NetworkCredential networkCredential = value;
			int uriPrefixLength = credentialCacheKey.UriPrefixLength;
			if (uriPrefixLength > num && credentialCacheKey.Match(uriPrefix, num2, authType))
			{
				num = uriPrefixLength;
				mostSpecificMatch = networkCredential;
				mostSpecificMatchUri = credentialCacheKey.UriPrefix;
				if (num2 == uriPrefixLength)
				{
					break;
				}
			}
		}
		return mostSpecificMatch != null;
	}
}
