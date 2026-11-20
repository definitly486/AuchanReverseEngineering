using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Java.Net;

namespace Xamarin.Android.Net;

internal sealed class AuthDigestSession
{
	private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

	private DateTime lastUse = DateTime.UtcNow;

	private int _nc = 1;

	private HashAlgorithm? hash;

	private AuthDigestHeaderParser? parser;

	private string? _cnonce;

	public string? Algorithm => parser?.Algorithm;

	public string? Realm => parser?.Realm;

	public string? Nonce => parser?.Nonce;

	public string? Opaque => parser?.Opaque;

	public string? QOP => parser?.QOP;

	public string CNonce
	{
		get
		{
			if (_cnonce == null)
			{
				byte[] array = new byte[15];
				rng.GetBytes(array);
				_cnonce = Convert.ToBase64String(array);
				Array.Clear(array, 0, array.Length);
			}
			return _cnonce;
		}
	}

	public DateTime LastUse => lastUse;

	public bool Parse(string challenge)
	{
		parser = new AuthDigestHeaderParser(challenge);
		if (!parser.Parse())
		{
			return false;
		}
		if (parser.Algorithm == null || parser.Algorithm.StartsWith("MD5", StringComparison.OrdinalIgnoreCase))
		{
			hash = MD5.Create();
		}
		return true;
	}

	private string? HashToHexString(string toBeHashed)
	{
		if (hash == null)
		{
			return null;
		}
		hash.Initialize();
		byte[] array = hash.ComputeHash(Encoding.ASCII.GetBytes(toBeHashed));
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
		}
		return stringBuilder.ToString();
	}

	private string? HA1(string username, string password)
	{
		string toBeHashed = $"{username}:{Realm}:{password}";
		if (string.Compare(Algorithm, "md5-sess", StringComparison.OrdinalIgnoreCase) == 0)
		{
			toBeHashed = $"{HashToHexString(toBeHashed)}:{Nonce}:{CNonce}";
		}
		return HashToHexString(toBeHashed);
	}

	private string? HA2(HttpURLConnection webRequest)
	{
		Uri uri = new Uri(webRequest.URL?.ToString());
		string toBeHashed = webRequest.RequestMethod + ":" + uri.PathAndQuery;
		_ = QOP == "auth-int";
		return HashToHexString(toBeHashed);
	}

	private string? Response(string username, string password, HttpURLConnection webRequest)
	{
		string text = FormattableString.Invariant($"{HA1(username, password)}:{Nonce}:");
		if (QOP != null)
		{
			text += FormattableString.Invariant($"{_nc:X8}:{CNonce}:{QOP}:");
		}
		text += HA2(webRequest);
		return HashToHexString(text);
	}

	public Authorization? Authenticate(HttpURLConnection request, ICredentials credentials)
	{
		if (parser == null)
		{
			throw new InvalidOperationException();
		}
		if (request == null)
		{
			return null;
		}
		lastUse = DateTime.Now;
		Uri uri = new Uri(request.URL?.ToString());
		NetworkCredential credential = credentials.GetCredential(uri, "digest");
		if (credential == null)
		{
			return null;
		}
		string userName = credential.UserName;
		if (string.IsNullOrEmpty(userName))
		{
			return null;
		}
		string password = credential.Password;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(FormattableString.Invariant($"Digest username=\"{userName}\", "));
		stringBuilder.Append(FormattableString.Invariant($"realm=\"{Realm}\", "));
		stringBuilder.Append(FormattableString.Invariant($"nonce=\"{Nonce}\", "));
		stringBuilder.Append(FormattableString.Invariant($"uri=\"{uri.PathAndQuery}\", "));
		if (Algorithm != null)
		{
			stringBuilder.Append(FormattableString.Invariant($"algorithm=\"{Algorithm}\", "));
		}
		stringBuilder.Append(FormattableString.Invariant($"response=\"{Response(userName, password, request)}\", "));
		if (QOP != null)
		{
			stringBuilder.Append(FormattableString.Invariant($"qop=\"{QOP}\", "));
		}
		lock (this)
		{
			if (QOP != null)
			{
				stringBuilder.Append(FormattableString.Invariant($"nc={_nc:X8}, "));
				_nc++;
			}
		}
		if (CNonce != null)
		{
			stringBuilder.Append(FormattableString.Invariant($"cnonce=\"{CNonce}\", "));
		}
		if (Opaque != null)
		{
			stringBuilder.Append(FormattableString.Invariant($"opaque=\"{Opaque}\", "));
		}
		stringBuilder.Length -= 2;
		return new Authorization(stringBuilder.ToString());
	}
}
