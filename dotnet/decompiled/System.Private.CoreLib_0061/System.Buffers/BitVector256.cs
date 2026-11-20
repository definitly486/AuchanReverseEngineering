using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Buffers;

internal struct BitVector256
{
	private unsafe fixed uint _values[8];

	public unsafe void Set(int c)
	{
		uint num = (uint)(c >> 5);
		uint num2 = (uint)(1 << c);
		ref uint reference = ref _values[num];
		reference |= num2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Contains(byte b)
	{
		return ContainsUnchecked(b);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe readonly bool ContainsUnchecked(int b)
	{
		uint num = (uint)(b >> 5);
		uint num2 = (uint)(1 << b);
		return (_values[num] & num2) != 0;
	}

	public readonly byte[] GetByteValues()
	{
		List<byte> list = new List<byte>();
		for (int i = 0; i < 256; i++)
		{
			if (ContainsUnchecked(i))
			{
				list.Add((byte)i);
			}
		}
		return list.ToArray();
	}
}
