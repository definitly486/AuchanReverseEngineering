using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Android.Runtime;
using Java.Net;

namespace Xamarin.Android.Net;

internal sealed class AuthModuleDigest : IAndroidAuthenticationModule
{
	private static readonly object cache_lock = new object();

	private static readonly Dictionary<int, AuthDigestSession> cache = new Dictionary<int, AuthDigestSession>();

	[CompilerGenerated]
	private readonly string _003CAuthenticationType_003Ek__BackingField = "Digest";

	[CompilerGenerated]
	private readonly bool _003CCanPreAuthenticate_003Ek__BackingField = true;

	public AuthenticationScheme Scheme { get; } = AuthenticationScheme.Digest;

	private static Dictionary<int, AuthDigestSession> Cache
	{
		get
		{
			lock (cache_lock)
			{
				CheckExpired(cache.Count);
			}
			return cache;
		}
	}

	private static void CheckExpired(int count)
	{
		if (count < 10)
		{
			return;
		}
		DateTime dateTime = DateTime.MaxValue;
		DateTime now = DateTime.Now;
		List<int> list = null;
		foreach (KeyValuePair<int, AuthDigestSession> item in cache)
		{
			AuthDigestSession value = item.Value;
			if (value.LastUse < dateTime && (value.LastUse - now).Ticks > 6000000000L)
			{
				dateTime = value.LastUse;
				if (list == null)
				{
					list = new List<int>();
				}
				list.Add(item.Key);
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (int item2 in list)
		{
			cache.Remove(item2);
		}
	}

	public Authorization? Authenticate(string challenge, HttpURLConnection request, ICredentials credentials)
	{
		if (credentials == null || challenge == null)
		{
			Logger.Log(LogLevel.Info, "monodroid-net-digest-auth", "No credentials or no challenge");
			return null;
		}
		if (challenge.Trim().IndexOf("digest", StringComparison.OrdinalIgnoreCase) == -1)
		{
			Logger.Log(LogLevel.Info, "monodroid-net-digest-auth", "Not a digest auth request");
			return null;
		}
		AuthDigestSession authDigestSession = new AuthDigestSession();
		if (!authDigestSession.Parse(challenge))
		{
			Logger.Log(LogLevel.Info, "monodroid-net-digest-auth", "Unable to parse challenge");
			return null;
		}
		int key = new Uri(request.URL?.ToString()).GetHashCode() ^ credentials.GetHashCode() ^ (authDigestSession.Nonce?.GetHashCode() ?? 1);
		AuthDigestSession value = null;
		bool flag = false;
		if (!Cache.TryGetValue(key, out value) || value == null)
		{
			flag = true;
		}
		if (flag)
		{
			value = authDigestSession;
		}
		else if (!value.Parse(challenge))
		{
			Logger.Log(LogLevel.Info, "monodroid-net-digest-auth", "Current DS failed to parse the challenge");
			return null;
		}
		if (flag)
		{
			Cache.Add(key, value);
		}
		return value.Authenticate(request, credentials);
	}
}
