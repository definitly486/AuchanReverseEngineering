using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace System.Text.Json;

internal static class JsonReaderHelper
{
	private static readonly SearchValues<char> s_specialCharacters = SearchValues.Create(". '/\"[]()\t\n\r\f\b\\\u0085\u2028\u2029".AsSpan());

	public static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

	private static readonly SearchValues<byte> s_controlQuoteBackslash = SearchValues.Create(new byte[34]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
		20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
		30, 31, 34, 92
	});

	public static bool ContainsSpecialCharacters(this ReadOnlySpan<char> text)
	{
		return text.ContainsAny(s_specialCharacters);
	}

	public static (int, int) CountNewLines(ReadOnlySpan<byte> data)
	{
		int num = data.LastIndexOf<byte>(10);
		int item = 0;
		if (num >= 0)
		{
			item = 1;
			data = data.Slice(0, num);
			item += data.Count<byte>(10);
		}
		return (item, num);
	}

	internal static JsonValueKind ToValueKind(this JsonTokenType tokenType)
	{
		switch (tokenType)
		{
		case JsonTokenType.None:
			return JsonValueKind.Undefined;
		case JsonTokenType.StartArray:
			return JsonValueKind.Array;
		case JsonTokenType.StartObject:
			return JsonValueKind.Object;
		case JsonTokenType.String:
		case JsonTokenType.Number:
		case JsonTokenType.True:
		case JsonTokenType.False:
		case JsonTokenType.Null:
			return (JsonValueKind)(tokenType - 4);
		default:
			return JsonValueKind.Undefined;
		}
	}

	public static bool IsTokenTypePrimitive(JsonTokenType tokenType)
	{
		return (int)(tokenType - 7) <= 4;
	}

	public static bool IsHexDigit(byte nextByte)
	{
		return System.HexConverter.IsHexChar(nextByte);
	}

	public static bool TryGetValue(ReadOnlySpan<byte> segment, bool isEscaped, out DateTime value)
	{
		if (!JsonHelpers.IsValidDateTimeOffsetParseLength(segment.Length))
		{
			value = default(DateTime);
			return false;
		}
		if (isEscaped)
		{
			return TryGetEscapedDateTime(segment, out value);
		}
		if (JsonHelpers.TryParseAsISO(segment, out var value2))
		{
			value = value2;
			return true;
		}
		value = default(DateTime);
		return false;
	}

	public static bool TryGetEscapedDateTime(ReadOnlySpan<byte> source, out DateTime value)
	{
		Span<byte> span = stackalloc byte[252];
		Unescape(source, span, out var written);
		span = span.Slice(0, written);
		if (JsonHelpers.IsValidUnescapedDateTimeOffsetParseLength(span.Length) && JsonHelpers.TryParseAsISO(span, out var value2))
		{
			value = value2;
			return true;
		}
		value = default(DateTime);
		return false;
	}

	public static string GetUnescapedString(ReadOnlySpan<byte> utf8Source)
	{
		int length = utf8Source.Length;
		byte[] array = null;
		Span<byte> span = ((length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Unescape(utf8Source, span2, out var written);
		span2 = span2.Slice(0, written);
		string result = TranscodeHelper(span2);
		if (array != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static byte[] GetUnescaped(ReadOnlySpan<byte> utf8Source)
	{
		int length = utf8Source.Length;
		byte[] array = null;
		Span<byte> span = ((length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(length))) : stackalloc byte[256]);
		Span<byte> destination = span;
		Unescape(utf8Source, destination, out var written);
		byte[] result = destination.Slice(0, written).ToArray();
		if (array != null)
		{
			new Span<byte>(array, 0, written).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static string TranscodeHelper(ReadOnlySpan<byte> utf8Unescaped)
	{
		try
		{
			return s_utf8Encoding.GetString(utf8Unescaped);
		}
		catch (DecoderFallbackException innerException)
		{
			throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(innerException);
		}
	}

	public static int TranscodeHelper(ReadOnlySpan<byte> utf8Unescaped, Span<char> destination)
	{
		try
		{
			return s_utf8Encoding.GetChars(utf8Unescaped, destination);
		}
		catch (DecoderFallbackException innerException)
		{
			throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(innerException);
		}
		catch (ArgumentException)
		{
			destination.Clear();
			throw;
		}
	}

	internal static int GetUtf8ByteCount(ReadOnlySpan<char> text)
	{
		try
		{
			return s_utf8Encoding.GetByteCount(text);
		}
		catch (EncoderFallbackException innerException)
		{
			throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(innerException);
		}
	}

	internal static int GetUtf8FromText(ReadOnlySpan<char> text, Span<byte> dest)
	{
		try
		{
			return s_utf8Encoding.GetBytes(text, dest);
		}
		catch (EncoderFallbackException innerException)
		{
			throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(innerException);
		}
	}

	internal static string GetTextFromUtf8(ReadOnlySpan<byte> utf8Text)
	{
		return s_utf8Encoding.GetString(utf8Text);
	}

	internal static void Unescape(ReadOnlySpan<byte> source, Span<byte> destination, out int written)
	{
		int idx = source.IndexOf<byte>(92);
		TryUnescape(source, destination, idx, out written);
	}

	internal static bool TryUnescape(ReadOnlySpan<byte> source, Span<byte> destination, out int written)
	{
		int idx = source.IndexOf<byte>(92);
		return TryUnescape(source, destination, idx, out written);
	}

	private static bool TryUnescape(ReadOnlySpan<byte> source, Span<byte> destination, int idx, out int written)
	{
		if (!source.Slice(0, idx).TryCopyTo(destination))
		{
			written = 0;
		}
		else
		{
			written = idx;
			while (written != destination.Length)
			{
				byte b = source[++idx];
				if ((uint)b <= 98u)
				{
					if ((uint)b <= 47u)
					{
						if (b != 34)
						{
							if (b != 47)
							{
								goto IL_0179;
							}
							destination[written++] = 47;
						}
						else
						{
							destination[written++] = 34;
						}
					}
					else if (b != 92)
					{
						if (b != 98)
						{
							goto IL_0179;
						}
						destination[written++] = 8;
					}
					else
					{
						destination[written++] = 92;
					}
				}
				else if ((uint)b <= 110u)
				{
					if (b != 102)
					{
						if (b != 110)
						{
							goto IL_0179;
						}
						destination[written++] = 10;
					}
					else
					{
						destination[written++] = 12;
					}
				}
				else if (b != 114)
				{
					if (b != 116)
					{
						goto IL_0179;
					}
					destination[written++] = 9;
				}
				else
				{
					destination[written++] = 13;
				}
				goto IL_0260;
				IL_0260:
				if (++idx != source.Length)
				{
					if (source[idx] == 92)
					{
						continue;
					}
					ReadOnlySpan<byte> span = source.Slice(idx);
					int num = span.IndexOf<byte>(92);
					if (num < 0)
					{
						num = span.Length;
					}
					if ((uint)(written + num) >= (uint)destination.Length)
					{
						break;
					}
					switch (num)
					{
					case 1:
						destination[written++] = source[idx++];
						break;
					case 2:
						destination[written++] = source[idx++];
						destination[written++] = source[idx++];
						break;
					case 3:
						destination[written++] = source[idx++];
						destination[written++] = source[idx++];
						destination[written++] = source[idx++];
						break;
					default:
						span.Slice(0, num).CopyTo(destination.Slice(written));
						written += num;
						idx += num;
						break;
					}
					if (idx != source.Length)
					{
						continue;
					}
				}
				return true;
				IL_0179:
				Utf8Parser.TryParse(source.Slice(idx + 1, 4), out int value, out int bytesConsumed, 'x');
				idx += 4;
				if (JsonHelpers.IsInRangeInclusive((uint)value, 55296u, 57343u))
				{
					if (value >= 56320)
					{
						ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(value);
					}
					if (source.Length < idx + 7 || source[idx + 1] != 92 || source[idx + 2] != 117)
					{
						ThrowHelper.ThrowInvalidOperationException_ReadIncompleteUTF16();
					}
					Utf8Parser.TryParse(source.Slice(idx + 3, 4), out int value2, out bytesConsumed, 'x');
					idx += 6;
					if (!JsonHelpers.IsInRangeInclusive((uint)value2, 56320u, 57343u))
					{
						ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(value2);
					}
					value = 1024 * (value - 55296) + (value2 - 56320) + 65536;
				}
				if (!new Rune(value).TryEncodeToUtf8(destination.Slice(written), out var bytesWritten))
				{
					break;
				}
				written += bytesWritten;
				goto IL_0260;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int IndexOfQuoteOrAnyControlOrBackSlash(this ReadOnlySpan<byte> span)
	{
		return span.IndexOfAny(s_controlQuoteBackslash);
	}
}
