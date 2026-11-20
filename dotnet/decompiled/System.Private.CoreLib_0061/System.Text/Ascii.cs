using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Text.Unicode;

namespace System.Text;

public static class Ascii
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct ToUpperConversion
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct ToLowerConversion
	{
	}

	private interface ILoader<TLeft, TRight> where TLeft : unmanaged, INumberBase<TLeft> where TRight : unmanaged, INumberBase<TRight>
	{
		static abstract nuint Count128 { get; }

		static abstract nuint Count256 { get; }

		static abstract nuint Count512 { get; }

		static abstract Vector128<TRight> Load128(ref TLeft ptr);

		static abstract Vector256<TRight> Load256(ref TLeft ptr);

		static abstract Vector512<TRight> Load512(ref TLeft ptr);

		static abstract bool EqualAndAscii256(ref TLeft left, ref TRight right);

		static abstract bool EqualAndAscii512(ref TLeft left, ref TRight right);
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct PlainLoader<T> : ILoader<T, T> where T : unmanaged, INumberBase<T>
	{
		public static nuint Count128 => (uint)Vector128<T>.Count;

		public static nuint Count256 => (uint)Vector256<T>.Count;

		public static nuint Count512 => (uint)Vector512<T>.Count;

		public static Vector128<T> Load128(ref T ptr)
		{
			return Vector128.LoadUnsafe(in ptr);
		}

		public static Vector256<T> Load256(ref T ptr)
		{
			return Vector256.LoadUnsafe(in ptr);
		}

		public static Vector512<T> Load512(ref T ptr)
		{
			return Vector512.LoadUnsafe(in ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EqualAndAscii256(ref T left, ref T right)
		{
			Vector256<T> vector = Vector256.LoadUnsafe(in left);
			Vector256<T> vector2 = Vector256.LoadUnsafe(in right);
			if (vector != vector2 || !AllCharsInVectorAreAscii(vector))
			{
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EqualAndAscii512(ref T left, ref T right)
		{
			Vector512<T> vector = Vector512.LoadUnsafe(in left);
			Vector512<T> vector2 = Vector512.LoadUnsafe(in right);
			if (vector != vector2 || !AllCharsInVectorAreAscii(vector))
			{
				return false;
			}
			return true;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct WideningLoader : ILoader<byte, ushort>
	{
		public static nuint Count128 => 8u;

		public static nuint Count256 => (uint)Vector128<byte>.Count;

		public static nuint Count512 => (uint)Vector256<byte>.Count;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector128<ushort> Load128(ref byte ptr)
		{
			if (false)
			{
			}
			if (false)
			{
			}
			if (false)
			{
			}
			var (lower, upper) = Vector64.Widen(Vector64.LoadUnsafe(in ptr));
			return Vector128.Create(lower, upper);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector256<ushort> Load256(ref byte ptr)
		{
			var (lower, upper) = Vector128.Widen(Vector128.LoadUnsafe(in ptr));
			return Vector256.Create(lower, upper);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector512<ushort> Load512(ref byte ptr)
		{
			return Vector512.WidenLower(Vector256.LoadUnsafe(in ptr).ToVector512());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EqualAndAscii256(ref byte utf8, ref ushort utf16)
		{
			Vector256<byte> vector = Vector256.LoadUnsafe(in utf8);
			if (!AllCharsInVectorAreAscii(vector))
			{
				return false;
			}
			(Vector256<ushort> Lower, Vector256<ushort> Upper) tuple = Vector256.Widen(vector);
			Vector256<ushort> item = tuple.Lower;
			Vector256<ushort> item2 = tuple.Upper;
			Vector256<ushort> vector2 = Vector256.LoadUnsafe(in utf16);
			Vector256<ushort> vector3 = Vector256.LoadUnsafe(in utf16, (uint)Vector256<ushort>.Count);
			if (((item ^ vector2) | (item2 ^ vector3)) != Vector256<ushort>.Zero)
			{
				return false;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EqualAndAscii512(ref byte utf8, ref ushort utf16)
		{
			Vector512<byte> vector = Vector512.LoadUnsafe(in utf8);
			if (!AllCharsInVectorAreAscii(vector))
			{
				return false;
			}
			(Vector512<ushort> Lower, Vector512<ushort> Upper) tuple = Vector512.Widen(vector);
			Vector512<ushort> item = tuple.Lower;
			Vector512<ushort> item2 = tuple.Upper;
			Vector512<ushort> vector2 = Vector512.LoadUnsafe(in utf16);
			Vector512<ushort> vector3 = Vector512.LoadUnsafe(in utf16, (uint)Vector512<ushort>.Count);
			if (((item ^ vector2) | (item2 ^ vector3)) != Vector512<ushort>.Zero)
			{
				return false;
			}
			return true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValid(ReadOnlySpan<byte> value)
	{
		return IsValidCore(ref MemoryMarshal.GetReference(value), value.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValid(ReadOnlySpan<char> value)
	{
		return IsValidCore(ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(value)), value.Length);
	}

	public static bool IsValid(byte value)
	{
		return value <= 127;
	}

	public static bool IsValid(char value)
	{
		return value <= '\u007f';
	}

	private unsafe static bool IsValidCore<T>(ref T searchSpace, int length) where T : unmanaged
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<T>.Count)
		{
			uint num = (uint)(8 / sizeof(T));
			if (length < num)
			{
				if (typeof(T) == typeof(byte) && length >= 4)
				{
					return AllBytesInUInt32AreAscii(Unsafe.ReadUnaligned<uint>(in Unsafe.As<T, byte>(ref searchSpace)) | Unsafe.ReadUnaligned<uint>(in Unsafe.As<T, byte>(ref Unsafe.Add(ref searchSpace, length - 4))));
				}
				for (nuint num2 = 0u; num2 < (uint)length; num2++)
				{
					if ((typeof(T) == typeof(byte)) ? (Unsafe.BitCast<T, byte>(Unsafe.Add(ref searchSpace, num2)) > 127) : (Unsafe.BitCast<T, char>(Unsafe.Add(ref searchSpace, num2)) > '\u007f'))
					{
						return false;
					}
				}
				return true;
			}
			nuint num3 = 0u;
			if (!Vector128.IsHardwareAccelerated && length > 2 * num)
			{
				nuint num4;
				for (num4 = (nuint)length - (nuint)(2 * num); num3 < num4; num3 += 2 * num)
				{
					if (!AllCharsInUInt64AreAscii<T>(Unsafe.ReadUnaligned<ulong>(in Unsafe.As<T, byte>(ref Unsafe.Add(ref searchSpace, num3))) | Unsafe.ReadUnaligned<ulong>(in Unsafe.As<T, byte>(ref Unsafe.Add(ref searchSpace, num3 + num)))))
					{
						return false;
					}
				}
				num3 = num4;
			}
			return AllCharsInUInt64AreAscii<T>(Unsafe.ReadUnaligned<ulong>(in Unsafe.As<T, byte>(ref Unsafe.Add(ref searchSpace, num3))) | Unsafe.ReadUnaligned<ulong>(in Unsafe.Subtract(ref Unsafe.As<T, byte>(ref Unsafe.Add(ref searchSpace, length)), 8)));
		}
		ref T source = ref Unsafe.Add(ref searchSpace, length);
		if (length <= 2 * Vector128<T>.Count)
		{
			return AllCharsInVectorAreAscii(Vector128.LoadUnsafe(in searchSpace) | Vector128.LoadUnsafe(in Unsafe.Subtract(ref source, Vector128<T>.Count)));
		}
		if (false)
		{
		}
		if (length > 4 * Vector128<T>.Count)
		{
			if (!AllCharsInVectorAreAscii(Vector128.LoadUnsafe(in searchSpace) | Vector128.LoadUnsafe(in searchSpace, (nuint)Vector128<T>.Count) | Vector128.LoadUnsafe(in searchSpace, (nuint)2u * (nuint)Vector128<T>.Count) | Vector128.LoadUnsafe(in searchSpace, (nuint)3u * (nuint)Vector128<T>.Count)))
			{
				return false;
			}
			nuint num5 = (nuint)4u * (nuint)Vector128<T>.Count;
			nuint num6 = Unsafe.OpportunisticMisalignment(in searchSpace, (uint)Vector128<byte>.Count) / (nuint)sizeof(T);
			num5 -= num6;
			nuint num7;
			for (num7 = (nuint)(length - (nint)4 * (nint)Vector128<T>.Count); num5 < num7; num5 += (nuint)((nint)4 * (nint)Vector128<T>.Count))
			{
				ref T source2 = ref Unsafe.Add(ref searchSpace, num5);
				if (!AllCharsInVectorAreAscii(Vector128.LoadUnsafe(in source2) | Vector128.LoadUnsafe(in source2, (nuint)Vector128<T>.Count) | Vector128.LoadUnsafe(in source2, (nuint)2u * (nuint)Vector128<T>.Count) | Vector128.LoadUnsafe(in source2, (nuint)3u * (nuint)Vector128<T>.Count)))
				{
					return false;
				}
			}
			searchSpace = ref Unsafe.Add(ref searchSpace, num7);
		}
		return AllCharsInVectorAreAscii(Vector128.LoadUnsafe(in searchSpace) | Vector128.LoadUnsafe(in searchSpace, (nuint)Vector128<T>.Count) | Vector128.LoadUnsafe(in Unsafe.Subtract(ref source, 2 * Vector128<T>.Count)) | Vector128.LoadUnsafe(in Unsafe.Subtract(ref source, Vector128<T>.Count)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpper(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		return ChangeCase<byte, byte, ToUpperConversion>(source, destination, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpper(ReadOnlySpan<char> source, Span<char> destination, out int charsWritten)
	{
		return ChangeCase<ushort, ushort, ToUpperConversion>(MemoryMarshal.Cast<char, ushort>(source), MemoryMarshal.Cast<char, ushort>(destination), out charsWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpper(ReadOnlySpan<byte> source, Span<char> destination, out int charsWritten)
	{
		return ChangeCase<byte, ushort, ToUpperConversion>(source, MemoryMarshal.Cast<char, ushort>(destination), out charsWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpper(ReadOnlySpan<char> source, Span<byte> destination, out int bytesWritten)
	{
		return ChangeCase<ushort, byte, ToUpperConversion>(MemoryMarshal.Cast<char, ushort>(source), destination, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLower(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
	{
		return ChangeCase<byte, byte, ToLowerConversion>(source, destination, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLower(ReadOnlySpan<char> source, Span<char> destination, out int charsWritten)
	{
		return ChangeCase<ushort, ushort, ToLowerConversion>(MemoryMarshal.Cast<char, ushort>(source), MemoryMarshal.Cast<char, ushort>(destination), out charsWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLower(ReadOnlySpan<byte> source, Span<char> destination, out int charsWritten)
	{
		return ChangeCase<byte, ushort, ToLowerConversion>(source, MemoryMarshal.Cast<char, ushort>(destination), out charsWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLower(ReadOnlySpan<char> source, Span<byte> destination, out int bytesWritten)
	{
		return ChangeCase<ushort, byte, ToLowerConversion>(MemoryMarshal.Cast<char, ushort>(source), destination, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLowerInPlace(Span<byte> value, out int bytesWritten)
	{
		return ChangeCase<byte, ToLowerConversion>(value, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToLowerInPlace(Span<char> value, out int charsWritten)
	{
		return ChangeCase<ushort, ToLowerConversion>(MemoryMarshal.Cast<char, ushort>(value), out charsWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpperInPlace(Span<byte> value, out int bytesWritten)
	{
		return ChangeCase<byte, ToUpperConversion>(value, out bytesWritten);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationStatus ToUpperInPlace(Span<char> value, out int charsWritten)
	{
		return ChangeCase<ushort, ToUpperConversion>(MemoryMarshal.Cast<char, ushort>(value), out charsWritten);
	}

	private unsafe static OperationStatus ChangeCase<TFrom, TTo, TCasing>(ReadOnlySpan<TFrom> source, Span<TTo> destination, out int destinationElementsWritten) where TFrom : unmanaged, IBinaryInteger<TFrom> where TTo : unmanaged, IBinaryInteger<TTo> where TCasing : struct
	{
		if (MemoryMarshal.AsBytes(source).Overlaps(MemoryMarshal.AsBytes(destination)))
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_SpanOverlappedOperation);
		}
		nuint num;
		OperationStatus result;
		if (source.Length <= destination.Length)
		{
			num = (uint)source.Length;
			result = OperationStatus.Done;
		}
		else
		{
			num = (uint)destination.Length;
			result = OperationStatus.DestinationTooSmall;
		}
		fixed (TFrom* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (TTo* reference2 = &MemoryMarshal.GetReference(destination))
			{
				nuint num2 = ChangeCase<TFrom, TTo, TCasing>(reference, reference2, num);
				destinationElementsWritten = (int)num2;
				if (num != num2)
				{
					return OperationStatus.InvalidData;
				}
				return result;
			}
		}
	}

	private unsafe static OperationStatus ChangeCase<T, TCasing>(Span<T> buffer, out int elementsWritten) where T : unmanaged, IBinaryInteger<T> where TCasing : struct
	{
		fixed (T* reference = &MemoryMarshal.GetReference(buffer))
		{
			nuint num = ChangeCase<T, T, TCasing>(reference, reference, (nuint)buffer.Length);
			elementsWritten = (int)num;
			if (elementsWritten != buffer.Length)
			{
				return OperationStatus.InvalidData;
			}
			return OperationStatus.Done;
		}
	}

	private unsafe static nuint ChangeCase<TFrom, TTo, TCasing>(TFrom* pSrc, TTo* pDest, nuint elementCount) where TFrom : unmanaged, IBinaryInteger<TFrom> where TTo : unmanaged, IBinaryInteger<TTo> where TCasing : struct
	{
		bool flag = sizeof(TFrom) == 1;
		bool flag2 = sizeof(TTo) == 1;
		bool flag3 = flag && !flag2;
		bool flag4 = typeof(TFrom) == typeof(TTo);
		bool flag5 = typeof(TCasing) == typeof(ToUpperConversion);
		uint num = (uint)(sizeof(Vector128<byte>) / sizeof(TFrom));
		nuint num2 = 0u;
		if (flag4 || Vector128.IsHardwareAccelerated)
		{
			if (Vector128.IsHardwareAccelerated && elementCount >= num)
			{
				Vector128<TFrom> vector = Vector128.LoadUnsafe(in *pSrc);
				if (!VectorContainsNonAsciiChar(vector))
				{
					TFrom val = TFrom.CreateTruncating(1 << 8 * sizeof(TFrom) - 1);
					Vector128<TFrom> vector2 = Vector128.Create(flag5 ? (val + TFrom.CreateTruncating('a')) : (val + TFrom.CreateTruncating('A')));
					Vector128<TFrom> right = Vector128.Create(val + TFrom.CreateTruncating(26));
					Vector128<TFrom> vector3 = Vector128.Create(TFrom.CreateTruncating(32));
					Vector128<TFrom> vector4 = SignedLessThan(vector - vector2, right);
					vector ^= vector4 & vector3;
					ChangeWidthAndWriteTo(vector, pDest, 0u);
					uint num3 = num * (uint)sizeof(TTo);
					num2 = num - (uint)pDest % num3 / (uint)sizeof(TTo);
					while (true)
					{
						if (elementCount - num2 < num)
						{
							if (num2 == elementCount)
							{
								break;
							}
							num2 = elementCount - num;
						}
						vector = Vector128.LoadUnsafe(in *pSrc, num2);
						if (!VectorContainsNonAsciiChar(vector))
						{
							vector4 = SignedLessThan(vector - vector2, right);
							vector ^= vector4 & vector3;
							ChangeWidthAndWriteTo(vector, pDest, num2);
							num2 += num;
							continue;
						}
						goto IL_01db;
					}
					goto IL_0372;
				}
			}
			goto IL_01db;
		}
		goto IL_036d;
		IL_02f6:
		uint num4 = uint.CreateTruncating(pSrc[num2]);
		if (UnicodeUtility.IsAsciiCodePoint(num4))
		{
			if (flag5)
			{
				if (UnicodeUtility.IsInRangeInclusive(num4, 97u, 122u))
				{
					num4 -= 32;
				}
			}
			else if (UnicodeUtility.IsInRangeInclusive(num4, 65u, 90u))
			{
				num4 += 32;
			}
			pDest[num2] = TTo.CreateTruncating(num4);
			num2++;
			goto IL_036d;
		}
		goto IL_0372;
		IL_0372:
		return num2;
		IL_01db:
		if (4 >= 8)
		{
		}
		while (elementCount - num2 >= (nuint)(4 / sizeof(TFrom)))
		{
			uint value = Unsafe.ReadUnaligned<uint>(pSrc + num2);
			if (flag)
			{
				if (!Utf8Utility.AllBytesInUInt32AreAscii(value))
				{
					break;
				}
				value = (flag5 ? Utf8Utility.ConvertAllAsciiBytesInUInt32ToUppercase(value) : Utf8Utility.ConvertAllAsciiBytesInUInt32ToLowercase(value));
			}
			else
			{
				if (!Utf16Utility.AllCharsInUInt32AreAscii(value))
				{
					break;
				}
				value = (flag5 ? Utf16Utility.ConvertAllAsciiCharsInUInt32ToUppercase(value) : Utf16Utility.ConvertAllAsciiCharsInUInt32ToLowercase(value));
			}
			if (flag4)
			{
				Unsafe.WriteUnaligned(pDest + num2, value);
			}
			else
			{
				Vector128<uint> vector5 = Vector128.CreateScalarUnsafe(value);
				if (flag3)
				{
					Vector128<ulong> vector6 = Vector128.WidenLower(vector5.AsByte()).AsUInt64();
					Unsafe.WriteUnaligned(pDest + num2, vector6.ToScalar());
				}
				else
				{
					Vector128<ushort> vector7 = vector5.AsUInt16();
					Vector128<ushort> vector8 = Vector128.Narrow(vector7, vector7).AsUInt16();
					Unsafe.WriteUnaligned(pDest + num2, vector8.ToScalar());
				}
			}
			num2 += (nuint)(4 / sizeof(TFrom));
			if (4 < 8)
			{
				continue;
			}
			goto IL_02f6;
		}
		goto IL_036d;
		IL_036d:
		if (num2 < elementCount)
		{
			goto IL_02f6;
		}
		goto IL_0372;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void ChangeWidthAndWriteTo<TFrom, TTo>(Vector128<TFrom> vector, TTo* pDest, nuint elementOffset) where TFrom : unmanaged where TTo : unmanaged
	{
		if (sizeof(TFrom) == sizeof(TTo))
		{
			vector.As<TFrom, TTo>().StoreUnsafe(ref *pDest, elementOffset);
		}
		else if (sizeof(TFrom) == 1 && sizeof(TTo) == 2)
		{
			if (false)
			{
			}
			Vector128.WidenLower(vector.AsByte()).StoreUnsafe(ref *(ushort*)pDest, elementOffset);
			Vector128.WidenUpper(vector.AsByte()).StoreUnsafe(ref *(ushort*)pDest, elementOffset + 8);
		}
		else
		{
			if (sizeof(TFrom) != 2 || sizeof(TTo) != 1)
			{
				throw new NotSupportedException();
			}
			ExtractAsciiVector(vector.AsUInt16(), vector.AsUInt16()).StoreLowerUnsafe(ref *(byte*)pDest, elementOffset);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static Vector128<T> SignedLessThan<T>(Vector128<T> left, Vector128<T> right) where T : unmanaged
	{
		if (sizeof(T) == 1)
		{
			return Vector128.LessThan(left.AsSByte(), right.AsSByte()).As<sbyte, T>();
		}
		if (sizeof(T) == 2)
		{
			return Vector128.LessThan(left.AsInt16(), right.AsInt16()).As<short, T>();
		}
		throw new NotSupportedException();
	}

	public static bool Equals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
	{
		if (left.Length == right.Length)
		{
			return Equals<byte, byte, PlainLoader<byte>>(ref MemoryMarshal.GetReference(left), ref MemoryMarshal.GetReference(right), (uint)right.Length);
		}
		return false;
	}

	public static bool Equals(ReadOnlySpan<byte> left, ReadOnlySpan<char> right)
	{
		if (left.Length == right.Length)
		{
			return Equals<byte, ushort, WideningLoader>(ref MemoryMarshal.GetReference(left), ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(right)), (uint)right.Length);
		}
		return false;
	}

	public static bool Equals(ReadOnlySpan<char> left, ReadOnlySpan<byte> right)
	{
		return Equals(right, left);
	}

	public static bool Equals(ReadOnlySpan<char> left, ReadOnlySpan<char> right)
	{
		if (left.Length == right.Length)
		{
			return Equals<ushort, ushort, PlainLoader<ushort>>(ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(left)), ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(right)), (uint)right.Length);
		}
		return false;
	}

	private static bool Equals<TLeft, TRight, TLoader>(ref TLeft left, ref TRight right, nuint length) where TLeft : unmanaged, INumberBase<TLeft> where TRight : unmanaged, INumberBase<TRight> where TLoader : struct, ILoader<TLeft, TRight>
	{
		if (!Vector128.IsHardwareAccelerated || length < (uint)Vector128<TLeft>.Count)
		{
			for (nuint num = 0u; num < length; num++)
			{
				uint num2 = uint.CreateTruncating(Unsafe.Add(ref left, num));
				uint num3 = uint.CreateTruncating(Unsafe.Add(ref right, num));
				if (num2 != num3 || !UnicodeUtility.IsAsciiCodePoint(num2))
				{
					return false;
				}
			}
		}
		else
		{
			if (false)
			{
			}
			if (false)
			{
			}
			ref TLeft reference = ref left;
			ref TLeft ptr = ref Unsafe.Add(ref reference, length - TLoader.Count128);
			ref TRight reference2 = ref right;
			ref TRight reference3 = ref Unsafe.Add(ref reference2, length - (uint)Vector128<TRight>.Count);
			do
			{
				Vector128<TRight> vector = TLoader.Load128(ref reference);
				Vector128<TRight> vector2 = Vector128.LoadUnsafe(in reference2);
				if (vector != vector2 || !AllCharsInVectorAreAscii(vector))
				{
					return false;
				}
				reference2 = ref Unsafe.Add(ref reference2, (uint)Vector128<TRight>.Count);
				reference = ref Unsafe.Add(ref reference, TLoader.Count128);
			}
			while (Unsafe.IsAddressLessThanOrEqualTo(in reference2, in reference3));
			if (length % (uint)Vector128<TRight>.Count != 0)
			{
				Vector128<TRight> vector = TLoader.Load128(ref ptr);
				Vector128<TRight> vector2 = Vector128.LoadUnsafe(in reference3);
				if (vector != vector2 || !AllCharsInVectorAreAscii(vector))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool EqualsIgnoreCase(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
	{
		if (left.Length == right.Length)
		{
			return EqualsIgnoreCase<byte, byte, PlainLoader<byte>>(ref MemoryMarshal.GetReference(left), ref MemoryMarshal.GetReference(right), (uint)right.Length);
		}
		return false;
	}

	public static bool EqualsIgnoreCase(ReadOnlySpan<byte> left, ReadOnlySpan<char> right)
	{
		if (left.Length == right.Length)
		{
			return EqualsIgnoreCase<byte, ushort, WideningLoader>(ref MemoryMarshal.GetReference(left), ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(right)), (uint)right.Length);
		}
		return false;
	}

	public static bool EqualsIgnoreCase(ReadOnlySpan<char> left, ReadOnlySpan<byte> right)
	{
		return EqualsIgnoreCase(right, left);
	}

	public static bool EqualsIgnoreCase(ReadOnlySpan<char> left, ReadOnlySpan<char> right)
	{
		if (left.Length == right.Length)
		{
			return EqualsIgnoreCase<ushort, ushort, PlainLoader<ushort>>(ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(left)), ref Unsafe.As<char, ushort>(ref MemoryMarshal.GetReference(right)), (uint)right.Length);
		}
		return false;
	}

	internal static bool EqualsIgnoreCase(ref char left, ref char right, nuint length)
	{
		return EqualsIgnoreCase<ushort, ushort, PlainLoader<ushort>>(ref Unsafe.As<char, ushort>(ref left), ref Unsafe.As<char, ushort>(ref right), length);
	}

	private static bool EqualsIgnoreCase<TLeft, TRight, TLoader>(ref TLeft left, ref TRight right, nuint length) where TLeft : unmanaged, INumberBase<TLeft> where TRight : unmanaged, INumberBase<TRight> where TLoader : ILoader<TLeft, TRight>
	{
		if (!Vector128.IsHardwareAccelerated || length < (uint)Vector128<TRight>.Count)
		{
			for (nuint num = 0u; num < length; num++)
			{
				uint num2 = uint.CreateTruncating(Unsafe.Add(ref left, num));
				uint num3 = uint.CreateTruncating(Unsafe.Add(ref right, num));
				if (!UnicodeUtility.IsAsciiCodePoint(num2 | num3))
				{
					return false;
				}
				if (num2 != num3)
				{
					num2 |= 0x20;
					if (num2 - 97 > 25)
					{
						return false;
					}
					if (num2 != (num3 | 0x20))
					{
						return false;
					}
				}
			}
		}
		else
		{
			if (false)
			{
			}
			if (false)
			{
			}
			ref TLeft reference = ref left;
			ref TLeft ptr = ref Unsafe.Add(ref reference, length - TLoader.Count128);
			ref TRight reference2 = ref right;
			ref TRight reference3 = ref Unsafe.Add(ref reference2, length - (uint)Vector128<TRight>.Count);
			Vector128<TRight> vector = Vector128.Create(TRight.CreateTruncating(32));
			Vector128<TRight> vector2 = Vector128.Create(TRight.CreateTruncating('a'));
			Vector128<TRight> right2 = Vector128.Create(TRight.CreateTruncating(25));
			do
			{
				Vector128<TRight> vector3 = TLoader.Load128(ref reference);
				Vector128<TRight> vector4 = Vector128.LoadUnsafe(in reference2);
				if (!AllCharsInVectorAreAscii(vector3 | vector4))
				{
					return false;
				}
				Vector128<TRight> vector5 = ~Vector128.Equals(vector3, vector4);
				if (vector5 != Vector128<TRight>.Zero)
				{
					vector3 |= vector;
					vector4 |= vector;
					if (Vector128.GreaterThanAny((vector3 - vector2) & vector5, right2) || vector3 != vector4)
					{
						return false;
					}
				}
				reference2 = ref Unsafe.Add(ref reference2, (uint)Vector128<TRight>.Count);
				reference = ref Unsafe.Add(ref reference, TLoader.Count128);
			}
			while (Unsafe.IsAddressLessThanOrEqualTo(in reference2, in reference3));
			if (length % (uint)Vector128<TRight>.Count != 0)
			{
				Vector128<TRight> vector3 = TLoader.Load128(ref ptr);
				Vector128<TRight> vector4 = Vector128.LoadUnsafe(in reference3);
				if (!AllCharsInVectorAreAscii(vector3 | vector4))
				{
					return false;
				}
				Vector128<TRight> vector6 = ~Vector128.Equals(vector3, vector4);
				if (vector6 != Vector128<TRight>.Zero)
				{
					vector3 |= vector;
					vector4 |= vector;
					if (Vector128.GreaterThanAny((vector3 - vector2) & vector6, right2) || vector3 != vector4)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public unsafe static OperationStatus ToUtf16(ReadOnlySpan<byte> source, Span<char> destination, out int charsWritten)
	{
		nuint num;
		OperationStatus result;
		if (source.Length <= destination.Length)
		{
			num = (uint)source.Length;
			result = OperationStatus.Done;
		}
		else
		{
			num = (uint)destination.Length;
			result = OperationStatus.DestinationTooSmall;
		}
		fixed (byte* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(destination))
			{
				nuint num2 = WidenAsciiToUtf16(reference, reference2, num);
				charsWritten = (int)num2;
				if (num != num2)
				{
					return OperationStatus.InvalidData;
				}
				return result;
			}
		}
	}

	public unsafe static OperationStatus FromUtf16(ReadOnlySpan<char> source, Span<byte> destination, out int bytesWritten)
	{
		nuint num;
		OperationStatus result;
		if (source.Length <= destination.Length)
		{
			num = (uint)source.Length;
			result = OperationStatus.Done;
		}
		else
		{
			num = (uint)destination.Length;
			result = OperationStatus.DestinationTooSmall;
		}
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference(destination))
			{
				nuint num2 = NarrowUtf16ToAscii(reference, reference2, num);
				bytesWritten = (int)num2;
				if (num != num2)
				{
					return OperationStatus.InvalidData;
				}
				return result;
			}
		}
	}

	public static Range Trim(ReadOnlySpan<byte> value)
	{
		return TrimHelper(value, TrimType.Both);
	}

	public static Range Trim(ReadOnlySpan<char> value)
	{
		return TrimHelper(value, TrimType.Both);
	}

	public static Range TrimStart(ReadOnlySpan<byte> value)
	{
		return TrimHelper(value, TrimType.Head);
	}

	public static Range TrimStart(ReadOnlySpan<char> value)
	{
		return TrimHelper(value, TrimType.Head);
	}

	public static Range TrimEnd(ReadOnlySpan<byte> value)
	{
		return TrimHelper(value, TrimType.Tail);
	}

	public static Range TrimEnd(ReadOnlySpan<char> value)
	{
		return TrimHelper(value, TrimType.Tail);
	}

	private static Range TrimHelper<T>(ReadOnlySpan<T> value, TrimType trimType) where T : unmanaged, IBinaryInteger<T>
	{
		int i = 0;
		if ((trimType & TrimType.Head) != 0)
		{
			for (; i < value.Length; i++)
			{
				uint num = uint.CreateTruncating(value[i]) - 1;
				if (num > 31 || (-2147475712 & (1 << (int)num)) == 0)
				{
					break;
				}
			}
		}
		int num2 = value.Length - 1;
		if ((trimType & TrimType.Tail) != 0)
		{
			while (i <= num2)
			{
				uint num3 = uint.CreateTruncating(value[num2]) - 1;
				if (num3 > 31 || (-2147475712 & (1 << (int)num3)) == 0)
				{
					break;
				}
				num2--;
			}
		}
		return i..(num2 + 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllBytesInUInt64AreAscii(ulong value)
	{
		return (value & 0x8080808080808080uL) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInUInt32AreAscii(uint value)
	{
		return (value & 0xFF80FF80u) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInUInt64AreAscii(ulong value)
	{
		return (value & 0xFF80FF80FF80FF80uL) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInUInt64AreAscii<T>(ulong value) where T : unmanaged
	{
		if (!(typeof(T) == typeof(byte)))
		{
			return AllCharsInUInt64AreAscii(value);
		}
		return AllBytesInUInt64AreAscii(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool FirstCharInUInt32IsAscii(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		if ((value & 0xFF80) != 0)
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nuint GetIndexOfFirstNonAsciiByte(byte* pBuffer, nuint bufferLength)
	{
		_ = 0;
		_ = 0;
		_ = 0;
		if (false)
		{
		}
		return GetIndexOfFirstNonAsciiByte_Vector(pBuffer, bufferLength);
	}

	private unsafe static nuint GetIndexOfFirstNonAsciiByte_Vector(byte* pBuffer, nuint bufferLength)
	{
		byte* ptr = pBuffer;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && bufferLength >= (uint)(2 * Vector128<byte>.Count) && !VectorContainsNonAsciiChar(Vector128.Load(pBuffer)))
		{
			byte* ptr2 = pBuffer + bufferLength - 16;
			pBuffer = (byte*)((nuint)(pBuffer + 16) & (nuint)(~(nint)15));
			while (!VectorContainsNonAsciiChar(Vector128.LoadAligned(pBuffer)))
			{
				pBuffer += 16;
				if (pBuffer > ptr2)
				{
					break;
				}
			}
			bufferLength -= (nuint)pBuffer;
			bufferLength = (nuint)(bufferLength + ptr);
		}
		while (true)
		{
			uint num;
			if (bufferLength >= 8)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				uint num2 = Unsafe.ReadUnaligned<uint>(pBuffer + 4);
				if (!AllBytesInUInt32AreAscii(num | num2))
				{
					if (AllBytesInUInt32AreAscii(num))
					{
						num = num2;
						pBuffer += 4;
					}
					goto IL_00f4;
				}
				pBuffer += 8;
				bufferLength -= 8;
				continue;
			}
			if ((bufferLength & 4) != 0)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				if (!AllBytesInUInt32AreAscii(num))
				{
					goto IL_00f4;
				}
				pBuffer += 4;
			}
			if ((bufferLength & 2) != 0)
			{
				num = Unsafe.ReadUnaligned<ushort>(pBuffer);
				if (!AllBytesInUInt32AreAscii(num) && BitConverter.IsLittleEndian)
				{
					goto IL_00f4;
				}
				pBuffer += 2;
			}
			if ((bufferLength & 1) != 0 && *pBuffer >= 0)
			{
				pBuffer++;
			}
			break;
			IL_00f4:
			pBuffer += CountNumberOfLeadingAsciiBytesFromUInt32WithSomeNonAsciiData(num);
			break;
		}
		return (nuint)(pBuffer - (nuint)ptr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static nuint GetIndexOfFirstNonAsciiChar(char* pBuffer, nuint bufferLength)
	{
		_ = 0;
		_ = 0;
		_ = 0;
		if (false)
		{
		}
		return GetIndexOfFirstNonAsciiChar_Vector(pBuffer, bufferLength);
	}

	private unsafe static nuint GetIndexOfFirstNonAsciiChar_Vector(char* pBuffer, nuint bufferLength)
	{
		char* ptr = pBuffer;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && bufferLength >= (uint)(2 * Vector128<ushort>.Count) && !VectorContainsNonAsciiChar(Vector128.Load((ushort*)pBuffer)))
		{
			char* ptr2 = pBuffer + bufferLength - 8u;
			pBuffer = (char*)((nuint)(pBuffer + 8) & (nuint)(~(nint)15));
			while (!VectorContainsNonAsciiChar(Vector128.LoadAligned((ushort*)pBuffer)))
			{
				pBuffer += 8u;
				if (pBuffer > ptr2)
				{
					break;
				}
			}
			bufferLength -= (nuint)(nint)(pBuffer - ptr);
		}
		while (true)
		{
			uint num;
			if (bufferLength >= 4)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				uint num2 = Unsafe.ReadUnaligned<uint>(pBuffer + 2);
				if (!AllCharsInUInt32AreAscii(num | num2))
				{
					if (AllCharsInUInt32AreAscii(num))
					{
						num = num2;
						pBuffer += 2;
					}
					goto IL_00f1;
				}
				pBuffer += 4;
				bufferLength -= 4;
				continue;
			}
			if ((bufferLength & 2) != 0)
			{
				num = Unsafe.ReadUnaligned<uint>(pBuffer);
				if (!AllCharsInUInt32AreAscii(num))
				{
					goto IL_00f1;
				}
				pBuffer += 2;
			}
			if ((bufferLength & 1) != 0 && *pBuffer <= '\u007f')
			{
				pBuffer++;
			}
			break;
			IL_00f1:
			if (FirstCharInUInt32IsAscii(num))
			{
				pBuffer++;
			}
			break;
		}
		return (nuint)(pBuffer - ptr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void NarrowTwoUtf16CharsToAsciiAndWriteToBuffer(ref byte outputBuffer, uint value)
	{
		_ = BitConverter.IsLittleEndian;
		outputBuffer = (byte)value;
		Unsafe.Add(ref outputBuffer, 1) = (byte)(value >> 16);
	}

	internal unsafe static nuint NarrowUtf16ToAscii(char* pUtf16Buffer, byte* pAsciiBuffer, nuint elementCount)
	{
		nuint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		ulong num4 = 0uL;
		_ = BitConverter.IsLittleEndian;
		if (Vector128.IsHardwareAccelerated && elementCount >= (uint)(2 * Vector128<byte>.Count))
		{
			if (4 >= 8)
			{
			}
			num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer);
			num3 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + 2);
			if (!AllCharsInUInt32AreAscii(num2 | num3))
			{
				goto IL_011d;
			}
			if (false)
			{
			}
			if (false)
			{
			}
			num = NarrowUtf16ToAscii_Intrinsified(pUtf16Buffer, pAsciiBuffer, elementCount);
		}
		nuint num5 = elementCount - num;
		if (num5 < 4)
		{
			goto IL_00c9;
		}
		nuint num6 = num + num5 - 4;
		while (true)
		{
			if (4 >= 8)
			{
			}
			num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num);
			num3 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num + 2);
			if (!AllCharsInUInt32AreAscii(num2 | num3))
			{
				break;
			}
			NarrowTwoUtf16CharsToAsciiAndWriteToBuffer(ref pAsciiBuffer[num], num2);
			NarrowTwoUtf16CharsToAsciiAndWriteToBuffer(ref pAsciiBuffer[num + 2], num3);
			num += 4;
			if (num <= num6)
			{
				continue;
			}
			goto IL_00c9;
		}
		goto IL_011d;
		IL_011d:
		if (4 >= 8)
		{
		}
		if (AllCharsInUInt32AreAscii(num2))
		{
			NarrowTwoUtf16CharsToAsciiAndWriteToBuffer(ref pAsciiBuffer[num], num2);
			num2 = num3;
			num += 2;
		}
		goto IL_013f;
		IL_011b:
		return num;
		IL_013f:
		if (FirstCharInUInt32IsAscii(num2))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			pAsciiBuffer[num] = (byte)num2;
			num++;
		}
		goto IL_011b;
		IL_00c9:
		if (((int)num5 & 2) != 0)
		{
			num2 = Unsafe.ReadUnaligned<uint>(pUtf16Buffer + num);
			if (!AllCharsInUInt32AreAscii(num2))
			{
				goto IL_013f;
			}
			NarrowTwoUtf16CharsToAsciiAndWriteToBuffer(ref pAsciiBuffer[num], num2);
			num += 2;
		}
		if (((int)num5 & 1) != 0)
		{
			num2 = pUtf16Buffer[num];
			if (num2 <= 127)
			{
				pAsciiBuffer[num] = (byte)num2;
				num++;
			}
		}
		goto IL_011b;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool VectorContainsNonAsciiChar(Vector128<byte> asciiVector)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return asciiVector.ExtractMostSignificantBits() != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool VectorContainsNonAsciiChar(Vector128<ushort> utf16Vector)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		return (utf16Vector & Vector128.Create((ushort)65408)) != Vector128<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool VectorContainsNonAsciiChar(Vector256<ushort> utf16Vector)
	{
		return (utf16Vector & Vector256.Create((ushort)65408)) != Vector256<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool VectorContainsNonAsciiChar(Vector512<ushort> utf16Vector)
	{
		return (utf16Vector & Vector512.Create((ushort)65408)) != Vector512<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool VectorContainsNonAsciiChar<T>(Vector128<T> vector) where T : unmanaged
	{
		if (!(typeof(T) == typeof(byte)))
		{
			return VectorContainsNonAsciiChar(vector.AsUInt16());
		}
		return VectorContainsNonAsciiChar(vector.AsByte());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInVectorAreAscii<T>(Vector128<T> vector) where T : unmanaged
	{
		if (typeof(T) == typeof(byte))
		{
			_ = 0;
			_ = 0;
			return vector.AsByte().ExtractMostSignificantBits() == 0;
		}
		_ = 0;
		return (vector.AsUInt16() & Vector128.Create((ushort)65408)) == Vector128<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInVectorAreAscii<T>(Vector256<T> vector) where T : unmanaged
	{
		if (typeof(T) == typeof(byte))
		{
			_ = 0;
			return vector.AsByte().ExtractMostSignificantBits() == 0;
		}
		return (vector.AsUInt16() & Vector256.Create((ushort)65408)) == Vector256<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AllCharsInVectorAreAscii<T>(Vector512<T> vector) where T : unmanaged
	{
		if (typeof(T) == typeof(byte))
		{
			return vector.AsByte().ExtractMostSignificantBits() == 0;
		}
		return (vector.AsUInt16() & Vector512.Create((ushort)65408)) == Vector512<ushort>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Vector128<byte> ExtractAsciiVector(Vector128<ushort> vectorFirst, Vector128<ushort> vectorSecond)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		if (false)
		{
		}
		return Vector128.Narrow(vectorFirst, vectorSecond);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Vector256<byte> ExtractAsciiVector(Vector256<ushort> vectorFirst, Vector256<ushort> vectorSecond)
	{
		_ = 0;
		return Vector256.Narrow(vectorFirst, vectorSecond);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Vector512<byte> ExtractAsciiVector(Vector512<ushort> vectorFirst, Vector512<ushort> vectorSecond)
	{
		_ = 0;
		return Vector512.Narrow(vectorFirst, vectorSecond);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static nuint NarrowUtf16ToAscii_Intrinsified(char* pUtf16Buffer, byte* pAsciiBuffer, nuint elementCount)
	{
		uint count = (uint)Vector128<byte>.Count;
		nuint num = count - 1;
		ref ushort source = ref *(ushort*)pUtf16Buffer;
		Vector128<ushort> vector = Vector128.LoadUnsafe(in source);
		if (VectorContainsNonAsciiChar(vector))
		{
			return 0u;
		}
		ref byte destination = ref *pAsciiBuffer;
		ExtractAsciiVector(vector, vector).StoreLowerUnsafe(ref destination, 0u);
		nuint num2 = count / 2;
		if (((uint)(int)pAsciiBuffer & (count / 2)) == 0)
		{
			vector = Vector128.LoadUnsafe(in source, num2);
			if (VectorContainsNonAsciiChar(vector))
			{
				goto IL_00b4;
			}
			ExtractAsciiVector(vector, vector).StoreLowerUnsafe(ref destination, num2);
		}
		num2 = count - ((nuint)pAsciiBuffer & num);
		nuint num3 = elementCount - count;
		do
		{
			vector = Vector128.LoadUnsafe(in source, num2);
			Vector128<ushort> vector2 = Vector128.LoadUnsafe(in source, num2 + count / 2);
			if (!VectorContainsNonAsciiChar(vector | vector2))
			{
				ExtractAsciiVector(vector, vector2).StoreUnsafe(ref destination, num2);
				num2 += count;
				continue;
			}
			if (!VectorContainsNonAsciiChar(vector))
			{
				ExtractAsciiVector(vector, vector).StoreLowerUnsafe(ref destination, num2);
				num2 += count / 2;
			}
			break;
		}
		while (num2 <= num3);
		goto IL_00b4;
		IL_00b4:
		return num2;
	}

	internal unsafe static nuint WidenAsciiToUtf16(byte* pAsciiBuffer, char* pUtf16Buffer, nuint elementCount)
	{
		nuint currentOffset = 0u;
		_ = BitConverter.IsLittleEndian;
		if (Vector128.IsHardwareAccelerated && elementCount >= (uint)Vector128<byte>.Count)
		{
			if (false)
			{
			}
			if (false)
			{
			}
			if (Vector128.IsHardwareAccelerated && elementCount - currentOffset >= (uint)Vector128<byte>.Count)
			{
				WidenAsciiToUtf1_Vector<Vector128<byte>, Vector128<ushort>>(pAsciiBuffer, pUtf16Buffer, ref currentOffset, elementCount);
			}
		}
		nuint num = elementCount - currentOffset;
		if (num < 4)
		{
			goto IL_0078;
		}
		nuint num2 = currentOffset + num - 4;
		uint num3;
		while (true)
		{
			num3 = Unsafe.ReadUnaligned<uint>(pAsciiBuffer + currentOffset);
			if (!AllBytesInUInt32AreAscii(num3))
			{
				break;
			}
			WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref pUtf16Buffer[currentOffset], num3);
			currentOffset += 4;
			if (currentOffset <= num2)
			{
				continue;
			}
			goto IL_0078;
		}
		goto IL_00e8;
		IL_00e8:
		_ = BitConverter.IsLittleEndian;
		while (((byte)num3 & 0x80) == 0)
		{
			pUtf16Buffer[currentOffset] = (char)(byte)num3;
			currentOffset++;
			num3 >>= 8;
		}
		goto IL_00e6;
		IL_00e6:
		return currentOffset;
		IL_0078:
		if (((int)num & 2) != 0)
		{
			num3 = Unsafe.ReadUnaligned<ushort>(pAsciiBuffer + currentOffset);
			if (!AllBytesInUInt32AreAscii(num3) && BitConverter.IsLittleEndian)
			{
				goto IL_00e8;
			}
			_ = BitConverter.IsLittleEndian;
			pUtf16Buffer[currentOffset] = (char)(byte)num3;
			pUtf16Buffer[currentOffset + 1] = (char)(num3 >> 8);
			currentOffset += 2;
		}
		if (((int)num & 1) != 0)
		{
			num3 = pAsciiBuffer[currentOffset];
			if (((byte)num3 & 0x80) == 0)
			{
				pUtf16Buffer[currentOffset] = (char)num3;
				currentOffset++;
			}
		}
		goto IL_00e6;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void WidenAsciiToUtf1_Vector<TVectorByte, TVectorUInt16>(byte* pAsciiBuffer, char* pUtf16Buffer, ref nuint currentOffset, nuint elementCount) where TVectorByte : unmanaged, ISimdVector<TVectorByte, byte> where TVectorUInt16 : unmanaged, ISimdVector<TVectorUInt16, ushort>
	{
		ushort* ptr = (ushort*)pUtf16Buffer;
		nuint num = elementCount - (nuint)TVectorByte.ElementCount;
		TVectorByte vector = TVectorByte.Load(pAsciiBuffer + currentOffset);
		if (HasMatch(vector))
		{
			return;
		}
		TVectorUInt16 source2;
		TVectorUInt16 source;
		(source, source2) = Widen<TVectorByte, TVectorUInt16>(vector);
		source.Store(ptr);
		source2.Store(ptr + TVectorUInt16.ElementCount);
		ptr += (nuint)(TVectorUInt16.ElementCount * 2);
		if ((nuint)ptr % (nuint)2u == 0)
		{
			ptr = (ushort*)((nuint)ptr & (nuint)(~(nint)(TVectorUInt16.Alignment - 1)));
			nuint num2 = (nuint)((byte*)ptr - (nuint)pUtf16Buffer);
			currentOffset += num2 / 2;
		}
		else
		{
			currentOffset += (nuint)TVectorByte.ElementCount;
		}
		while (currentOffset <= num)
		{
			vector = TVectorByte.Load(pAsciiBuffer + currentOffset);
			if (HasMatch(vector))
			{
				break;
			}
			TVectorUInt16 source3;
			(source, source3) = Widen<TVectorByte, TVectorUInt16>(vector);
			source.Store(ptr);
			source3.Store(ptr + TVectorUInt16.ElementCount);
			currentOffset += (nuint)TVectorByte.ElementCount;
			ptr += (nuint)(TVectorUInt16.ElementCount * 2);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool HasMatch<TVectorByte>(TVectorByte vector) where TVectorByte : unmanaged, ISimdVector<TVectorByte, byte>
	{
		return !(vector & TVectorByte.Create(128)).Equals(TVectorByte.Zero);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static (TVectorUInt16 Lower, TVectorUInt16 Upper) Widen<TVectorByte, TVectorUInt16>(TVectorByte vector) where TVectorByte : unmanaged, ISimdVector<TVectorByte, byte> where TVectorUInt16 : unmanaged, ISimdVector<TVectorUInt16, ushort>
	{
		if (typeof(TVectorByte) == typeof(Vector256<byte>))
		{
			var (vector2, vector3) = Vector256.Widen((Vector256<byte>)(object)vector);
			return (Lower: (TVectorUInt16)(object)vector2, Upper: (TVectorUInt16)(object)vector3);
		}
		if (typeof(TVectorByte) == typeof(Vector512<byte>))
		{
			var (vector4, vector5) = Vector512.Widen((Vector512<byte>)(object)vector);
			return (Lower: (TVectorUInt16)(object)vector4, Upper: (TVectorUInt16)(object)vector5);
		}
		var (vector6, vector7) = Vector128.Widen((Vector128<byte>)(object)vector);
		return (Lower: (TVectorUInt16)(object)vector6, Upper: (TVectorUInt16)(object)vector7);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void WidenFourAsciiBytesToUtf16AndWriteToBuffer(ref char outputBuffer, uint value)
	{
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated)
		{
			Vector128<ulong> vector = Vector128.WidenLower(Vector128.CreateScalar(value).AsByte()).AsUInt64();
			Unsafe.WriteUnaligned(ref Unsafe.As<char, byte>(ref outputBuffer), vector.ToScalar());
			return;
		}
		_ = BitConverter.IsLittleEndian;
		outputBuffer = (char)(byte)value;
		value >>= 8;
		Unsafe.Add(ref outputBuffer, 1) = (char)(byte)value;
		value >>= 8;
		Unsafe.Add(ref outputBuffer, 2) = (char)(byte)value;
		value >>= 8;
		Unsafe.Add(ref outputBuffer, 3) = (char)value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool AllBytesInUInt32AreAscii(uint value)
	{
		return (value & 0x80808080u) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint CountNumberOfLeadingAsciiBytesFromUInt32WithSomeNonAsciiData(uint value)
	{
		_ = BitConverter.IsLittleEndian;
		return (uint)BitOperations.TrailingZeroCount(value & 0x80808080u) >> 3;
	}
}
