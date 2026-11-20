using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace System.Text.Json;

internal static class JsonWriterHelper
{
	private static readonly StandardFormat s_dateTimeStandardFormat = new StandardFormat('O');

	private static readonly StandardFormat s_hexStandardFormat = new StandardFormat('X', 4);

	private static ReadOnlySpan<byte> AllowList => new byte[256]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 1, 1, 0, 1, 1, 1, 0, 0,
		1, 1, 1, 0, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		0, 1, 0, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 0, 1, 1, 1, 0, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0
	};

	public static void WriteIndentation(Span<byte> buffer, int indent, byte indentByte)
	{
		if (indent < 8)
		{
			int num = 0;
			while (num + 1 < indent)
			{
				buffer[num++] = indentByte;
				buffer[num++] = indentByte;
			}
			if (num < indent)
			{
				buffer[num] = indentByte;
			}
		}
		else
		{
			buffer.Slice(0, indent).Fill(indentByte);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateNewLine(string value)
	{
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException("value");
		}
		if (!(value == "\n") && !(value == "\r\n"))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_NewLine("value");
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateIndentCharacter(char value)
	{
		if (value != ' ' && value != '\t')
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_IndentCharacter("value");
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateIndentSize(int value)
	{
		if ((value < 0 || value > 127) ? true : false)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_IndentSize("value", 0, 127);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateValue(ReadOnlySpan<char> value)
	{
		if (value.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException_ValueTooLarge(value.Length);
		}
	}

	internal static OperationStatus ToUtf8(ReadOnlySpan<char> source, Span<byte> destination, out int written)
	{
		int charsRead;
		return Utf8.FromUtf16(source, destination, out charsRead, out written, replaceInvalidSequences: false);
	}

	private static bool NeedsEscaping(byte value)
	{
		return AllowList[value] == 0;
	}

	private static bool NeedsEscapingNoBoundsCheck(char value)
	{
		return AllowList[value] == 0;
	}

	public static int NeedsEscaping(ReadOnlySpan<byte> value, JavaScriptEncoder encoder)
	{
		return (encoder ?? JavaScriptEncoder.Default).FindFirstCharacterToEncodeUtf8(value);
	}

	public unsafe static int NeedsEscaping(ReadOnlySpan<char> value, JavaScriptEncoder encoder)
	{
		if (value.IsEmpty)
		{
			return -1;
		}
		fixed (char* text = value)
		{
			return (encoder ?? JavaScriptEncoder.Default).FindFirstCharacterToEncode(text, value.Length);
		}
	}

	public static int GetMaxEscapedLength(int textLength, int firstIndexToEscape)
	{
		return firstIndexToEscape + 6 * (textLength - firstIndexToEscape);
	}

	private static void EscapeString(ReadOnlySpan<byte> value, Span<byte> destination, JavaScriptEncoder encoder, ref int consumed, ref int written, bool isFinalBlock)
	{
		int bytesConsumed;
		int bytesWritten;
		OperationStatus operationStatus = encoder.EncodeUtf8(value, destination, out bytesConsumed, out bytesWritten, isFinalBlock);
		if (operationStatus != OperationStatus.Done && (operationStatus != OperationStatus.NeedMoreData || isFinalBlock))
		{
			ThrowHelper.ThrowArgumentException_InvalidUTF8(value.Slice(bytesWritten));
		}
		written += bytesWritten;
		consumed += bytesConsumed;
	}

	public static void EscapeString(ReadOnlySpan<byte> value, Span<byte> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int written)
	{
		EscapeString(value, destination, indexOfFirstByteToEscape, encoder, out var _, out written);
	}

	public static void EscapeString(ReadOnlySpan<byte> value, Span<byte> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int consumed, out int written, bool isFinalBlock = true)
	{
		value.Slice(0, indexOfFirstByteToEscape).CopyTo(destination);
		written = indexOfFirstByteToEscape;
		consumed = indexOfFirstByteToEscape;
		if (encoder != null)
		{
			destination = destination.Slice(indexOfFirstByteToEscape);
			value = value.Slice(indexOfFirstByteToEscape);
			EscapeString(value, destination, encoder, ref consumed, ref written, isFinalBlock);
			return;
		}
		while (indexOfFirstByteToEscape < value.Length)
		{
			byte b = value[indexOfFirstByteToEscape];
			if (IsAsciiValue(b))
			{
				if (NeedsEscaping(b))
				{
					EscapeNextBytes(b, destination, ref written);
					indexOfFirstByteToEscape++;
					consumed++;
				}
				else
				{
					destination[written] = b;
					written++;
					indexOfFirstByteToEscape++;
					consumed++;
				}
				continue;
			}
			destination = destination.Slice(written);
			value = value.Slice(indexOfFirstByteToEscape);
			EscapeString(value, destination, JavaScriptEncoder.Default, ref consumed, ref written, isFinalBlock);
			break;
		}
	}

	private static void EscapeNextBytes(byte value, Span<byte> destination, ref int written)
	{
		destination[written++] = 92;
		switch (value)
		{
		case 34:
			destination[written++] = 117;
			destination[written++] = 48;
			destination[written++] = 48;
			destination[written++] = 50;
			destination[written++] = 50;
			break;
		case 10:
			destination[written++] = 110;
			break;
		case 13:
			destination[written++] = 114;
			break;
		case 9:
			destination[written++] = 116;
			break;
		case 92:
			destination[written++] = 92;
			break;
		case 8:
			destination[written++] = 98;
			break;
		case 12:
			destination[written++] = 102;
			break;
		default:
		{
			destination[written++] = 117;
			Utf8Formatter.TryFormat(value, destination.Slice(written), out var bytesWritten, s_hexStandardFormat);
			written += bytesWritten;
			break;
		}
		}
	}

	private static bool IsAsciiValue(byte value)
	{
		return value <= 127;
	}

	private static bool IsAsciiValue(char value)
	{
		return value <= '\u007f';
	}

	private static void EscapeString(ReadOnlySpan<char> value, Span<char> destination, JavaScriptEncoder encoder, ref int consumed, ref int written, bool isFinalBlock)
	{
		int charsConsumed;
		int charsWritten;
		OperationStatus operationStatus = encoder.Encode(value, destination, out charsConsumed, out charsWritten, isFinalBlock);
		if (operationStatus != OperationStatus.Done && (operationStatus != OperationStatus.NeedMoreData || isFinalBlock))
		{
			ThrowHelper.ThrowArgumentException_InvalidUTF16(value[charsWritten]);
		}
		written += charsWritten;
		consumed += charsConsumed;
	}

	public static void EscapeString(ReadOnlySpan<char> value, Span<char> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int written)
	{
		EscapeString(value, destination, indexOfFirstByteToEscape, encoder, out var _, out written);
	}

	public static void EscapeString(ReadOnlySpan<char> value, Span<char> destination, int indexOfFirstByteToEscape, JavaScriptEncoder encoder, out int consumed, out int written, bool isFinalBlock = true)
	{
		value.Slice(0, indexOfFirstByteToEscape).CopyTo(destination);
		written = indexOfFirstByteToEscape;
		consumed = indexOfFirstByteToEscape;
		if (encoder != null)
		{
			destination = destination.Slice(indexOfFirstByteToEscape);
			value = value.Slice(indexOfFirstByteToEscape);
			EscapeString(value, destination, encoder, ref consumed, ref written, isFinalBlock);
			return;
		}
		while (indexOfFirstByteToEscape < value.Length)
		{
			char c = value[indexOfFirstByteToEscape];
			if (IsAsciiValue(c))
			{
				if (NeedsEscapingNoBoundsCheck(c))
				{
					EscapeNextChars(c, destination, ref written);
					indexOfFirstByteToEscape++;
					consumed++;
				}
				else
				{
					destination[written] = c;
					written++;
					indexOfFirstByteToEscape++;
					consumed++;
				}
				continue;
			}
			destination = destination.Slice(written);
			value = value.Slice(indexOfFirstByteToEscape);
			EscapeString(value, destination, JavaScriptEncoder.Default, ref consumed, ref written, isFinalBlock);
			break;
		}
	}

	private static void EscapeNextChars(char value, Span<char> destination, ref int written)
	{
		destination[written++] = '\\';
		switch ((byte)value)
		{
		case 34:
			destination[written++] = 'u';
			destination[written++] = '0';
			destination[written++] = '0';
			destination[written++] = '2';
			destination[written++] = '2';
			break;
		case 10:
			destination[written++] = 'n';
			break;
		case 13:
			destination[written++] = 'r';
			break;
		case 9:
			destination[written++] = 't';
			break;
		case 92:
			destination[written++] = '\\';
			break;
		case 8:
			destination[written++] = 'b';
			break;
		case 12:
			destination[written++] = 'f';
			break;
		default:
		{
			destination[written++] = 'u';
			int num = value;
			num.TryFormat(destination.Slice(written), out var charsWritten, "X4".AsSpan());
			written += charsWritten;
			break;
		}
		}
	}
}
