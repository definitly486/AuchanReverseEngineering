using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace System.Web.Util;

internal static class HttpEncoder
{
	private ref struct UrlDecoder
	{
		private int _numChars;

		private readonly Span<char> _charBuffer;

		private int _numBytes;

		private readonly Span<byte> _byteBuffer;

		private readonly Encoding _encoding;

		private void FlushBytes()
		{
			if (_numBytes > 0)
			{
				_numChars += _encoding.GetChars(_byteBuffer.Slice(0, _numBytes), _charBuffer.Slice(_numChars));
				_numBytes = 0;
			}
		}

		internal UrlDecoder(Span<char> charBuffer, Span<byte> byteBuffer, Encoding encoding)
		{
			_numChars = 0;
			_numBytes = 0;
			_charBuffer = charBuffer;
			_byteBuffer = byteBuffer;
			_encoding = encoding;
		}

		internal void AddChar(char ch)
		{
			if (_numBytes > 0)
			{
				FlushBytes();
			}
			_charBuffer[_numChars++] = ch;
		}

		internal void AddByte(byte b)
		{
			_byteBuffer[_numBytes++] = b;
		}

		internal string GetString()
		{
			if (_numBytes > 0)
			{
				FlushBytes();
			}
			Span<char> span = _charBuffer.Slice(0, _numChars);
			for (int i = ((ReadOnlySpan<char>)span).IndexOfAnyInRange('\ud800', '\udfff'); (uint)i < (uint)span.Length; i++)
			{
				if (char.IsHighSurrogate(span[i]))
				{
					if ((uint)(i + 1) >= (uint)span.Length || !char.IsLowSurrogate(span[i + 1]))
					{
						span[i] = (char)Rune.ReplacementChar.Value;
					}
					else
					{
						i++;
					}
				}
				else if (char.IsLowSurrogate(span[i]))
				{
					span[i] = (char)Rune.ReplacementChar.Value;
				}
			}
			return span.ToString();
		}
	}

	private static readonly SearchValues<byte> s_urlSafeBytes = SearchValues.Create("!()*-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz"u8);

	private static readonly SearchValues<char> s_invalidJavaScriptChars = SearchValues.Create("\0\u0001\u0002\u0003\u0004\u0005\u0006\a\b\t\n\v\f\r\u000e\u000f\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\u001c\u001d\u001e\u001f\"&'<>\\\u0085\u2028\u2029".AsSpan());

	[return: NotNullIfNotNull("value")]
	internal static string HtmlDecode(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return WebUtility.HtmlDecode(value);
		}
		return value;
	}

	internal static string UrlDecode(ReadOnlySpan<char> value, Encoding encoding)
	{
		if (value.IsEmpty)
		{
			return string.Empty;
		}
		int length = value.Length;
		UrlDecoder urlDecoder;
		if (length <= 256)
		{
			Span<char> charBuffer = stackalloc char[256];
			Span<byte> byteBuffer = stackalloc byte[256];
			urlDecoder = new UrlDecoder(charBuffer, byteBuffer, encoding);
		}
		else
		{
			urlDecoder = new UrlDecoder(new char[length], new byte[length], encoding);
		}
		UrlDecoder urlDecoder2 = urlDecoder;
		for (int i = 0; i < length; i++)
		{
			char c = value[i];
			switch (c)
			{
			case '+':
				c = ' ';
				break;
			case '%':
				if (i >= length - 2)
				{
					break;
				}
				if (value[i + 1] == 'u' && i < length - 5)
				{
					int num = System.HexConverter.FromChar(value[i + 2]);
					int num2 = System.HexConverter.FromChar(value[i + 3]);
					int num3 = System.HexConverter.FromChar(value[i + 4]);
					int num4 = System.HexConverter.FromChar(value[i + 5]);
					if ((num | num2 | num3 | num4) != 255)
					{
						c = (char)((num << 12) | (num2 << 8) | (num3 << 4) | num4);
						i += 5;
						urlDecoder2.AddChar(c);
						continue;
					}
				}
				else
				{
					int num5 = System.HexConverter.FromChar(value[i + 1]);
					int num6 = System.HexConverter.FromChar(value[i + 2]);
					if ((num5 | num6) != 255)
					{
						byte b = (byte)((num5 << 4) | num6);
						i += 2;
						urlDecoder2.AddByte(b);
						continue;
					}
				}
				break;
			}
			if ((c & 0xFF80) == 0)
			{
				urlDecoder2.AddByte((byte)c);
			}
			else
			{
				urlDecoder2.AddChar(c);
			}
		}
		return urlDecoder2.GetString();
	}

	private static byte[] UrlEncode(ReadOnlySpan<byte> bytes)
	{
		if (!NeedsEncoding(bytes, out var cUnsafe))
		{
			return bytes.ToArray();
		}
		return UrlEncode(bytes, cUnsafe);
	}

	private static byte[] UrlEncode(ReadOnlySpan<byte> bytes, int cUnsafe)
	{
		byte[] array = new byte[bytes.Length + cUnsafe * 2];
		int num = 0;
		ReadOnlySpan<byte> readOnlySpan = bytes;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			if (s_urlSafeBytes.Contains(b))
			{
				array[num++] = b;
				continue;
			}
			if (b == 32)
			{
				array[num++] = 43;
				continue;
			}
			array[num++] = 37;
			array[num++] = (byte)System.HexConverter.ToCharLower(b >> 4);
			array[num++] = (byte)System.HexConverter.ToCharLower(b);
		}
		return array;
	}

	private static bool NeedsEncoding(ReadOnlySpan<byte> bytes, out int cUnsafe)
	{
		cUnsafe = 0;
		int num = bytes.IndexOfAnyExcept(s_urlSafeBytes);
		if (num < 0)
		{
			return false;
		}
		ReadOnlySpan<byte> readOnlySpan = bytes.Slice(num);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			if (!s_urlSafeBytes.Contains(b) && b != 32)
			{
				cUnsafe++;
			}
		}
		return true;
	}

	internal static byte[] UrlEncode(string str, Encoding e)
	{
		if (e.GetMaxByteCount(str.Length) <= 512)
		{
			Span<byte> bytes = stackalloc byte[512];
			return UrlEncode(bytes[..e.GetBytes(str.AsSpan(), bytes)]);
		}
		byte[] bytes2 = e.GetBytes(str);
		if (!NeedsEncoding(bytes2, out var cUnsafe))
		{
			return bytes2;
		}
		return UrlEncode(bytes2, cUnsafe);
	}
}
