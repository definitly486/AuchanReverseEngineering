using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace System;

internal static class SpanHelpers
{
	internal readonly ref struct ComparerComparable<T, TComparer> : IComparable<T> where TComparer : IComparer<T>
	{
		private readonly T _value;

		private readonly TComparer _comparer;

		public ComparerComparable(T value, TComparer comparer)
		{
			_value = value;
			_comparer = comparer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(T other)
		{
			return _comparer.Compare(_value, other);
		}
	}

	internal interface INegator<T> where T : struct
	{
		static abstract bool NegateIfNeeded(bool equals);

		static abstract Vector128<T> NegateIfNeeded(Vector128<T> equals);

		static abstract Vector256<T> NegateIfNeeded(Vector256<T> equals);

		static abstract Vector512<T> NegateIfNeeded(Vector512<T> equals);

		static abstract bool HasMatch<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>;

		static abstract TVector GetMatchMask<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct DontNegate<T> : INegator<T> where T : struct
	{
		public static bool NegateIfNeeded(bool equals)
		{
			return equals;
		}

		public static Vector128<T> NegateIfNeeded(Vector128<T> equals)
		{
			return equals;
		}

		public static Vector256<T> NegateIfNeeded(Vector256<T> equals)
		{
			return equals;
		}

		public static Vector512<T> NegateIfNeeded(Vector512<T> equals)
		{
			return equals;
		}

		public static bool HasMatch<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>
		{
			return TVector.EqualsAny(left, right);
		}

		public static TVector GetMatchMask<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>
		{
			return TVector.Equals(left, right);
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct Negate<T> : INegator<T> where T : struct
	{
		public static bool NegateIfNeeded(bool equals)
		{
			return !equals;
		}

		public static Vector128<T> NegateIfNeeded(Vector128<T> equals)
		{
			return ~equals;
		}

		public static Vector256<T> NegateIfNeeded(Vector256<T> equals)
		{
			return ~equals;
		}

		public static Vector512<T> NegateIfNeeded(Vector512<T> equals)
		{
			return ~equals;
		}

		public static bool HasMatch<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>
		{
			return !TVector.EqualsAll(left, right);
		}

		public static TVector GetMatchMask<TVector>(TVector left, TVector right) where TVector : struct, ISimdVector<TVector, T>
		{
			return ~TVector.Equals(left, right);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int BinarySearch<T, TComparable>(ReadOnlySpan<T> span, TComparable comparable) where TComparable : IComparable<T>
	{
		if (comparable == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.comparable);
		}
		return BinarySearch(ref MemoryMarshal.GetReference(span), span.Length, comparable);
	}

	public static int BinarySearch<T, TComparable>(ref T spanStart, int length, TComparable comparable) where TComparable : IComparable<T>
	{
		int num = 0;
		int num2 = length - 1;
		while (num <= num2)
		{
			int num3 = num2 + num >>> 1;
			int num4 = comparable.CompareTo(Unsafe.Add(ref spanStart, num3));
			if (num4 == 0)
			{
				return num3;
			}
			if (num4 > 0)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return ~num;
	}

	public static int IndexOf(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
	{
		if (valueLength == 0)
		{
			return 0;
		}
		int num = valueLength - 1;
		if (num == 0)
		{
			return IndexOfValueType(ref searchSpace, value, searchSpaceLength);
		}
		nint num2 = 0;
		byte value2 = value;
		int num3 = searchSpaceLength - num;
		if (!Vector128.IsHardwareAccelerated || num3 < Vector128<byte>.Count)
		{
			ref byte second = ref Unsafe.Add(ref value, 1);
			int num4 = num3;
			while (num4 > 0)
			{
				int num5 = IndexOfValueType(ref Unsafe.Add(ref searchSpace, num2), value2, num4);
				if (num5 < 0)
				{
					break;
				}
				num4 -= num5;
				num2 += num5;
				if (num4 <= 0)
				{
					break;
				}
				if (SequenceEqual(ref Unsafe.Add(ref searchSpace, num2 + 1), ref second, (uint)num))
				{
					return (int)num2;
				}
				num4--;
				num2++;
			}
			return -1;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		byte b = Unsafe.Add(ref value, num);
		int num6 = num;
		while (b == value && num6 > 1)
		{
			b = Unsafe.Add(ref value, --num6);
		}
		Vector128<byte> left = Vector128.Create(value);
		Vector128<byte> left2 = Vector128.Create(b);
		nint num7 = (nint)num3 - (nint)Vector128<byte>.Count;
		while (true)
		{
			Vector128<byte> vector = Vector128.Equals(left2, Vector128.LoadUnsafe(in searchSpace, (nuint)(num2 + num6)));
			Vector128<byte> vector2 = (Vector128.Equals(left, Vector128.LoadUnsafe(in searchSpace, (nuint)num2)) & vector).AsByte();
			if (vector2 != Vector128<byte>.Zero)
			{
				uint num8 = vector2.ExtractMostSignificantBits();
				do
				{
					int num9 = BitOperations.TrailingZeroCount(num8);
					if (valueLength == 2 || SequenceEqual(ref Unsafe.Add(ref searchSpace, num2 + num9), ref value, (uint)valueLength))
					{
						return (int)(num2 + num9);
					}
					num8 = BitOperations.ResetLowestSetBit(num8);
				}
				while (num8 != 0);
			}
			num2 += Vector128<byte>.Count;
			if (num2 == num3)
			{
				break;
			}
			if (num2 > num7)
			{
				num2 = num7;
			}
		}
		return -1;
	}

	public static int LastIndexOf(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength)
	{
		if (valueLength == 0)
		{
			return searchSpaceLength;
		}
		int num = valueLength - 1;
		if (num == 0)
		{
			return LastIndexOfValueType(ref searchSpace, value, searchSpaceLength);
		}
		int num2 = 0;
		byte value2 = value;
		int num3 = searchSpaceLength - num;
		if (!Vector128.IsHardwareAccelerated || num3 < Vector128<byte>.Count)
		{
			ref byte second = ref Unsafe.Add(ref value, 1);
			while (true)
			{
				int num4 = searchSpaceLength - num2 - num;
				if (num4 <= 0)
				{
					break;
				}
				int num5 = LastIndexOfValueType(ref searchSpace, value2, num4);
				if (num5 < 0)
				{
					break;
				}
				if (SequenceEqual(ref Unsafe.Add(ref searchSpace, num5 + 1), ref second, (uint)num))
				{
					return num5;
				}
				num2 += num4 - num5;
			}
			return -1;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		num2 = num3 - Vector128<byte>.Count;
		byte b = Unsafe.Add(ref value, num);
		int num6 = num;
		while (b == value && num6 > 1)
		{
			b = Unsafe.Add(ref value, --num6);
		}
		Vector128<byte> left = Vector128.Create(value);
		Vector128<byte> left2 = Vector128.Create(b);
		while (true)
		{
			Vector128<byte> vector = Vector128.Equals(left, Vector128.LoadUnsafe(in searchSpace, (nuint)num2));
			Vector128<byte> vector2 = Vector128.Equals(left2, Vector128.LoadUnsafe(in searchSpace, (nuint)(num2 + num6)));
			Vector128<byte> vector3 = (vector & vector2).AsByte();
			if (vector3 != Vector128<byte>.Zero)
			{
				uint num7 = vector3.ExtractMostSignificantBits();
				do
				{
					int num8 = 31 - BitOperations.LeadingZeroCount(num7);
					if (valueLength == 2 || SequenceEqual(ref Unsafe.Add(ref searchSpace, num2 + num8), ref value, (uint)valueLength))
					{
						return num8 + num2;
					}
					num7 = BitOperations.FlipBit(num7, num8);
				}
				while (num7 != 0);
			}
			num2 -= Vector128<byte>.Count;
			if (num2 == -Vector128<byte>.Count)
			{
				break;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
		}
		return -1;
	}

	[DoesNotReturn]
	private static void ThrowMustBeNullTerminatedString()
	{
		throw new ArgumentException("Arg_MustBeNullTerminatedString");
	}

	internal unsafe static int IndexOfNullByte(byte* searchSpace)
	{
		nuint num = 0u;
		nuint num2 = 2147483647u;
		if (Vector128.IsHardwareAccelerated)
		{
			num2 = UnalignedCountVector128(searchSpace);
		}
		while (true)
		{
			if (num2 >= 8)
			{
				num2 -= 8;
				if (searchSpace[num] != 0)
				{
					if (searchSpace[num + 1] == 0)
					{
						goto IL_018e;
					}
					if (searchSpace[num + 2] == 0)
					{
						goto IL_0194;
					}
					if (searchSpace[num + 3] != 0)
					{
						if (searchSpace[num + 4] != 0)
						{
							if (searchSpace[num + 5] != 0)
							{
								if (searchSpace[num + 6] != 0)
								{
									if (searchSpace[num + 7] == 0)
									{
										break;
									}
									num += 8;
									continue;
								}
								return (int)(num + 6);
							}
							return (int)(num + 5);
						}
						return (int)(num + 4);
					}
					goto IL_019a;
				}
			}
			else
			{
				if (num2 >= 4)
				{
					num2 -= 4;
					if (searchSpace[num] == 0)
					{
						goto IL_018b;
					}
					if (searchSpace[num + 1] == 0)
					{
						goto IL_018e;
					}
					if (searchSpace[num + 2] == 0)
					{
						goto IL_0194;
					}
					if (searchSpace[num + 3] == 0)
					{
						goto IL_019a;
					}
					num += 4;
				}
				while (num2 != 0)
				{
					num2--;
					if (searchSpace[num] != 0)
					{
						num++;
						continue;
					}
					goto IL_018b;
				}
				if (false)
				{
				}
				if (false)
				{
				}
				if (Vector128.IsHardwareAccelerated && num < int.MaxValue)
				{
					for (num2 = GetByteVector128SpanLength(num, int.MaxValue); num2 > num; num += (nuint)Vector128<byte>.Count)
					{
						Vector128<byte> right = Vector128.Load(searchSpace + num);
						Vector128<byte> vector = Vector128.Equals(Vector128<byte>.Zero, right);
						if (!(vector == Vector128<byte>.Zero))
						{
							uint value = vector.ExtractMostSignificantBits();
							return (int)(num + (uint)BitOperations.TrailingZeroCount(value));
						}
					}
					if (num < int.MaxValue)
					{
						num2 = int.MaxValue - num;
						continue;
					}
				}
				ThrowMustBeNullTerminatedString();
			}
			goto IL_018b;
			IL_018e:
			return (int)(num + 1);
			IL_019a:
			return (int)(num + 3);
			IL_0194:
			return (int)(num + 2);
			IL_018b:
			return (int)num;
		}
		return (int)(num + 7);
	}

	[Intrinsic]
	public static bool SequenceEqual(ref byte first, ref byte second, nuint length)
	{
		if (length < 4)
		{
			uint num = 0u;
			nuint num2 = length & 2;
			if (num2 != 0)
			{
				num = LoadUShort(ref first);
				num -= LoadUShort(ref second);
			}
			if ((length & 1) != 0)
			{
				num |= (uint)(Unsafe.AddByteOffset(ref first, num2) - Unsafe.AddByteOffset(ref second, num2));
			}
			return num == 0;
		}
		if (Unsafe.AreSame(in first, in second))
		{
			goto IL_0051;
		}
		nuint num4;
		if (Vector128.IsHardwareAccelerated)
		{
			if (false)
			{
			}
			if (false)
			{
			}
			if (length >= (nuint)Vector128<byte>.Count)
			{
				nuint num3 = 0u;
				num4 = length - (nuint)Vector128<byte>.Count;
				if (num4 == 0)
				{
					goto IL_00a6;
				}
				while (!(Vector128.LoadUnsafe(in first, num3) != Vector128.LoadUnsafe(in second, num3)))
				{
					num3 += (nuint)Vector128<byte>.Count;
					if (num4 > num3)
					{
						continue;
					}
					goto IL_00a6;
				}
				goto IL_0111;
			}
		}
		nuint num5 = 0u;
		nuint num6 = length - 4;
		if (num6 == 0)
		{
			goto IL_00f9;
		}
		while (LoadNUInt(ref first, num5) == LoadNUInt(ref second, num5))
		{
			num5 += 4;
			if (num6 > num5)
			{
				continue;
			}
			goto IL_00f9;
		}
		goto IL_0111;
		IL_0051:
		return true;
		IL_00f9:
		return LoadNUInt(ref first, num6) == LoadNUInt(ref second, num6);
		IL_00a6:
		if (Vector128.LoadUnsafe(in first, num4) == Vector128.LoadUnsafe(in second, num4))
		{
			goto IL_0051;
		}
		goto IL_0111;
		IL_0111:
		return false;
	}

	public static int SequenceCompareTo(ref byte first, int firstLength, ref byte second, int secondLength)
	{
		nuint num;
		nuint num2;
		if (!Unsafe.AreSame(in first, in second))
		{
			num = (uint)(((uint)firstLength < (uint)secondLength) ? firstLength : secondLength);
			num2 = 0u;
			nuint num3 = num;
			if (false)
			{
			}
			if (Vector128.IsHardwareAccelerated && num3 >= (nuint)Vector128<byte>.Count)
			{
				num3 -= (nuint)Vector128<byte>.Count;
				while (num3 > num2)
				{
					if (Vector128.LoadUnsafe(in first, num2) == Vector128.LoadUnsafe(in second, num2))
					{
						num2 += (nuint)Vector128<byte>.Count;
						continue;
					}
					goto IL_00cc;
				}
				num2 = num3;
				if (Vector128.LoadUnsafe(in first, num2) == Vector128.LoadUnsafe(in second, num2))
				{
					goto IL_00d0;
				}
			}
			else if (num3 > 4)
			{
				for (num3 -= 4; num3 > num2 && LoadNUInt(ref first, num2) == LoadNUInt(ref second, num2); num2 += 4)
				{
				}
			}
			goto IL_00cc;
		}
		goto IL_00d0;
		IL_00cc:
		for (; num > num2; num2++)
		{
			int num4 = Unsafe.AddByteOffset(ref first, num2).CompareTo(Unsafe.AddByteOffset(ref second, num2));
			if (num4 != 0)
			{
				return num4;
			}
		}
		goto IL_00d0;
		IL_00d0:
		return firstLength - secondLength;
	}

	public static nuint CommonPrefixLength(ref byte first, ref byte second, nuint length)
	{
		nuint num;
		if (!Vector128.IsHardwareAccelerated || length < (nuint)Vector128<byte>.Count)
		{
			num = length % 4;
			if (num != 0)
			{
				if (first != second)
				{
					return 0u;
				}
				if (num > 1)
				{
					if (Unsafe.Add(ref first, 1) != Unsafe.Add(ref second, 1))
					{
						return 1u;
					}
					if (num > 2 && Unsafe.Add(ref first, 2) != Unsafe.Add(ref second, 2))
					{
						return 2u;
					}
				}
			}
			while (true)
			{
				if ((nint)num <= (nint)(length - 4))
				{
					if (Unsafe.Add(ref first, num + 0) == Unsafe.Add(ref second, num + 0))
					{
						if (Unsafe.Add(ref first, num + 1) == Unsafe.Add(ref second, num + 1))
						{
							if (Unsafe.Add(ref first, num + 2) == Unsafe.Add(ref second, num + 2))
							{
								if (Unsafe.Add(ref first, num + 3) != Unsafe.Add(ref second, num + 3))
								{
									break;
								}
								num += 4;
								continue;
							}
							return num + 2;
						}
						return num + 1;
					}
					return num;
				}
				return length;
			}
			return num + 3;
		}
		nuint num2 = length - (nuint)Vector128<byte>.Count;
		num = 0u;
		uint num3;
		while (true)
		{
			if (num < num2)
			{
				num3 = Vector128.Equals(Vector128.LoadUnsafe(in first, num), Vector128.LoadUnsafe(in second, num)).ExtractMostSignificantBits();
				if (num3 != 65535)
				{
					break;
				}
				num += (nuint)Vector128<byte>.Count;
				continue;
			}
			num = num2;
			num3 = Vector128.Equals(Vector128.LoadUnsafe(in first, num), Vector128.LoadUnsafe(in second, num)).ExtractMostSignificantBits();
			if (num3 != 65535)
			{
				break;
			}
			return length;
		}
		num3 = ~num3;
		return num + uint.TrailingZeroCount(num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ushort LoadUShort(ref byte start)
	{
		return Unsafe.ReadUnaligned<ushort>(in start);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static nuint LoadNUInt(ref byte start, nuint offset)
	{
		return Unsafe.ReadUnaligned<nuint>(in Unsafe.AddByteOffset(ref start, offset));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static nuint GetByteVector128SpanLength(nuint offset, int length)
	{
		return (uint)((length - (int)offset) & ~(Vector128<byte>.Count - 1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static nuint UnalignedCountVector128(byte* searchSpace)
	{
		nint num = (nint)searchSpace & (nint)(Vector128<byte>.Count - 1);
		return (uint)((Vector128<byte>.Count - num) & (Vector128<byte>.Count - 1));
	}

	public static void Reverse(ref byte buf, nuint length)
	{
		nint num = (nint)length;
		nint num2 = 0;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && num >= Vector128<byte>.Count * 2)
		{
			nint num3 = num - Vector128<byte>.Count;
			do
			{
				Vector128<byte> vector = Vector128.LoadUnsafe(in buf, (nuint)num2);
				Vector128<byte> vector2 = Vector128.LoadUnsafe(in buf, (nuint)num3);
				Vector128<byte> source = Vector128.Shuffle(vector, Vector128.Create((byte)15, (byte)14, (byte)13, (byte)12, (byte)11, (byte)10, (byte)9, (byte)8, (byte)7, (byte)6, (byte)5, (byte)4, (byte)3, (byte)2, (byte)1, (byte)0));
				vector2 = Vector128.Shuffle(vector2, Vector128.Create((byte)15, (byte)14, (byte)13, (byte)12, (byte)11, (byte)10, (byte)9, (byte)8, (byte)7, (byte)6, (byte)5, (byte)4, (byte)3, (byte)2, (byte)1, (byte)0));
				vector2.StoreUnsafe(ref buf, (nuint)num2);
				source.StoreUnsafe(ref buf, (nuint)num3);
				num2 += Vector128<byte>.Count;
				num3 -= Vector128<byte>.Count;
			}
			while (num3 >= num2);
			num = num3 + Vector128<byte>.Count - num2;
		}
		if (num >= 8)
		{
			nint num4 = (nint)length - num2 - 8;
			do
			{
				long value = Unsafe.ReadUnaligned<long>(in Unsafe.Add(ref buf, num2));
				long value2 = Unsafe.ReadUnaligned<long>(in Unsafe.Add(ref buf, num4));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref buf, num2), BinaryPrimitives.ReverseEndianness(value2));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref buf, num4), BinaryPrimitives.ReverseEndianness(value));
				num2 += 8;
				num4 -= 8;
			}
			while (num4 >= num2);
			num = num4 + 8 - num2;
		}
		if (num >= 4)
		{
			nint num5 = (nint)length - num2 - 4;
			do
			{
				int value3 = Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref buf, num2));
				int value4 = Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref buf, num5));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref buf, num2), BinaryPrimitives.ReverseEndianness(value4));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref buf, num5), BinaryPrimitives.ReverseEndianness(value3));
				num2 += 4;
				num5 -= 4;
			}
			while (num5 >= num2);
			num = num5 + 4 - num2;
		}
		if (num > 1)
		{
			ReverseInner(ref Unsafe.Add(ref buf, num2), (nuint)num);
		}
	}

	[Intrinsic]
	internal static void Memmove(ref byte dest, ref byte src, nuint len)
	{
		if ((nuint)Unsafe.ByteOffset(in src, in dest) >= len && (nuint)Unsafe.ByteOffset(in dest, in src) >= len)
		{
			ref byte source = ref Unsafe.Add(ref src, len);
			ref byte source2 = ref Unsafe.Add(ref dest, len);
			if (len > 16)
			{
				if (len > 64)
				{
					if (len > 512)
					{
						goto IL_04d7;
					}
					nuint num = len >> 6;
					do
					{
						Unsafe.WriteUnaligned(ref dest, Unsafe.ReadUnaligned<int>(in src));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 4)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 8), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 8)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 12), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 12)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 16), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 16)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 20), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 20)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 24), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 24)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 28), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 28)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 32), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 32)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 36), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 36)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 40), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 40)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 44), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 44)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 48), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 48)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 52), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 52)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 56), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 56)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 60), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 60)));
						dest = ref Unsafe.Add(ref dest, 64);
						src = ref Unsafe.Add(ref src, 64);
						num--;
					}
					while (num != 0);
					len %= 64;
					if (len <= 16)
					{
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -16), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -16)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -12), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -12)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -8), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -8)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -4)));
						return;
					}
				}
				Unsafe.WriteUnaligned(ref dest, Unsafe.ReadUnaligned<int>(in src));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 4)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 8), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 8)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 12), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 12)));
				if (len > 32)
				{
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 16), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 16)));
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 20), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 20)));
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 24), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 24)));
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 28), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 28)));
					if (len > 48)
					{
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 32), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 32)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 36), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 36)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 40), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 40)));
						Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 44), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 44)));
					}
				}
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -16), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -16)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -12), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -12)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -8), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -8)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -4)));
			}
			else if ((len & 0x18) != 0)
			{
				Unsafe.WriteUnaligned(ref dest, Unsafe.ReadUnaligned<int>(in src));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref src, 4)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -8), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -8)));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -4)));
			}
			else if ((len & 4) != 0)
			{
				Unsafe.WriteUnaligned(ref dest, Unsafe.ReadUnaligned<int>(in src));
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -4), Unsafe.ReadUnaligned<int>(in Unsafe.Add(ref source, -4)));
			}
			else if (len != 0)
			{
				dest = src;
				if ((len & 2) != 0)
				{
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref source2, -2), Unsafe.ReadUnaligned<short>(in Unsafe.Add(ref source, -2)));
				}
			}
			return;
		}
		if (Unsafe.AreSame(in dest, in src))
		{
			Unsafe.ReadUnaligned<byte>(in dest);
			return;
		}
		goto IL_04d7;
		IL_04d7:
		Unsafe.ReadUnaligned<byte>(in dest);
		Unsafe.ReadUnaligned<byte>(in src);
		Buffer.MemmoveInternal(ref dest, ref src, len);
	}

	[Intrinsic]
	public static void ClearWithoutReferences(ref byte dest, nuint len)
	{
		if (len == 0)
		{
			return;
		}
		ref byte source = ref Unsafe.Add(ref dest, len);
		if (len > 16)
		{
			if (len > 64)
			{
				if (len > 1024)
				{
					Unsafe.ReadUnaligned<byte>(in dest);
					Buffer.ZeroMemoryInternal(ref dest, len);
					return;
				}
				nuint num = len >> 6;
				do
				{
					Unsafe.WriteUnaligned(ref dest, 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 8), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 12), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 16), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 20), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 24), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 28), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 32), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 36), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 40), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 44), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 48), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 52), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 56), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 60), 0);
					dest = ref Unsafe.Add(ref dest, 64);
					num--;
				}
				while (num != 0);
				len %= 64;
				if (len <= 16)
				{
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -16), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -12), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -8), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -4), 0);
					return;
				}
			}
			Unsafe.WriteUnaligned(ref dest, 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 8), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 12), 0);
			if (len > 32)
			{
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 16), 0);
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 20), 0);
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 24), 0);
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 28), 0);
				if (len > 48)
				{
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 32), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 36), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 40), 0);
					Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 44), 0);
				}
			}
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -16), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -12), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -8), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -4), 0);
		}
		else if ((len & 0x18) != 0)
		{
			Unsafe.WriteUnaligned(ref dest, 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref dest, 4), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -8), 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -4), 0);
		}
		else if ((len & 4) != 0)
		{
			Unsafe.WriteUnaligned(ref dest, 0);
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -4), 0);
		}
		else if (len != 0)
		{
			dest = 0;
			if ((len & 2) != 0)
			{
				Unsafe.WriteUnaligned(ref Unsafe.Add(ref source, -2), (short)0);
			}
		}
	}

	public static int IndexOf(ref char searchSpace, int searchSpaceLength, ref char value, int valueLength)
	{
		if (valueLength == 0)
		{
			return 0;
		}
		int num = valueLength - 1;
		if (num == 0)
		{
			return IndexOfChar(ref searchSpace, value, searchSpaceLength);
		}
		nint num2 = 0;
		char c = value;
		int num3 = searchSpaceLength - num;
		if (!Vector128.IsHardwareAccelerated || num3 < Vector128<ushort>.Count)
		{
			ref byte second = ref Unsafe.As<char, byte>(ref Unsafe.Add(ref value, 1));
			int num4 = num3;
			while (num4 > 0)
			{
				int num5 = NonPackedIndexOfChar(ref Unsafe.Add(ref searchSpace, num2), c, num4);
				if (num5 < 0)
				{
					break;
				}
				num4 -= num5;
				num2 += num5;
				if (num4 <= 0)
				{
					break;
				}
				if (SequenceEqual(ref Unsafe.As<char, byte>(ref Unsafe.Add(ref searchSpace, num2 + 1)), ref second, (nuint)(uint)num * (nuint)2u))
				{
					return (int)num2;
				}
				num4--;
				num2++;
			}
			return -1;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		ushort num6 = Unsafe.Add(ref value, num);
		nint num7 = num;
		while (num6 == c && num7 > 1)
		{
			num6 = Unsafe.Add(ref value, --num7);
		}
		Vector128<ushort> left = Vector128.Create((ushort)c);
		Vector128<ushort> left2 = Vector128.Create(num6);
		nint num8 = (nint)num3 - (nint)Vector128<ushort>.Count;
		while (true)
		{
			Vector128<ushort> vector = Vector128.Equals(left2, Vector128.LoadUnsafe(ref searchSpace, (nuint)(num2 + num7)));
			Vector128<byte> vector2 = (Vector128.Equals(left, Vector128.LoadUnsafe(ref searchSpace, (nuint)num2)) & vector).AsByte();
			if (vector2 != Vector128<byte>.Zero)
			{
				uint num9 = vector2.ExtractMostSignificantBits();
				do
				{
					nint num10 = (nint)(uint.TrailingZeroCount(num9) / 2);
					if (valueLength == 2 || SequenceEqual(ref Unsafe.As<char, byte>(ref Unsafe.Add(ref searchSpace, num2 + num10)), ref Unsafe.As<char, byte>(ref value), (nuint)(uint)valueLength * (nuint)2u))
					{
						return (int)(num2 + num10);
					}
					num9 = BitOperations.ResetLowestSetBit(BitOperations.ResetLowestSetBit(num9));
				}
				while (num9 != 0);
			}
			num2 += Vector128<ushort>.Count;
			if (num2 == num3)
			{
				break;
			}
			if (num2 > num8)
			{
				num2 = num8;
			}
		}
		return -1;
	}

	public static int LastIndexOf(ref char searchSpace, int searchSpaceLength, ref char value, int valueLength)
	{
		if (valueLength == 0)
		{
			return searchSpaceLength;
		}
		int num = valueLength - 1;
		if (num == 0)
		{
			return LastIndexOfValueType(ref Unsafe.As<char, short>(ref searchSpace), (short)value, searchSpaceLength);
		}
		int num2 = 0;
		char c = value;
		int num3 = searchSpaceLength - num;
		if (!Vector128.IsHardwareAccelerated || num3 < Vector128<ushort>.Count)
		{
			ref byte second = ref Unsafe.As<char, byte>(ref Unsafe.Add(ref value, 1));
			while (true)
			{
				int num4 = searchSpaceLength - num2 - num;
				if (num4 <= 0)
				{
					break;
				}
				int num5 = LastIndexOfValueType(ref Unsafe.As<char, short>(ref searchSpace), (short)c, num4);
				if (num5 == -1)
				{
					break;
				}
				if (SequenceEqual(ref Unsafe.As<char, byte>(ref Unsafe.Add(ref searchSpace, num5 + 1)), ref second, (nuint)(uint)num * (nuint)2u))
				{
					return num5;
				}
				num2 += num4 - num5;
			}
			return -1;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		num2 = num3 - Vector128<ushort>.Count;
		char c2 = Unsafe.Add(ref value, num);
		int num6 = num;
		while (c2 == value && num6 > 1)
		{
			c2 = Unsafe.Add(ref value, --num6);
		}
		Vector128<ushort> left = Vector128.Create((ushort)value);
		Vector128<ushort> left2 = Vector128.Create((ushort)c2);
		while (true)
		{
			Vector128<ushort> vector = Vector128.Equals(left, Vector128.LoadUnsafe(ref searchSpace, (nuint)num2));
			Vector128<ushort> vector2 = Vector128.Equals(left2, Vector128.LoadUnsafe(ref searchSpace, (nuint)(num2 + num6)));
			Vector128<byte> vector3 = (vector & vector2).AsByte();
			if (vector3 != Vector128<byte>.Zero)
			{
				uint num7 = vector3.ExtractMostSignificantBits();
				do
				{
					int num8 = 30 - BitOperations.LeadingZeroCount(num7);
					int num9 = (int)((uint)num8 / 2u);
					if (valueLength == 2 || SequenceEqual(ref Unsafe.As<char, byte>(ref Unsafe.Add(ref searchSpace, num2 + num9)), ref Unsafe.As<char, byte>(ref value), (nuint)(uint)valueLength * (nuint)2u))
					{
						return num9 + num2;
					}
					num7 &= (uint)(~(3 << num8));
				}
				while (num7 != 0);
			}
			num2 -= Vector128<ushort>.Count;
			if (num2 == -Vector128<ushort>.Count)
			{
				break;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
		}
		return -1;
	}

	public static int SequenceCompareTo(ref char first, int firstLength, ref char second, int secondLength)
	{
		int result = firstLength - secondLength;
		if (!Unsafe.AreSame(in first, in second))
		{
			nuint num = (uint)(((uint)firstLength < (uint)secondLength) ? firstLength : secondLength);
			nuint num2 = 0u;
			if (num >= 4 / 2)
			{
				if (Vector.IsHardwareAccelerated && num >= (nuint)Vector<ushort>.Count)
				{
					nuint num3 = num - (nuint)Vector<ushort>.Count;
					while (!(Unsafe.ReadUnaligned<Vector<ushort>>(in Unsafe.As<char, byte>(ref Unsafe.Add(ref first, (nint)num2))) != Unsafe.ReadUnaligned<Vector<ushort>>(in Unsafe.As<char, byte>(ref Unsafe.Add(ref second, (nint)num2)))))
					{
						num2 += (nuint)Vector<ushort>.Count;
						if (num3 < num2)
						{
							break;
						}
					}
				}
				for (; num >= num2 + 4 / 2 && Unsafe.ReadUnaligned<nuint>(in Unsafe.As<char, byte>(ref Unsafe.Add(ref first, (nint)num2))) == Unsafe.ReadUnaligned<nuint>(in Unsafe.As<char, byte>(ref Unsafe.Add(ref second, (nint)num2))); num2 += 4 / 2)
				{
				}
			}
			for (; num2 < num; num2++)
			{
				int num4 = Unsafe.Add(ref first, (nint)num2).CompareTo(Unsafe.Add(ref second, (nint)num2));
				if (num4 != 0)
				{
					return num4;
				}
			}
		}
		return result;
	}

	public unsafe static int IndexOfNullCharacter(char* searchSpace)
	{
		nint num = 0;
		nint num2 = int.MaxValue;
		if (((int)searchSpace & 1) == 0 && Vector128.IsHardwareAccelerated)
		{
			num2 = UnalignedCountVector128(searchSpace);
		}
		while (true)
		{
			if (num2 >= 4)
			{
				if (searchSpace[num] == '\0')
				{
					break;
				}
				if (searchSpace[num + 1] == '\0')
				{
					return (int)(num + 1);
				}
				if (searchSpace[num + 2] == '\0')
				{
					return (int)(num + 2);
				}
				if (searchSpace[num + 3] != 0)
				{
					num += 4;
					num2 -= 4;
					continue;
				}
			}
			else
			{
				while (num2 > 0)
				{
					if (searchSpace[num] == '\0')
					{
						goto end_IL_006b;
					}
					num++;
					num2--;
				}
				if (false)
				{
				}
				if (false)
				{
				}
				if (Vector128.IsHardwareAccelerated && num < int.MaxValue)
				{
					num2 = GetCharVector128SpanLength(num, int.MaxValue);
					if (num2 > 0)
					{
						do
						{
							Vector128<ushort> right = *(Vector128<ushort>*)(searchSpace + (nuint)num);
							Vector128<ushort> vector = Vector128.Equals(Vector128<ushort>.Zero, right);
							if (vector == Vector128<ushort>.Zero)
							{
								num += Vector128<ushort>.Count;
								num2 -= Vector128<ushort>.Count;
								continue;
							}
							uint value = vector.AsByte().ExtractMostSignificantBits();
							return (int)(num + (uint)BitOperations.TrailingZeroCount(value) / 2u);
						}
						while (num2 > 0);
					}
					if (num < int.MaxValue)
					{
						num2 = int.MaxValue - num;
						continue;
					}
				}
				ThrowMustBeNullTerminatedString();
			}
			return (int)(num + 3);
			continue;
			end_IL_006b:
			break;
		}
		return (int)num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static nint GetCharVector128SpanLength(nint offset, nint length)
	{
		return (length - offset) & ~(Vector128<ushort>.Count - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static nint UnalignedCountVector128(char* searchSpace)
	{
		return (nint)(uint)(-(int)searchSpace / 2) & (nint)(Vector128<ushort>.Count - 1);
	}

	public static void Reverse(ref char buf, nuint length)
	{
		nint num = (nint)length;
		nint num2 = 0;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && num >= Vector128<ushort>.Count * 2)
		{
			nint num3 = num - Vector128<ushort>.Count;
			do
			{
				ref ushort reference = ref Unsafe.As<char, ushort>(ref Unsafe.Add(ref buf, num2));
				ref ushort reference2 = ref Unsafe.As<char, ushort>(ref Unsafe.Add(ref buf, num3));
				Vector128<ushort> vector = Vector128.LoadUnsafe(in reference);
				Vector128<ushort> vector2 = Vector128.LoadUnsafe(in reference2);
				Vector128<ushort> source = Vector128.Shuffle(vector, Vector128.Create((ushort)7, (ushort)6, (ushort)5, (ushort)4, (ushort)3, (ushort)2, (ushort)1, (ushort)0));
				vector2 = Vector128.Shuffle(vector2, Vector128.Create((ushort)7, (ushort)6, (ushort)5, (ushort)4, (ushort)3, (ushort)2, (ushort)1, (ushort)0));
				vector2.StoreUnsafe(ref reference);
				source.StoreUnsafe(ref reference2);
				num2 += Vector128<ushort>.Count;
				num3 -= Vector128<ushort>.Count;
			}
			while (num3 >= num2);
			num = num3 + Vector128<ushort>.Count - num2;
		}
		if (num > 1)
		{
			ReverseInner(ref Unsafe.Add(ref buf, num2), (nuint)num);
		}
	}

	public static void ClearWithReferences(ref nint ip, nuint pointerSizeLength)
	{
		while (pointerSizeLength >= 8)
		{
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -1) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -2) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -3) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -4) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -5) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -6) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -7) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -8) = 0;
			pointerSizeLength -= 8;
		}
		if (pointerSizeLength < 4)
		{
			if (pointerSizeLength < 2)
			{
				if (pointerSizeLength == 0)
				{
					return;
				}
				goto IL_00fa;
			}
		}
		else
		{
			Unsafe.Add(ref ip, 2) = 0;
			Unsafe.Add(ref ip, 3) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -3) = 0;
			Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -2) = 0;
		}
		Unsafe.Add(ref ip, 1) = 0;
		Unsafe.Add(ref Unsafe.Add(ref ip, (nint)pointerSizeLength), -1) = 0;
		goto IL_00fa;
		IL_00fa:
		ip = 0;
	}

	public static void Reverse(ref int buf, nuint length)
	{
		nint num = (nint)length;
		nint num2 = 0;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && num >= Vector128<int>.Count * 2)
		{
			nint num3 = num - Vector128<int>.Count;
			do
			{
				Vector128<int> vector = Vector128.LoadUnsafe(in buf, (nuint)num2);
				Vector128<int> vector2 = Vector128.LoadUnsafe(in buf, (nuint)num3);
				Vector128<int> source = Vector128.Shuffle(vector, Vector128.Create(3, 2, 1, 0));
				vector2 = Vector128.Shuffle(vector2, Vector128.Create(3, 2, 1, 0));
				vector2.StoreUnsafe(ref buf, (nuint)num2);
				source.StoreUnsafe(ref buf, (nuint)num3);
				num2 += Vector128<int>.Count;
				num3 -= Vector128<int>.Count;
			}
			while (num3 >= num2);
			num = num3 + Vector128<int>.Count - num2;
		}
		if (num > 1)
		{
			ReverseInner(ref Unsafe.Add(ref buf, num2), (nuint)num);
		}
	}

	public static void Reverse(ref long buf, nuint length)
	{
		nint num = (nint)length;
		nint num2 = 0;
		if (false)
		{
		}
		if (false)
		{
		}
		if (Vector128.IsHardwareAccelerated && num >= Vector128<long>.Count * 2)
		{
			nint num3 = num - Vector128<long>.Count;
			do
			{
				Vector128<long> vector = Vector128.LoadUnsafe(in buf, (nuint)num2);
				Vector128<long> vector2 = Vector128.LoadUnsafe(in buf, (nuint)num3);
				Vector128<long> source = Vector128.Shuffle(vector, Vector128.Create(1L, 0L));
				vector2 = Vector128.Shuffle(vector2, Vector128.Create(1L, 0L));
				vector2.StoreUnsafe(ref buf, (nuint)num2);
				source.StoreUnsafe(ref buf, (nuint)num3);
				num2 += Vector128<long>.Count;
				num3 -= Vector128<long>.Count;
			}
			while (num3 >= num2);
			num = num3 + Vector128<long>.Count - num2;
		}
		if (num > 1)
		{
			ReverseInner(ref Unsafe.Add(ref buf, num2), (nuint)num);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Reverse<T>(ref T elements, nuint length)
	{
		if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
		{
			if (Unsafe.SizeOf<T>() == 1)
			{
				Reverse(ref Unsafe.As<T, byte>(ref elements), length);
				return;
			}
			if (Unsafe.SizeOf<T>() == 2)
			{
				Reverse(ref Unsafe.As<T, char>(ref elements), length);
				return;
			}
			if (Unsafe.SizeOf<T>() == 4)
			{
				Reverse(ref Unsafe.As<T, int>(ref elements), length);
				return;
			}
			if (Unsafe.SizeOf<T>() == 8)
			{
				Reverse(ref Unsafe.As<T, long>(ref elements), length);
				return;
			}
		}
		ReverseInner(ref elements, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ReverseInner<T>(ref T elements, nuint length)
	{
		ref T reference = ref elements;
		ref T reference2 = ref Unsafe.Subtract(ref Unsafe.Add(ref reference, length), 1);
		do
		{
			T val = reference;
			reference = reference2;
			reference2 = val;
			reference = ref Unsafe.Add(ref reference, 1);
			reference2 = ref Unsafe.Subtract(ref reference2, 1);
		}
		while (Unsafe.IsAddressLessThan(in reference, in reference2));
	}

	[Intrinsic]
	public static void Fill<T>(ref T refData, nuint numElements, T value)
	{
		if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>() && Vector.IsHardwareAccelerated && Unsafe.SizeOf<T>() <= Vector<byte>.Count && BitOperations.IsPow2(Unsafe.SizeOf<T>()) && numElements >= (uint)(Vector<byte>.Count / Unsafe.SizeOf<T>()))
		{
			Vector<byte> value2;
			if (Unsafe.SizeOf<T>() == 1)
			{
				value2 = new Vector<byte>(Unsafe.BitCast<T, byte>(value));
			}
			else if (Unsafe.SizeOf<T>() == 2)
			{
				value2 = (Vector<byte>)new Vector<ushort>(Unsafe.BitCast<T, ushort>(value));
			}
			else if (Unsafe.SizeOf<T>() == 4)
			{
				value2 = ((typeof(T) == typeof(float)) ? ((Vector<byte>)new Vector<float>(Unsafe.BitCast<T, float>(value))) : ((Vector<byte>)new Vector<uint>(Unsafe.BitCast<T, uint>(value))));
			}
			else if (Unsafe.SizeOf<T>() == 8)
			{
				value2 = ((typeof(T) == typeof(double)) ? ((Vector<byte>)new Vector<double>(Unsafe.BitCast<T, double>(value))) : ((Vector<byte>)new Vector<ulong>(Unsafe.BitCast<T, ulong>(value))));
			}
			else if (Unsafe.SizeOf<T>() == Vector<byte>.Count)
			{
				value2 = Unsafe.BitCast<T, Vector<byte>>(value);
			}
			else if (Unsafe.SizeOf<T>() == 16)
			{
				if (Vector<byte>.Count == 32)
				{
					value2 = Vector256.Create(Unsafe.BitCast<T, Vector128<byte>>(value)).AsVector();
				}
				else
				{
					if (Vector<byte>.Count != 64)
					{
						goto IL_0235;
					}
					value2 = Vector512.Create(Unsafe.BitCast<T, Vector128<byte>>(value)).AsVector();
				}
			}
			else
			{
				if (Unsafe.SizeOf<T>() != 32 || Vector<byte>.Count != 64)
				{
					goto IL_0235;
				}
				value2 = Vector512.Create(Unsafe.BitCast<T, Vector256<byte>>(value)).AsVector();
			}
			ref byte source = ref Unsafe.As<T, byte>(ref refData);
			nuint num = numElements * (nuint)Unsafe.SizeOf<T>();
			nuint num2 = num & (nuint)(2 * -Vector<byte>.Count);
			nuint num3 = 0u;
			if (numElements >= (uint)(2 * Vector<byte>.Count / Unsafe.SizeOf<T>()))
			{
				do
				{
					Unsafe.WriteUnaligned(ref Unsafe.AddByteOffset(ref source, num3), value2);
					Unsafe.WriteUnaligned(ref Unsafe.AddByteOffset(ref source, num3 + (nuint)Vector<byte>.Count), value2);
					num3 += (uint)(2 * Vector<byte>.Count);
				}
				while (num3 < num2);
			}
			if ((num & (nuint)Vector<byte>.Count) != 0)
			{
				Unsafe.WriteUnaligned(ref Unsafe.AddByteOffset(ref source, num3), value2);
			}
			Unsafe.WriteUnaligned(ref Unsafe.AddByteOffset(ref source, num - (nuint)Vector<byte>.Count), value2);
			return;
		}
		goto IL_0235;
		IL_0235:
		nuint num4 = 0u;
		if (numElements >= 8)
		{
			nuint num5 = numElements & (nuint)(~(nint)7);
			do
			{
				Unsafe.Add(ref refData, (nint)(num4 + 0)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 1)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 2)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 3)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 4)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 5)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 6)) = value;
				Unsafe.Add(ref refData, (nint)(num4 + 7)) = value;
			}
			while ((num4 += 8) < num5);
		}
		if ((numElements & 4) != 0)
		{
			Unsafe.Add(ref refData, (nint)(num4 + 0)) = value;
			Unsafe.Add(ref refData, (nint)(num4 + 1)) = value;
			Unsafe.Add(ref refData, (nint)(num4 + 2)) = value;
			Unsafe.Add(ref refData, (nint)(num4 + 3)) = value;
			num4 += 4;
		}
		if ((numElements & 2) != 0)
		{
			Unsafe.Add(ref refData, (nint)(num4 + 0)) = value;
			Unsafe.Add(ref refData, (nint)(num4 + 1)) = value;
			num4 += 2;
		}
		if ((numElements & 1) != 0)
		{
			Unsafe.Add(ref refData, (nint)num4) = value;
		}
	}

	public static int IndexOf<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
	{
		if (valueLength == 0)
		{
			return 0;
		}
		T value2 = value;
		ref T second = ref Unsafe.Add(ref value, 1);
		int num = valueLength - 1;
		int num2 = 0;
		while (true)
		{
			int num3 = searchSpaceLength - num2 - num;
			if (num3 <= 0)
			{
				break;
			}
			int num4 = IndexOf(ref Unsafe.Add(ref searchSpace, num2), value2, num3);
			if (num4 < 0)
			{
				break;
			}
			num2 += num4;
			if (SequenceEqual(ref Unsafe.Add(ref searchSpace, num2 + 1), ref second, num))
			{
				return num2;
			}
			num2++;
		}
		return -1;
	}

	public static bool Contains<T>(ref T searchSpace, T value, int length) where T : IEquatable<T>
	{
		nint num = 0;
		T val = default(T);
		if (val != null || value != null)
		{
			while (length >= 8)
			{
				length -= 8;
				ref T reference = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				T other = Unsafe.Add(ref searchSpace, num + 0);
				if (!reference.Equals(other))
				{
					ref T reference2 = ref value;
					val = default(T);
					if (val == null)
					{
						val = reference2;
						reference2 = ref val;
					}
					T other2 = Unsafe.Add(ref searchSpace, num + 1);
					if (!reference2.Equals(other2))
					{
						ref T reference3 = ref value;
						val = default(T);
						if (val == null)
						{
							val = reference3;
							reference3 = ref val;
						}
						T other3 = Unsafe.Add(ref searchSpace, num + 2);
						if (!reference3.Equals(other3))
						{
							ref T reference4 = ref value;
							val = default(T);
							if (val == null)
							{
								val = reference4;
								reference4 = ref val;
							}
							T other4 = Unsafe.Add(ref searchSpace, num + 3);
							if (!reference4.Equals(other4))
							{
								ref T reference5 = ref value;
								val = default(T);
								if (val == null)
								{
									val = reference5;
									reference5 = ref val;
								}
								T other5 = Unsafe.Add(ref searchSpace, num + 4);
								if (!reference5.Equals(other5))
								{
									ref T reference6 = ref value;
									val = default(T);
									if (val == null)
									{
										val = reference6;
										reference6 = ref val;
									}
									T other6 = Unsafe.Add(ref searchSpace, num + 5);
									if (!reference6.Equals(other6))
									{
										ref T reference7 = ref value;
										val = default(T);
										if (val == null)
										{
											val = reference7;
											reference7 = ref val;
										}
										T other7 = Unsafe.Add(ref searchSpace, num + 6);
										if (!reference7.Equals(other7))
										{
											ref T reference8 = ref value;
											val = default(T);
											if (val == null)
											{
												val = reference8;
												reference8 = ref val;
											}
											T other8 = Unsafe.Add(ref searchSpace, num + 7);
											if (!reference8.Equals(other8))
											{
												num += 8;
												continue;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_035b;
			}
			if (length < 4)
			{
				goto IL_0330;
			}
			length -= 4;
			ref T reference9 = ref value;
			val = default(T);
			if (val == null)
			{
				val = reference9;
				reference9 = ref val;
			}
			T other9 = Unsafe.Add(ref searchSpace, num + 0);
			if (!reference9.Equals(other9))
			{
				ref T reference10 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference10;
					reference10 = ref val;
				}
				T other10 = Unsafe.Add(ref searchSpace, num + 1);
				if (!reference10.Equals(other10))
				{
					ref T reference11 = ref value;
					val = default(T);
					if (val == null)
					{
						val = reference11;
						reference11 = ref val;
					}
					T other11 = Unsafe.Add(ref searchSpace, num + 2);
					if (!reference11.Equals(other11))
					{
						ref T reference12 = ref value;
						val = default(T);
						if (val == null)
						{
							val = reference12;
							reference12 = ref val;
						}
						T other12 = Unsafe.Add(ref searchSpace, num + 3);
						if (!reference12.Equals(other12))
						{
							num += 4;
							goto IL_0330;
						}
					}
				}
			}
			goto IL_035b;
		}
		nint num2 = length;
		num = 0;
		while (num < num2)
		{
			if (Unsafe.Add(ref searchSpace, num) != null)
			{
				num++;
				continue;
			}
			goto IL_035b;
		}
		goto IL_0359;
		IL_0330:
		while (length > 0)
		{
			length--;
			ref T reference13 = ref value;
			val = default(T);
			if (val == null)
			{
				val = reference13;
				reference13 = ref val;
			}
			T other13 = Unsafe.Add(ref searchSpace, num);
			if (!reference13.Equals(other13))
			{
				num++;
				continue;
			}
			goto IL_035b;
		}
		goto IL_0359;
		IL_0359:
		return false;
		IL_035b:
		return true;
	}

	public static int IndexOf<T>(ref T searchSpace, T value, int length) where T : IEquatable<T>
	{
		nint num = 0;
		T val = default(T);
		if (val != null || value != null)
		{
			while (length >= 8)
			{
				length -= 8;
				ref T reference = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				T other = Unsafe.Add(ref searchSpace, num);
				if (reference.Equals(other))
				{
					goto IL_0355;
				}
				ref T reference2 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
				}
				T other2 = Unsafe.Add(ref searchSpace, num + 1);
				if (reference2.Equals(other2))
				{
					goto IL_0358;
				}
				ref T reference3 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference3;
					reference3 = ref val;
				}
				T other3 = Unsafe.Add(ref searchSpace, num + 2);
				if (reference3.Equals(other3))
				{
					goto IL_035e;
				}
				ref T reference4 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference4;
					reference4 = ref val;
				}
				T other4 = Unsafe.Add(ref searchSpace, num + 3);
				if (!reference4.Equals(other4))
				{
					ref T reference5 = ref value;
					val = default(T);
					if (val == null)
					{
						val = reference5;
						reference5 = ref val;
					}
					T other5 = Unsafe.Add(ref searchSpace, num + 4);
					if (!reference5.Equals(other5))
					{
						ref T reference6 = ref value;
						val = default(T);
						if (val == null)
						{
							val = reference6;
							reference6 = ref val;
						}
						T other6 = Unsafe.Add(ref searchSpace, num + 5);
						if (!reference6.Equals(other6))
						{
							ref T reference7 = ref value;
							val = default(T);
							if (val == null)
							{
								val = reference7;
								reference7 = ref val;
							}
							T other7 = Unsafe.Add(ref searchSpace, num + 6);
							if (!reference7.Equals(other7))
							{
								ref T reference8 = ref value;
								val = default(T);
								if (val == null)
								{
									val = reference8;
									reference8 = ref val;
								}
								T other8 = Unsafe.Add(ref searchSpace, num + 7);
								if (!reference8.Equals(other8))
								{
									num += 8;
									continue;
								}
								return (int)(num + 7);
							}
							return (int)(num + 6);
						}
						return (int)(num + 5);
					}
					return (int)(num + 4);
				}
				goto IL_0364;
			}
			if (length >= 4)
			{
				length -= 4;
				ref T reference9 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference9;
					reference9 = ref val;
				}
				T other9 = Unsafe.Add(ref searchSpace, num);
				if (reference9.Equals(other9))
				{
					goto IL_0355;
				}
				ref T reference10 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference10;
					reference10 = ref val;
				}
				T other10 = Unsafe.Add(ref searchSpace, num + 1);
				if (reference10.Equals(other10))
				{
					goto IL_0358;
				}
				ref T reference11 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference11;
					reference11 = ref val;
				}
				T other11 = Unsafe.Add(ref searchSpace, num + 2);
				if (reference11.Equals(other11))
				{
					goto IL_035e;
				}
				ref T reference12 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference12;
					reference12 = ref val;
				}
				T other12 = Unsafe.Add(ref searchSpace, num + 3);
				if (reference12.Equals(other12))
				{
					goto IL_0364;
				}
				num += 4;
			}
			while (length > 0)
			{
				ref T reference13 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference13;
					reference13 = ref val;
				}
				T other13 = Unsafe.Add(ref searchSpace, num);
				if (!reference13.Equals(other13))
				{
					num++;
					length--;
					continue;
				}
				goto IL_0355;
			}
		}
		else
		{
			nint num2 = length;
			num = 0;
			while (num < num2)
			{
				if (Unsafe.Add(ref searchSpace, num) != null)
				{
					num++;
					continue;
				}
				goto IL_0355;
			}
		}
		return -1;
		IL_0355:
		return (int)num;
		IL_0358:
		return (int)(num + 1);
		IL_0364:
		return (int)(num + 3);
		IL_035e:
		return (int)(num + 2);
	}

	public static int IndexOfAny<T>(ref T searchSpace, T value0, T value1, int length) where T : IEquatable<T>
	{
		int i = 0;
		if (default(T) != null || (value0 != null && value1 != null))
		{
			while (length - i >= 8)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0350;
				}
				other = Unsafe.Add(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0352;
				}
				other = Unsafe.Add(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0356;
				}
				other = Unsafe.Add(ref searchSpace, i + 3);
				if (!value0.Equals(other) && !value1.Equals(other))
				{
					other = Unsafe.Add(ref searchSpace, i + 4);
					if (!value0.Equals(other) && !value1.Equals(other))
					{
						other = Unsafe.Add(ref searchSpace, i + 5);
						if (!value0.Equals(other) && !value1.Equals(other))
						{
							other = Unsafe.Add(ref searchSpace, i + 6);
							if (!value0.Equals(other) && !value1.Equals(other))
							{
								other = Unsafe.Add(ref searchSpace, i + 7);
								if (!value0.Equals(other) && !value1.Equals(other))
								{
									i += 8;
									continue;
								}
								return i + 7;
							}
							return i + 6;
						}
						return i + 5;
					}
					return i + 4;
				}
				goto IL_035a;
			}
			if (length - i >= 4)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0350;
				}
				other = Unsafe.Add(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0352;
				}
				other = Unsafe.Add(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0356;
				}
				other = Unsafe.Add(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_035a;
				}
				i += 4;
			}
			while (i < length)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (!value0.Equals(other) && !value1.Equals(other))
				{
					i++;
					continue;
				}
				goto IL_0350;
			}
		}
		else
		{
			for (i = 0; i < length; i++)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (other == null)
				{
					if (value0 != null && value1 != null)
					{
						continue;
					}
				}
				else
				{
					T other2 = value0;
					if (!other.Equals(other2))
					{
						T other3 = value1;
						if (!other.Equals(other3))
						{
							continue;
						}
					}
				}
				goto IL_0350;
			}
		}
		return -1;
		IL_0352:
		return i + 1;
		IL_0350:
		return i;
		IL_0356:
		return i + 2;
		IL_035a:
		return i + 3;
	}

	public static int IndexOfAny<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : IEquatable<T>
	{
		int i = 0;
		if (default(T) != null || (value0 != null && value1 != null && value2 != null))
		{
			while (length - i >= 8)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0471;
				}
				other = Unsafe.Add(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0473;
				}
				other = Unsafe.Add(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0477;
				}
				other = Unsafe.Add(ref searchSpace, i + 3);
				if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
				{
					other = Unsafe.Add(ref searchSpace, i + 4);
					if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
					{
						other = Unsafe.Add(ref searchSpace, i + 5);
						if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
						{
							other = Unsafe.Add(ref searchSpace, i + 6);
							if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
							{
								other = Unsafe.Add(ref searchSpace, i + 7);
								if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
								{
									i += 8;
									continue;
								}
								return i + 7;
							}
							return i + 6;
						}
						return i + 5;
					}
					return i + 4;
				}
				goto IL_047b;
			}
			if (length - i >= 4)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0471;
				}
				other = Unsafe.Add(ref searchSpace, i + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0473;
				}
				other = Unsafe.Add(ref searchSpace, i + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0477;
				}
				other = Unsafe.Add(ref searchSpace, i + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_047b;
				}
				i += 4;
			}
			while (i < length)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
				{
					i++;
					continue;
				}
				goto IL_0471;
			}
		}
		else
		{
			for (i = 0; i < length; i++)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				if (other == null)
				{
					if (value0 != null && value1 != null && value2 != null)
					{
						continue;
					}
				}
				else
				{
					T other2 = value0;
					if (!other.Equals(other2))
					{
						T other3 = value1;
						if (!other.Equals(other3))
						{
							T other4 = value2;
							if (!other.Equals(other4))
							{
								continue;
							}
						}
					}
				}
				goto IL_0471;
			}
		}
		return -1;
		IL_0473:
		return i + 1;
		IL_047b:
		return i + 3;
		IL_0471:
		return i;
		IL_0477:
		return i + 2;
	}

	public static int IndexOfAny<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
	{
		if (valueLength == 0)
		{
			return -1;
		}
		if (typeof(T).IsValueType)
		{
			for (int i = 0; i < searchSpaceLength; i++)
			{
				T other = Unsafe.Add(ref searchSpace, i);
				for (int j = 0; j < valueLength; j++)
				{
					if (Unsafe.Add(ref value, j).Equals(other))
					{
						return i;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < searchSpaceLength; k++)
			{
				T val = Unsafe.Add(ref searchSpace, k);
				if (val != null)
				{
					for (int l = 0; l < valueLength; l++)
					{
						if (val.Equals(Unsafe.Add(ref value, l)))
						{
							return k;
						}
					}
					continue;
				}
				for (int m = 0; m < valueLength; m++)
				{
					if (Unsafe.Add(ref value, m) == null)
					{
						return k;
					}
				}
			}
		}
		return -1;
	}

	public static int LastIndexOf<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
	{
		if (valueLength == 0)
		{
			return searchSpaceLength;
		}
		int num = valueLength - 1;
		if (num == 0)
		{
			return LastIndexOf(ref searchSpace, value, searchSpaceLength);
		}
		int num2 = 0;
		T value2 = value;
		ref T second = ref Unsafe.Add(ref value, 1);
		while (true)
		{
			int num3 = searchSpaceLength - num2 - num;
			if (num3 <= 0)
			{
				break;
			}
			int num4 = LastIndexOf(ref searchSpace, value2, num3);
			if (num4 < 0)
			{
				break;
			}
			if (SequenceEqual(ref Unsafe.Add(ref searchSpace, num4 + 1), ref second, num))
			{
				return num4;
			}
			num2 += num3 - num4;
		}
		return -1;
	}

	public static int LastIndexOf<T>(ref T searchSpace, T value, int length) where T : IEquatable<T>
	{
		T val = default(T);
		if (val != null || value != null)
		{
			while (length >= 8)
			{
				length -= 8;
				ref T reference = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				T other = Unsafe.Add(ref searchSpace, length + 7);
				if (!reference.Equals(other))
				{
					ref T reference2 = ref value;
					val = default(T);
					if (val == null)
					{
						val = reference2;
						reference2 = ref val;
					}
					T other2 = Unsafe.Add(ref searchSpace, length + 6);
					if (!reference2.Equals(other2))
					{
						ref T reference3 = ref value;
						val = default(T);
						if (val == null)
						{
							val = reference3;
							reference3 = ref val;
						}
						T other3 = Unsafe.Add(ref searchSpace, length + 5);
						if (!reference3.Equals(other3))
						{
							ref T reference4 = ref value;
							val = default(T);
							if (val == null)
							{
								val = reference4;
								reference4 = ref val;
							}
							T other4 = Unsafe.Add(ref searchSpace, length + 4);
							if (!reference4.Equals(other4))
							{
								ref T reference5 = ref value;
								val = default(T);
								if (val == null)
								{
									val = reference5;
									reference5 = ref val;
								}
								T other5 = Unsafe.Add(ref searchSpace, length + 3);
								if (!reference5.Equals(other5))
								{
									ref T reference6 = ref value;
									val = default(T);
									if (val == null)
									{
										val = reference6;
										reference6 = ref val;
									}
									T other6 = Unsafe.Add(ref searchSpace, length + 2);
									if (!reference6.Equals(other6))
									{
										ref T reference7 = ref value;
										val = default(T);
										if (val == null)
										{
											val = reference7;
											reference7 = ref val;
										}
										T other7 = Unsafe.Add(ref searchSpace, length + 1);
										if (!reference7.Equals(other7))
										{
											ref T reference8 = ref value;
											val = default(T);
											if (val == null)
											{
												val = reference8;
												reference8 = ref val;
											}
											T other8 = Unsafe.Add(ref searchSpace, length);
											if (!reference8.Equals(other8))
											{
												continue;
											}
											goto IL_0339;
										}
										goto IL_033b;
									}
									goto IL_033f;
								}
								goto IL_0343;
							}
							return length + 4;
						}
						return length + 5;
					}
					return length + 6;
				}
				return length + 7;
			}
			if (length >= 4)
			{
				length -= 4;
				ref T reference9 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference9;
					reference9 = ref val;
				}
				T other9 = Unsafe.Add(ref searchSpace, length + 3);
				if (reference9.Equals(other9))
				{
					goto IL_0343;
				}
				ref T reference10 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference10;
					reference10 = ref val;
				}
				T other10 = Unsafe.Add(ref searchSpace, length + 2);
				if (reference10.Equals(other10))
				{
					goto IL_033f;
				}
				ref T reference11 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference11;
					reference11 = ref val;
				}
				T other11 = Unsafe.Add(ref searchSpace, length + 1);
				if (reference11.Equals(other11))
				{
					goto IL_033b;
				}
				ref T reference12 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference12;
					reference12 = ref val;
				}
				T other12 = Unsafe.Add(ref searchSpace, length);
				if (reference12.Equals(other12))
				{
					goto IL_0339;
				}
			}
			while (length > 0)
			{
				length--;
				ref T reference13 = ref value;
				val = default(T);
				if (val == null)
				{
					val = reference13;
					reference13 = ref val;
				}
				T other13 = Unsafe.Add(ref searchSpace, length);
				if (!reference13.Equals(other13))
				{
					continue;
				}
				goto IL_0339;
			}
		}
		else
		{
			length--;
			while (length >= 0)
			{
				if (Unsafe.Add(ref searchSpace, length) != null)
				{
					length--;
					continue;
				}
				goto IL_0339;
			}
		}
		return -1;
		IL_033b:
		return length + 1;
		IL_0339:
		return length;
		IL_033f:
		return length + 2;
		IL_0343:
		return length + 3;
	}

	public static int LastIndexOfAny<T>(ref T searchSpace, T value0, T value1, int length) where T : IEquatable<T>
	{
		if (default(T) != null || (value0 != null && value1 != null))
		{
			while (length >= 8)
			{
				length -= 8;
				T other = Unsafe.Add(ref searchSpace, length + 7);
				if (!value0.Equals(other) && !value1.Equals(other))
				{
					other = Unsafe.Add(ref searchSpace, length + 6);
					if (!value0.Equals(other) && !value1.Equals(other))
					{
						other = Unsafe.Add(ref searchSpace, length + 5);
						if (!value0.Equals(other) && !value1.Equals(other))
						{
							other = Unsafe.Add(ref searchSpace, length + 4);
							if (!value0.Equals(other) && !value1.Equals(other))
							{
								other = Unsafe.Add(ref searchSpace, length + 3);
								if (!value0.Equals(other) && !value1.Equals(other))
								{
									other = Unsafe.Add(ref searchSpace, length + 2);
									if (!value0.Equals(other) && !value1.Equals(other))
									{
										other = Unsafe.Add(ref searchSpace, length + 1);
										if (!value0.Equals(other) && !value1.Equals(other))
										{
											other = Unsafe.Add(ref searchSpace, length);
											if (!value0.Equals(other) && !value1.Equals(other))
											{
												continue;
											}
											goto IL_0351;
										}
										goto IL_0353;
									}
									goto IL_0357;
								}
								goto IL_035b;
							}
							return length + 4;
						}
						return length + 5;
					}
					return length + 6;
				}
				return length + 7;
			}
			if (length >= 4)
			{
				length -= 4;
				T other = Unsafe.Add(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_035b;
				}
				other = Unsafe.Add(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0357;
				}
				other = Unsafe.Add(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0353;
				}
				other = Unsafe.Add(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other))
				{
					goto IL_0351;
				}
			}
			while (length > 0)
			{
				length--;
				T other = Unsafe.Add(ref searchSpace, length);
				if (!value0.Equals(other) && !value1.Equals(other))
				{
					continue;
				}
				goto IL_0351;
			}
		}
		else
		{
			for (length--; length >= 0; length--)
			{
				T other = Unsafe.Add(ref searchSpace, length);
				if (other == null)
				{
					if (value0 != null && value1 != null)
					{
						continue;
					}
				}
				else
				{
					T other2 = value0;
					if (!other.Equals(other2))
					{
						T other3 = value1;
						if (!other.Equals(other3))
						{
							continue;
						}
					}
				}
				goto IL_0351;
			}
		}
		return -1;
		IL_035b:
		return length + 3;
		IL_0357:
		return length + 2;
		IL_0351:
		return length;
		IL_0353:
		return length + 1;
	}

	public static int LastIndexOfAny<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : IEquatable<T>
	{
		if (default(T) != null || (value0 != null && value1 != null && value2 != null))
		{
			while (length >= 8)
			{
				length -= 8;
				T other = Unsafe.Add(ref searchSpace, length + 7);
				if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
				{
					other = Unsafe.Add(ref searchSpace, length + 6);
					if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
					{
						other = Unsafe.Add(ref searchSpace, length + 5);
						if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
						{
							other = Unsafe.Add(ref searchSpace, length + 4);
							if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
							{
								other = Unsafe.Add(ref searchSpace, length + 3);
								if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
								{
									other = Unsafe.Add(ref searchSpace, length + 2);
									if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
									{
										other = Unsafe.Add(ref searchSpace, length + 1);
										if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
										{
											other = Unsafe.Add(ref searchSpace, length);
											if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
											{
												continue;
											}
											goto IL_0485;
										}
										goto IL_0488;
									}
									goto IL_048d;
								}
								goto IL_0492;
							}
							return length + 4;
						}
						return length + 5;
					}
					return length + 6;
				}
				return length + 7;
			}
			if (length >= 4)
			{
				length -= 4;
				T other = Unsafe.Add(ref searchSpace, length + 3);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0492;
				}
				other = Unsafe.Add(ref searchSpace, length + 2);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_048d;
				}
				other = Unsafe.Add(ref searchSpace, length + 1);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0488;
				}
				other = Unsafe.Add(ref searchSpace, length);
				if (value0.Equals(other) || value1.Equals(other) || value2.Equals(other))
				{
					goto IL_0485;
				}
			}
			while (length > 0)
			{
				length--;
				T other = Unsafe.Add(ref searchSpace, length);
				if (!value0.Equals(other) && !value1.Equals(other) && !value2.Equals(other))
				{
					continue;
				}
				goto IL_0485;
			}
		}
		else
		{
			for (length--; length >= 0; length--)
			{
				T other = Unsafe.Add(ref searchSpace, length);
				if (other == null)
				{
					if (value0 != null && value1 != null && value2 != null)
					{
						continue;
					}
				}
				else
				{
					T other2 = value0;
					if (!other.Equals(other2))
					{
						T other3 = value1;
						if (!other.Equals(other3))
						{
							T other4 = value2;
							if (!other.Equals(other4))
							{
								continue;
							}
						}
					}
				}
				goto IL_0485;
			}
		}
		return -1;
		IL_0488:
		return length + 1;
		IL_0485:
		return length;
		IL_0492:
		return length + 3;
		IL_048d:
		return length + 2;
	}

	public static int LastIndexOfAny<T>(ref T searchSpace, int searchSpaceLength, ref T value, int valueLength) where T : IEquatable<T>
	{
		if (valueLength == 0)
		{
			return -1;
		}
		if (typeof(T).IsValueType)
		{
			for (int num = searchSpaceLength - 1; num >= 0; num--)
			{
				T other = Unsafe.Add(ref searchSpace, num);
				for (int i = 0; i < valueLength; i++)
				{
					if (Unsafe.Add(ref value, i).Equals(other))
					{
						return num;
					}
				}
			}
		}
		else
		{
			for (int num2 = searchSpaceLength - 1; num2 >= 0; num2--)
			{
				T val = Unsafe.Add(ref searchSpace, num2);
				if (val != null)
				{
					for (int j = 0; j < valueLength; j++)
					{
						if (val.Equals(Unsafe.Add(ref value, j)))
						{
							return num2;
						}
					}
				}
				else
				{
					for (int k = 0; k < valueLength; k++)
					{
						if (Unsafe.Add(ref value, k) == null)
						{
							return num2;
						}
					}
				}
			}
		}
		return -1;
	}

	internal static int IndexOfAnyExcept<T>(ref T searchSpace, T value0, int length)
	{
		for (int i = 0; i < length; i++)
		{
			if (!EqualityComparer<T>.Default.Equals(Unsafe.Add(ref searchSpace, i), value0))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyExcept<T>(ref T searchSpace, T value0, int length)
	{
		for (int num = length - 1; num >= 0; num--)
		{
			if (!EqualityComparer<T>.Default.Equals(Unsafe.Add(ref searchSpace, num), value0))
			{
				return num;
			}
		}
		return -1;
	}

	internal static int IndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, int length)
	{
		for (int i = 0; i < length; i++)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, i);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, int length)
	{
		for (int num = length - 1; num >= 0; num--)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, num);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1))
			{
				return num;
			}
		}
		return -1;
	}

	internal static int IndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, T value2, int length)
	{
		for (int i = 0; i < length; i++)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, i);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1) && !EqualityComparer<T>.Default.Equals(reference, value2))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, T value2, int length)
	{
		for (int num = length - 1; num >= 0; num--)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, num);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1) && !EqualityComparer<T>.Default.Equals(reference, value2))
			{
				return num;
			}
		}
		return -1;
	}

	internal static int IndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length)
	{
		for (int i = 0; i < length; i++)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, i);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1) && !EqualityComparer<T>.Default.Equals(reference, value2) && !EqualityComparer<T>.Default.Equals(reference, value3))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyExcept<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length)
	{
		for (int num = length - 1; num >= 0; num--)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, num);
			if (!EqualityComparer<T>.Default.Equals(reference, value0) && !EqualityComparer<T>.Default.Equals(reference, value1) && !EqualityComparer<T>.Default.Equals(reference, value2) && !EqualityComparer<T>.Default.Equals(reference, value3))
			{
				return num;
			}
		}
		return -1;
	}

	public static bool SequenceEqual<T>(ref T first, ref T second, int length) where T : IEquatable<T>
	{
		if (!Unsafe.AreSame(in first, in second))
		{
			nint num = 0;
			while (true)
			{
				if (length >= 8)
				{
					length -= 8;
					T val = Unsafe.Add(ref first, num);
					T val2 = Unsafe.Add(ref second, num);
					if (val?.Equals(val2) ?? (val2 == null))
					{
						val = Unsafe.Add(ref first, num + 1);
						val2 = Unsafe.Add(ref second, num + 1);
						if (val?.Equals(val2) ?? (val2 == null))
						{
							val = Unsafe.Add(ref first, num + 2);
							val2 = Unsafe.Add(ref second, num + 2);
							if (val?.Equals(val2) ?? (val2 == null))
							{
								val = Unsafe.Add(ref first, num + 3);
								val2 = Unsafe.Add(ref second, num + 3);
								if (val?.Equals(val2) ?? (val2 == null))
								{
									val = Unsafe.Add(ref first, num + 4);
									val2 = Unsafe.Add(ref second, num + 4);
									if (val?.Equals(val2) ?? (val2 == null))
									{
										val = Unsafe.Add(ref first, num + 5);
										val2 = Unsafe.Add(ref second, num + 5);
										if (val?.Equals(val2) ?? (val2 == null))
										{
											val = Unsafe.Add(ref first, num + 6);
											val2 = Unsafe.Add(ref second, num + 6);
											if (val?.Equals(val2) ?? (val2 == null))
											{
												val = Unsafe.Add(ref first, num + 7);
												val2 = Unsafe.Add(ref second, num + 7);
												if (val?.Equals(val2) ?? (val2 == null))
												{
													num += 8;
													continue;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (length < 4)
					{
						goto IL_03b8;
					}
					length -= 4;
					T val = Unsafe.Add(ref first, num);
					T val2 = Unsafe.Add(ref second, num);
					if (val?.Equals(val2) ?? (val2 == null))
					{
						val = Unsafe.Add(ref first, num + 1);
						val2 = Unsafe.Add(ref second, num + 1);
						if (val?.Equals(val2) ?? (val2 == null))
						{
							val = Unsafe.Add(ref first, num + 2);
							val2 = Unsafe.Add(ref second, num + 2);
							if (val?.Equals(val2) ?? (val2 == null))
							{
								val = Unsafe.Add(ref first, num + 3);
								val2 = Unsafe.Add(ref second, num + 3);
								if (val?.Equals(val2) ?? (val2 == null))
								{
									num += 4;
									goto IL_03b8;
								}
							}
						}
					}
				}
				goto IL_03be;
				IL_03b8:
				while (length > 0)
				{
					T val = Unsafe.Add(ref first, num);
					T val2 = Unsafe.Add(ref second, num);
					if (val?.Equals(val2) ?? (val2 == null))
					{
						num++;
						length--;
						continue;
					}
					goto IL_03be;
				}
				break;
				IL_03be:
				return false;
			}
		}
		return true;
	}

	public static int SequenceCompareTo<T>(ref T first, int firstLength, ref T second, int secondLength) where T : IComparable<T>
	{
		int num = firstLength;
		if (num > secondLength)
		{
			num = secondLength;
		}
		for (int i = 0; i < num; i++)
		{
			T val = Unsafe.Add(ref second, i);
			int num2 = Unsafe.Add(ref first, i)?.CompareTo(val) ?? ((val != null) ? (-1) : 0);
			if (num2 != 0)
			{
				return num2;
			}
		}
		return firstLength.CompareTo(secondLength);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool ContainsValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		if (false)
		{
		}
		return NonPackedContainsValueType(ref searchSpace, value, length);
	}

	internal static bool NonPackedContainsValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<T>.Count)
		{
			nuint num = 0u;
			while (length >= 8)
			{
				length -= 8;
				if (Unsafe.Add(ref searchSpace, num) == value || Unsafe.Add(ref searchSpace, num + 1) == value || Unsafe.Add(ref searchSpace, num + 2) == value || Unsafe.Add(ref searchSpace, num + 3) == value || Unsafe.Add(ref searchSpace, num + 4) == value || Unsafe.Add(ref searchSpace, num + 5) == value || Unsafe.Add(ref searchSpace, num + 6) == value || Unsafe.Add(ref searchSpace, num + 7) == value)
				{
					return true;
				}
				num += 8;
			}
			if (length >= 4)
			{
				length -= 4;
				if (Unsafe.Add(ref searchSpace, num) == value || Unsafe.Add(ref searchSpace, num + 1) == value || Unsafe.Add(ref searchSpace, num + 2) == value || Unsafe.Add(ref searchSpace, num + 3) == value)
				{
					return true;
				}
				num += 4;
			}
			while (length > 0)
			{
				length--;
				if (Unsafe.Add(ref searchSpace, num) == value)
				{
					return true;
				}
				num++;
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
			Vector128<T> left = Vector128.Create(value);
			ref T reference = ref searchSpace;
			ref T reference2 = ref Unsafe.Add(ref searchSpace, (uint)(length - Vector128<T>.Count));
			do
			{
				if (Vector128.Equals(left, Vector128.LoadUnsafe(in reference)) == Vector128<T>.Zero)
				{
					reference = ref Unsafe.Add(ref reference, Vector128<T>.Count);
					continue;
				}
				return true;
			}
			while (Unsafe.IsAddressLessThanOrEqualTo(in reference, in reference2));
			if ((uint)length % Vector128<T>.Count != 0L && Vector128.Equals(left, Vector128.LoadUnsafe(in reference2)) != Vector128<T>.Zero)
			{
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfChar(ref char searchSpace, char value, int length)
	{
		return IndexOfValueType(ref Unsafe.As<char, short>(ref searchSpace), (short)value, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int NonPackedIndexOfChar(ref char searchSpace, char value, int length)
	{
		return NonPackedIndexOfValueType<short, DontNegate<short>>(ref Unsafe.As<char, short>(ref searchSpace), (short)value, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		return IndexOfValueType<T, DontNegate<T>>(ref searchSpace, value, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyExceptValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		return IndexOfValueType<T, Negate<T>>(ref searchSpace, value, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int IndexOfValueType<TValue, TNegator>(ref TValue searchSpace, TValue value, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (false)
		{
		}
		return NonPackedIndexOfValueType<TValue, TNegator>(ref searchSpace, value, length);
	}

	internal static int NonPackedIndexOfValueType<TValue, TNegator>(ref TValue searchSpace, TValue value, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = 0u;
			while (true)
			{
				if (length >= 8)
				{
					length -= 8;
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
					{
						break;
					}
					if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 1) == value))
					{
						if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 2) == value))
						{
							if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 3) == value))
							{
								if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 4) == value))
								{
									if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 5) == value))
									{
										if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 6) == value))
										{
											if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 7) == value))
											{
												num += 8;
												continue;
											}
											return (int)(num + 7);
										}
										return (int)(num + 6);
									}
									return (int)(num + 5);
								}
								return (int)(num + 4);
							}
							goto IL_0286;
						}
						goto IL_028c;
					}
					goto IL_0292;
				}
				if (length >= 4)
				{
					length -= 4;
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
					{
						break;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 1) == value))
					{
						goto IL_0292;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 2) == value))
					{
						goto IL_028c;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num + 3) == value))
					{
						goto IL_0286;
					}
					num += 4;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				break;
				IL_0292:
				return (int)(num + 1);
				IL_0286:
				return (int)(num + 3);
				IL_028c:
				return (int)(num + 2);
			}
			return (int)num;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> left = Vector128.Create(value);
		ref TValue reference = ref searchSpace;
		ref TValue reference2 = ref Unsafe.Add(ref searchSpace, length - Vector128<TValue>.Count);
		do
		{
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, Vector128.LoadUnsafe(in reference)));
			if (vector == Vector128<TValue>.Zero)
			{
				reference = ref Unsafe.Add(ref reference, Vector128<TValue>.Count);
				continue;
			}
			return ComputeFirstIndex(ref searchSpace, ref reference, vector);
		}
		while (Unsafe.IsAddressLessThanOrEqualTo(in reference, in reference2));
		if ((uint)length % Vector128<TValue>.Count != 0L)
		{
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, Vector128.LoadUnsafe(in reference2)));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference2, vector);
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyChar(ref char searchSpace, char value0, char value1, int length)
	{
		return IndexOfAnyValueType(ref Unsafe.As<char, short>(ref searchSpace), (short)value0, (short)value1, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int IndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (false)
		{
		}
		return NonPackedIndexOfAnyValueType<TValue, TNegator>(ref searchSpace, value0, value1, length);
	}

	internal static int NonPackedIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		nuint num;
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			num = 0u;
			if (typeof(TValue) == typeof(byte))
			{
				while (length >= 8)
				{
					length -= 8;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						val = Unsafe.Add(ref reference, 1);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							val = Unsafe.Add(ref reference, 2);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
							{
								val = Unsafe.Add(ref reference, 3);
								if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
								{
									val = Unsafe.Add(ref reference, 4);
									if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
									{
										val = Unsafe.Add(ref reference, 5);
										if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
										{
											val = Unsafe.Add(ref reference, 6);
											if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
											{
												val = Unsafe.Add(ref reference, 7);
												if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
												{
													num += 8;
													continue;
												}
												return (int)(num + 7);
											}
											return (int)(num + 6);
										}
										return (int)(num + 5);
									}
									return (int)(num + 4);
								}
								goto IL_0393;
							}
							goto IL_0399;
						}
						goto IL_039f;
					}
					goto IL_03a5;
				}
			}
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference2 = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference2;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						break;
					}
					val = Unsafe.Add(ref reference2, 1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						val = Unsafe.Add(ref reference2, 2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							val = Unsafe.Add(ref reference2, 3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
							{
								num += 4;
								continue;
							}
							goto IL_0393;
						}
						goto IL_0399;
					}
					goto IL_039f;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				break;
			}
			goto IL_03a5;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> left = Vector128.Create(value0);
		Vector128<TValue> left2 = Vector128.Create(value1);
		ref TValue reference3 = ref searchSpace;
		ref TValue reference4 = ref Unsafe.Add(ref searchSpace, length - Vector128<TValue>.Count);
		do
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference3);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right));
			if (vector == Vector128<TValue>.Zero)
			{
				reference3 = ref Unsafe.Add(ref reference3, Vector128<TValue>.Count);
				continue;
			}
			return ComputeFirstIndex(ref searchSpace, ref reference3, vector);
		}
		while (Unsafe.IsAddressLessThanOrEqualTo(in reference3, in reference4));
		if ((uint)length % Vector128<TValue>.Count != 0L)
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference4);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference4, vector);
			}
		}
		return -1;
		IL_03a5:
		return (int)num;
		IL_0393:
		return (int)(num + 3);
		IL_039f:
		return (int)(num + 1);
		IL_0399:
		return (int)(num + 2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int IndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (false)
		{
		}
		return NonPackedIndexOfAnyValueType<TValue, TNegator>(ref searchSpace, value0, value1, value2, length);
	}

	internal static int NonPackedIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		nuint num;
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			num = 0u;
			if (typeof(TValue) == typeof(byte))
			{
				while (length >= 8)
				{
					length -= 8;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						val = Unsafe.Add(ref reference, 1);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							val = Unsafe.Add(ref reference, 2);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
							{
								val = Unsafe.Add(ref reference, 3);
								if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
								{
									val = Unsafe.Add(ref reference, 4);
									if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
									{
										val = Unsafe.Add(ref reference, 5);
										if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
										{
											val = Unsafe.Add(ref reference, 6);
											if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
											{
												val = Unsafe.Add(ref reference, 7);
												if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
												{
													num += 8;
													continue;
												}
												return (int)(num + 7);
											}
											return (int)(num + 6);
										}
										return (int)(num + 5);
									}
									return (int)(num + 4);
								}
								goto IL_0460;
							}
							goto IL_0466;
						}
						goto IL_046c;
					}
					goto IL_0472;
				}
			}
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference2 = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference2;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						break;
					}
					val = Unsafe.Add(ref reference2, 1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						val = Unsafe.Add(ref reference2, 2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							val = Unsafe.Add(ref reference2, 3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
							{
								num += 4;
								continue;
							}
							goto IL_0460;
						}
						goto IL_0466;
					}
					goto IL_046c;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				break;
			}
			goto IL_0472;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> left = Vector128.Create(value0);
		Vector128<TValue> left2 = Vector128.Create(value1);
		Vector128<TValue> left3 = Vector128.Create(value2);
		ref TValue reference3 = ref searchSpace;
		ref TValue reference4 = ref Unsafe.Add(ref searchSpace, length - Vector128<TValue>.Count);
		do
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference3);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right));
			if (vector == Vector128<TValue>.Zero)
			{
				reference3 = ref Unsafe.Add(ref reference3, Vector128<TValue>.Count);
				continue;
			}
			return ComputeFirstIndex(ref searchSpace, ref reference3, vector);
		}
		while (Unsafe.IsAddressLessThanOrEqualTo(in reference3, in reference4));
		if ((uint)length % Vector128<TValue>.Count != 0L)
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference4);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference4, vector);
			}
		}
		return -1;
		IL_0466:
		return (int)(num + 2);
		IL_046c:
		return (int)(num + 1);
		IL_0460:
		return (int)(num + 3);
		IL_0472:
		return (int)num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, value3, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, value3, length);
	}

	private static int IndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, TValue value3, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = 0u;
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
					{
						break;
					}
					val = Unsafe.Add(ref reference, 1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
					{
						val = Unsafe.Add(ref reference, 2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
						{
							val = Unsafe.Add(ref reference, 3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
							{
								num += 4;
								continue;
							}
							return (int)(num + 3);
						}
						return (int)(num + 2);
					}
					return (int)(num + 1);
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				break;
			}
			return (int)num;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> left = Vector128.Create(value0);
		Vector128<TValue> left2 = Vector128.Create(value1);
		Vector128<TValue> left3 = Vector128.Create(value2);
		Vector128<TValue> left4 = Vector128.Create(value3);
		ref TValue reference2 = ref searchSpace;
		ref TValue reference3 = ref Unsafe.Add(ref searchSpace, length - Vector128<TValue>.Count);
		do
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference2);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right) | Vector128.Equals(left4, right));
			if (vector == Vector128<TValue>.Zero)
			{
				reference2 = ref Unsafe.Add(ref reference2, Vector128<TValue>.Count);
				continue;
			}
			return ComputeFirstIndex(ref searchSpace, ref reference2, vector);
		}
		while (Unsafe.IsAddressLessThanOrEqualTo(in reference2, in reference3));
		if ((uint)length % Vector128<TValue>.Count != 0L)
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference3);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right) | Vector128.Equals(left4, right));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference3, vector);
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, T value4, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, value3, value4, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int IndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, T value4, int length) where T : struct, INumber<T>
	{
		return IndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, value3, value4, length);
	}

	private static int IndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, TValue value3, TValue value4, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = 0u;
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
					{
						break;
					}
					val = Unsafe.Add(ref reference, 1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
					{
						val = Unsafe.Add(ref reference, 2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
						{
							val = Unsafe.Add(ref reference, 3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
							{
								num += 4;
								continue;
							}
							return (int)(num + 3);
						}
						return (int)(num + 2);
					}
					return (int)(num + 1);
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
						{
							break;
						}
						num++;
						continue;
					}
					return -1;
				}
				break;
			}
			return (int)num;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> left = Vector128.Create(value0);
		Vector128<TValue> left2 = Vector128.Create(value1);
		Vector128<TValue> left3 = Vector128.Create(value2);
		Vector128<TValue> left4 = Vector128.Create(value3);
		Vector128<TValue> left5 = Vector128.Create(value4);
		ref TValue reference2 = ref searchSpace;
		ref TValue reference3 = ref Unsafe.Add(ref searchSpace, (uint)(length - Vector128<TValue>.Count));
		do
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference2);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right) | Vector128.Equals(left4, right) | Vector128.Equals(left5, right));
			if (vector == Vector128<TValue>.Zero)
			{
				reference2 = ref Unsafe.Add(ref reference2, Vector128<TValue>.Count);
				continue;
			}
			return ComputeFirstIndex(ref searchSpace, ref reference2, vector);
		}
		while (Unsafe.IsAddressLessThanOrEqualTo(in reference2, in reference3));
		if ((uint)length % Vector128<TValue>.Count != 0L)
		{
			Vector128<TValue> right = Vector128.LoadUnsafe(in reference3);
			Vector128<TValue> vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left2, right) | Vector128.Equals(left3, right) | Vector128.Equals(left4, right) | Vector128.Equals(left5, right));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference3, vector);
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		return LastIndexOfValueType<T, DontNegate<T>>(ref searchSpace, value, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyExceptValueType<T>(ref T searchSpace, T value, int length) where T : struct, INumber<T>
	{
		return LastIndexOfValueType<T, Negate<T>>(ref searchSpace, value, length);
	}

	private static int LastIndexOfValueType<TValue, TNegator>(ref TValue searchSpace, TValue value, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = (nuint)length - (nuint)1u;
			while (true)
			{
				if (length >= 8)
				{
					length -= 8;
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
					{
						break;
					}
					if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 1) == value))
					{
						if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 2) == value))
						{
							if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 3) == value))
							{
								if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 4) == value))
								{
									if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 5) == value))
									{
										if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 6) == value))
										{
											if (!TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 7) == value))
											{
												num -= 8;
												continue;
											}
											return (int)(num - 7);
										}
										return (int)(num - 6);
									}
									return (int)(num - 5);
								}
								return (int)(num - 4);
							}
							goto IL_0289;
						}
						goto IL_028f;
					}
					goto IL_0295;
				}
				if (length >= 4)
				{
					length -= 4;
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
					{
						break;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 1) == value))
					{
						goto IL_0295;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 2) == value))
					{
						goto IL_028f;
					}
					if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num - 3) == value))
					{
						goto IL_0289;
					}
					num -= 4;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) == value))
						{
							break;
						}
						num--;
						continue;
					}
					return -1;
				}
				break;
				IL_0295:
				return (int)(num - 1);
				IL_0289:
				return (int)(num - 3);
				IL_028f:
				return (int)(num - 2);
			}
			return (int)num;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		return SimdImpl<Vector128<TValue>>(ref searchSpace, value, length);
		static int SimdImpl<TVector>(ref TValue source, TValue value2, int num3) where TVector : struct, ISimdVector<TVector, TValue>
		{
			TVector left = ((ISimdVector<TVector, TValue>)TVector/*cast due to .constrained prefix*/).Create(value2);
			TVector right;
			for (int num2 = num3 - ((ISimdVector<TVector, TValue>)TVector).ElementCount; num2 > 0; num2 -= ((ISimdVector<TVector, TValue>)TVector).ElementCount)
			{
				right = ((ISimdVector<TVector, TValue>)TVector/*cast due to .constrained prefix*/).LoadUnsafe(in source, (nuint)(uint)num2);
				if (((INegator<TValue>)TNegator/*cast due to .constrained prefix*/).HasMatch<TVector>(left, right))
				{
					return num2 + ((ISimdVector<TVector, TValue>)TVector/*cast due to .constrained prefix*/).LastIndexOfWhereAllBitsSet(((INegator<TValue>)TNegator/*cast due to .constrained prefix*/).GetMatchMask<TVector>(left, right));
				}
			}
			right = ((ISimdVector<TVector, TValue>)TVector/*cast due to .constrained prefix*/).LoadUnsafe(in source);
			if (((INegator<TValue>)TNegator/*cast due to .constrained prefix*/).HasMatch<TVector>(left, right))
			{
				return ((ISimdVector<TVector, TValue>)TVector/*cast due to .constrained prefix*/).LastIndexOfWhereAllBitsSet(((INegator<TValue>)TNegator/*cast due to .constrained prefix*/).GetMatchMask<TVector>(left, right));
			}
			return -1;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, length);
	}

	private static int LastIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		nuint num;
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			num = (nuint)length - (nuint)1u;
			if (typeof(TValue) == typeof(byte))
			{
				while (length >= 8)
				{
					length -= 8;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						val = Unsafe.Add(ref reference, -1);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							val = Unsafe.Add(ref reference, -2);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
							{
								val = Unsafe.Add(ref reference, -3);
								if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
								{
									val = Unsafe.Add(ref reference, -4);
									if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
									{
										val = Unsafe.Add(ref reference, -5);
										if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
										{
											val = Unsafe.Add(ref reference, -6);
											if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
											{
												val = Unsafe.Add(ref reference, -7);
												if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
												{
													num -= 8;
													continue;
												}
												return (int)(num - 7);
											}
											return (int)(num - 6);
										}
										return (int)(num - 5);
									}
									return (int)(num - 4);
								}
								goto IL_039e;
							}
							goto IL_03a4;
						}
						goto IL_03aa;
					}
					goto IL_03b0;
				}
			}
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference2 = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference2;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						break;
					}
					val = Unsafe.Add(ref reference2, -1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
					{
						val = Unsafe.Add(ref reference2, -2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							val = Unsafe.Add(ref reference2, -3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1))
							{
								num -= 4;
								continue;
							}
							goto IL_039e;
						}
						goto IL_03a4;
					}
					goto IL_03aa;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1))
						{
							break;
						}
						num--;
						continue;
					}
					return -1;
				}
				break;
			}
			goto IL_03b0;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> right = Vector128.Create(value0);
		Vector128<TValue> right2 = Vector128.Create(value1);
		nint num2 = length - Vector128<TValue>.Count;
		Vector128<TValue> left;
		Vector128<TValue> vector;
		while (num2 > 0)
		{
			left = Vector128.LoadUnsafe(in searchSpace, (nuint)num2);
			vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2));
			if (vector == Vector128<TValue>.Zero)
			{
				num2 -= Vector128<TValue>.Count;
				continue;
			}
			return ComputeLastIndex(num2, vector);
		}
		left = Vector128.LoadUnsafe(in searchSpace);
		vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2));
		if (vector != Vector128<TValue>.Zero)
		{
			return ComputeLastIndex(0, vector);
		}
		return -1;
		IL_03aa:
		return (int)(num - 1);
		IL_03a4:
		return (int)(num - 2);
		IL_03b0:
		return (int)num;
		IL_039e:
		return (int)(num - 3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, length);
	}

	private static int LastIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		nuint num;
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			num = (nuint)length - (nuint)1u;
			if (typeof(TValue) == typeof(byte))
			{
				while (length >= 8)
				{
					length -= 8;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						val = Unsafe.Add(ref reference, -1);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							val = Unsafe.Add(ref reference, -2);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
							{
								val = Unsafe.Add(ref reference, -3);
								if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
								{
									val = Unsafe.Add(ref reference, -4);
									if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
									{
										val = Unsafe.Add(ref reference, -5);
										if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
										{
											val = Unsafe.Add(ref reference, -6);
											if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
											{
												val = Unsafe.Add(ref reference, -7);
												if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
												{
													num -= 8;
													continue;
												}
												return (int)(num - 7);
											}
											return (int)(num - 6);
										}
										return (int)(num - 5);
									}
									return (int)(num - 4);
								}
								goto IL_046c;
							}
							goto IL_0472;
						}
						goto IL_0478;
					}
					goto IL_047e;
				}
			}
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference2 = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference2;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						break;
					}
					val = Unsafe.Add(ref reference2, -1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
					{
						val = Unsafe.Add(ref reference2, -2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							val = Unsafe.Add(ref reference2, -3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
							{
								num -= 4;
								continue;
							}
							goto IL_046c;
						}
						goto IL_0472;
					}
					goto IL_0478;
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2))
						{
							break;
						}
						num--;
						continue;
					}
					return -1;
				}
				break;
			}
			goto IL_047e;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> right = Vector128.Create(value0);
		Vector128<TValue> right2 = Vector128.Create(value1);
		Vector128<TValue> right3 = Vector128.Create(value2);
		nint num2 = length - Vector128<TValue>.Count;
		Vector128<TValue> left;
		Vector128<TValue> vector;
		while (num2 > 0)
		{
			left = Vector128.LoadUnsafe(in searchSpace, (nuint)num2);
			vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3));
			if (vector == Vector128<TValue>.Zero)
			{
				num2 -= Vector128<TValue>.Count;
				continue;
			}
			return ComputeLastIndex(num2, vector);
		}
		left = Vector128.LoadUnsafe(in searchSpace);
		vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3));
		if (vector != Vector128<TValue>.Zero)
		{
			return ComputeLastIndex(0, vector);
		}
		return -1;
		IL_046c:
		return (int)(num - 3);
		IL_047e:
		return (int)num;
		IL_0472:
		return (int)(num - 2);
		IL_0478:
		return (int)(num - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, value3, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, value3, length);
	}

	private static int LastIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, TValue value3, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = (nuint)length - (nuint)1u;
			while (true)
			{
				if (length >= 4)
				{
					length -= 4;
					ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
					TValue val = reference;
					if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
					{
						break;
					}
					val = Unsafe.Add(ref reference, -1);
					if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
					{
						val = Unsafe.Add(ref reference, -2);
						if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
						{
							val = Unsafe.Add(ref reference, -3);
							if (!TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
							{
								num -= 4;
								continue;
							}
							return (int)(num - 3);
						}
						return (int)(num - 2);
					}
					return (int)(num - 1);
				}
				while (true)
				{
					if (length > 0)
					{
						length--;
						TValue val = Unsafe.Add(ref searchSpace, num);
						if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3))
						{
							break;
						}
						num--;
						continue;
					}
					return -1;
				}
				break;
			}
			return (int)num;
		}
		if (false)
		{
		}
		if (false)
		{
		}
		Vector128<TValue> right = Vector128.Create(value0);
		Vector128<TValue> right2 = Vector128.Create(value1);
		Vector128<TValue> right3 = Vector128.Create(value2);
		Vector128<TValue> right4 = Vector128.Create(value3);
		nint num2 = length - Vector128<TValue>.Count;
		Vector128<TValue> left;
		Vector128<TValue> vector;
		while (num2 > 0)
		{
			left = Vector128.LoadUnsafe(in searchSpace, (nuint)num2);
			vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3) | Vector128.Equals(left, right4));
			if (vector == Vector128<TValue>.Zero)
			{
				num2 -= Vector128<TValue>.Count;
				continue;
			}
			return ComputeLastIndex(num2, vector);
		}
		left = Vector128.LoadUnsafe(in searchSpace);
		vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3) | Vector128.Equals(left, right4));
		if (vector != Vector128<TValue>.Zero)
		{
			return ComputeLastIndex(0, vector);
		}
		return -1;
	}

	public static void Replace<T>(ref T src, ref T dst, T oldValue, T newValue, nuint length) where T : IEquatable<T>
	{
		if (default(T) != null || oldValue != null)
		{
			for (nuint num = 0u; num < length; num++)
			{
				T val = Unsafe.Add(ref src, num);
				Unsafe.Add(ref dst, num) = (oldValue.Equals(val) ? newValue : val);
			}
		}
		else
		{
			for (nuint num2 = 0u; num2 < length; num2++)
			{
				T val2 = Unsafe.Add(ref src, num2);
				Unsafe.Add(ref dst, num2) = ((val2 == null) ? newValue : val2);
			}
		}
	}

	public static void ReplaceValueType<T>(ref T src, ref T dst, T oldValue, T newValue, nuint length) where T : struct
	{
		if (!Vector128.IsHardwareAccelerated || length < (uint)Vector128<T>.Count)
		{
			for (nuint num = 0u; num < length; num++)
			{
				T val = Unsafe.Add(ref src, num);
				Unsafe.Add(ref dst, num) = (EqualityComparer<T>.Default.Equals(val, oldValue) ? newValue : val);
			}
			return;
		}
		nuint num2 = 0u;
		if (false)
		{
		}
		nuint num3 = length - (uint)Vector128<T>.Count;
		Vector128<T> left = Vector128.Create(oldValue);
		Vector128<T> left2 = Vector128.Create(newValue);
		Vector128<T> right;
		do
		{
			right = Vector128.LoadUnsafe(in src, num2);
			Vector128.ConditionalSelect(Vector128.Equals(left, right), left2, right).StoreUnsafe(ref dst, num2);
			num2 += (uint)Vector128<T>.Count;
		}
		while (num2 < num3);
		right = Vector128.LoadUnsafe(in src, num3);
		Vector128.ConditionalSelect(Vector128.Equals(left, right), left2, right).StoreUnsafe(ref dst, num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, T value4, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, DontNegate<T>>(ref searchSpace, value0, value1, value2, value3, value4, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int LastIndexOfAnyExceptValueType<T>(ref T searchSpace, T value0, T value1, T value2, T value3, T value4, int length) where T : struct, INumber<T>
	{
		return LastIndexOfAnyValueType<T, Negate<T>>(ref searchSpace, value0, value1, value2, value3, value4, length);
	}

	private static int LastIndexOfAnyValueType<TValue, TNegator>(ref TValue searchSpace, TValue value0, TValue value1, TValue value2, TValue value3, TValue value4, int length) where TValue : struct, INumber<TValue> where TNegator : struct, INegator<TValue>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
		{
			nuint num = (nuint)length - (nuint)1u;
			while (length >= 4)
			{
				length -= 4;
				ref TValue reference = ref Unsafe.Add(ref searchSpace, num);
				TValue val = reference;
				if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
				{
					return (int)num;
				}
				val = Unsafe.Add(ref reference, -1);
				if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
				{
					return (int)num - 1;
				}
				val = Unsafe.Add(ref reference, -2);
				if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
				{
					return (int)num - 2;
				}
				val = Unsafe.Add(ref reference, -3);
				if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
				{
					return (int)num - 3;
				}
				num -= 4;
			}
			while (length > 0)
			{
				length--;
				TValue val = Unsafe.Add(ref searchSpace, num);
				if (TNegator.NegateIfNeeded(val == value0 || val == value1 || val == value2 || val == value3 || val == value4))
				{
					return (int)num;
				}
				num--;
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
			Vector128<TValue> right = Vector128.Create(value0);
			Vector128<TValue> right2 = Vector128.Create(value1);
			Vector128<TValue> right3 = Vector128.Create(value2);
			Vector128<TValue> right4 = Vector128.Create(value3);
			Vector128<TValue> right5 = Vector128.Create(value4);
			nint num2 = length - Vector128<TValue>.Count;
			Vector128<TValue> left;
			Vector128<TValue> vector;
			while (num2 > 0)
			{
				left = Vector128.LoadUnsafe(in searchSpace, (nuint)num2);
				vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3) | Vector128.Equals(left, right4) | Vector128.Equals(left, right5));
				if (vector == Vector128<TValue>.Zero)
				{
					num2 -= Vector128<TValue>.Count;
					continue;
				}
				return ComputeLastIndex(num2, vector);
			}
			left = Vector128.LoadUnsafe(in searchSpace);
			vector = TNegator.NegateIfNeeded(Vector128.Equals(left, right) | Vector128.Equals(left, right2) | Vector128.Equals(left, right3) | Vector128.Equals(left, right4) | Vector128.Equals(left, right5));
			if (vector != Vector128<TValue>.Zero)
			{
				return ComputeLastIndex(0, vector);
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ComputeFirstIndex<T>(ref T searchSpace, ref T current, Vector128<T> equals) where T : struct
	{
		return BitOperations.TrailingZeroCount(equals.ExtractMostSignificantBits()) + (int)((nuint)Unsafe.ByteOffset(in searchSpace, in current) / (nuint)Unsafe.SizeOf<T>());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ComputeLastIndex<T>(nint offset, Vector128<T> equals) where T : struct
	{
		uint value = equals.ExtractMostSignificantBits();
		int num = 31 - BitOperations.LeadingZeroCount(value);
		return (int)offset + num;
	}

	internal static int IndexOfAnyInRange<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : IComparable<T>
	{
		for (int i = 0; i < length; i++)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, i);
			if (lowInclusive.CompareTo(reference) <= 0 && highInclusive.CompareTo(reference) >= 0)
			{
				return i;
			}
		}
		return -1;
	}

	internal static int IndexOfAnyExceptInRange<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : IComparable<T>
	{
		for (int i = 0; i < length; i++)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, i);
			if (lowInclusive.CompareTo(reference) > 0 || highInclusive.CompareTo(reference) < 0)
			{
				return i;
			}
		}
		return -1;
	}

	internal static int IndexOfAnyInRangeUnsignedNumber<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool>
	{
		return IndexOfAnyInRangeUnsignedNumber<T, DontNegate<T>>(ref searchSpace, lowInclusive, highInclusive, length);
	}

	internal static int IndexOfAnyExceptInRangeUnsignedNumber<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool>
	{
		return IndexOfAnyInRangeUnsignedNumber<T, Negate<T>>(ref searchSpace, lowInclusive, highInclusive, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int IndexOfAnyInRangeUnsignedNumber<T, TNegator>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool> where TNegator : struct, INegator<T>
	{
		if (false)
		{
		}
		return NonPackedIndexOfAnyInRangeUnsignedNumber<T, TNegator>(ref searchSpace, lowInclusive, highInclusive, length);
	}

	internal static int NonPackedIndexOfAnyInRangeUnsignedNumber<T, TNegator>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool> where TNegator : struct, INegator<T>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<T>.Count)
		{
			T val = highInclusive - lowInclusive;
			for (int i = 0; i < length; i++)
			{
				if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, i) - lowInclusive <= val))
				{
					return i;
				}
			}
		}
		else
		{
			if (false)
			{
			}
			Vector128<T> vector = Vector128.Create(lowInclusive);
			Vector128<T> right = Vector128.Create(highInclusive - lowInclusive);
			ref T reference = ref searchSpace;
			ref T reference2 = ref Unsafe.Add(ref searchSpace, (uint)(length - Vector128<T>.Count));
			Vector128<T> vector2;
			do
			{
				vector2 = TNegator.NegateIfNeeded(Vector128.LessThanOrEqual(Vector128.LoadUnsafe(in reference) - vector, right));
				if (vector2 != Vector128<T>.Zero)
				{
					return ComputeFirstIndex(ref searchSpace, ref reference, vector2);
				}
				reference = ref Unsafe.Add(ref reference, Vector128<T>.Count);
			}
			while (Unsafe.IsAddressLessThan(in reference, in reference2));
			vector2 = TNegator.NegateIfNeeded(Vector128.LessThanOrEqual(Vector128.LoadUnsafe(in reference2) - vector, right));
			if (vector2 != Vector128<T>.Zero)
			{
				return ComputeFirstIndex(ref searchSpace, ref reference2, vector2);
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyInRange<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : IComparable<T>
	{
		for (int num = length - 1; num >= 0; num--)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, num);
			if (lowInclusive.CompareTo(reference) <= 0 && highInclusive.CompareTo(reference) >= 0)
			{
				return num;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyExceptInRange<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : IComparable<T>
	{
		for (int num = length - 1; num >= 0; num--)
		{
			ref T reference = ref Unsafe.Add(ref searchSpace, num);
			if (lowInclusive.CompareTo(reference) > 0 || highInclusive.CompareTo(reference) < 0)
			{
				return num;
			}
		}
		return -1;
	}

	internal static int LastIndexOfAnyInRangeUnsignedNumber<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool>
	{
		return LastIndexOfAnyInRangeUnsignedNumber<T, DontNegate<T>>(ref searchSpace, lowInclusive, highInclusive, length);
	}

	internal static int LastIndexOfAnyExceptInRangeUnsignedNumber<T>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool>
	{
		return LastIndexOfAnyInRangeUnsignedNumber<T, Negate<T>>(ref searchSpace, lowInclusive, highInclusive, length);
	}

	private static int LastIndexOfAnyInRangeUnsignedNumber<T, TNegator>(ref T searchSpace, T lowInclusive, T highInclusive, int length) where T : struct, IUnsignedNumber<T>, IComparisonOperators<T, T, bool> where TNegator : struct, INegator<T>
	{
		if (!Vector128.IsHardwareAccelerated || length < Vector128<T>.Count)
		{
			T val = highInclusive - lowInclusive;
			for (int num = length - 1; num >= 0; num--)
			{
				if (TNegator.NegateIfNeeded(Unsafe.Add(ref searchSpace, num) - lowInclusive <= val))
				{
					return num;
				}
			}
		}
		else
		{
			if (false)
			{
			}
			Vector128<T> vector = Vector128.Create(lowInclusive);
			Vector128<T> right = Vector128.Create(highInclusive - lowInclusive);
			Vector128<T> vector2;
			for (nint num2 = length - Vector128<T>.Count; num2 > 0; num2 -= Vector128<T>.Count)
			{
				vector2 = TNegator.NegateIfNeeded(Vector128.LessThanOrEqual(Vector128.LoadUnsafe(in searchSpace, (nuint)num2) - vector, right));
				if (vector2 != Vector128<T>.Zero)
				{
					return ComputeLastIndex(num2, vector2);
				}
			}
			vector2 = TNegator.NegateIfNeeded(Vector128.LessThanOrEqual(Vector128.LoadUnsafe(in searchSpace) - vector, right));
			if (vector2 != Vector128<T>.Zero)
			{
				return ComputeLastIndex(0, vector2);
			}
		}
		return -1;
	}

	public static int Count<T>(ref T current, T value, int length) where T : IEquatable<T>
	{
		int num = 0;
		ref T right = ref Unsafe.Add(ref current, length);
		if (value != null)
		{
			while (Unsafe.IsAddressLessThan(in current, in right))
			{
				if (value.Equals(current))
				{
					num++;
				}
				current = ref Unsafe.Add(ref current, 1);
			}
		}
		else
		{
			while (Unsafe.IsAddressLessThan(in current, in right))
			{
				if (current == null)
				{
					num++;
				}
				current = ref Unsafe.Add(ref current, 1);
			}
		}
		return num;
	}

	public static int CountValueType<T>(ref T current, T value, int length) where T : struct, IEquatable<T>
	{
		int num = 0;
		ref T reference = ref Unsafe.Add(ref current, length);
		if (Vector128.IsHardwareAccelerated && length >= Vector128<T>.Count)
		{
			if (false)
			{
			}
			if (false)
			{
			}
			Vector128<T> right = Vector128.Create(value);
			ref T reference2 = ref Unsafe.Subtract(ref reference, Vector128<T>.Count);
			while (Unsafe.IsAddressLessThan(in current, in reference2))
			{
				num += BitOperations.PopCount(Vector128.Equals(Vector128.LoadUnsafe(in current), right).ExtractMostSignificantBits());
				current = ref Unsafe.Add(ref current, Vector128<T>.Count);
			}
			uint num2 = Vector128.Equals(Vector128.LoadUnsafe(in reference2), right).ExtractMostSignificantBits();
			num2 >>= (int)((nuint)Unsafe.ByteOffset(in reference2, in current) / (nuint)(uint)Unsafe.SizeOf<T>());
			num += BitOperations.PopCount(num2);
		}
		else
		{
			while (Unsafe.IsAddressLessThan(in current, in reference))
			{
				if (current.Equals(value))
				{
					num++;
				}
				current = ref Unsafe.Add(ref current, 1);
			}
		}
		return num;
	}
}
