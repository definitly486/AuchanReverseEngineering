using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace System.Reflection.Internal;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
internal readonly struct MemoryBlock
{
	internal unsafe readonly byte* Pointer;

	internal readonly int Length;

	internal unsafe MemoryBlock(byte* buffer, int length)
	{
		Pointer = buffer;
		Length = length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckBounds(int offset, int byteCount)
	{
		if ((ulong)((long)(uint)offset + (long)(uint)byteCount) > (ulong)Length)
		{
			Throw.OutOfBounds();
		}
	}

	private unsafe string GetDebuggerDisplay()
	{
		if (Pointer == null)
		{
			return "<null>";
		}
		int displayedBytes;
		return GetDebuggerDisplay(out displayedBytes);
	}

	internal string GetDebuggerDisplay(out int displayedBytes)
	{
		displayedBytes = Math.Min(Length, 64);
		string text = BitConverter.ToString(PeekBytes(0, displayedBytes));
		if (displayedBytes < Length)
		{
			text += "-...";
		}
		return text;
	}

	internal unsafe MemoryBlock GetMemoryBlockAt(int offset, int length)
	{
		CheckBounds(offset, length);
		return new MemoryBlock(Pointer + offset, length);
	}

	internal unsafe byte PeekByte(int offset)
	{
		CheckBounds(offset, 1);
		return Pointer[offset];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe uint PeekUInt32(int offset)
	{
		CheckBounds(offset, 4);
		uint result = Unsafe.ReadUnaligned<uint>(Pointer + offset);
		if (!BitConverter.IsLittleEndian)
		{
		}
		return result;
	}

	internal unsafe int PeekCompressedInteger(int offset, out int numberOfBytesRead)
	{
		CheckBounds(offset, 0);
		byte* ptr = Pointer + offset;
		long num = Length - offset;
		if (num == 0L)
		{
			numberOfBytesRead = 0;
			return int.MaxValue;
		}
		byte b = *ptr;
		if ((b & 0x80) == 0)
		{
			numberOfBytesRead = 1;
			return b;
		}
		if ((b & 0x40) == 0)
		{
			if (num >= 2)
			{
				numberOfBytesRead = 2;
				return ((b & 0x3F) << 8) | ptr[1];
			}
		}
		else if ((b & 0x20) == 0 && num >= 4)
		{
			numberOfBytesRead = 4;
			return ((b & 0x1F) << 24) | (ptr[1] << 16) | (ptr[2] << 8) | ptr[3];
		}
		numberOfBytesRead = 0;
		return int.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe ushort PeekUInt16(int offset)
	{
		CheckBounds(offset, 2);
		ushort result = Unsafe.ReadUnaligned<ushort>(Pointer + offset);
		if (!BitConverter.IsLittleEndian)
		{
		}
		return result;
	}

	internal uint PeekReferenceUnchecked(int offset, bool smallRefSize)
	{
		if (!smallRefSize)
		{
			return PeekUInt32(offset);
		}
		return PeekUInt16(offset);
	}

	internal int PeekHeapReference(int offset, bool smallRefSize)
	{
		if (smallRefSize)
		{
			return PeekUInt16(offset);
		}
		uint num = PeekUInt32(offset);
		if (!HeapHandleType.IsValidHeapOffset(num))
		{
			Throw.ReferenceOverflow();
		}
		return (int)num;
	}

	internal unsafe string PeekUtf8NullTerminated(int offset, byte[]? prefix, MetadataStringDecoder utf8Decoder, out int numberOfBytesRead, char terminator = '\0')
	{
		CheckBounds(offset, 0);
		int utf8NullTerminatedLength = GetUtf8NullTerminatedLength(offset, out numberOfBytesRead, terminator);
		return EncodingHelper.DecodeUtf8(Pointer + offset, utf8NullTerminatedLength, prefix, utf8Decoder);
	}

	internal unsafe int GetUtf8NullTerminatedLength(int offset, out int numberOfBytesRead, char terminator)
	{
		CheckBounds(offset, 0);
		ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(Pointer + offset, Length - offset);
		int num = ((terminator != 0) ? span.IndexOfAny<byte>(0, (byte)terminator) : span.IndexOf<byte>(0));
		if (num < 0)
		{
			num = (numberOfBytesRead = span.Length);
		}
		else
		{
			numberOfBytesRead = num + 1;
		}
		return num;
	}

	internal unsafe int CompareUtf8NullTerminatedStringWithAsciiString(int offset, string asciiString)
	{
		CheckBounds(offset, 0);
		byte* ptr = Pointer + offset;
		int num = Length - offset;
		for (int i = 0; i < asciiString.Length; i++)
		{
			if (i > num)
			{
				return -1;
			}
			if (*ptr != asciiString[i])
			{
				return *ptr - asciiString[i];
			}
			ptr++;
		}
		return (*ptr != 0) ? 1 : 0;
	}

	internal unsafe byte[] PeekBytes(int offset, int byteCount)
	{
		CheckBounds(offset, byteCount);
		return new ReadOnlySpan<byte>(Pointer + offset, byteCount).ToArray();
	}

	internal bool IsOrderedByReferenceAscending(int rowSize, int referenceOffset, bool isReferenceSmall)
	{
		int i = referenceOffset;
		int length = Length;
		uint num = 0u;
		for (; i < length; i += rowSize)
		{
			uint num2 = PeekReferenceUnchecked(i, isReferenceSmall);
			if (num2 < num)
			{
				return false;
			}
			num = num2;
		}
		return true;
	}

	internal int[] BuildPtrTable(int numberOfRows, int rowSize, int referenceOffset, bool isReferenceSmall)
	{
		int[] array = new int[numberOfRows];
		uint[] unsortedReferences = new uint[numberOfRows];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i + 1;
		}
		ReadColumn(unsortedReferences, rowSize, referenceOffset, isReferenceSmall);
		Array.Sort(array, (int a, int b) => unsortedReferences[a - 1].CompareTo(unsortedReferences[b - 1]));
		return array;
	}

	private void ReadColumn(uint[] result, int rowSize, int referenceOffset, bool isReferenceSmall)
	{
		int num = referenceOffset;
		int length = Length;
		int num2 = 0;
		while (num < length)
		{
			result[num2] = PeekReferenceUnchecked(num, isReferenceSmall);
			num += rowSize;
			num2++;
		}
	}
}
