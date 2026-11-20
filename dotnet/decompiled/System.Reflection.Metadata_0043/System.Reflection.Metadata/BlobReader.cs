using System.Diagnostics;
using System.Reflection.Internal;
using System.Runtime.CompilerServices;

namespace System.Reflection.Metadata;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public struct BlobReader
{
	private readonly MemoryBlock _block;

	private unsafe readonly byte* _endPointer;

	private unsafe byte* _currentPointer;

	public unsafe int Offset
	{
		get
		{
			return (int)(_currentPointer - _block.Pointer);
		}
		set
		{
			if ((uint)value > (uint)_block.Length)
			{
				Throw.OutOfBounds();
			}
			_currentPointer = _block.Pointer + value;
		}
	}

	public unsafe int RemainingBytes => (int)(_endPointer - _currentPointer);

	internal unsafe BlobReader(MemoryBlock block)
	{
		_block = block;
		_currentPointer = block.Pointer;
		_endPointer = block.Pointer + block.Length;
	}

	internal unsafe string GetDebuggerDisplay()
	{
		if (_block.Pointer == null)
		{
			return "<null>";
		}
		int displayedBytes;
		string debuggerDisplay = _block.GetDebuggerDisplay(out displayedBytes);
		if (Offset < displayedBytes)
		{
			return debuggerDisplay.Insert(Offset * 3, "*");
		}
		if (displayedBytes == _block.Length)
		{
			return debuggerDisplay + "*";
		}
		return debuggerDisplay + "*...";
	}

	internal unsafe bool TryAlign(byte alignment)
	{
		int num = Offset & (alignment - 1);
		if (num != 0)
		{
			int num2 = alignment - num;
			if (num2 > RemainingBytes)
			{
				return false;
			}
			_currentPointer += num2;
		}
		return true;
	}

	internal unsafe MemoryBlock GetMemoryBlockAt(int offset, int length)
	{
		CheckBounds(offset, length);
		return new MemoryBlock(_currentPointer + offset, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe void CheckBounds(int offset, int byteCount)
	{
		if ((ulong)((long)(uint)offset + (long)(uint)byteCount) > (ulong)(_endPointer - _currentPointer))
		{
			Throw.OutOfBounds();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe byte* GetCurrentPointerAndAdvance(int length)
	{
		byte* currentPointer = _currentPointer;
		if ((uint)length > (uint)(_endPointer - currentPointer))
		{
			Throw.OutOfBounds();
		}
		_currentPointer = currentPointer + length;
		return currentPointer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe byte* GetCurrentPointerAndAdvance1()
	{
		byte* currentPointer = _currentPointer;
		if (currentPointer == _endPointer)
		{
			Throw.OutOfBounds();
		}
		_currentPointer = currentPointer + 1;
		return currentPointer;
	}

	public unsafe byte ReadByte()
	{
		return *GetCurrentPointerAndAdvance1();
	}

	public unsafe short ReadInt16()
	{
		byte* currentPointerAndAdvance = GetCurrentPointerAndAdvance(2);
		return (short)(*currentPointerAndAdvance + (currentPointerAndAdvance[1] << 8));
	}

	public unsafe ushort ReadUInt16()
	{
		byte* currentPointerAndAdvance = GetCurrentPointerAndAdvance(2);
		return (ushort)(*currentPointerAndAdvance + (currentPointerAndAdvance[1] << 8));
	}

	public unsafe int ReadInt32()
	{
		byte* currentPointerAndAdvance = GetCurrentPointerAndAdvance(4);
		return *currentPointerAndAdvance + (currentPointerAndAdvance[1] << 8) + (currentPointerAndAdvance[2] << 16) + (currentPointerAndAdvance[3] << 24);
	}

	public unsafe uint ReadUInt32()
	{
		byte* currentPointerAndAdvance = GetCurrentPointerAndAdvance(4);
		return (uint)(*currentPointerAndAdvance + (currentPointerAndAdvance[1] << 8) + (currentPointerAndAdvance[2] << 16) + (currentPointerAndAdvance[3] << 24));
	}

	public unsafe long ReadInt64()
	{
		byte* currentPointerAndAdvance = GetCurrentPointerAndAdvance(8);
		int num = *currentPointerAndAdvance + (currentPointerAndAdvance[1] << 8) + (currentPointerAndAdvance[2] << 16) + (currentPointerAndAdvance[3] << 24);
		uint num2 = (uint)(currentPointerAndAdvance[4] + (currentPointerAndAdvance[5] << 8) + (currentPointerAndAdvance[6] << 16) + (currentPointerAndAdvance[7] << 24));
		return (long)((uint)num + ((ulong)num2 << 32));
	}

	public ulong ReadUInt64()
	{
		return (ulong)ReadInt64();
	}

	public unsafe byte[] ReadBytes(int byteCount)
	{
		byte[] result = _block.PeekBytes(Offset, byteCount);
		_currentPointer += byteCount;
		return result;
	}

	internal unsafe string ReadUtf8NullTerminated()
	{
		int numberOfBytesRead;
		string result = _block.PeekUtf8NullTerminated(Offset, null, MetadataStringDecoder.DefaultUTF8, out numberOfBytesRead);
		_currentPointer += numberOfBytesRead;
		return result;
	}
}
