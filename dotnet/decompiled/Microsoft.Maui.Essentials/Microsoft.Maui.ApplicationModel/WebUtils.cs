using System;
using System.Collections.Generic;

namespace Microsoft.Maui.ApplicationModel;

internal static class WebUtils
{
	internal static IDictionary<string, string> ParseQueryString(Uri uri)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
		if (uri == null)
		{
			return dictionary;
		}
		if (!string.IsNullOrEmpty(uri.Query))
		{
			UnpackParameters(uri.Query.AsSpan(1), dictionary);
		}
		if (!string.IsNullOrEmpty(uri.Fragment))
		{
			UnpackParameters(uri.Fragment.AsSpan(1), dictionary);
		}
		return dictionary;
	}

	private static void UnpackParameters(ReadOnlySpan<char> query, Dictionary<string, string> parameters)
	{
		while (!query.IsEmpty)
		{
			int num = query.IndexOf('&');
			ReadOnlySpan<char> span;
			if (num >= 0)
			{
				span = query.Slice(0, num);
				query = query.Slice(num + 1);
			}
			else
			{
				span = query;
				query = default(ReadOnlySpan<char>);
			}
			if (span.IsEmpty)
			{
				continue;
			}
			int num2 = span.IndexOf('=');
			string stringToUnescape2;
			string stringToUnescape;
			if (num2 >= 0)
			{
				stringToUnescape = span.Slice(0, num2).ToString();
				ReadOnlySpan<char> readOnlySpan = span.Slice(num2 + 1);
				char[] array = new char[readOnlySpan.Length];
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					array[i] = ((readOnlySpan[i] == '+') ? ' ' : readOnlySpan[i]);
				}
				stringToUnescape2 = new string(array);
			}
			else
			{
				stringToUnescape = span.ToString();
				stringToUnescape2 = string.Empty;
			}
			stringToUnescape = Uri.UnescapeDataString(stringToUnescape);
			parameters[stringToUnescape] = Uri.UnescapeDataString(stringToUnescape2);
		}
	}

	internal static bool CanHandleCallback(Uri expectedUrl, Uri callbackUrl)
	{
		if (!callbackUrl.Scheme.Equals(expectedUrl.Scheme, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(expectedUrl.Host) && !callbackUrl.Host.Equals(expectedUrl.Host, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		return true;
	}
}
