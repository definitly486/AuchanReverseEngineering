using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

public static class Buffer
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void ZeroMemoryInternal(void* b, nuint byteLength);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void MemmoveInternal(byte* dest, byte* src, nuint len);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BulkMoveWithWriteBarrier(ref byte dmem, ref byte smem, nuint len, nint type_handle);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void Memmove<T>(ref T destination, ref T source, nuint elementCount)
	{
		if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
		{
			SpanHelpers.Memmove(ref Unsafe.As<T, byte>(ref destination), ref Unsafe.As<T, byte>(ref source), elementCount * (nuint)Unsafe.SizeOf<T>());
		}
		else if (elementCount != 0)
		{
			BulkMoveWithWriteBarrier(ref Unsafe.As<T, byte>(ref destination), ref Unsafe.As<T, byte>(ref source), elementCount, typeof(T).TypeHandle.Value);
		}
	}

	public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count)
	{
		ArgumentNullException.ThrowIfNull(src, "src");
		ArgumentNullException.ThrowIfNull(dst, "dst");
		nuint num = src.NativeLength;
		if (src.GetType() != typeof(byte[]))
		{
			if (!src.GetCorElementTypeOfElementType().IsPrimitiveType())
			{
				throw new ArgumentException("Arg_MustBePrimArray", "src");
			}
			num *= (nuint)src.GetElementSize();
		}
		nuint num2 = num;
		if (src != dst)
		{
			num2 = dst.NativeLength;
			if (dst.GetType() != typeof(byte[]))
			{
				if (!dst.GetCorElementTypeOfElementType().IsPrimitiveType())
				{
					throw new ArgumentException("Arg_MustBePrimArray", "dst");
				}
				num2 *= (nuint)dst.GetElementSize();
			}
		}
		ArgumentOutOfRangeException.ThrowIfNegative(srcOffset, "srcOffset");
		ArgumentOutOfRangeException.ThrowIfNegative(dstOffset, "dstOffset");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		nuint num3 = (nuint)count;
		nuint num4 = (nuint)srcOffset;
		nuint num5 = (nuint)dstOffset;
		if (num < num4 + num3 || num2 < num5 + num3)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		Memmove(ref Unsafe.AddByteOffset(ref MemoryMarshal.GetArrayDataReference(dst), num5), ref Unsafe.AddByteOffset(ref MemoryMarshal.GetArrayDataReference(src), num4), num3);
	}

	public static int ByteLength(Array array)
	{
		ArgumentNullException.ThrowIfNull(array, "array");
		if (!array.GetCorElementTypeOfElementType().IsPrimitiveType())
		{
			throw new ArgumentException("Arg_MustBePrimArray", "array");
		}
		checked
		{
			return (int)unchecked(array.NativeLength * (nuint)array.GetElementSize());
		}
	}

	public static byte GetByte(Array array, int index)
	{
		if ((uint)index >= (uint)ByteLength(array))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
		}
		return Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), index);
	}

	public static void SetByte(Array array, int index, byte value)
	{
		if ((uint)index >= (uint)ByteLength(array))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
		}
		Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), index) = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public unsafe static void MemoryCopy(void* source, void* destination, long destinationSizeInBytes, long sourceBytesToCopy)
	{
		if (sourceBytesToCopy > destinationSizeInBytes)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.sourceBytesToCopy);
		}
		Memmove(ref *(byte*)destination, ref *(byte*)source, checked((nuint)sourceBytesToCopy));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public unsafe static void MemoryCopy(void* source, void* destination, ulong destinationSizeInBytes, ulong sourceBytesToCopy)
	{
		if (sourceBytesToCopy > destinationSizeInBytes)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.sourceBytesToCopy);
		}
		Memmove(ref *(byte*)destination, ref *(byte*)source, checked((nuint)sourceBytesToCopy));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal unsafe static void MemmoveInternal(ref byte dest, ref byte src, nuint len)
	{
		fixed (byte* dest2 = &dest)
		{
			fixed (byte* src2 = &src)
			{
				MemmoveInternal(dest2, src2, len);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal unsafe static void ZeroMemoryInternal(ref byte b, nuint byteLength)
	{
		fixed (byte* b2 = &b)
		{
			ZeroMemoryInternal(b2, byteLength);
		}
	}
}
