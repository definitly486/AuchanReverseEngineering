using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Auchan.Common.Extensions;

public static class StringExtensions
{
	private static readonly List<string> SENSITIVE_KEYWORDS = new List<string>
	{
		"x-token-cmd", "postApiKey", "post_api_key", "partnerId", "pin", "secret", "pass", "auth", "authorization", "bearer",
		"udid", "accessToken", "access_token", "Authorization", "session_id", "device_id", "deviceId", "username", "password", "email_address",
		"email", "address", "mobile", "phone", "phone_number", "apiKey", "api-key", "api_key", "key", "cvc",
		"cvc_code", "card", "card_number", "CardNumber", "virtual_card_number", "androidKey", "iosKey"
	};

	private static Regex? _cardFormatRegEx;

	private static Regex CardFormatRegEx => _cardFormatRegEx ?? (_cardFormatRegEx = new Regex("^\\d{13}$", RegexOptions.None, TimeSpan.FromSeconds(60L)));

	private static string JoinedSensitiveKeywords { get; } = string.Join("|", SENSITIVE_KEYWORDS.Select(Regex.Escape));

	private static Regex JsonSanitizeRegex { get; } = new Regex("\"(?<key>" + JoinedSensitiveKeywords + ")\"(?<sep>\\s*:\\s*)\"(?<val>(?:\\\\.|[^\"\\\\])*)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(10L));

	private static Regex EscapedJsonSanitizeRegex { get; } = new Regex("\\\\\"(?<key>" + JoinedSensitiveKeywords + ")\\\\\"(?<sep>\\s*:\\s*)\\\\\"(?<val>(?:\\\\.|[^\"\\\\])*)\\\\\"", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(10L));

	private static Regex QuerySanitizeRegex { get; } = new Regex("(?<prefix>^|[^\\w])(?<key>" + JoinedSensitiveKeywords + ")(?<sep>\\s*[:=]\\s*)(?<val>(?:(?<quote>\")(?:(?:\\\\.)|[^\"\\\\])*(?:\")|(?<quote>')(?:(?:\\\\.)|[^'\\\\])*(?:')|[^&\\s]+))", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(10L));

	public static string FirstCharToUpper(this string input)
	{
		if (input != null)
		{
			if (input == "")
			{
				return string.Empty;
			}
			return input.First().ToString().ToUpper() + input.Substring(1);
		}
		return string.Empty;
	}

	public static string ExtractCardNumber(this string input)
	{
		if (input.Length > 16)
		{
			return input.Substring(3, 13);
		}
		return input;
	}

	public static string RemoveOddWhiteSpacesAndDots(this string input)
	{
		Regex regex = new Regex("^[ ]?([^ ]+[ ])*[^ ]*$", RegexOptions.None, TimeSpan.FromSeconds(60L));
		if (input.Contains('.'))
		{
			input = input.Replace(".", " ");
		}
		if (input.FirstOrDefault() == ' ')
		{
			input = input.TrimStart(' ');
		}
		if (!regex.IsMatch(input))
		{
			input = Regex.Replace(input, "\\s+", " ", RegexOptions.None, TimeSpan.FromSeconds(60L));
		}
		return input;
	}

	public static bool EqualsIgnoreCase(this string source, string toCheck)
	{
		return source.Equals(toCheck, StringComparison.OrdinalIgnoreCase);
	}

	public static bool ContainsIgnoreCase(this string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return source.IndexOf(toCheck, comp) >= 0;
	}

	public static string GetCardNumberFormatted(this string rawNumber)
	{
		if (string.IsNullOrEmpty(rawNumber))
		{
			return string.Empty;
		}
		if (rawNumber.Length > 13)
		{
			return rawNumber;
		}
		return Regex.Replace(rawNumber, "(\\w{4})(\\w{4})(\\w{4})(\\w{1})", "$1 $2 $3 $4", RegexOptions.None, TimeSpan.FromSeconds(60L));
	}

	public static bool IsCardNumberFormat(this string rawData)
	{
		string input = rawData.Replace(" ", string.Empty).Substring(3, 13);
		return CardFormatRegEx.Match(input).Success;
	}

	public static string GetPhoneNumberFormatted(this string rawNumber, bool withDashes = false, bool obscured = false)
	{
		if (string.IsNullOrEmpty(rawNumber))
		{
			return string.Empty;
		}
		if (rawNumber.Length > 11)
		{
			return rawNumber;
		}
		if (obscured && rawNumber.Length > 8)
		{
			char[] array = rawNumber.ToCharArray();
			for (int i = 4; i < 9; i++)
			{
				array[i] = '•';
			}
			rawNumber = new string(array);
		}
		string replacement = (withDashes ? "$1 $2 $3-$4-$5" : "$1 $2 $3 $4 $5");
		return Regex.Replace(rawNumber, "(\\w{1})(\\w{3})([0-9|•]{3})([0-9|•]{2})(\\w{2})", replacement, RegexOptions.None, TimeSpan.FromSeconds(60L));
	}

	public static string Last(this string input, int number)
	{
		if (number < input.Length)
		{
			return input.Substring(input.Length - number);
		}
		return input;
	}

	public static bool ComparePhoneNumbers(this string pn1, string pn2)
	{
		return ((pn1.Length > 10) ? pn1.Last(10) : pn1).Replace("-", "").Replace("(", "").Replace(")", "")
			.Replace(" ", "") == ((pn2.Length > 10) ? pn2.Last(10) : pn2).Replace("-", "").Replace("(", "").Replace(")", "")
			.Replace(" ", "");
	}

	public static T ToEnum<T>(this string str) where T : Enum
	{
		Type typeFromHandle = typeof(T);
		string[] names = Enum.GetNames(typeFromHandle);
		foreach (string text in names)
		{
			FieldInfo field = typeFromHandle.GetField(text);
			if (!(field == null))
			{
				EnumMemberAttribute enumMemberAttribute = ((EnumMemberAttribute[])field.GetCustomAttributes(typeof(EnumMemberAttribute), inherit: true)).SingleOrDefault();
				if (enumMemberAttribute != null && enumMemberAttribute.Value != null && enumMemberAttribute.Value.EqualsIgnoreCase(str))
				{
					return (T)Enum.Parse(typeFromHandle, text);
				}
			}
		}
		T val = default(T);
		if (val == null)
		{
			throw new InvalidCastException();
		}
		return val;
	}

	public static List<int> AllIndexesOf(this string str, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		int num;
		for (num = 0; num < str.Length; num += value.Length)
		{
			num = str.IndexOf(value, num, StringComparison.OrdinalIgnoreCase);
			if (num == -1)
			{
				return list;
			}
			list.Add(num);
		}
		return new List<int>();
	}

	public static string Encode(this string str)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
	}

