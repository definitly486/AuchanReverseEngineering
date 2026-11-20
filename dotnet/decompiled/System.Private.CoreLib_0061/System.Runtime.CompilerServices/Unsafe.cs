using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace System.Runtime.CompilerServices;

public static class Unsafe
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void* AsPointer<T>(ref readonly T value)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static int SizeOf<T>()
	{
		return Unsafe.SizeOf<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[return: NotNullIfNotNull("o")]
	public static T As<T>(object? o) where T : class?
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref TTo As<TFrom, TTo>(ref TFrom source)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T Add<T>(ref T source, int elementOffset)
	{
		return ref AddByteOffset(ref source, (nint)elementOffset * (nint)Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T Add<T>(ref T source, nint elementOffset)
	{
		return ref AddByteOffset(ref source, elementOffset * Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void* Add<T>(void* source, int elementOffset)
	{
		return (byte*)source + (nint)elementOffset * (nint)Unsafe.SizeOf<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static ref T Add<T>(ref T source, nuint elementOffset)
	{
		return ref AddByteOffset(ref source, elementOffset * (nuint)Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static ref T AddByteOffset<T>(ref T source, nuint byteOffset)
	{
		return ref AddByteOffset(ref source, (nint)byteOffset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static bool AreSame<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static TTo BitCast<TFrom, TTo>(TFrom source)
	{
		if (Unsafe.SizeOf<TFrom>() != Unsafe.SizeOf<TTo>() || !typeof(TFrom).IsValueType || !typeof(TTo).IsValueType)
		{
			ThrowHelper.ThrowNotSupportedException();
		}
		return ReadUnaligned<TTo>(in As<TFrom, byte>(ref source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void Copy<T>(void* destination, ref readonly T source)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void Copy<T>(ref T destination, void* source)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void CopyBlock(void* destination, void* source, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static void CopyBlock(ref byte destination, ref readonly byte source, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void CopyBlockUnaligned(void* destination, void* source, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static void CopyBlockUnaligned(ref byte destination, ref readonly byte source, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static bool IsAddressGreaterThan<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static bool IsAddressGreaterThanOrEqualTo<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right)
	{
		return !IsAddressLessThan(in left, in right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static bool IsAddressLessThan<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static bool IsAddressLessThanOrEqualTo<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right)
	{
		return !IsAddressGreaterThan(in left, in right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void InitBlock(void* startAddress, byte value, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static void InitBlock(ref byte startAddress, byte value, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void InitBlockUnaligned(void* startAddress, byte value, uint byteCount)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount)
	{
		for (uint num = 0u; num < byteCount; num++)
		{
			AddByteOffset(ref startAddress, num) = value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static T ReadUnaligned<T>(void* source)
	{
		return Unsafe.Read<T>(source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static T ReadUnaligned<T>(scoped ref readonly byte source)
	{
		return As<byte, T>(ref AsRef(in source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void WriteUnaligned<T>(void* destination, T value)
	{
		Unsafe.Write(destination, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static void WriteUnaligned<T>(ref byte destination, T value)
	{
		As<byte, T>(ref destination) = value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T AddByteOffset<T>(ref T source, nint byteOffset)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static T Read<T>(void* source)
	{
		return Unsafe.Read<T>(source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void Write<T>(void* destination, T value)
	{
		Unsafe.Write(destination, value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static ref T AsRef<T>(void* source)
	{
		return ref *(T*)source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T AsRef<T>(scoped ref readonly T source)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static nint ByteOffset<T>([AllowNull] ref readonly T origin, [AllowNull] ref readonly T target)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public unsafe static ref T NullRef<T>()
	{
		return ref AsRef<T>(null);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public unsafe static bool IsNullRef<T>(ref readonly T source)
	{
		return AsPointer(in source) == null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static void SkipInit<T>(out T value)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T Subtract<T>(ref T source, int elementOffset)
	{
		return ref SubtractByteOffset(ref source, (nint)elementOffset * (nint)Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public unsafe static void* Subtract<T>(void* source, int elementOffset)
	{
		return (byte*)source - (nint)elementOffset * (nint)Unsafe.SizeOf<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T Subtract<T>(ref T source, nint elementOffset)
	{
		return ref SubtractByteOffset(ref source, elementOffset * Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static ref T Subtract<T>(ref T source, nuint elementOffset)
	{
		return ref SubtractByteOffset(ref source, elementOffset * (nuint)Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T SubtractByteOffset<T>(ref T source, nint byteOffset)
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	[CLSCompliant(false)]
	public static ref T SubtractByteOffset<T>(ref T source, nuint byteOffset)
	{
		return ref SubtractByteOffset(ref source, (nint)byteOffset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	[NonVersionable]
	public static ref T Unbox<T>(object box) where T : struct
	{
		throw new PlatformNotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nuint OpportunisticMisalignment<T>(ref readonly T address, nuint alignment)
	{
		return (nuint)AsPointer(in address) & (alignment - 1);
	}
}
