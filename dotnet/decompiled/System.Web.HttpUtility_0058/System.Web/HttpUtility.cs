using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web.Util;

namespace System.Web;

public sealed class HttpUtility
{
	private sealed class HttpQSCollection : NameValueCollection
	{
		internal HttpQSCollection()
			: base(StringComparer.OrdinalIgnoreCase)
		{
		}

		public override string ToString()
		{
			int count = Count;
			if (count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			string[] allKeys = AllKeys;
			for (int i = 0; i < count; i++)
			{
				string text = allKeys[i];
				string[] values = GetValues(text);
				if (values == null)
				{
					continue;
				}
				string[] array = values;
				foreach (string str in array)
				{
					if (!string.IsNullOrEmpty(text))
					{
						stringBuilder.Append(UrlEncode(text)).Append('=');
					}
					stringBuilder.Append(UrlEncode(str)).Append('&');
				}
			}
			if (stringBuilder.Length <= 0)
			{
				return "";
			}
			return stringBuilder.ToString(0, stringBuilder.Length - 1);
		}
	}

	public static NameValueCollection ParseQueryString(string query)
	{
		return ParseQueryString(query, Encoding.UTF8);
	}

	public static NameValueCollection ParseQueryString(string query, Encoding encoding)
	{
		ArgumentNullException.ThrowIfNull(query, "query");
		ArgumentNullException.ThrowIfNull(encoding, "encoding");
		HttpQSCollection httpQSCollection = new HttpQSCollection();
		int length = query.Length;
		int num = (query.StartsWith('?') ? 1 : 0);
		if (length == num)
		{
			return httpQSCollection;
		}
		while (num <= length)
		{
			int num2 = -1;
			int num3 = -1;
			for (int i = num; i < length; i++)
			{
				if (num2 == -1 && query[i] == '=')
				{
					num2 = i + 1;
				}
				else if (query[i] == '&')
				{
					num3 = i;
					break;
				}
			}
			string name;
			if (num2 == -1)
			{
				name = null;
				num2 = num;
			}
			else
			{
				name = UrlDecode(query.AsSpan(num, num2 - num - 1), encoding);
			}
			if (num3 < 0)
			{
				num3 = query.Length;
			}
			num = num3 + 1;
			string value = UrlDecode(query.AsSpan(num2, num3 - num2), encoding);
			httpQSCollection.Add(name, value);
		}
		return httpQSCollection;
	}

	[return: NotNullIfNotNull("s")]
	public static string? HtmlDecode(string? s)
	{
		return HttpEncoder.HtmlDecode(s);
	}

	[return: NotNullIfNotNull("str")]
	public static string? UrlEncode(string? str)
	{
		return UrlEncode(str, Encoding.UTF8);
	}

	[return: NotNullIfNotNull("str")]
	public static string? UrlEncode(string? str, Encoding e)
	{
		if (str != null)
		{
			return Encoding.ASCII.GetString(UrlEncodeToBytes(str, e));
		}
		return null;
	}

	[return: NotNullIfNotNull("str")]
	public static byte[]? UrlEncodeToBytes(string? str, Encoding e)
	{
		if (str != null)
		{
			return HttpEncoder.UrlEncode(str, e);
		}
		return null;
	}

	private static string UrlDecode(ReadOnlySpan<char> str, Encoding e)
	{
		return HttpEncoder.UrlDecode(str, e);
	}
}