	public static string Decode(this string str)
	{
		byte[] bytes = Convert.FromBase64String(str);
		return Encoding.UTF8.GetString(bytes);
	}

	public static string Substring(this string source, string from, string to)
	{
		int num = source.IndexOf(from);
		if (num == -1)
		{
			return string.Empty;
		}
		int num2 = source.IndexOf(to);
		if (num2 == -1)
		{
			return source.Substring(num);
		}
		return source[(num + from.Length)..num2];
	}

	public static string Format(this string str, params string[] args)
	{
		return string.Format(str, args);
	}

	public static string SubstringSafe(this string source, int startIndex)
	{
		startIndex = Math.Max(startIndex, 0);
		if (source.Length - 1 > startIndex)
		{
			return source.Substring(startIndex);
		}
		return string.Empty;
	}

	public static string SubstringSafe(this string source, int startIndex, int length)
	{
		startIndex = Math.Max(startIndex, 0);
		length = Math.Min(length, source.Length - startIndex);
		if (source.Length - 1 > startIndex)
		{
			return source.Substring(startIndex, length);
		}
		return string.Empty;
	}

	public static string InsertMultiple(this string str, int interval, string insert)
	{
		if (str.Length < interval)
		{
			return str;
		}
		int num = (str.Length - 1) / interval;
		for (int i = 0; i < num; i++)
		{
			str = str.Insert(str.Length - interval * (i + 1), insert);
		}
		return str;
	}

	public static string ReplacePercentIfNeeded(this string text)
	{
		if (text.Contains('℅'))
		{
			text = text.Replace("℅", "%");
		}
		return text;
	}

	public static HttpMethod ToHttpMethod(this string str)
	{
		if (str.ContainsIgnoreCase("get"))
		{
			return HttpMethod.Get;
		}
		if (str.ContainsIgnoreCase("post"))
		{
			return HttpMethod.Post;
		}
		if (str.ContainsIgnoreCase("put"))
		{
			return HttpMethod.Put;
		}
		if (str.ContainsIgnoreCase("delete"))
		{
			return HttpMethod.Delete;
		}
		if (str.ContainsIgnoreCase("head"))
		{
			return HttpMethod.Head;
		}
		if (str.ContainsIgnoreCase("options"))
		{
			return HttpMethod.Options;
		}
		if (str.ContainsIgnoreCase("connect"))
		{
			return HttpMethod.Connect;
		}
		if (str.ContainsIgnoreCase("patch"))
		{
			return HttpMethod.Patch;
		}
		if (str.ContainsIgnoreCase("trace"))
		{
			return HttpMethod.Trace;
		}
		return HttpMethod.Get;
	}

	public static string Sanitize(this string str)
	{
		try
		{
			str = QuerySanitizeRegex.Replace(str, delegate(Match m)
			{
				string value = m.Groups["prefix"].Value;
				string value2 = m.Groups["key"].Value;
				string value3 = m.Groups["sep"].Value;
				string value4 = (m.Groups["quote"].Success ? m.Groups["quote"].Value : "");
				return $"{value}{value2}{value3}{value4}[REDACTED]{value4}";
			});
			str = EscapedJsonSanitizeRegex.Replace(str, (Match m) => $"\\\"{m.Groups["key"].Value}\\\"{m.Groups["sep"].Value}\\\"[REDACTED]\\\"");
			str = JsonSanitizeRegex.Replace(str, (Match m) => $"\"{m.Groups["key"].Value}\"{m.Groups["sep"].Value}\"[REDACTED]\"");
			return str;
		}
		catch (RegexMatchTimeoutException)
		{
			return "[REDACTED]";
		}
	}

	public static string TrimStart(this string @this, string str)
	{
		if (@this.StartsWith(str))
		{
			return @this.Substring(str.Length);
		}
		return @this;
	}
}
