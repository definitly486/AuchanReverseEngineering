using System;
using System.Collections.Generic;

namespace Xamarin.Android.Net;

internal sealed class AuthDigestHeaderParser
{
	private static readonly Dictionary<string, string?> keywords = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		["realm"] = null,
		["opaque"] = null,
		["nonce"] = null,
		["algorithm"] = null,
		["qop"] = null
	};

	private string header;

	private int length;

	private int pos;

	public string? Realm => keywords["realm"];

	public string? Opaque => keywords["opaque"];

	public string? Nonce => keywords["nonce"];

	public string? Algorithm => keywords["algorithm"];

	public string? QOP => keywords["qop"];

	public AuthDigestHeaderParser(string? header)
	{
		this.header = header?.Trim() ?? string.Empty;
	}

	public bool Parse()
	{
		if (header == null || !header.StartsWith("digest ", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		pos = "digest".Length;
		length = header.Length;
		while (pos < length)
		{
			if (!GetKeywordAndValue(out string key, out string value))
			{
				return false;
			}
			SkipWhitespace();
			if (pos < length && header[pos] == ',')
			{
				pos++;
			}
			if (keywords.ContainsKey(key))
			{
				if (keywords[key] != null)
				{
					return false;
				}
				keywords[key] = value;
			}
		}
		if (Realm == null || Nonce == null)
		{
			return false;
		}
		return true;
	}

	private void SkipWhitespace()
	{
		char c = ' ';
		while (pos < length && (c == ' ' || c == '\t' || c == '\r' || c == '\n'))
		{
			c = header[pos++];
		}
		pos--;
	}

	private string GetKey()
	{
		SkipWhitespace();
		int num = pos;
		while (pos < length && header[pos] != '=')
		{
			pos++;
		}
		return header.Substring(num, pos - num).Trim().ToLowerInvariant();
	}

	private bool GetKeywordAndValue(out string key, out string? value)
	{
		value = null;
		key = GetKey();
		if (pos >= length)
		{
			return false;
		}
		SkipWhitespace();
		if (pos + 1 >= length || header[pos++] != '=')
		{
			return false;
		}
		SkipWhitespace();
		if (pos + 1 >= length)
		{
			return false;
		}
		bool flag = false;
		if (header[pos] == '"')
		{
			pos++;
			flag = true;
		}
		int num = pos;
		if (flag)
		{
			pos = header.IndexOf('"', pos);
			if (pos == -1)
			{
				return false;
			}
		}
		else
		{
			char c;
			do
			{
				c = header[pos];
			}
			while (c != ',' && c != ' ' && c != '\t' && c != '\r' && c != '\n' && ++pos < length);
			if (pos >= length && num == pos)
			{
				return false;
			}
		}
		value = header.Substring(num, pos - num);
		pos += ((!flag) ? 1 : 2);
		return true;
	}
}
