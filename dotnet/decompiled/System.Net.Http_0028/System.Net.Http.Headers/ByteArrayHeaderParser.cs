using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal sealed class ByteArrayHeaderParser : HttpHeaderParser
{
	internal static readonly ByteArrayHeaderParser Parser = new ByteArrayHeaderParser();

	private ByteArrayHeaderParser()
		: base(supportsMultipleValues: false)
	{
	}

	public override string ToString(object value)
	{
		return Convert.ToBase64String((byte[])value);
	}

	public override bool TryParseValue([NotNullWhen(true)] string value, object storeValue, ref int index, [NotNullWhen(true)] out object parsedValue)
	{
		parsedValue = null;
		if (string.IsNullOrEmpty(value) || index == value.Length)
		{
			return false;
		}
		string s = value;
		if (index > 0)
		{
			s = value.Substring(index);
		}
		try
		{
			parsedValue = Convert.FromBase64String(s);
			index = value.Length;
			return true;
		}
		catch (FormatException)
		{
			if (!System.Net.NetEventSource.Log.IsEnabled())
			{
			}
		}
		return false;
	}
}
