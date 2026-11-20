using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Akavache;

public static class LoginMixin
{
	public static IObservable<Unit> SaveLogin(this ISecureBlobCache blobCache, string user, string password, string host = "default", DateTimeOffset? absoluteExpiration = null)
	{
		return blobCache.InsertObject("login:" + host, new Tuple<string, string>(user, password), absoluteExpiration);
	}

	public static IObservable<LoginInfo> GetLoginAsync(this ISecureBlobCache blobCache, string host = "default")
	{
		return from x in blobCache.GetObject<(string, string)>("login:" + host)
			select new LoginInfo(x);
	}

	public static IObservable<Unit> EraseLogin(this ISecureBlobCache blobCache, string host = "default")
	{
		return blobCache.InvalidateObject<(string, string)>("login:" + host);
	}
}
