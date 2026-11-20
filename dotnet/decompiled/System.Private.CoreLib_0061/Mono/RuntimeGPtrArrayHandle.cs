using System;
using System.Runtime.CompilerServices;

namespace Mono;

internal struct RuntimeGPtrArrayHandle
{
	private unsafe RuntimeStructs.GPtrArray* value;

	internal unsafe int Length => value->len;

	internal nint this[int i] => Lookup(i);

	internal unsafe RuntimeGPtrArrayHandle(nint ptr)
	{
		value = (RuntimeStructs.GPtrArray*)ptr;
	}

	internal unsafe nint Lookup(int i)
	{
		if (i >= 0 && i < Length)
		{
			return *(nint*)((byte*)value->data + (nint)i * (nint)4);
		}
		throw new IndexOutOfRangeException();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void GPtrArrayFree(RuntimeStructs.GPtrArray* value);

	internal unsafe static void DestroyAndFree(ref RuntimeGPtrArrayHandle h)
	{
		GPtrArrayFree(h.value);
		h.value = null;
	}
}
