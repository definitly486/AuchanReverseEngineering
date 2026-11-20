using System.Buffers;
using System.Runtime.InteropServices;

namespace System.Text;

internal class EncoderNLS : Encoder
{
	internal char _charLeftOver;

	private readonly Encoding _encoding;

	private bool _mustFlush;

	internal bool _throwOnOverflow;

	internal int _charsUsed;

	public Encoding Encoding => _encoding;

	public bool MustFlush => _mustFlush;

	internal bool HasLeftoverData
	{
		get
		{
			if (_charLeftOver == '\0')
			{
				if (_fallbackBuffer != null)
				{
					return _fallbackBuffer.Remaining > 0;
				}
				return false;
			}
			return true;
		}
	}

	internal virtual bool HasState => _charLeftOver != '\0';

	internal EncoderNLS(Encoding encoding)
	{
		_encoding = encoding;
		_fallback = _encoding.EncoderFallback;
		Reset();
	}

	public override void Reset()
	{
		_charLeftOver = '\0';
		_fallbackBuffer?.Reset();
	}

	public unsafe override int GetByteCount(char[] chars, int index, int count, bool flush)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		if (chars.Length - index < count)
		{
			throw new ArgumentOutOfRangeException("chars", "ArgumentOutOfRange_IndexCountBuffer");
		}
		int byteCount;
		fixed (char* arrayDataReference = &MemoryMarshal.GetArrayDataReference(chars))
		{
			byteCount = GetByteCount(arrayDataReference + index, count, flush);
		}
		return byteCount;
	}

	public unsafe override int GetByteCount(char* chars, int count, bool flush)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		_mustFlush = flush;
		_throwOnOverflow = true;
		return _encoding.GetByteCount(chars, count, this);
	}

	public unsafe override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentOutOfRangeException.ThrowIfNegative(charIndex, "charIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		if (chars.Length - charIndex < charCount)
		{
			throw new ArgumentOutOfRangeException("chars", "ArgumentOutOfRange_IndexCountBuffer");
		}
		if (byteIndex < 0 || byteIndex > bytes.Length)
		{
			throw new ArgumentOutOfRangeException("byteIndex", "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		int byteCount = bytes.Length - byteIndex;
		fixed (char* arrayDataReference = &MemoryMarshal.GetArrayDataReference(chars))
		{
			fixed (byte* arrayDataReference2 = &MemoryMarshal.GetArrayDataReference(bytes))
			{
				return GetBytes(arrayDataReference + charIndex, charCount, arrayDataReference2 + byteIndex, byteCount, flush);
			}
		}
	}

	public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		_mustFlush = flush;
		_throwOnOverflow = true;
		return _encoding.GetBytes(chars, charCount, bytes, byteCount, this);
	}

	public unsafe override void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentOutOfRangeException.ThrowIfNegative(charIndex, "charIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		ArgumentOutOfRangeException.ThrowIfNegative(byteIndex, "byteIndex");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		if (chars.Length - charIndex < charCount)
		{
			throw new ArgumentOutOfRangeException("chars", "ArgumentOutOfRange_IndexCountBuffer");
		}
		if (bytes.Length - byteIndex < byteCount)
		{
			throw new ArgumentOutOfRangeException("bytes", "ArgumentOutOfRange_IndexCountBuffer");
		}
		fixed (char* arrayDataReference = &MemoryMarshal.GetArrayDataReference(chars))
		{
			fixed (byte* arrayDataReference2 = &MemoryMarshal.GetArrayDataReference(bytes))
			{
				Convert(arrayDataReference + charIndex, charCount, arrayDataReference2 + byteIndex, byteCount, flush, out charsUsed, out bytesUsed, out completed);
			}
		}
	}

	public unsafe override void Convert(char* chars, int charCount, byte* bytes, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed)
	{
		ArgumentNullException.ThrowIfNull(chars, "chars");
		ArgumentNullException.ThrowIfNull(bytes, "bytes");
		ArgumentOutOfRangeException.ThrowIfNegative(charCount, "charCount");
		ArgumentOutOfRangeException.ThrowIfNegative(byteCount, "byteCount");
		_mustFlush = flush;
		_throwOnOverflow = false;
		_charsUsed = 0;
		bytesUsed = _encoding.GetBytes(chars, charCount, bytes, byteCount, this);
		charsUsed = _charsUsed;
		completed = charsUsed == charCount && (!flush || !HasState) && (_fallbackBuffer == null || _fallbackBuffer.Remaining == 0);
	}

	internal void ClearMustFlush()
	{
		_mustFlush = false;
	}

	internal int DrainLeftoverDataForGetByteCount(ReadOnlySpan<char> chars, out int charsConsumed)
	{
		if (_fallbackBuffer != null && _fallbackBuffer.Remaining > 0)
		{
			throw new ArgumentException(SR.Format("Argument_EncoderFallbackNotEmpty", Encoding.EncodingName, _fallbackBuffer.GetType()));
		}
		charsConsumed = 0;
		if (_charLeftOver == '\0')
		{
			return 0;
		}
		char c = '\0';
		if (chars.IsEmpty)
		{
			if (!MustFlush)
			{
				return 0;
			}
		}
		else
		{
			c = chars[0];
		}
		if (Rune.TryCreate(_charLeftOver, c, out var result))
		{
			charsConsumed = 1;
			if (_encoding.TryGetByteCount(result, out var byteCount))
			{
				return byteCount;
			}
			base.FallbackBuffer.Fallback(_charLeftOver, c, -1);
		}
		else
		{
			base.FallbackBuffer.Fallback(_charLeftOver, -1);
		}
		return _fallbackBuffer.DrainRemainingDataForGetByteCount();
	}

	internal bool TryDrainLeftoverDataForGetBytes(ReadOnlySpan<char> chars, Span<byte> bytes, out int charsConsumed, out int bytesWritten)
	{
		charsConsumed = 0;
		bytesWritten = 0;
		if (_charLeftOver != 0)
		{
			char c = '\0';
			if (chars.IsEmpty)
			{
				if (!MustFlush)
				{
					charsConsumed = 0;
					bytesWritten = 0;
					return true;
				}
			}
			else
			{
				c = chars[0];
			}
			char charLeftOver = _charLeftOver;
			_charLeftOver = '\0';
			if (Rune.TryCreate(charLeftOver, c, out var result))
			{
				charsConsumed = 1;
				switch (_encoding.EncodeRune(result, bytes, out bytesWritten))
				{
				case OperationStatus.Done:
					return true;
				case OperationStatus.DestinationTooSmall:
					_encoding.ThrowBytesOverflow(this, nothingEncoded: true);
					break;
				case OperationStatus.InvalidData:
					base.FallbackBuffer.Fallback(charLeftOver, c, -1);
					break;
				}
			}
			else
			{
				base.FallbackBuffer.Fallback(charLeftOver, -1);
			}
		}
		if (_fallbackBuffer != null && _fallbackBuffer.Remaining > 0)
		{
			return _fallbackBuffer.TryDrainRemainingDataForGetBytes(bytes, out bytesWritten);
		}
		return true;
	}
}
