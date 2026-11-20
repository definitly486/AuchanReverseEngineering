using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;

namespace System;

internal static class Number
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal ref struct BigInteger
	{
		private int _length;

		private unsafe fixed uint _blocks[116];

		private static ReadOnlySpan<uint> Pow10UInt32Table => new uint[10] { 1u, 10u, 100u, 1000u, 10000u, 100000u, 1000000u, 10000000u, 100000000u, 1000000000u };

		private static ReadOnlySpan<int> Pow10BigNumTableIndices => new int[8] { 0, 2, 5, 10, 18, 33, 61, 116 };

		private static ReadOnlySpan<uint> Pow10BigNumTable => new uint[234]
		{
			1u, 100000000u, 2u, 1874919424u, 2328306u, 4u, 0u, 2242703233u, 762134875u, 1262u,
			7u, 0u, 0u, 3211403009u, 1849224548u, 3668416493u, 3913284084u, 1593091u, 14u, 0u,
			0u, 0u, 0u, 781532673u, 64985353u, 253049085u, 594863151u, 3553621484u, 3288652808u, 3167596762u,
			2788392729u, 3911132675u, 590u, 27u, 0u, 0u, 0u, 0u, 0u, 0u,
			0u, 0u, 2553183233u, 3201533787u, 3638140786u, 303378311u, 1809731782u, 3477761648u, 3583367183u, 649228654u,
			2915460784u, 487929380u, 1011012442u, 1677677582u, 3428152256u, 1710878487u, 1438394610u, 2161952759u, 4100910556u, 1608314830u,
			349175u, 54u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
			0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 4234999809u, 2012377703u,
			2408924892u, 1570150255u, 3090844311u, 3273530073u, 1187251475u, 2498123591u, 3364452033u, 1148564857u, 687371067u, 2854068671u,
			1883165473u, 505794538u, 2988060450u, 3159489326u, 2531348317u, 3215191468u, 849106862u, 3892080979u, 3288073877u, 2242451748u,
			4183778142u, 2995818208u, 2477501924u, 325481258u, 2487842652u, 1774082830u, 1933815724u, 2962865281u, 1168579910u, 2724829000u,
			2360374019u, 2315984659u, 2360052375u, 3251779801u, 1664357844u, 28u, 107u, 0u, 0u, 0u,
			0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
			0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
			0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 689565697u,
			4116392818u, 1853628763u, 516071302u, 2568769159u, 365238920u, 336250165u, 1283268122u, 3425490969u, 248595470u, 2305176814u,
			2111925499u, 507770399u, 2681111421u, 589114268u, 591287751u, 1708941527u, 4098957707u, 475844916u, 3378731398u, 2452339615u,
			2817037361u, 2678008327u, 1656645978u, 2383430340u, 73103988u, 448667107u, 2329420453u, 3124020241u, 3625235717u, 3208634035u,
			2412059158u, 2981664444u, 4117622508u, 838560765u, 3069470027u, 270153238u, 1802868219u, 3692709886u, 2161737865u, 2159912357u,
			2585798786u, 837488486u, 4237238160u, 2540319504u, 3798629246u, 3748148874u, 1021550776u, 2386715342u, 1973637538u, 1823520457u,
			1146713475u, 833971519u, 3277251466u, 905620390u, 26278816u, 2680483154u, 2294040859u, 373297482u, 5996609u, 4109575006u,
			512575049u, 917036550u, 1942311753u, 2816916778u, 3248920332u, 1192784020u, 3537586671u, 2456567643u, 2925660628u, 759380297u,
			888447942u, 3559939476u, 3654687237u, 805u, 0u, 0u, 0u, 0u, 0u, 0u,
			0u, 0u, 0u, 0u
		};

		public unsafe static void Add(scoped ref BigInteger lhs, scoped ref BigInteger rhs, out BigInteger result)
		{
			ref BigInteger reference = ref lhs._length < rhs._length ? ref rhs : ref lhs;
			ref BigInteger reference2 = ref lhs._length < rhs._length ? ref lhs : ref rhs;
			int length = reference._length;
			int length2 = reference2._length;
			result._length = length;
			ulong num = 0uL;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			while (num3 < length2)
			{
				ulong num5 = num + reference._blocks[num2] + reference2._blocks[num3];
				num = num5 >> 32;
				result._blocks[num4] = (uint)num5;
				num2++;
				num3++;
				num4++;
			}
			while (num2 < length)
			{
				ulong num6 = num + reference._blocks[num2];
				num = num6 >> 32;
				result._blocks[num4] = (uint)num6;
				num2++;
				num4++;
			}
			int num7 = length;
			if (num != 0L)
			{
				if ((uint)num7 >= 116u)
				{
					SetZero(out result);
					return;
				}
				result._blocks[num4] = 1u;
				result._length++;
			}
		}

		public unsafe static int Compare(scoped ref BigInteger lhs, scoped ref BigInteger rhs)
		{
			int length = lhs._length;
			int length2 = rhs._length;
			int num = length - length2;
			if (num != 0)
			{
				return num;
			}
			if (length == 0)
			{
				return 0;
			}
			for (int num2 = length - 1; num2 >= 0; num2--)
			{
				long num3 = (long)lhs._blocks[num2] - (long)rhs._blocks[num2];
				if (num3 != 0L)
				{
					if (num3 <= 0)
					{
						return -1;
					}
					return 1;
				}
			}
			return 0;
		}

		public static uint CountSignificantBits(uint value)
		{
			return (uint)(32 - BitOperations.LeadingZeroCount(value));
		}

		public static uint CountSignificantBits(ulong value)
		{
			return (uint)(64 - BitOperations.LeadingZeroCount(value));
		}

		public unsafe static uint CountSignificantBits(ref BigInteger value)
		{
			if (value.IsZero())
			{
				return 0u;
			}
			uint num = (uint)(value._length - 1);
			return num * 32 + CountSignificantBits(value._blocks[num]);
		}

		public unsafe static void DivRem(scoped ref BigInteger lhs, scoped ref BigInteger rhs, out BigInteger quo, out BigInteger rem)
		{
			if (lhs.IsZero())
			{
				SetZero(out quo);
				SetZero(out rem);
				return;
			}
			int length = lhs._length;
			int length2 = rhs._length;
			if (length == 1 && length2 == 1)
			{
				var (value, value2) = Math.DivRem(lhs._blocks[0], rhs._blocks[0]);
				SetUInt32(out quo, value);
				SetUInt32(out rem, value2);
				return;
			}
			if (length2 == 1)
			{
				int num = length;
				ulong right = rhs._blocks[0];
				ulong num2 = 0uL;
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					ulong num4;
					(num4, num2) = Math.DivRem((num2 << 32) | lhs._blocks[num3], right);
					if (num4 == 0L && num3 == num - 1)
					{
						num--;
					}
					else
					{
						quo._blocks[num3] = (uint)num4;
					}
				}
				quo._length = num;
				SetUInt32(out rem, (uint)num2);
				return;
			}
			if (length2 > length)
			{
				SetZero(out quo);
				SetValue(out rem, ref lhs);
				return;
			}
			int num5 = length - length2 + 1;
			SetValue(out rem, ref lhs);
			int num6 = length;
			uint num7 = rhs._blocks[length2 - 1];
			uint num8 = rhs._blocks[length2 - 2];
			int num9 = BitOperations.LeadingZeroCount(num7);
			int num10 = 32 - num9;
			if (num9 > 0)
			{
				num7 = (num7 << num9) | (num8 >> num10);
				num8 <<= num9;
				if (length2 > 2)
				{
					num8 |= rhs._blocks[length2 - 3] >> num10;
				}
			}
			for (int num11 = length; num11 >= length2; num11--)
			{
				int num12 = num11 - length2;
				uint num13 = ((num11 < length) ? rem._blocks[num11] : 0u);
				ulong num14 = ((ulong)num13 << 32) | rem._blocks[num11 - 1];
				uint num15 = ((num11 > 1) ? rem._blocks[num11 - 2] : 0u);
				if (num9 > 0)
				{
					num14 = (num14 << num9) | (num15 >> num10);
					num15 <<= num9;
					if (num11 > 2)
					{
						num15 |= rem._blocks[num11 - 3] >> num10;
					}
				}
				ulong num16 = num14 / num7;
				if (num16 > uint.MaxValue)
				{
					num16 = 4294967295uL;
				}
				while (DivideGuessTooBig(num16, num14, num15, num7, num8))
				{
					num16--;
				}
				if (num16 != 0 && SubtractDivisor(ref rem, num12, ref rhs, num16) != num13)
				{
					AddDivisor(ref rem, num12, ref rhs);
					num16--;
				}
				if (num5 != 0)
				{
					if (num16 == 0L && num12 == num5 - 1)
					{
						num5--;
					}
					else
					{
						quo._blocks[num12] = (uint)num16;
					}
				}
				if (num11 < num6)
				{
					num6--;
				}
			}
			quo._length = num5;
			int num17 = num6 - 1;
			while (num17 >= 0 && rem._blocks[num17] == 0)
			{
				num6--;
				num17--;
			}
			rem._length = num6;
		}

		public unsafe static uint HeuristicDivide(ref BigInteger dividend, ref BigInteger divisor)
		{
			int num = divisor._length;
			if (dividend._length < num)
			{
				return 0u;
			}
			int num2 = num - 1;
			uint num3 = dividend._blocks[num2] / (divisor._blocks[num2] + 1);
			if (num3 != 0)
			{
				int num4 = 0;
				ulong num5 = 0uL;
				ulong num6 = 0uL;
				do
				{
					ulong num7 = (ulong)((long)divisor._blocks[num4] * (long)num3) + num6;
					num6 = num7 >> 32;
					ulong num8 = (ulong)((long)dividend._blocks[num4] - (long)(uint)num7) - num5;
					num5 = (num8 >> 32) & 1;
					dividend._blocks[num4] = (uint)num8;
					num4++;
				}
				while (num4 < num);
				while (num > 0 && dividend._blocks[num - 1] == 0)
				{
					num--;
				}
				dividend._length = num;
			}
			if (Compare(ref dividend, ref divisor) >= 0)
			{
				num3++;
				int num9 = 0;
				ulong num10 = 0uL;
				do
				{
					ulong num11 = (ulong)((long)dividend._blocks[num9] - (long)divisor._blocks[num9]) - num10;
					num10 = (num11 >> 32) & 1;
					dividend._blocks[num9] = (uint)num11;
					num9++;
				}
				while (num9 < num);
				while (num > 0 && dividend._blocks[num - 1] == 0)
				{
					num--;
				}
				dividend._length = num;
			}
			return num3;
		}

		public unsafe static void Multiply(scoped ref BigInteger lhs, uint value, out BigInteger result)
		{
			if (lhs._length <= 1)
			{
				SetUInt64(out result, (ulong)lhs.ToUInt32() * (ulong)value);
				return;
			}
			switch (value)
			{
			case 0u:
				SetZero(out result);
				return;
			case 1u:
				SetValue(out result, ref lhs);
				return;
			}
			int length = lhs._length;
			int i = 0;
			uint num = 0u;
			for (; i < length; i++)
			{
				ulong num2 = (ulong)((long)lhs._blocks[i] * (long)value + num);
				result._blocks[i] = (uint)num2;
				num = (uint)(num2 >> 32);
			}
			int num3 = length;
			if (num != 0)
			{
				if ((uint)num3 >= 116u)
				{
					SetZero(out result);
					return;
				}
				result._blocks[i] = num;
				num3++;
			}
			result._length = num3;
		}

		public unsafe static void Multiply(scoped ref BigInteger lhs, scoped ref BigInteger rhs, out BigInteger result)
		{
			if (lhs._length <= 1)
			{
				Multiply(ref rhs, lhs.ToUInt32(), out result);
				return;
			}
			if (rhs._length <= 1)
			{
				Multiply(ref lhs, rhs.ToUInt32(), out result);
				return;
			}
			ref BigInteger reference = ref lhs;
			int length = lhs._length;
			ref BigInteger reference2 = ref rhs;
			int length2 = rhs._length;
			if (length < length2)
			{
				reference = ref rhs;
				length = rhs._length;
				reference2 = ref lhs;
				length2 = lhs._length;
			}
			int num = length2 + length;
			if ((uint)num > 116u)
			{
				SetZero(out result);
				return;
			}
			result._length = num;
			result.Clear((uint)num);
			int num2 = 0;
			int num3 = 0;
			while (num2 < length2)
			{
				if (reference2._blocks[num2] != 0)
				{
					int num4 = 0;
					int num5 = num3;
					ulong num6 = 0uL;
					do
					{
						ulong num7 = (ulong)(result._blocks[num5] + (long)reference2._blocks[num2] * (long)reference._blocks[num4]) + num6;
						num6 = num7 >> 32;
						result._blocks[num5] = (uint)num7;
						num5++;
						num4++;
					}
					while (num4 < length);
					result._blocks[num5] = (uint)num6;
				}
				num2++;
				num3++;
			}
			if (num > 0 && result._blocks[num - 1] == 0)
			{
				result._length--;
			}
		}

		public unsafe static void Pow2(uint exponent, out BigInteger result)
		{
			uint remainder;
			uint num = DivRem32(exponent, out remainder);
			result._length = (int)(num + 1);
			if ((uint)result._length > 116u)
			{
				SetZero(out result);
				return;
			}
			if (num != 0)
			{
				result.Clear(num);
			}
			result._blocks[num] = (uint)(1 << (int)remainder);
		}

		public unsafe static void Pow10(uint exponent, out BigInteger result)
		{
			SetUInt32(out var result2, Pow10UInt32Table[(int)(exponent & 7)]);
			ref BigInteger reference = ref result2;
			SetZero(out var result3);
			ref BigInteger reference2 = ref result3;
			exponent >>= 3;
			uint num = 0u;
			while (exponent != 0)
			{
				if ((exponent & 1) != 0)
				{
					fixed (uint* ptr = &Pow10BigNumTable[Pow10BigNumTableIndices[(int)num]])
					{
						Multiply(ref reference, ref *(BigInteger*)ptr, out reference2);
					}
					ref BigInteger reference3 = ref reference2;
					reference2 = ref reference;
					reference = ref reference3;
				}
				num++;
				exponent >>= 1;
			}
			SetValue(out result, ref reference);
		}

		private unsafe static uint AddDivisor(ref BigInteger lhs, int lhsStartIndex, ref BigInteger rhs)
		{
			int length = rhs._length;
			ulong num = 0uL;
			for (int i = 0; i < length; i++)
			{
				ref uint reference = ref lhs._blocks[lhsStartIndex + i];
				ulong num2 = reference + num + rhs._blocks[i];
				reference = (uint)num2;
				num = num2 >> 32;
			}
			return (uint)num;
		}

		private static bool DivideGuessTooBig(ulong q, ulong valHi, uint valLo, uint divHi, uint divLo)
		{
			ulong num = divHi * q;
			ulong num2 = divLo * q;
			num += num2 >> 32;
			num2 &= 0xFFFFFFFFu;
			if (num < valHi)
			{
				return false;
			}
			if (num > valHi)
			{
				return true;
			}
			if (num2 < valLo)
			{
				return false;
			}
			if (num2 > valLo)
			{
				return true;
			}
			return false;
		}

		private unsafe static uint SubtractDivisor(ref BigInteger lhs, int lhsStartIndex, ref BigInteger rhs, ulong q)
		{
			int length = rhs._length;
			ulong num = 0uL;
			for (int i = 0; i < length; i++)
			{
				num += rhs._blocks[i] * q;
				uint num2 = (uint)num;
				num >>= 32;
				ref uint reference = ref lhs._blocks[lhsStartIndex + i];
				if (reference < num2)
				{
					num++;
				}
				reference -= num2;
			}
			return (uint)num;
		}

		public unsafe void Add(uint value)
		{
			int length = _length;
			if (length == 0)
			{
				SetUInt32(out this, value);
				return;
			}
			_blocks[0] += value;
			if (_blocks[0] >= value)
			{
				return;
			}
			for (int i = 1; i < length; i++)
			{
				ref uint reference = ref _blocks[i];
				reference++;
				if (_blocks[i] != 0)
				{
					return;
				}
			}
			if ((uint)length >= 116u)
			{
				SetZero(out this);
				return;
			}
			_blocks[length] = 1u;
			_length = length + 1;
		}

		public unsafe uint GetBlock(uint index)
		{
			return _blocks[index];
		}

		public int GetLength()
		{
			return _length;
		}

		public bool IsZero()
		{
			return _length == 0;
		}

		public void Multiply(uint value)
		{
			Multiply(ref this, value, out this);
		}

		public void Multiply(scoped ref BigInteger value)
		{
			if (value._length <= 1)
			{
				Multiply(ref this, value.ToUInt32(), out this);
				return;
			}
			SetValue(out var result, ref this);
			Multiply(ref result, ref value, out this);
		}

		public unsafe void Multiply10()
		{
			if (IsZero())
			{
				return;
			}
			int num = 0;
			int length = _length;
			ulong num2 = 0uL;
			do
			{
				ulong num3 = _blocks[num];
				ulong num4 = (num3 << 3) + (num3 << 1) + num2;
				num2 = num4 >> 32;
				_blocks[num] = (uint)num4;
				num++;
			}
			while (num < length);
			if (num2 != 0L)
			{
				if ((uint)length >= 116u)
				{
					SetZero(out this);
					return;
				}
				_blocks[num] = (uint)num2;
				_length = length + 1;
			}
		}

		public void MultiplyPow10(uint exponent)
		{
			if (exponent <= 9)
			{
				Multiply(Pow10UInt32Table[(int)exponent]);
			}
			else if (!IsZero())
			{
				Pow10(exponent, out var result);
				Multiply(ref result);
			}
		}

		public unsafe static void SetUInt32(out BigInteger result, uint value)
		{
			if (value == 0)
			{
				SetZero(out result);
				return;
			}
			result._blocks[0] = value;
			result._length = 1;
		}

		public unsafe static void SetUInt64(out BigInteger result, ulong value)
		{
			if (value <= uint.MaxValue)
			{
				SetUInt32(out result, (uint)value);
				return;
			}
			result._blocks[0] = (uint)value;
			result._blocks[1] = (uint)(value >> 32);
			result._length = 2;
		}

		public unsafe static void SetValue(out BigInteger result, scoped ref BigInteger value)
		{
			Buffer.Memmove(elementCount: (nuint)(result._length = value._length), destination: ref result._blocks[0], source: ref value._blocks[0]);
		}

		public static void SetZero(out BigInteger result)
		{
			result._length = 0;
		}

		public unsafe void ShiftLeft(uint shift)
		{
			int length = _length;
			if (length == 0 || shift == 0)
			{
				return;
			}
			uint remainder;
			uint num = DivRem32(shift, out remainder);
			int num2 = length - 1;
			int num3 = num2 + (int)num;
			if (remainder == 0)
			{
				if ((uint)length >= 116u)
				{
					SetZero(out this);
					return;
				}
				while (num2 >= 0)
				{
					_blocks[num3] = _blocks[num2];
					num2--;
					num3--;
				}
				_length += (int)num;
				Clear(num);
				return;
			}
			num3++;
			if ((uint)length >= 116u)
			{
				SetZero(out this);
				return;
			}
			_length = num3 + 1;
			uint num4 = 32 - remainder;
			uint num5 = 0u;
			uint num6 = _blocks[num2];
			uint num7 = num6 >> (int)num4;
			while (num2 > 0)
			{
				_blocks[num3] = num5 | num7;
				num5 = num6 << (int)remainder;
				num2--;
				num3--;
				num6 = _blocks[num2];
				num7 = num6 >> (int)num4;
			}
			_blocks[num3] = num5 | num7;
			_blocks[num3 - 1] = num6 << (int)remainder;
			Clear(num);
			if (_blocks[_length - 1] == 0)
			{
				_length--;
			}
		}

		public unsafe uint ToUInt32()
		{
			if (_length > 0)
			{
				return _blocks[0];
			}
			return 0u;
		}

		public unsafe ulong ToUInt64()
		{
			if (_length > 1)
			{
				return ((ulong)_blocks[1] << 32) + _blocks[0];
			}
			if (_length > 0)
			{
				return _blocks[0];
			}
			return 0uL;
		}

		private unsafe void Clear(uint length)
		{
			NativeMemory.Clear(Unsafe.AsPointer(in _blocks[0]), length * 4);
		}

		private static uint DivRem32(uint value, out uint remainder)
		{
			remainder = value & 0x1F;
			return value >> 5;
		}
	}

	internal readonly ref struct DiyFp
	{
		public readonly ulong f;

		public readonly int e;

		public static DiyFp CreateAndGetBoundaries<TNumber>(TNumber value, out DiyFp mMinus, out DiyFp mPlus) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
		{
			DiyFp result = Create(value);
			result.GetBoundaries(TNumber.DenormalMantissaBits, out mMinus, out mPlus);
			return result;
		}

		public static DiyFp Create<TNumber>(TNumber value) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
		{
			int exponent;
			return new DiyFp(ExtractFractionAndBiasedExponent(value, out exponent), exponent);
		}

		public DiyFp(ulong f, int e)
		{
			this.f = f;
			this.e = e;
		}

		public DiyFp Multiply(in DiyFp other)
		{
			int num = (int)(f >> 32);
			uint num2 = (uint)f;
			uint num3 = (uint)(other.f >> 32);
			uint num4 = (uint)other.f;
			ulong num5 = (ulong)(uint)num * (ulong)num3;
			ulong num6 = (ulong)num2 * (ulong)num3;
			ulong num7 = (ulong)(uint)num * (ulong)num4;
			ulong num8 = (ulong)(((long)num2 * (long)num4 >>> 32) + (uint)num7 + (uint)num6);
			num8 += 2147483648u;
			return new DiyFp(num5 + (num7 >> 32) + (num6 >> 32) + (num8 >> 32), e + other.e + 64);
		}

		public DiyFp Normalize()
		{
			int num = BitOperations.LeadingZeroCount(f);
			return new DiyFp(f << num, e - num);
		}

		public DiyFp Subtract(in DiyFp other)
		{
			return new DiyFp(f - other.f, e);
		}

		private void GetBoundaries(int implicitBitIndex, out DiyFp mMinus, out DiyFp mPlus)
		{
			mPlus = new DiyFp((f << 1) + 1, e - 1).Normalize();
			if (f == (ulong)(1L << implicitBitIndex))
			{
				mMinus = new DiyFp((f << 2) - 1, e - 2);
			}
			else
			{
				mMinus = new DiyFp((f << 1) - 1, e - 1);
			}
			mMinus = new DiyFp(mMinus.f << mMinus.e - mPlus.e, mPlus.e);
		}
	}

	internal static class Grisu3
	{
		private static ReadOnlySpan<short> CachedPowersBinaryExponent => new short[87]
		{
			-1220, -1193, -1166, -1140, -1113, -1087, -1060, -1034, -1007, -980,
			-954, -927, -901, -874, -847, -821, -794, -768, -741, -715,
			-688, -661, -635, -608, -582, -555, -529, -502, -475, -449,
			-422, -396, -369, -343, -316, -289, -263, -236, -210, -183,
			-157, -130, -103, -77, -50, -24, 3, 30, 56, 83,
			109, 136, 162, 189, 216, 242, 269, 295, 322, 348,
			375, 402, 428, 455, 481, 508, 534, 561, 588, 614,
			641, 667, 694, 720, 747, 774, 800, 827, 853, 880,
			907, 933, 960, 986, 1013, 1039, 1066
		};

		private static ReadOnlySpan<short> CachedPowersDecimalExponent => new short[87]
		{
			-348, -340, -332, -324, -316, -308, -300, -292, -284, -276,
			-268, -260, -252, -244, -236, -228, -220, -212, -204, -196,
			-188, -180, -172, -164, -156, -148, -140, -132, -124, -116,
			-108, -100, -92, -84, -76, -68, -60, -52, -44, -36,
			-28, -20, -12, -4, 4, 12, 20, 28, 36, 44,
			52, 60, 68, 76, 84, 92, 100, 108, 116, 124,
			132, 140, 148, 156, 164, 172, 180, 188, 196, 204,
			212, 220, 228, 236, 244, 252, 260, 268, 276, 284,
			292, 300, 308, 316, 324, 332, 340
		};

		private static ReadOnlySpan<ulong> CachedPowersSignificand => new ulong[87]
		{
			18054884314459144840uL, 13451937075301367670uL, 10022474136428063862uL, 14934650266808366570uL, 11127181549972568877uL, 16580792590934885855uL, 12353653155963782858uL, 18408377700990114895uL, 13715310171984221708uL, 10218702384817765436uL,
			15227053142812498563uL, 11345038669416679861uL, 16905424996341287883uL, 12595523146049147757uL, 9384396036005875287uL, 13983839803942852151uL, 10418772551374772303uL, 15525180923007089351uL, 11567161174868858868uL, 17236413322193710309uL,
			12842128665889583758uL, 9568131466127621947uL, 14257626930069360058uL, 10622759856335341974uL, 15829145694278690180uL, 11793632577567316726uL, 17573882009934360870uL, 13093562431584567480uL, 9755464219737475723uL, 14536774485912137811uL,
			10830740992659433045uL, 16139061738043178685uL, 12024538023802026127uL, 17917957937422433684uL, 13349918974505688015uL, 9946464728195732843uL, 14821387422376473014uL, 11042794154864902060uL, 16455045573212060422uL, 12259964326927110867uL,
			18268770466636286478uL, 13611294676837538539uL, 10141204801825835212uL, 15111572745182864684uL, 11258999068426240000uL, 16777216000000000000uL, 12500000000000000000uL, 9313225746154785156uL, 13877787807814456755uL, 10339757656912845936uL,
			15407439555097886824uL, 11479437019748901445uL, 17105694144590052135uL, 12744735289059618216uL, 9495567745759798747uL, 14149498560666738074uL, 10542197943230523224uL, 15709099088952724970uL, 11704190886730495818uL, 17440603504673385349uL,
			12994262207056124023uL, 9681479787123295682uL, 14426529090290212157uL, 10748601772107342003uL, 16016664761464807395uL, 11933345169920330789uL, 17782069995880619868uL, 13248674568444952270uL, 9871031767461413346uL, 14708983551653345445uL,
			10959046745042015199uL, 16330252207878254650uL, 12166986024289022870uL, 18130221999122236476uL, 13508068024458167312uL, 10064294952495520794uL, 14996968138956309548uL, 11173611982879273257uL, 16649979327439178909uL, 12405201291620119593uL,
			9242595204427927429uL, 13772540099066387757uL, 10261342003245940623uL, 15290591125556738113uL, 11392378155556871081uL, 16975966327722178521uL, 12648080533535911531uL
		};

		private static ReadOnlySpan<uint> SmallPowersOfTen => new uint[10] { 1u, 10u, 100u, 1000u, 10000u, 100000u, 1000000u, 10000000u, 100000000u, 1000000000u };

		public static bool TryRun<TNumber>(TNumber value, int requestedDigits, ref NumberBuffer number) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
		{
			TNumber value2 = (TNumber.IsNegative(value) ? (-value) : value);
			int length;
			int decimalExponent;
			DiyFp mMinus;
			DiyFp mPlus;
			bool flag = ((requestedDigits != -1) ? TryRunCounted(DiyFp.Create(value2).Normalize(), requestedDigits, number.Digits, out length, out decimalExponent) : TryRunShortest(in mMinus, DiyFp.CreateAndGetBoundaries(value2, out mMinus, out mPlus).Normalize(), in mPlus, number.Digits, out length, out decimalExponent));
			if (flag)
			{
				number.Scale = length + decimalExponent;
				number.Digits[length] = 0;
				number.DigitsCount = length;
			}
			return flag;
		}

		private static bool TryRunCounted(in DiyFp w, int requestedDigits, Span<byte> buffer, out int length, out int decimalExponent)
		{
			int minExponent = -60 - (w.e + 64);
			int maxExponent = -32 - (w.e + 64);
			int decimalExponent2;
			int kappa;
			bool result = TryDigitGenCounted(w.Multiply(GetCachedPowerForBinaryExponentRange(minExponent, maxExponent, out decimalExponent2)), requestedDigits, buffer, out length, out kappa);
			decimalExponent = -decimalExponent2 + kappa;
			return result;
		}

		private static bool TryRunShortest(in DiyFp boundaryMinus, in DiyFp w, in DiyFp boundaryPlus, Span<byte> buffer, out int length, out int decimalExponent)
		{
			int minExponent = -60 - (w.e + 64);
			int maxExponent = -32 - (w.e + 64);
			int decimalExponent2;
			DiyFp other = GetCachedPowerForBinaryExponentRange(minExponent, maxExponent, out decimalExponent2);
			DiyFp w2 = w.Multiply(in other);
			int kappa;
			bool result = TryDigitGenShortest(boundaryMinus.Multiply(in other), in w2, boundaryPlus.Multiply(in other), buffer, out length, out kappa);
			decimalExponent = -decimalExponent2 + kappa;
			return result;
		}

		private static uint BiggestPowerTen(uint number, int numberBits, out int exponentPlusOne)
		{
			int num = (numberBits + 1) * 1233 >> 12;
			uint num2 = SmallPowersOfTen[num];
			if (number < num2)
			{
				num--;
				num2 = SmallPowersOfTen[num];
			}
			exponentPlusOne = num + 1;
			return num2;
		}

		private static bool TryDigitGenCounted(in DiyFp w, int requestedDigits, Span<byte> buffer, out int length, out int kappa)
		{
			ulong num = 1uL;
			DiyFp diyFp = new DiyFp((ulong)(1L << -w.e), w.e);
			uint num2 = (uint)(w.f >> -diyFp.e);
			ulong num3 = w.f & (diyFp.f - 1);
			if (num3 == 0L && (requestedDigits >= 11 || num2 < SmallPowersOfTen[requestedDigits - 1]))
			{
				length = 0;
				kappa = 0;
				return false;
			}
			uint num4 = BiggestPowerTen(num2, 64 - -diyFp.e, out kappa);
			length = 0;
			while (kappa > 0)
			{
				uint num5;
				(num5, num2) = Math.DivRem(num2, num4);
				buffer[length] = (byte)(48 + num5);
				length++;
				requestedDigits--;
				kappa--;
				if (requestedDigits == 0)
				{
					break;
				}
				num4 /= 10;
			}
			if (requestedDigits == 0)
			{
				ulong rest = ((ulong)num2 << -diyFp.e) + num3;
				return TryRoundWeedCounted(buffer, length, rest, (ulong)num4 << -diyFp.e, num, ref kappa);
			}
			while (requestedDigits > 0 && num3 > num)
			{
				num3 *= 10;
				num *= 10;
				uint num6 = (uint)(num3 >> -diyFp.e);
				buffer[length] = (byte)(48 + num6);
				length++;
				requestedDigits--;
				kappa--;
				num3 &= diyFp.f - 1;
			}
			if (requestedDigits != 0)
			{
				buffer[0] = 0;
				length = 0;
				kappa = 0;
				return false;
			}
			return TryRoundWeedCounted(buffer, length, num3, diyFp.f, num, ref kappa);
		}

		private static bool TryDigitGenShortest(in DiyFp low, in DiyFp w, in DiyFp high, Span<byte> buffer, out int length, out int kappa)
		{
			ulong num = 1uL;
			DiyFp other = new DiyFp(low.f - num, low.e);
			DiyFp diyFp = new DiyFp(high.f + num, high.e);
			DiyFp diyFp2 = diyFp.Subtract(in other);
			DiyFp diyFp3 = new DiyFp((ulong)(1L << -w.e), w.e);
			uint num2 = (uint)(diyFp.f >> -diyFp3.e);
			ulong num3 = diyFp.f & (diyFp3.f - 1);
			uint num4 = BiggestPowerTen(num2, 64 - -diyFp3.e, out kappa);
			length = 0;
			while (kappa > 0)
			{
				uint num5;
				(num5, num2) = Math.DivRem(num2, num4);
				buffer[length] = (byte)(48 + num5);
				length++;
				kappa--;
				ulong num6 = ((ulong)num2 << -diyFp3.e) + num3;
				if (num6 < diyFp2.f)
				{
					return TryRoundWeedShortest(buffer, length, diyFp.Subtract(in w).f, diyFp2.f, num6, (ulong)num4 << -diyFp3.e, num);
				}
				num4 /= 10;
			}
			do
			{
				num3 *= 10;
				num *= 10;
				diyFp2 = new DiyFp(diyFp2.f * 10, diyFp2.e);
				uint num7 = (uint)(num3 >> -diyFp3.e);
				buffer[length] = (byte)(48 + num7);
				length++;
				kappa--;
				num3 &= diyFp3.f - 1;
			}
			while (num3 >= diyFp2.f);
			return TryRoundWeedShortest(buffer, length, diyFp.Subtract(in w).f * num, diyFp2.f, num3, diyFp3.f, num);
		}

		private static DiyFp GetCachedPowerForBinaryExponentRange(int minExponent, int maxExponent, out int decimalExponent)
		{
			double num = Math.Ceiling((double)(minExponent + 64 - 1) * 0.3010299956639812);
			int index = (348 + (int)num - 1) / 8 + 1;
			decimalExponent = CachedPowersDecimalExponent[index];
			return new DiyFp(CachedPowersSignificand[index], CachedPowersBinaryExponent[index]);
		}

		private static bool TryRoundWeedCounted(Span<byte> buffer, int length, ulong rest, ulong tenKappa, ulong unit, ref int kappa)
		{
			if (unit >= tenKappa || tenKappa - unit <= unit)
			{
				return false;
			}
			if (tenKappa - rest > rest && tenKappa - 2 * rest >= 2 * unit)
			{
				return true;
			}
			if (rest > unit && (tenKappa <= rest - unit || tenKappa - (rest - unit) <= rest - unit))
			{
				buffer[length - 1]++;
				int num = length - 1;
				while (num > 0 && buffer[num] == 58)
				{
					buffer[num] = 48;
					buffer[num - 1]++;
					num--;
				}
				if (buffer[0] == 58)
				{
					buffer[0] = 49;
					kappa++;
				}
				return true;
			}
			return false;
		}

		private static bool TryRoundWeedShortest(Span<byte> buffer, int length, ulong distanceTooHighW, ulong unsafeInterval, ulong rest, ulong tenKappa, ulong unit)
		{
			ulong num = distanceTooHighW - unit;
			ulong num2 = distanceTooHighW + unit;
			while (rest < num && unsafeInterval - rest >= tenKappa && (rest + tenKappa < num || num - rest >= rest + tenKappa - num))
			{
				buffer[length - 1]--;
				rest += tenKappa;
			}
			if (rest < num2 && unsafeInterval - rest >= tenKappa && (rest + tenKappa < num2 || num2 - rest > rest + tenKappa - num2))
			{
				return false;
			}
			if (2 * unit <= rest)
			{
				return rest <= unsafeInterval - 4 * unit;
			}
			return false;
		}
	}

	private interface IHexOrBinaryParser<TInteger> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		static abstract NumberStyles AllowedStyles { get; }

		static abstract uint MaxDigitValue { get; }

		static abstract int MaxDigitCount { get; }

		static abstract bool IsValidChar(uint ch);

		static abstract uint FromChar(uint ch);

		static abstract TInteger ShiftLeftForNextDigit(TInteger value);
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct HexParser<TInteger> : IHexOrBinaryParser<TInteger> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		public static NumberStyles AllowedStyles => NumberStyles.HexNumber;

		public static uint MaxDigitValue => 15u;

		public static int MaxDigitCount => TInteger.MaxHexDigitCount;

		public static bool IsValidChar(uint ch)
		{
			return HexConverter.IsHexChar((int)ch);
		}

		public static uint FromChar(uint ch)
		{
			return (uint)HexConverter.FromChar((int)ch);
		}

		public static TInteger ShiftLeftForNextDigit(TInteger value)
		{
			return TInteger.MultiplyBy16(value);
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct BinaryParser<TInteger> : IHexOrBinaryParser<TInteger> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		public static NumberStyles AllowedStyles => NumberStyles.BinaryNumber;

		public static uint MaxDigitValue => 1u;

		public unsafe static int MaxDigitCount => sizeof(TInteger) * 8;

		public static bool IsValidChar(uint ch)
		{
			return ch - 48 <= 1;
		}

		public static uint FromChar(uint ch)
		{
			return ch - 48;
		}

		public static TInteger ShiftLeftForNextDigit(TInteger value)
		{
			return value << 1;
		}
	}

	internal ref struct NumberBuffer
	{
		public int DigitsCount;

		public int Scale;

		public bool IsNegative;

		public bool HasNonZeroTail;

		public NumberBufferKind Kind;

		public Span<byte> Digits;

		public unsafe readonly byte* DigitsPtr => (byte*)Unsafe.AsPointer(in MemoryMarshal.GetReference(Digits));

		public unsafe NumberBuffer(NumberBufferKind kind, byte* digits, int digitsLength)
			: this(kind, new Span<byte>(digits, digitsLength))
		{
		}

		public NumberBuffer(NumberBufferKind kind, Span<byte> digits)
		{
			DigitsCount = 0;
			Scale = 0;
			IsNegative = false;
			HasNonZeroTail = false;
			Kind = kind;
			Digits = digits;
			Digits[0] = 0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('[');
			stringBuilder.Append('"');
			for (int i = 0; i < Digits.Length; i++)
			{
				byte b = Digits[i];
				if (b == 0)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
			stringBuilder.Append('"');
			stringBuilder.Append(", Length = ").Append(DigitsCount);
			stringBuilder.Append(", Scale = ").Append(Scale);
			stringBuilder.Append(", IsNegative = ").Append(IsNegative);
			stringBuilder.Append(", HasNonZeroTail = ").Append(HasNonZeroTail);
			stringBuilder.Append(", Kind = ").Append(Kind);
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}

	internal enum NumberBufferKind : byte
	{
		Unknown,
		Integer,
		Decimal,
		FloatingPoint
	}

	internal enum ParsingStatus
	{
		OK,
		Failed,
		Overflow
	}

	private static readonly string[] s_smallNumberCache = new string[10];

	private static readonly byte[] TwoDigitsCharsAsBytes = MemoryMarshal.AsBytes("00010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899".AsSpan()).ToArray();

	private static readonly byte[] TwoDigitsBytes = "00010203040506070809101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899"u8.ToArray();

	private static readonly string[] s_posCurrencyFormats = new string[4] { "$#", "#$", "$ #", "# $" };

	private static readonly string[] s_negCurrencyFormats = new string[17]
	{
		"($#)", "-$#", "$-#", "$#-", "(#$)", "-#$", "#-$", "#$-", "-# $", "-$ #",
		"# $-", "$ #-", "$ -#", "#- $", "($ #)", "(# $)", "$- #"
	};

	private static readonly string[] s_posPercentFormats = new string[4] { "# %", "#%", "%#", "% #" };

	private static readonly string[] s_negPercentFormats = new string[12]
	{
		"-# %", "-#%", "-%#", "%-#", "%#-", "#-%", "#%-", "-% #", "# %-", "% #-",
		"% -#", "#- %"
	};

	private static readonly string[] s_negNumberFormats = new string[5] { "(#)", "-#", "- #", "#-", "# -" };

	private static ReadOnlySpan<double> Pow10DoubleTable => new double[23]
	{
		1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0,
		10000000000.0, 100000000000.0, 1000000000000.0, 10000000000000.0, 100000000000000.0, 1000000000000000.0, 10000000000000000.0, 1E+17, 1E+18, 1E+19,
		1E+20, 1E+21, 1E+22
	};

	private static ReadOnlySpan<ulong> Pow5128Table => new ulong[1302]
	{
		17218479456385750618uL, 1242899115359157055uL, 10761549660241094136uL, 5388497965526861063uL, 13451937075301367670uL, 6735622456908576329uL, 16814921344126709587uL, 17642900107990496220uL, 10509325840079193492uL, 8720969558280366185uL,
		13136657300098991865uL, 10901211947850457732uL, 16420821625123739831uL, 18238200953240460069uL, 10263013515702337394uL, 18316404623416369399uL, 12828766894627921743uL, 13672133742415685941uL, 16035958618284902179uL, 12478481159592219522uL,
		10022474136428063862uL, 5493207715531443249uL, 12528092670535079827uL, 16089881681269079869uL, 15660115838168849784uL, 15500666083158961933uL, 9787572398855531115uL, 9687916301974351208uL, 12234465498569413894uL, 7498209359040551106uL,
		15293081873211767368uL, 149389661945913074uL, 9558176170757354605uL, 93368538716195671uL, 11947720213446693256uL, 4728396691822632493uL, 14934650266808366570uL, 5910495864778290617uL, 9334156416755229106uL, 8305745933913819539uL,
		11667695520944036383uL, 1158810380537498616uL, 14584619401180045478uL, 15283571030954036982uL, 18230774251475056848uL, 9881091751837770420uL, 11394233907171910530uL, 6175682344898606512uL, 14242792383964888162uL, 16942974967978033949uL,
		17803490479956110203uL, 11955346673117766628uL, 11127181549972568877uL, 5166248661484910190uL, 13908976937465711096uL, 11069496845283525642uL, 17386221171832138870uL, 13836871056604407053uL, 10866388232395086794uL, 4036358391950366504uL,
		13582985290493858492uL, 14268820026792733938uL, 16978731613117323115uL, 17836025033490917422uL, 10611707258198326947uL, 8841672636718129437uL, 13264634072747908684uL, 6440404777470273892uL, 16580792590934885855uL, 8050505971837842365uL,
		10362995369334303659uL, 11949095260039733334uL, 12953744211667879574uL, 10324683056622278764uL, 16192180264584849468uL, 3682481783923072647uL, 10120112665365530917uL, 11524923151806696212uL, 12650140831706913647uL, 571095884476206553uL,
		15812676039633642058uL, 14548927910877421904uL, 9882922524771026286uL, 13704765962725776594uL, 12353653155963782858uL, 7907585416552444934uL, 15442066444954728573uL, 661109733835780360uL, 9651291528096705358uL, 2719036592861056677uL,
		12064114410120881697uL, 12622167777931096654uL, 15080143012651102122uL, 1942651667131707105uL, 9425089382906938826uL, 5825843310384704845uL, 11781361728633673532uL, 16505676174835656864uL, 14726702160792091916uL, 2185351144835019464uL,
		18408377700990114895uL, 2731688931043774330uL, 11505236063118821809uL, 8624834609543440812uL, 14381545078898527261uL, 15392729280356688919uL, 17976931348623159077uL, 5405853545163697437uL, 11235582092889474423uL, 5684501474941004850uL,
		14044477616111843029uL, 2493940825248868159uL, 17555597020139803786uL, 7729112049988473103uL, 10972248137587377366uL, 9442381049670183593uL, 13715310171984221708uL, 2579604275232953683uL, 17144137714980277135uL, 3224505344041192104uL,
		10715086071862673209uL, 8932844867666826921uL, 13393857589828341511uL, 15777742103010921555uL, 16742321987285426889uL, 15110491610336264040uL, 10463951242053391806uL, 2526528228819083169uL, 13079939052566739757uL, 12381532322878629770uL,
		16349923815708424697uL, 1641857348316123500uL, 10218702384817765435uL, 12555375888766046947uL, 12773377981022206794uL, 11082533842530170780uL, 15966722476277758493uL, 4629795266307937667uL, 9979201547673599058uL, 5199465050656154994uL,
		12474001934591998822uL, 15722703350174969551uL, 15592502418239998528uL, 10430007150863936130uL, 9745314011399999080uL, 6518754469289960081uL, 12181642514249998850uL, 8148443086612450102uL, 15227053142812498563uL, 962181821410786819uL,
		9516908214257811601uL, 16742264702877599426uL, 11896135267822264502uL, 7092772823314835570uL, 14870169084777830627uL, 18089338065998320271uL, 9293855677986144142uL, 8999993282035256217uL, 11617319597482680178uL, 2026619565689294464uL,
		14521649496853350222uL, 11756646493966393888uL, 18152061871066687778uL, 5472436080603216552uL, 11345038669416679861uL, 8031958568804398249uL, 14181298336770849826uL, 14651634229432885715uL, 17726622920963562283uL, 9091170749936331336uL,
		11079139325602226427uL, 3376138709496513133uL, 13848924157002783033uL, 18055231442152805128uL, 17311155196253478792uL, 8733981247408842698uL, 10819471997658424245uL, 5458738279630526686uL, 13524339997073030306uL, 11435108867965546262uL,
		16905424996341287883uL, 5070514048102157020uL, 10565890622713304927uL, 863228270850154185uL, 13207363278391631158uL, 14914093393844856443uL, 16509204097989538948uL, 9419244705451294746uL, 10318252561243461842uL, 15110399977761835024uL,
		12897815701554327303uL, 9664627935347517973uL, 16122269626942909129uL, 7469098900757009562uL, 10076418516839318205uL, 16197401859041600736uL, 12595523146049147757uL, 6411694268519837208uL, 15744403932561434696uL, 12626303854077184414uL,
		9840252457850896685uL, 7891439908798240259uL, 12300315572313620856uL, 14475985904425188227uL, 15375394465392026070uL, 18094982380531485284uL, 9609621540870016294uL, 6697677969404790399uL, 12012026926087520367uL, 17595469498610763806uL,
		15015033657609400459uL, 17382650854836066854uL, 9384396036005875287uL, 8558313775058847832uL, 11730495045007344109uL, 6086206200396171886uL, 14663118806259180136uL, 12219443768922602761uL, 18328898507823975170uL, 15274304711153253452uL,
		11455561567389984481uL, 14158126462898171311uL, 14319451959237480602uL, 3862600023340550427uL, 17899314949046850752uL, 14051622066030463842uL, 11187071843154281720uL, 8782263791269039901uL, 13983839803942852150uL, 10977829739086299876uL,
		17479799754928565188uL, 4498915137003099037uL, 10924874846830353242uL, 12035193997481712706uL, 13656093558537941553uL, 5820620459997365075uL, 17070116948172426941uL, 11887461593424094248uL, 10668823092607766838uL, 9735506505103752857uL,
		13336028865759708548uL, 2946011094524915263uL, 16670036082199635685uL, 3682513868156144079uL, 10418772551374772303uL, 4607414176811284001uL, 13023465689218465379uL, 1147581702586717097uL, 16279332111523081723uL, 15269535183515560084uL,
		10174582569701926077uL, 7237616480483531100uL, 12718228212127407596uL, 13658706619031801779uL, 15897785265159259495uL, 17073383273789752224uL, 9936115790724537184uL, 17588393573759676996uL, 12420144738405671481uL, 3538747893490044629uL,
		15525180923007089351uL, 9035120885289943691uL, 9703238076879430844uL, 12564479580947296663uL, 12129047596099288555uL, 15705599476184120828uL, 15161309495124110694uL, 15020313326802763131uL, 9475818434452569184uL, 4776009810824339053uL,
		11844773043065711480uL, 5970012263530423816uL, 14805966303832139350uL, 7462515329413029771uL, 9253728939895087094uL, 52386062455755702uL, 11567161174868858867uL, 9288854614924470436uL, 14458951468586073584uL, 6999382250228200141uL,
		18073689335732591980uL, 8749227812785250177uL, 11296055834832869987uL, 14691639419845557168uL, 14120069793541087484uL, 13752863256379558556uL, 17650087241926359355uL, 17191079070474448196uL, 11031304526203974597uL, 8438581409832836170uL,
		13789130657754968246uL, 15159912780718433117uL, 17236413322193710308uL, 9726518939043265588uL, 10772758326371068942uL, 15302446373756816800uL, 13465947907963836178uL, 9904685930341245193uL, 16832434884954795223uL, 3157485376071780683uL,
		10520271803096747014uL, 8890957387685944783uL, 13150339753870933768uL, 1890324697752655170uL, 16437924692338667210uL, 2362905872190818963uL, 10273702932711667006uL, 6088502188546649756uL, 12842128665889583757uL, 16833999772538088003uL,
		16052660832361979697uL, 7207441660390446292uL, 10032913020226237310uL, 16033866083812498692uL, 12541141275282796638uL, 10818960567910847557uL, 15676426594103495798uL, 4300328673033783639uL, 9797766621314684873uL, 16522763475928278486uL,
		12247208276643356092uL, 6818396289628184396uL, 15309010345804195115uL, 8522995362035230495uL, 9568131466127621947uL, 3021029092058325107uL, 11960164332659527433uL, 17611344420355070096uL, 14950205415824409292uL, 8179122470161673908uL,
		9343878384890255807uL, 14335323580705822000uL, 11679847981112819759uL, 13307468457454889596uL, 14599809976391024699uL, 12022649553391224092uL, 18249762470488780874uL, 10416625923311642211uL, 11406101544055488046uL, 11122077220497164286uL,
		14257626930069360058uL, 4679224488766679549uL, 17822033662586700072uL, 15072402647813125244uL, 11138771039116687545uL, 9420251654883203278uL, 13923463798895859431uL, 16387000587031392001uL, 17404329748619824289uL, 15872064715361852097uL,
		10877706092887390181uL, 3002511419460075705uL, 13597132616109237726uL, 8364825292752482535uL, 16996415770136547158uL, 1232659579085827361uL, 10622759856335341973uL, 14605470292210805812uL, 13278449820419177467uL, 4421779809981343554uL,
		16598062275523971834uL, 915538744049291538uL, 10373788922202482396uL, 5183897733458195115uL, 12967236152753102995uL, 6479872166822743894uL, 16209045190941378744uL, 3488154190101041964uL, 10130653244338361715uL, 2180096368813151227uL,
		12663316555422952143uL, 16560178516298602746uL, 15829145694278690179uL, 16088537126945865529uL, 9893216058924181362uL, 7749492695127472003uL, 12366520073655226703uL, 463493832054564196uL, 15458150092069033378uL, 14414425345350368957uL,
		9661343807543145861uL, 13620701859271368502uL, 12076679759428932327uL, 3190819268807046916uL, 15095849699286165408uL, 17823582141290972357uL, 9434906062053853380uL, 11139738838306857723uL, 11793632577567316725uL, 13924673547883572154uL,
		14742040721959145907uL, 3570783879572301480uL, 18427550902448932383uL, 18298537904747540562uL, 11517219314030582739uL, 18354115218108294707uL, 14396524142538228424uL, 18330958004207980480uL, 17995655178172785531uL, 4466953431550423984uL,
		11247284486357990957uL, 486002885505321038uL, 14059105607947488696uL, 5219189625309039202uL, 17573882009934360870uL, 6523987031636299002uL, 10983676256208975543uL, 17912549950054850588uL, 13729595320261219429uL, 17779001419141175331uL,
		17161994150326524287uL, 8388693718644305452uL, 10726246343954077679uL, 12160462601793772764uL, 13407807929942597099uL, 10588892233814828051uL, 16759759912428246374uL, 8624429273841147159uL, 10474849945267653984uL, 778582277723329070uL,
		13093562431584567480uL, 973227847154161338uL, 16366953039480709350uL, 1216534808942701673uL, 10229345649675443343uL, 14595392310871352257uL, 12786682062094304179uL, 13632554370161802418uL, 15983352577617880224uL, 12429006944274865118uL,
		9989595361011175140uL, 7768129340171790699uL, 12486994201263968925uL, 9710161675214738374uL, 15608742751579961156uL, 16749388112445810871uL, 9755464219737475723uL, 1244995533423855986uL, 12194330274671844653uL, 15391302472061983695uL,
		15242912843339805817uL, 5404070034795315907uL, 9526820527087378635uL, 14906758817815542202uL, 11908525658859223294uL, 14021762503842039848uL, 14885657073574029118uL, 8303831092947774002uL, 9303535670983768199uL, 578208414664970847uL,
		11629419588729710248uL, 14557818573613377271uL, 14536774485912137810uL, 18197273217016721589uL, 18170968107390172263uL, 13523219484416126178uL, 11356855067118857664uL, 15369541205401160717uL, 14196068833898572081uL, 765182433041899281uL,
		17745086042373215101uL, 5568164059729762005uL, 11090678776483259438uL, 5785945546544795205uL, 13863348470604074297uL, 16455803970035769814uL, 17329185588255092872uL, 6734696907262548556uL, 10830740992659433045uL, 4209185567039092847uL,
		13538426240824291306uL, 9873167977226253963uL, 16923032801030364133uL, 3118087934678041646uL, 10576895500643977583uL, 4254647968387469981uL, 13221119375804971979uL, 706623942056949572uL, 16526399219756214973uL, 14718337982853350677uL,
		10328999512347634358uL, 11504804248497038125uL, 12911249390434542948uL, 5157633273766521849uL, 16139061738043178685uL, 6447041592208152311uL, 10086913586276986678uL, 6335244004343789146uL, 12608641982846233347uL, 17142427042284512241uL,
		15760802478557791684uL, 16816347784428252397uL, 9850501549098619803uL, 1286845328412881940uL, 12313126936373274753uL, 15443614715798266137uL, 15391408670466593442uL, 5469460339465668959uL, 9619630419041620901uL, 8030098730593431003uL,
		12024538023802026126uL, 14649309431669176658uL, 15030672529752532658uL, 9088264752731695015uL, 9394170331095332911uL, 10291851488884697288uL, 11742712913869166139uL, 8253128342678483706uL, 14678391142336457674uL, 5704724409920716729uL,
		18347988927920572092uL, 16354277549255671720uL, 11467493079950357558uL, 998051431430019017uL, 14334366349937946947uL, 10470936326142299579uL, 17917957937422433684uL, 8476984389250486570uL, 11198723710889021052uL, 14521487280136329914uL,
		13998404638611276315uL, 18151859100170412392uL, 17498005798264095394uL, 18078137856785627587uL, 10936253623915059621uL, 15910522178918405146uL, 13670317029893824527uL, 6053094668365842720uL, 17087896287367280659uL, 2954682317029915496uL,
		10679935179604550411uL, 17987577512639554849uL, 13349918974505688014uL, 17872785872372055657uL, 16687398718132110018uL, 13117610303610293764uL, 10429624198832568761uL, 12810192458183821506uL, 13037030248540710952uL, 2177682517447613171uL,
		16296287810675888690uL, 2722103146809516464uL, 10185179881672430431uL, 6313000485183335694uL, 12731474852090538039uL, 3279564588051781713uL, 15914343565113172548uL, 17934513790346890853uL, 9946464728195732843uL, 1985699082112030975uL,
		12433080910244666053uL, 16317181907922202431uL, 15541351137805832567uL, 6561419329620589327uL, 9713344461128645354uL, 11018416108653950185uL, 12141680576410806693uL, 4549648098962661924uL, 15177100720513508366uL, 10298746142130715309uL,
		9485687950320942729uL, 1825030320404309164uL, 11857109937901178411uL, 6892973918932774359uL, 14821387422376473014uL, 4004531380238580045uL, 9263367138985295633uL, 16337890167931276240uL, 11579208923731619542uL, 6587304654631931588uL,
		14474011154664524427uL, 17457502855144690293uL, 18092513943330655534uL, 17210192550503474962uL, 11307821214581659709uL, 6144684325637283947uL, 14134776518227074636uL, 12292541425473992838uL, 17668470647783843295uL, 15365676781842491048uL,
		11042794154864902059uL, 16521077016292638761uL, 13803492693581127574uL, 16039660251938410547uL, 17254365866976409468uL, 10826203278068237376uL, 10783978666860255917uL, 15989749085647424168uL, 13479973333575319897uL, 6152128301777116498uL,
		16849966666969149871uL, 12301846395648783526uL, 10531229166855718669uL, 14606183024921571560uL, 13164036458569648337uL, 4422670725869800738uL, 16455045573212060421uL, 10140024425764638826uL, 10284403483257537763uL, 8643358275316593218uL,
		12855504354071922204uL, 6192511825718353619uL, 16069380442589902755uL, 7740639782147942024uL, 10043362776618689222uL, 2532056854628769813uL, 12554203470773361527uL, 12388443105140738074uL, 15692754338466701909uL, 10873867862998534689uL,
		9807971461541688693uL, 9102010423587778132uL, 12259964326927110866uL, 15989199047912110569uL, 15324955408658888583uL, 10763126773035362404uL, 9578097130411805364uL, 13644483260788183358uL, 11972621413014756705uL, 17055604075985229198uL,
		14965776766268445882uL, 7484447039699372786uL, 9353610478917778676uL, 9289465418239495895uL, 11692013098647223345uL, 11611831772799369869uL, 14615016373309029182uL, 679731660717048624uL, 18268770466636286477uL, 10073036612751086588uL,
		11417981541647679048uL, 8601490892183123070uL, 14272476927059598810uL, 10751863615228903838uL, 17840596158824498513uL, 4216457482181353989uL, 11150372599265311570uL, 14164500972431816003uL, 13937965749081639463uL, 8482254178684994196uL,
		17422457186352049329uL, 5991131704928854841uL, 10889035741470030830uL, 15273672361649004036uL, 13611294676837538538uL, 9868718415206479237uL, 17014118346046923173uL, 3112525982153323238uL, 10633823966279326983uL, 4251171748059520976uL,
		13292279957849158729uL, 702278666647013315uL, 16615349947311448411uL, 5489534351736154548uL, 10384593717069655257uL, 1125115960621402641uL, 12980742146337069071uL, 6018080969204141205uL, 16225927682921336339uL, 2910915193077788602uL,
		10141204801825835211uL, 17960223060169475540uL, 12676506002282294014uL, 17838592806784456521uL, 15845632502852867518uL, 13074868971625794844uL, 9903520314283042199uL, 3560107088838733873uL, 12379400392853802748uL, 18285191916330581054uL,
		15474250491067253436uL, 4409745821703674701uL, 9671406556917033397uL, 11979463175419572496uL, 12089258196146291747uL, 1139270913992301908uL, 15111572745182864683uL, 15259146697772541097uL, 9444732965739290427uL, 7231123676894144234uL,
		11805916207174113034uL, 4427218577690292388uL, 14757395258967641292uL, 14757395258967641293uL, 9223372036854775808uL, 0uL, 11529215046068469760uL, 0uL, 14411518807585587200uL, 0uL,
		18014398509481984000uL, 0uL, 11258999068426240000uL, 0uL, 14073748835532800000uL, 0uL, 17592186044416000000uL, 0uL, 10995116277760000000uL, 0uL,
		13743895347200000000uL, 0uL, 17179869184000000000uL, 0uL, 10737418240000000000uL, 0uL, 13421772800000000000uL, 0uL, 16777216000000000000uL, 0uL,
		10485760000000000000uL, 0uL, 13107200000000000000uL, 0uL, 16384000000000000000uL, 0uL, 10240000000000000000uL, 0uL, 12800000000000000000uL, 0uL,
		16000000000000000000uL, 0uL, 10000000000000000000uL, 0uL, 12500000000000000000uL, 0uL, 15625000000000000000uL, 0uL, 9765625000000000000uL, 0uL,
		12207031250000000000uL, 0uL, 15258789062500000000uL, 0uL, 9536743164062500000uL, 0uL, 11920928955078125000uL, 0uL, 14901161193847656250uL, 0uL,
		9313225746154785156uL, 4611686018427387904uL, 11641532182693481445uL, 5764607523034234880uL, 14551915228366851806uL, 11817445422220181504uL, 18189894035458564758uL, 5548434740920451072uL, 11368683772161602973uL, 17302829768357445632uL,
		14210854715202003717uL, 7793479155164643328uL, 17763568394002504646uL, 14353534962383192064uL, 11102230246251565404uL, 4359273333062107136uL, 13877787807814456755uL, 5449091666327633920uL, 17347234759768070944uL, 2199678564482154496uL,
		10842021724855044340uL, 1374799102801346560uL, 13552527156068805425uL, 1718498878501683200uL, 16940658945086006781uL, 6759809616554491904uL, 10587911840678754238uL, 6530724019560251392uL, 13234889800848442797uL, 17386777061305090048uL,
		16543612251060553497uL, 7898413271349198848uL, 10339757656912845935uL, 16465723340661719040uL, 12924697071141057419uL, 15970468157399760896uL, 16155871338926321774uL, 15351399178322313216uL, 10097419586828951109uL, 4982938468024057856uL,
		12621774483536188886uL, 10840359103457460224uL, 15777218104420236108uL, 4327076842467049472uL, 9860761315262647567uL, 11927795063396681728uL, 12325951644078309459uL, 10298057810818464256uL, 15407439555097886824uL, 8260886245095692416uL,
		9629649721936179265uL, 5163053903184807760uL, 12037062152420224081uL, 11065503397408397604uL, 15046327690525280101uL, 18443565265187884909uL, 9403954806578300063uL, 13833071299956122020uL, 11754943508222875079uL, 12679653106517764621uL,
		14693679385278593849uL, 11237880364719817872uL, 18367099231598242312uL, 212292400617608628uL, 11479437019748901445uL, 132682750386005392uL, 14349296274686126806uL, 4777539456409894645uL, 17936620343357658507uL, 15195296357367144114uL,
		11210387714598536567uL, 7191217214140771119uL, 14012984643248170709uL, 4377335499248575995uL, 17516230804060213386uL, 10083355392488107898uL, 10947644252537633366uL, 10913783138732455340uL, 13684555315672041708uL, 4418856886560793367uL,
		17105694144590052135uL, 5523571108200991709uL, 10691058840368782584uL, 10369760970266701674uL, 13363823550460978230uL, 12962201212833377092uL, 16704779438076222788uL, 6979379479186945558uL, 10440487148797639242uL, 13585484211346616781uL,
		13050608935997049053uL, 7758483227328495169uL, 16313261169996311316uL, 14309790052588006865uL, 10195788231247694572uL, 18166990819722280098uL, 12744735289059618216uL, 4261994450943298507uL, 15930919111324522770uL, 5327493063679123134uL,
		9956824444577826731uL, 7941369183226839863uL, 12446030555722283414uL, 5315025460606161924uL, 15557538194652854267uL, 15867153862612478214uL, 9723461371658033917uL, 7611128154919104931uL, 12154326714572542396uL, 14125596212076269068uL,
		15192908393215677995uL, 17656995265095336336uL, 9495567745759798747uL, 8729779031470891258uL, 11869459682199748434uL, 6300537770911226168uL, 14836824602749685542uL, 17099044250493808518uL, 9273015376718553464uL, 6075216638131242420uL,
		11591269220898191830uL, 7594020797664053025uL, 14489086526122739788uL, 269153960225290473uL, 18111358157653424735uL, 336442450281613091uL, 11319598848533390459uL, 7127805559067090038uL, 14149498560666738074uL, 4298070930406474644uL,
		17686873200833422592uL, 14595960699862869113uL, 11054295750520889120uL, 9122475437414293195uL, 13817869688151111400uL, 11403094296767866494uL, 17272337110188889250uL, 14253867870959833118uL, 10795210693868055781uL, 13520353437777283602uL,
		13494013367335069727uL, 3065383741939440791uL, 16867516709168837158uL, 17666787732706464701uL, 10542197943230523224uL, 6430056314514152534uL, 13177747429038154030uL, 8037570393142690668uL, 16472184286297692538uL, 823590954573587527uL,
		10295115178936057836uL, 5126430365035880108uL, 12868893973670072295uL, 6408037956294850135uL, 16086117467087590369uL, 3398361426941174765uL, 10053823416929743980uL, 13653190937906703988uL, 12567279271162179975uL, 17066488672383379985uL,
		15709099088952724969uL, 16721424822051837077uL, 9818186930595453106uL, 3533361486141316317uL, 12272733663244316382uL, 13640073894531421205uL, 15340917079055395478uL, 7826720331309500698uL, 9588073174409622174uL, 280014188641050032uL,
		11985091468012027717uL, 9573389772656088348uL, 14981364335015034646uL, 16578423234247498339uL, 9363352709384396654uL, 5749828502977298558uL, 11704190886730495817uL, 16410657665576399005uL, 14630238608413119772uL, 6678264026688335045uL,
		18287798260516399715uL, 8347830033360418806uL, 11429873912822749822uL, 2911550761636567802uL, 14287342391028437277uL, 12862810488900485560uL, 17859177988785546597uL, 2243455055843443238uL, 11161986242990966623uL, 3708002419115845976uL,
		13952482803738708279uL, 23317005467419566uL, 17440603504673385348uL, 13864204312116438170uL, 10900377190420865842uL, 17888499731927549664uL, 13625471488026082303uL, 13137252628054661272uL, 17031839360032602879uL, 11809879766640938686uL,
		10644899600020376799uL, 14298703881791668535uL, 13306124500025470999uL, 13261693833812197764uL, 16632655625031838749uL, 11965431273837859301uL, 10395409765644899218uL, 9784237555362356015uL, 12994262207056124023uL, 3006924907348169211uL,
		16242827758820155028uL, 17593714189467375226uL, 10151767349262596893uL, 1772699331562333708uL, 12689709186578246116uL, 6827560182880305039uL, 15862136483222807645uL, 8534450228600381299uL, 9913835302014254778uL, 7639874402088932264uL,
		12392294127517818473uL, 326470965756389522uL, 15490367659397273091uL, 5019774725622874806uL, 9681479787123295682uL, 831516194300602802uL, 12101849733904119602uL, 10262767279730529310uL, 15127312167380149503uL, 3605087062808385830uL,
		9454570104612593439uL, 9170708441896323000uL, 11818212630765741799uL, 6851699533943015846uL, 14772765788457177249uL, 3952938399001381903uL, 9232978617785735780uL, 13999801545444333449uL, 11541223272232169725uL, 17499751931805416812uL,
		14426529090290212157uL, 8039631859474607303uL, 18033161362862765196uL, 14661225842770647033uL, 11270725851789228247uL, 18386638188586430203uL, 14088407314736535309uL, 18371611717305649850uL, 17610509143420669137uL, 9129456591349898601uL,
		11006568214637918210uL, 17235125415662156385uL, 13758210268297397763uL, 12320534732722919674uL, 17197762835371747204uL, 10788982397476261688uL, 10748601772107342002uL, 15966486035277439363uL, 13435752215134177503uL, 10734735507242023396uL,
		16794690268917721879uL, 8806733365625141341uL, 10496681418073576174uL, 12421737381156795194uL, 13120851772591970218uL, 6303799689591218185uL, 16401064715739962772uL, 17103121648843798539uL, 10250665447337476733uL, 1466078993672598279uL,
		12813331809171845916uL, 6444284760518135752uL, 16016664761464807395uL, 8055355950647669691uL, 10010415475915504622uL, 2728754459941099604uL, 12513019344894380777uL, 12634315111781150314uL, 15641274181117975972uL, 1957835834444274180uL,
		9775796363198734982uL, 10447019433382447170uL, 12219745453998418728uL, 3835402254873283155uL, 15274681817498023410uL, 4794252818591603944uL, 9546676135936264631uL, 7608094030047140369uL, 11933345169920330789uL, 4898431519131537557uL,
		14916681462400413486uL, 10734725417341809851uL, 9322925914000258429uL, 2097517367411243253uL, 11653657392500323036uL, 7233582727691441970uL, 14567071740625403795uL, 9041978409614302462uL, 18208839675781754744uL, 6690786993590490174uL,
		11380524797363596715uL, 4181741870994056359uL, 14225655996704495894uL, 615491320315182544uL, 17782069995880619867uL, 9992736187248753989uL, 11113793747425387417uL, 3939617107816777291uL, 13892242184281734271uL, 9536207403198359517uL,
		17365302730352167839uL, 7308573235570561493uL, 10853314206470104899uL, 11485387299872682789uL, 13566642758087631124uL, 9745048106413465582uL, 16958303447609538905uL, 12181310133016831978uL, 10598939654755961816uL, 695789805494438130uL,
		13248674568444952270uL, 869737256868047663uL, 16560843210556190337uL, 10310543607939835386uL, 10350527006597618960uL, 17973304801030866876uL, 12938158758247023701uL, 4019886927579031980uL, 16172698447808779626uL, 9636544677901177879uL,
		10107936529880487266uL, 10634526442115624078uL, 12634920662350609083uL, 4069786015789754290uL, 15793650827938261354uL, 475546501309804958uL, 9871031767461413346uL, 4908902581746016003uL, 12338789709326766682uL, 15359500264037295811uL,
		15423487136658458353uL, 9976003293191843956uL, 9639679460411536470uL, 17764217104313372233uL, 12049599325514420588uL, 12981899343536939483uL, 15061999156893025735uL, 16227374179421174354uL, 9413749473058141084uL, 17059637889779315827uL,
		11767186841322676356uL, 2877803288514593168uL, 14708983551653345445uL, 3597254110643241460uL, 18386229439566681806uL, 9108253656731439729uL, 11491393399729176129uL, 1080972517029761926uL, 14364241749661470161uL, 5962901664714590312uL,
		17955302187076837701uL, 12065313099320625794uL, 11222063866923023563uL, 9846663696289085073uL, 14027579833653779454uL, 7696643601933968437uL, 17534474792067224318uL, 397432465562684739uL, 10959046745042015198uL, 14083453346258841674uL,
		13698808431302518998uL, 8380944645968776284uL, 17123510539128148748uL, 1252808770606194547uL, 10702194086955092967uL, 10006377518483647400uL, 13377742608693866209uL, 7896285879677171346uL, 16722178260867332761uL, 14482043368023852087uL,
		10451361413042082976uL, 2133748077373825698uL, 13064201766302603720uL, 2667185096717282123uL, 16330252207878254650uL, 3333981370896602653uL, 10206407629923909156uL, 6695424375237764562uL, 12758009537404886445uL, 8369280469047205703uL,
		15947511921756108056uL, 15073286604736395033uL, 9967194951097567535uL, 9420804127960246895uL, 12458993688871959419uL, 7164319141522920715uL, 15573742111089949274uL, 4343712908476262990uL, 9733588819431218296uL, 7326506586225052273uL,
		12166986024289022870uL, 9158133232781315341uL, 15208732530361278588uL, 2224294504121868368uL, 9505457831475799117uL, 10613556101930943538uL, 11881822289344748896uL, 17878631145841067327uL, 14852277861680936121uL, 3901544858591782542uL,
		9282673663550585075uL, 13967680582688333849uL, 11603342079438231344uL, 12847914709933029407uL, 14504177599297789180uL, 16059893387416286759uL, 18130221999122236476uL, 1628122660560806833uL, 11331388749451397797uL, 10240948699705280078uL,
		14164235936814247246uL, 17412871893058988002uL, 17705294921017809058uL, 12542717829468959195uL, 11065809325636130661uL, 12450884661845487401uL, 13832261657045163327uL, 1728547772024695539uL, 17290327071306454158uL, 15995742770313033136uL,
		10806454419566533849uL, 5385653213018257806uL, 13508068024458167311uL, 11343752534700210161uL, 16885085030572709139uL, 9568004649947874797uL, 10553178144107943212uL, 3674159897003727796uL, 13191472680134929015uL, 4592699871254659745uL,
		16489340850168661269uL, 1129188820640936778uL, 10305838031355413293uL, 3011586022114279438uL, 12882297539194266616uL, 8376168546070237202uL, 16102871923992833270uL, 10470210682587796502uL, 10064294952495520794uL, 1932195658189984910uL,
		12580368690619400992uL, 11638616609592256945uL, 15725460863274251240uL, 14548270761990321182uL, 9828413039546407025uL, 9092669226243950738uL, 12285516299433008781uL, 15977522551232326327uL, 15356895374291260977uL, 6136845133758244197uL,
		9598059608932038110uL, 15364743254667372383uL, 11997574511165047638uL, 9982557031479439671uL, 14996968138956309548uL, 3254824252494523781uL, 9373105086847693467uL, 11257637194663853171uL, 11716381358559616834uL, 9460360474902428559uL,
		14645476698199521043uL, 2602078556773259891uL, 18306845872749401303uL, 17087656251248738576uL, 11441778670468375814uL, 17597314184671543466uL, 14302223338085469768uL, 12773270693984653525uL, 17877779172606837210uL, 15966588367480816906uL,
		11173611982879273256uL, 14590803748102898470uL, 13967014978599091570uL, 18238504685128623088uL, 17458768723248864463uL, 13574758819556003052uL, 10911730452030540289uL, 15401753289863583763uL, 13639663065038175362uL, 5417133557047315992uL,
		17049578831297719202uL, 15994788983163920798uL, 10655986769561074501uL, 14608429132904838403uL, 13319983461951343127uL, 4425478360848884291uL, 16649979327439178909uL, 920161932633717460uL, 10406237079649486818uL, 2880944217109767365uL,
		13007796349561858522uL, 12824552308241985014uL, 16259745436952323153uL, 6807318348447705459uL, 10162340898095201970uL, 15783789013848285672uL, 12702926122619002463uL, 10506364230455581282uL, 15878657653273753079uL, 8521269269642088699uL,
		9924161033296095674uL, 12243322321167387293uL, 12405201291620119593uL, 6080780864604458308uL, 15506501614525149491uL, 12212662099182960789uL, 9691563509078218432uL, 5327070802775656541uL, 12114454386347773040uL, 6658838503469570676uL,
		15143067982934716300uL, 8323548129336963345uL, 9464417489334197687uL, 14425589617690377899uL, 11830521861667747109uL, 13420301003685584469uL, 14788152327084683887uL, 2940318199324816875uL, 9242595204427927429uL, 8755227902219092403uL,
		11553244005534909286uL, 15555720896201253407uL, 14441555006918636608uL, 10221279083396790951uL, 18051943758648295760uL, 12776598854245988689uL, 11282464849155184850uL, 7985374283903742931uL, 14103081061443981063uL, 758345818024902856uL,
		17628851326804976328uL, 14782990327813292282uL, 11018032079253110205uL, 9239368954883307676uL, 13772540099066387756uL, 16160897212031522499uL, 17215675123832984696uL, 1754377441329851508uL, 10759796952395615435uL, 1096485900831157192uL,
		13449746190494519293uL, 15205665431321110202uL, 16812182738118149117uL, 5172023733869224041uL, 10507614211323843198uL, 5538357842881958977uL, 13134517764154803997uL, 16146319340457224530uL, 16418147205193504997uL, 6347841120289366950uL,
		10261342003245940623uL, 6273243709394548296uL
	};

	public static void Dragon4<TNumber>(TNumber value, int cutoffNumber, bool isSignificantDigits, ref NumberBuffer number) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
	{
		if (TNumber.IsNegative(value))
		{
			_ = -value;
		}
		int exponent;
		ulong num = ExtractFractionAndBiasedExponent(value, out exponent);
		bool hasUnequalMargins = false;
		uint mantissaHighBitIdx;
		if (num >> (int)TNumber.DenormalMantissaBits != 0L)
		{
			mantissaHighBitIdx = TNumber.DenormalMantissaBits;
			hasUnequalMargins = num == (uint)(1 << (int)TNumber.DenormalMantissaBits);
		}
		else
		{
			mantissaHighBitIdx = (uint)BitOperations.Log2(num);
		}
		int decimalExponent;
		int num2 = (int)Dragon4(num, exponent, mantissaHighBitIdx, hasUnequalMargins, cutoffNumber, isSignificantDigits, number.Digits, out decimalExponent);
		number.Scale = decimalExponent + 1;
		number.Digits[num2] = 0;
		number.DigitsCount = num2;
	}

	private unsafe static uint Dragon4(ulong mantissa, int exponent, uint mantissaHighBitIdx, bool hasUnequalMargins, int cutoffNumber, bool isSignificantDigits, Span<byte> buffer, out int decimalExponent)
	{
		int num = 0;
		BigInteger lhs;
		BigInteger rhs;
		BigInteger result;
		BigInteger* ptr;
		if (hasUnequalMargins)
		{
			BigInteger result2;
			if (exponent > 0)
			{
				BigInteger.SetUInt64(out lhs, 4 * mantissa);
				lhs.ShiftLeft((uint)exponent);
				BigInteger.SetUInt32(out rhs, 4u);
				BigInteger.Pow2((uint)exponent, out result);
				BigInteger.Pow2((uint)(exponent + 1), out result2);
			}
			else
			{
				BigInteger.SetUInt64(out lhs, 4 * mantissa);
				BigInteger.Pow2((uint)(-exponent + 2), out rhs);
				BigInteger.SetUInt32(out result, 1u);
				BigInteger.SetUInt32(out result2, 2u);
			}
			ptr = &result2;
		}
		else
		{
			if (exponent > 0)
			{
				BigInteger.SetUInt64(out lhs, 2 * mantissa);
				lhs.ShiftLeft((uint)exponent);
				BigInteger.SetUInt32(out rhs, 2u);
				BigInteger.Pow2((uint)exponent, out result);
			}
			else
			{
				BigInteger.SetUInt64(out lhs, 2 * mantissa);
				BigInteger.Pow2((uint)(-exponent + 1), out rhs);
				BigInteger.SetUInt32(out result, 1u);
			}
			ptr = &result;
		}
		int num2 = (int)Math.Ceiling((double)((int)mantissaHighBitIdx + exponent) * 0.3010299956639812 - 0.69);
		if (num2 > 0)
		{
			rhs.MultiplyPow10((uint)num2);
		}
		else if (num2 < 0)
		{
			BigInteger.Pow10((uint)(-num2), out var result3);
			lhs.Multiply(ref result3);
			result.Multiply(ref result3);
			if (ptr != &result)
			{
				BigInteger.Multiply(ref result, 2u, out *ptr);
			}
		}
		bool flag = mantissa % 2 == 0;
		bool flag2 = false;
		if (cutoffNumber == -1)
		{
			BigInteger.Add(ref lhs, ref *ptr, out var result4);
			int num3 = BigInteger.Compare(ref result4, ref rhs);
			flag2 = (flag ? (num3 >= 0) : (num3 > 0));
		}
		else
		{
			flag2 = BigInteger.Compare(ref lhs, ref rhs) >= 0;
		}
		if (flag2)
		{
			num2++;
		}
		else
		{
			lhs.Multiply10();
			result.Multiply10();
			if (ptr != &result)
			{
				BigInteger.Multiply(ref result, 2u, out *ptr);
			}
		}
		int num4 = num2 - buffer.Length;
		if (cutoffNumber != -1)
		{
			int num5 = 0;
			num5 = ((!isSignificantDigits) ? (-cutoffNumber) : (num2 - cutoffNumber));
			if (num5 > num4)
			{
				num4 = num5;
			}
		}
		num2 = (decimalExponent = num2 - 1);
		uint block = rhs.GetBlock((uint)(rhs.GetLength() - 1));
		if (block < 8 || block > 429496729)
		{
			uint num6 = (uint)BitOperations.Log2(block);
			uint shift = (59 - num6) % 32;
			rhs.ShiftLeft(shift);
			lhs.ShiftLeft(shift);
			result.ShiftLeft(shift);
			if (ptr != &result)
			{
				BigInteger.Multiply(ref result, 2u, out *ptr);
			}
		}
		bool flag3;
		bool flag4;
		uint num7;
		if (cutoffNumber == -1)
		{
			while (true)
			{
				num7 = BigInteger.HeuristicDivide(ref lhs, ref rhs);
				BigInteger.Add(ref lhs, ref *ptr, out var result5);
				int num8 = BigInteger.Compare(ref lhs, ref result);
				int num9 = BigInteger.Compare(ref result5, ref rhs);
				if (flag)
				{
					flag3 = num8 <= 0;
					flag4 = num9 >= 0;
				}
				else
				{
					flag3 = num8 < 0;
					flag4 = num9 > 0;
				}
				if (flag3 || flag4 || num2 == num4)
				{
					break;
				}
				buffer[num] = (byte)(48 + num7);
				num++;
				lhs.Multiply10();
				result.Multiply10();
				if (ptr != &result)
				{
					BigInteger.Multiply(ref result, 2u, out *ptr);
				}
				num2--;
			}
		}
		else
		{
			if (num2 < num4)
			{
				num7 = BigInteger.HeuristicDivide(ref lhs, ref rhs);
				if (num7 > 5 || (num7 == 5 && !lhs.IsZero()))
				{
					decimalExponent++;
					num7 = 1u;
				}
				buffer[num] = (byte)(48 + num7);
				return (uint)(num + 1);
			}
			flag3 = false;
			flag4 = false;
			while (true)
			{
				num7 = BigInteger.HeuristicDivide(ref lhs, ref rhs);
				if (lhs.IsZero() || num2 <= num4)
				{
					break;
				}
				buffer[num] = (byte)(48 + num7);
				num++;
				lhs.Multiply10();
				num2--;
			}
		}
		bool flag5 = flag3;
		if (flag3 == flag4)
		{
			lhs.ShiftLeft(1u);
			int num10 = BigInteger.Compare(ref lhs, ref rhs);
			flag5 = num10 < 0;
			if (num10 == 0)
			{
				flag5 = (num7 & 1) == 0;
			}
		}
		if (flag5)
		{
			buffer[num] = (byte)(48 + num7);
			num++;
		}
		else if (num7 == 9)
		{
			while (true)
			{
				if (num == 0)
				{
					buffer[num] = 49;
					num++;
					decimalExponent++;
					break;
				}
				num--;
				if (buffer[num] != 57)
				{
					buffer[num]++;
					num++;
					break;
				}
			}
		}
		else
		{
			buffer[num] = (byte)(48 + num7 + 1);
			num++;
		}
		return (uint)num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ref byte GetTwoDigitsBytesRef(bool useChars)
	{
		return ref MemoryMarshal.GetArrayDataReference(useChars ? TwoDigitsCharsAsBytes : TwoDigitsBytes);
	}

	public unsafe static string FormatDecimal(decimal value, ReadOnlySpan<char> format, NumberFormatInfo info)
	{
		int digits;
		char c = ParseFormatSpecifier(format, out digits);
		byte* digits2 = stackalloc byte[31];
		NumberBuffer number = new NumberBuffer(NumberBufferKind.Decimal, digits2, 31);
		DecimalToNumber(ref value, ref number);
		char* pointer = stackalloc char[32];
		ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
		if (c != 0)
		{
			NumberToString(ref vlb, ref number, c, digits, info);
		}
		else
		{
			NumberToStringFormat(ref vlb, ref number, format, info);
		}
		string result = vlb.AsSpan().ToString();
		vlb.Dispose();
		return result;
	}

	public unsafe static bool TryFormatDecimal<TChar>(decimal value, ReadOnlySpan<char> format, NumberFormatInfo info, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int digits;
		char c = ParseFormatSpecifier(format, out digits);
		byte* digits2 = stackalloc byte[31];
		NumberBuffer number = new NumberBuffer(NumberBufferKind.Decimal, digits2, 31);
		DecimalToNumber(ref value, ref number);
		TChar* pointer = stackalloc TChar[32];
		ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
		if (c != 0)
		{
			NumberToString(ref vlb, ref number, c, digits, info);
		}
		else
		{
			NumberToStringFormat(ref vlb, ref number, format, info);
		}
		bool result = vlb.TryCopyTo(destination, out charsWritten);
		vlb.Dispose();
		return result;
	}

	internal unsafe static void DecimalToNumber(scoped ref decimal d, ref NumberBuffer number)
	{
		byte* digitsPtr = number.DigitsPtr;
		number.DigitsCount = 29;
		number.IsNegative = decimal.IsNegative(d);
		byte* bufferEnd = digitsPtr + 29;
		while ((d.Mid | d.High) != 0)
		{
			bufferEnd = UInt32ToDecChars(bufferEnd, decimal.DecDivMod1E9(ref d), 9);
		}
		bufferEnd = UInt32ToDecChars(bufferEnd, d.Low, 0);
		int num = (number.DigitsCount = (int)(digitsPtr + 29 - bufferEnd));
		number.Scale = num - d.Scale;
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(bufferEnd++);
		}
		*digitsPtr2 = 0;
	}

	private static int GetFloatingPointMaxDigitsAndPrecision(char fmt, ref int precision, NumberFormatInfo info, out bool isSignificantDigits)
	{
		if (fmt == '\0')
		{
			isSignificantDigits = true;
			return precision;
		}
		int result = precision;
		switch (fmt | 0x20)
		{
		case 99:
			if (precision == -1)
			{
				precision = info.CurrencyDecimalDigits;
			}
			isSignificantDigits = false;
			break;
		case 101:
			if (precision == -1)
			{
				precision = 6;
			}
			precision++;
			isSignificantDigits = true;
			break;
		case 102:
		case 110:
			if (precision == -1)
			{
				precision = info.NumberDecimalDigits;
			}
			isSignificantDigits = false;
			break;
		case 103:
			if (precision == 0)
			{
				precision = -1;
			}
			isSignificantDigits = true;
			break;
		case 112:
			if (precision == -1)
			{
				precision = info.PercentDecimalDigits;
			}
			precision += 2;
			isSignificantDigits = false;
			break;
		case 114:
			precision = -1;
			isSignificantDigits = true;
			break;
		default:
			ThrowHelper.ThrowFormatException_BadFormatSpecifier();
			goto case 114;
		}
		return result;
	}

	public static string FormatFloat<TNumber>(TNumber value, string format, NumberFormatInfo info) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
	{
		Span<char> scratchBuffer = stackalloc char[32];
		ValueListBuilder<char> vlb = new ValueListBuilder<char>(scratchBuffer);
		string result = FormatFloat(ref vlb, value, format.AsSpan(), info) ?? vlb.AsSpan().ToString();
		vlb.Dispose();
		return result;
	}

	public static bool TryFormatFloat<TNumber, TChar>(TNumber value, ReadOnlySpan<char> format, NumberFormatInfo info, Span<TChar> destination, out int charsWritten) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber> where TChar : unmanaged, IUtfChar<TChar>
	{
		Span<TChar> scratchBuffer = stackalloc TChar[32];
		ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(scratchBuffer);
		string text = FormatFloat(ref vlb, value, format, info);
		bool result = ((text != null) ? TryCopyTo(text, destination, out charsWritten) : vlb.TryCopyTo(destination, out charsWritten));
		vlb.Dispose();
		return result;
	}

	private unsafe static string FormatFloat<TNumber, TChar>(ref ValueListBuilder<TChar> vlb, TNumber value, ReadOnlySpan<char> format, NumberFormatInfo info) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber> where TChar : unmanaged, IUtfChar<TChar>
	{
		if (!TNumber.IsFinite(value))
		{
			if (TNumber.IsNaN(value))
			{
				if (typeof(TChar) == typeof(char))
				{
					return info.NaNSymbol;
				}
				vlb.Append(info.NaNSymbolTChar<TChar>());
				return null;
			}
			if (typeof(TChar) == typeof(char))
			{
				if (!TNumber.IsNegative(value))
				{
					return info.PositiveInfinitySymbol;
				}
				return info.NegativeInfinitySymbol;
			}
			vlb.Append(TNumber.IsNegative(value) ? info.NegativeInfinitySymbolTChar<TChar>() : info.PositiveInfinitySymbolTChar<TChar>());
			return null;
		}
		int digits;
		char c = ParseFormatSpecifier(format, out digits);
		byte* digits2 = stackalloc byte[(int)(uint)TNumber.NumberBufferLength];
		if (c == '\0')
		{
			digits = TNumber.MaxPrecisionCustomFormat;
		}
		NumberBuffer number = new NumberBuffer(NumberBufferKind.FloatingPoint, digits2, TNumber.NumberBufferLength);
		number.IsNegative = TNumber.IsNegative(value);
		bool isSignificantDigits;
		int nMaxDigits = GetFloatingPointMaxDigitsAndPrecision(c, ref digits, info, out isSignificantDigits);
		if (value != default(TNumber) && (!isSignificantDigits || !Grisu3.TryRun(value, digits, ref number)))
		{
			Dragon4(value, digits, isSignificantDigits, ref number);
		}
		if (c != 0)
		{
			if (digits == -1)
			{
				nMaxDigits = Math.Max(number.DigitsCount, TNumber.MaxRoundTripDigits);
			}
			NumberToString(ref vlb, ref number, c, nMaxDigits, info);
		}
		else
		{
			NumberToStringFormat(ref vlb, ref number, format, info);
		}
		return null;
	}

	private static bool TryCopyTo<TChar>(string source, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (typeof(TChar) == typeof(char))
		{
			if (source.TryCopyTo(Unsafe.BitCast<Span<TChar>, Span<char>>(destination)))
			{
				charsWritten = source.Length;
				return true;
			}
			charsWritten = 0;
			return false;
		}
		return Encoding.UTF8.TryGetBytes(source.AsSpan(), Unsafe.BitCast<Span<TChar>, Span<byte>>(destination), out charsWritten);
	}

	internal static char GetHexBase(char fmt)
	{
		return (char)(fmt - 33);
	}

	public static string FormatInt32(int value, int hexMask, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			if (value < 0)
			{
				return NegativeInt32ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign);
			}
			return UInt32ToDecStr((uint)value);
		}
		return FormatInt32Slow(value, hexMask, format, provider);
		unsafe static string FormatInt32Slow(int num, int num2, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (num < 0)
				{
					return NegativeInt32ToDecStr(num, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSign);
				}
				return UInt32ToDecStr((uint)num, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int32ToHexStr(num & num2, GetHexBase(c), digits);
			case 'B':
				return UInt32ToBinaryStr((uint)(num & num2), digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[11];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 11);
				Int32ToNumber(num, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFormatInt32<TChar>(int value, int hexMask, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			if (value < 0)
			{
				return TryNegativeInt32ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSignTChar<TChar>(), destination, out charsWritten);
			}
			return TryUInt32ToDecStr((uint)value, destination, out charsWritten);
		}
		return TryFormatInt32Slow(value, hexMask, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatInt32Slow(int num, int num2, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (num < 0)
				{
					return TryNegativeInt32ToDecStr(num, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSignTChar<TChar>(), destination2, out reference);
				}
				return TryUInt32ToDecStr((uint)num, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt32ToHexStr(num & num2, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt32ToBinaryStr((uint)(num & num2), digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[11];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 11);
				Int32ToNumber(num, ref number);
				TChar* pointer = stackalloc TChar[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static string FormatUInt32(uint value, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			return UInt32ToDecStr(value);
		}
		return FormatUInt32Slow(value, format, provider);
		unsafe static string FormatUInt32Slow(uint value2, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return UInt32ToDecStr(value2, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int32ToHexStr((int)value2, GetHexBase(c), digits);
			case 'B':
				return UInt32ToBinaryStr(value2, digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[11];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 11);
				UInt32ToNumber(value2, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFormatUInt32<TChar>(uint value, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			return TryUInt32ToDecStr(value, destination, out charsWritten);
		}
		return TryFormatUInt32Slow(value, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatUInt32Slow(uint value2, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return TryUInt32ToDecStr(value2, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt32ToHexStr((int)value2, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt32ToBinaryStr(value2, digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[11];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 11);
				UInt32ToNumber(value2, ref number);
				TChar* pointer = stackalloc TChar[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static string FormatInt64(long value, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			if (value < 0)
			{
				return NegativeInt64ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign);
			}
			return UInt64ToDecStr((ulong)value);
		}
		return FormatInt64Slow(value, format, provider);
		unsafe static string FormatInt64Slow(long num, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (num < 0)
				{
					return NegativeInt64ToDecStr(num, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSign);
				}
				return UInt64ToDecStr((ulong)num, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int64ToHexStr(num, GetHexBase(c), digits);
			case 'B':
				return UInt64ToBinaryStr((ulong)num, digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[20];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 20);
				Int64ToNumber(num, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFormatInt64<TChar>(long value, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			if (value < 0)
			{
				return TryNegativeInt64ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSignTChar<TChar>(), destination, out charsWritten);
			}
			return TryUInt64ToDecStr((ulong)value, destination, out charsWritten);
		}
		return TryFormatInt64Slow(value, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatInt64Slow(long num, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (num < 0)
				{
					return TryNegativeInt64ToDecStr(num, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSignTChar<TChar>(), destination2, out reference);
				}
				return TryUInt64ToDecStr((ulong)num, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt64ToHexStr(num, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt64ToBinaryStr((ulong)num, digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[20];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 20);
				Int64ToNumber(num, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static string FormatUInt64(ulong value, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			return UInt64ToDecStr(value);
		}
		return FormatUInt64Slow(value, format, provider);
		unsafe static string FormatUInt64Slow(ulong value2, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return UInt64ToDecStr(value2, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int64ToHexStr((long)value2, GetHexBase(c), digits);
			case 'B':
				return UInt64ToBinaryStr(value2, digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[21];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 21);
				UInt64ToNumber(value2, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryFormatUInt64<TChar>(ulong value, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			return TryUInt64ToDecStr(value, destination, out charsWritten);
		}
		return TryFormatUInt64Slow(value, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatUInt64Slow(ulong value2, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return TryUInt64ToDecStr(value2, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt64ToHexStr((long)value2, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt64ToBinaryStr(value2, digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[21];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 21);
				UInt64ToNumber(value2, ref number);
				TChar* pointer = stackalloc TChar[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static string FormatInt128(Int128 value, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			if (!Int128.IsPositive(value))
			{
				return NegativeInt128ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign);
			}
			return UInt128ToDecStr((UInt128)value, -1);
		}
		return FormatInt128Slow(value, format, provider);
		unsafe static string FormatInt128Slow(Int128 @int, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (!Int128.IsPositive(@int))
				{
					return NegativeInt128ToDecStr(@int, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSign);
				}
				return UInt128ToDecStr((UInt128)@int, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int128ToHexStr(@int, GetHexBase(c), digits);
			case 'B':
				return UInt128ToBinaryStr(@int, digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[40];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 40);
				Int128ToNumber(@int, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static bool TryFormatInt128<TChar>(Int128 value, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			if (!Int128.IsPositive(value))
			{
				return TryNegativeInt128ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSignTChar<TChar>(), destination, out charsWritten);
			}
			return TryUInt128ToDecStr((UInt128)value, -1, destination, out charsWritten);
		}
		return TryFormatInt128Slow(value, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatInt128Slow(Int128 @int, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				if (!Int128.IsPositive(@int))
				{
					return TryNegativeInt128ToDecStr(@int, digits, NumberFormatInfo.GetInstance(formatProvider).NegativeSignTChar<TChar>(), destination2, out reference);
				}
				return TryUInt128ToDecStr((UInt128)@int, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt128ToHexStr(@int, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt128ToBinaryStr(@int, digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[40];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 40);
				Int128ToNumber(@int, ref number);
				TChar* pointer = stackalloc TChar[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static string FormatUInt128(UInt128 value, string format, IFormatProvider provider)
	{
		if (string.IsNullOrEmpty(format))
		{
			return UInt128ToDecStr(value, -1);
		}
		return FormatUInt128Slow(value, format, provider);
		unsafe static string FormatUInt128Slow(UInt128 uInt, string text, IFormatProvider formatProvider)
		{
			ReadOnlySpan<char> format2 = text.AsSpan();
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return UInt128ToDecStr(uInt, digits);
			}
			switch (c2)
			{
			case 'X':
				return Int128ToHexStr((Int128)uInt, GetHexBase(c), digits);
			case 'B':
				return UInt128ToBinaryStr((Int128)uInt, digits);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[40];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 40);
				UInt128ToNumber(uInt, ref number);
				char* pointer = stackalloc char[32];
				ValueListBuilder<char> vlb = new ValueListBuilder<char>(new Span<char>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				string result = vlb.AsSpan().ToString();
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	public static bool TryFormatUInt128<TChar>(UInt128 value, ReadOnlySpan<char> format, IFormatProvider provider, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (format.Length == 0)
		{
			return TryUInt128ToDecStr(value, -1, destination, out charsWritten);
		}
		return TryFormatUInt128Slow(value, format, provider, destination, out charsWritten);
		unsafe static bool TryFormatUInt128Slow(UInt128 uInt, ReadOnlySpan<char> format2, IFormatProvider formatProvider, Span<TChar> destination2, out int reference)
		{
			int digits;
			char c = ParseFormatSpecifier(format2, out digits);
			char c2 = (char)(c & 0xFFDF);
			if ((c2 == 'G') ? (digits < 1) : (c2 == 'D'))
			{
				return TryUInt128ToDecStr(uInt, digits, destination2, out reference);
			}
			switch (c2)
			{
			case 'X':
				return TryInt128ToHexStr((Int128)uInt, GetHexBase(c), digits, destination2, out reference);
			case 'B':
				return TryUInt128ToBinaryStr((Int128)uInt, digits, destination2, out reference);
			default:
			{
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(formatProvider);
				byte* digits2 = stackalloc byte[40];
				NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits2, 40);
				UInt128ToNumber(uInt, ref number);
				TChar* pointer = stackalloc TChar[32];
				ValueListBuilder<TChar> vlb = new ValueListBuilder<TChar>(new Span<TChar>(pointer, 32));
				if (c != 0)
				{
					NumberToString(ref vlb, ref number, c, digits, instance);
				}
				else
				{
					NumberToStringFormat(ref vlb, ref number, format2, instance);
				}
				bool result = vlb.TryCopyTo(destination2, out reference);
				vlb.Dispose();
				return result;
			}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void Int32ToNumber(int value, ref NumberBuffer number)
	{
		number.DigitsCount = 10;
		if (value >= 0)
		{
			number.IsNegative = false;
		}
		else
		{
			number.IsNegative = true;
			value = -value;
		}
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt32ToDecChars(digitsPtr + 10, (uint)value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 10 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	public static string Int32ToDecStr(int value)
	{
		if (value < 0)
		{
			return NegativeInt32ToDecStr(value, -1, NumberFormatInfo.CurrentInfo.NegativeSign);
		}
		return UInt32ToDecStr((uint)value);
	}

	private unsafe static string NegativeInt32ToDecStr(int value, int digits, string sNegative)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits((uint)(-value))) + sNegative.Length;
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			char* ptr2 = UInt32ToDecChars(ptr + num, (uint)(-value), digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr2) = sNegative[num2];
			}
		}
		return text;
	}

	internal unsafe static bool TryNegativeInt32ToDecStr<TChar>(int value, int digits, ReadOnlySpan<TChar> sNegative, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits((uint)(-value))) + sNegative.Length;
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			TChar* ptr = UInt32ToDecChars(reference + num, (uint)(-value), digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr) = sNegative[num2];
			}
		}
		return true;
	}

	private unsafe static string Int32ToHexStr(int value, char hexBase, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits((uint)value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			Int32ToHexChars(ptr + num, (uint)value, hexBase, digits);
		}
		return text;
	}

	internal unsafe static bool TryInt32ToHexStr<TChar>(int value, char hexBase, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits((uint)value));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			Int32ToHexChars(reference + num, (uint)value, hexBase, digits);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static TChar* Int32ToHexChars<TChar>(TChar* buffer, uint value, int hexBase, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		while (--digits >= 0 || value != 0)
		{
			byte b = (byte)(value & 0xF);
			*(--buffer) = TChar.CastFrom(b + ((b < 10) ? 48 : hexBase));
			value >>= 4;
		}
		return buffer;
	}

	private unsafe static string UInt32ToBinaryStr(uint value, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, (int)(32 - uint.LeadingZeroCount(value)));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt32ToBinaryChars(ptr + num, value, digits);
		}
		return text;
	}

	private unsafe static bool TryUInt32ToBinaryStr<TChar>(uint value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, (int)(32 - uint.LeadingZeroCount(value)));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			UInt32ToBinaryChars(reference + num, value, digits);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static TChar* UInt32ToBinaryChars<TChar>(TChar* buffer, uint value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		while (--digits >= 0 || value != 0)
		{
			*(--buffer) = TChar.CastFrom(48 + (byte)(value & 1));
			value >>= 1;
		}
		return buffer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void UInt32ToNumber(uint value, ref NumberBuffer number)
	{
		number.DigitsCount = 10;
		number.IsNegative = false;
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt32ToDecChars(digitsPtr + 10, value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 10 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void WriteTwoDigits<TChar>(uint value, TChar* ptr) where TChar : unmanaged, IUtfChar<TChar>
	{
		Unsafe.CopyBlockUnaligned(ref *(byte*)ptr, in Unsafe.Add(ref GetTwoDigitsBytesRef(typeof(TChar) == typeof(char)), (uint)(sizeof(TChar) * 2) * value), (uint)(sizeof(TChar) * 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void WriteFourDigits<TChar>(uint value, TChar* ptr) where TChar : unmanaged, IUtfChar<TChar>
	{
		(uint Quotient, uint Remainder) tuple = Math.DivRem(value, 100u);
		value = tuple.Quotient;
		uint item = tuple.Remainder;
		ref byte twoDigitsBytesRef = ref GetTwoDigitsBytesRef(typeof(TChar) == typeof(char));
		Unsafe.CopyBlockUnaligned(ref *(byte*)ptr, in Unsafe.Add(ref twoDigitsBytesRef, (uint)(sizeof(TChar) * 2) * value), (uint)(sizeof(TChar) * 2));
		Unsafe.CopyBlockUnaligned(ref *(byte*)(ptr + 2), in Unsafe.Add(ref twoDigitsBytesRef, (uint)(sizeof(TChar) * 2) * item), (uint)(sizeof(TChar) * 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void WriteDigits<TChar>(uint value, TChar* ptr, int count) where TChar : unmanaged, IUtfChar<TChar>
	{
		TChar* ptr2;
		for (ptr2 = ptr + count - 1; ptr2 > ptr; ptr2--)
		{
			uint num = 48 + value;
			value /= 10;
			*ptr2 = TChar.CastFrom(num - value * 10);
		}
		*ptr2 = TChar.CastFrom(48 + value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static TChar* UInt32ToDecChars<TChar>(TChar* bufferEnd, uint value) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (value >= 10)
		{
			while (true)
			{
				switch (value)
				{
				default:
					goto IL_0007;
				case 10u:
				case 11u:
				case 12u:
				case 13u:
				case 14u:
				case 15u:
				case 16u:
				case 17u:
				case 18u:
				case 19u:
				case 20u:
				case 21u:
				case 22u:
				case 23u:
				case 24u:
				case 25u:
				case 26u:
				case 27u:
				case 28u:
				case 29u:
				case 30u:
				case 31u:
				case 32u:
				case 33u:
				case 34u:
				case 35u:
				case 36u:
				case 37u:
				case 38u:
				case 39u:
				case 40u:
				case 41u:
				case 42u:
				case 43u:
				case 44u:
				case 45u:
				case 46u:
				case 47u:
				case 48u:
				case 49u:
				case 50u:
				case 51u:
				case 52u:
				case 53u:
				case 54u:
				case 55u:
				case 56u:
				case 57u:
				case 58u:
				case 59u:
				case 60u:
				case 61u:
				case 62u:
				case 63u:
				case 64u:
				case 65u:
				case 66u:
				case 67u:
				case 68u:
				case 69u:
				case 70u:
				case 71u:
				case 72u:
				case 73u:
				case 74u:
				case 75u:
				case 76u:
				case 77u:
				case 78u:
				case 79u:
				case 80u:
				case 81u:
				case 82u:
				case 83u:
				case 84u:
				case 85u:
				case 86u:
				case 87u:
				case 88u:
				case 89u:
				case 90u:
				case 91u:
				case 92u:
				case 93u:
				case 94u:
				case 95u:
				case 96u:
				case 97u:
				case 98u:
				case 99u:
					bufferEnd -= 2;
					WriteTwoDigits(value, bufferEnd);
					return bufferEnd;
				case 0u:
				case 1u:
				case 2u:
				case 3u:
				case 4u:
				case 5u:
				case 6u:
				case 7u:
				case 8u:
				case 9u:
					break;
				}
				break;
				IL_0007:
				bufferEnd -= 2;
				(uint Quotient, uint Remainder) tuple = Math.DivRem(value, 100u);
				(value, _) = tuple;
				WriteTwoDigits(tuple.Remainder, bufferEnd);
			}
		}
		*(--bufferEnd) = TChar.CastFrom(value + 48);
		return bufferEnd;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static TChar* UInt32ToDecChars<TChar>(TChar* bufferEnd, uint value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		while (value >= 100)
		{
			bufferEnd -= 2;
			digits -= 2;
			uint value2;
			(value, value2) = Math.DivRem(value, 100u);
			WriteTwoDigits(value2, bufferEnd);
		}
		while (value != 0 || digits > 0)
		{
			digits--;
			uint value2;
			(value, value2) = Math.DivRem(value, 10u);
			*(--bufferEnd) = TChar.CastFrom(value2 + 48);
		}
		return bufferEnd;
	}

	internal static string UInt32ToDecStr(uint value)
	{
		if (value < 10)
		{
			return UInt32ToDecStrForKnownSmallNumber(value);
		}
		return UInt32ToDecStr_NoSmallNumberCheck(value);
	}

	internal static string UInt32ToDecStrForKnownSmallNumber(uint value)
	{
		return s_smallNumberCache[value] ?? CreateAndCacheString(value);
		[MethodImpl(MethodImplOptions.NoInlining)]
		static string CreateAndCacheString(uint num)
		{
			return s_smallNumberCache[num] = UInt32ToDecStr_NoSmallNumberCheck(num);
		}
	}

	private unsafe static string UInt32ToDecStr_NoSmallNumberCheck(uint value)
	{
		int num = FormattingHelpers.CountDigits(value);
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt32ToDecChars(ptr + num, value);
		}
		return text;
	}

	private unsafe static string UInt32ToDecStr(uint value, int digits)
	{
		if (digits <= 1)
		{
			return UInt32ToDecStr(value);
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits(value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt32ToDecChars(ptr + num, value, digits);
		}
		return text;
	}

	internal unsafe static bool TryUInt32ToDecStr<TChar>(uint value, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = FormattingHelpers.CountDigits(value);
		if (num <= destination.Length)
		{
			charsWritten = num;
			fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
			{
				UInt32ToDecChars(reference + num, value);
			}
			return true;
		}
		charsWritten = 0;
		return false;
	}

	internal unsafe static bool TryUInt32ToDecStr<TChar>(uint value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = FormattingHelpers.CountDigits(value);
		int num2 = Math.Max(digits, num);
		if (num2 <= destination.Length)
		{
			charsWritten = num2;
			fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
			{
				TChar* bufferEnd = reference + num2;
				bufferEnd = ((digits > num) ? UInt32ToDecChars(bufferEnd, value, digits) : UInt32ToDecChars(bufferEnd, value));
			}
			return true;
		}
		charsWritten = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void Int64ToNumber(long value, ref NumberBuffer number)
	{
		number.DigitsCount = 19;
		if (value >= 0)
		{
			number.IsNegative = false;
		}
		else
		{
			number.IsNegative = true;
			value = -value;
		}
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt64ToDecChars(digitsPtr + 19, (ulong)value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 19 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	public static string Int64ToDecStr(long value)
	{
		if (value < 0)
		{
			return NegativeInt64ToDecStr(value, -1, NumberFormatInfo.CurrentInfo.NegativeSign);
		}
		return UInt64ToDecStr((ulong)value);
	}

	private unsafe static string NegativeInt64ToDecStr(long value, int digits, string sNegative)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits((ulong)(-value))) + sNegative.Length;
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			char* ptr2 = UInt64ToDecChars(ptr + num, (ulong)(-value), digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr2) = sNegative[num2];
			}
		}
		return text;
	}

	internal unsafe static bool TryNegativeInt64ToDecStr<TChar>(long value, int digits, ReadOnlySpan<TChar> sNegative, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits((ulong)(-value))) + sNegative.Length;
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			TChar* ptr = UInt64ToDecChars(reference + num, (ulong)(-value), digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr) = sNegative[num2];
			}
		}
		return true;
	}

	private unsafe static string Int64ToHexStr(long value, char hexBase, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong)value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			Int64ToHexChars(ptr + num, (ulong)value, hexBase, digits);
		}
		return text;
	}

	internal unsafe static bool TryInt64ToHexStr<TChar>(long value, char hexBase, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong)value));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			Int64ToHexChars(reference + num, (ulong)value, hexBase, digits);
		}
		return true;
	}

	private unsafe static TChar* Int64ToHexChars<TChar>(TChar* buffer, ulong value, int hexBase, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		uint value2 = (uint)value;
		uint num = (uint)(value >> 32);
		if (num != 0)
		{
			buffer = Int32ToHexChars(buffer, value2, hexBase, 8);
			return Int32ToHexChars(buffer, num, hexBase, digits - 8);
		}
		return Int32ToHexChars(buffer, value2, hexBase, Math.Max(digits, 1));
	}

	private unsafe static string UInt64ToBinaryStr(ulong value, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, 64 - (int)ulong.LeadingZeroCount(value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt64ToBinaryChars(ptr + num, value, digits);
		}
		return text;
	}

	private unsafe static bool TryUInt64ToBinaryStr<TChar>(ulong value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		int num = Math.Max(digits, 64 - (int)ulong.LeadingZeroCount(value));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			UInt64ToBinaryChars(reference + num, value, digits);
		}
		return true;
	}

	private unsafe static TChar* UInt64ToBinaryChars<TChar>(TChar* buffer, ulong value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		uint value2 = (uint)value;
		uint num = (uint)(value >> 32);
		if (num != 0)
		{
			buffer = UInt32ToBinaryChars(buffer, value2, 32);
			return UInt32ToBinaryChars(buffer, num, digits - 32);
		}
		return UInt32ToBinaryChars(buffer, value2, Math.Max(digits, 1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void UInt64ToNumber(ulong value, ref NumberBuffer number)
	{
		number.DigitsCount = 20;
		number.IsNegative = false;
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt64ToDecChars(digitsPtr + 20, value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 20 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint Int64DivMod1E9(ref ulong value)
	{
		int result = (int)(value % 1000000000);
		value /= 1000000000uL;
		return (uint)result;
	}

	internal unsafe static TChar* UInt64ToDecChars<TChar>(TChar* bufferEnd, ulong value) where TChar : unmanaged, IUtfChar<TChar>
	{
		while ((uint)(value >> 32) != 0)
		{
			bufferEnd = UInt32ToDecChars(bufferEnd, Int64DivMod1E9(ref value), 9);
		}
		return UInt32ToDecChars(bufferEnd, (uint)value);
	}

	internal unsafe static TChar* UInt64ToDecChars<TChar>(TChar* bufferEnd, ulong value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		while ((uint)(value >> 32) != 0)
		{
			bufferEnd = UInt32ToDecChars(bufferEnd, Int64DivMod1E9(ref value), 9);
			digits -= 9;
		}
		return UInt32ToDecChars(bufferEnd, (uint)value, digits);
	}

	internal unsafe static string UInt64ToDecStr(ulong value)
	{
		if (value < 10)
		{
			return UInt32ToDecStrForKnownSmallNumber((uint)value);
		}
		int num = FormattingHelpers.CountDigits(value);
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt64ToDecChars(ptr + num, value);
		}
		return text;
	}

	internal unsafe static string UInt64ToDecStr(ulong value, int digits)
	{
		if (digits <= 1)
		{
			return UInt64ToDecStr(value);
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits(value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt64ToDecChars(ptr + num, value, digits);
		}
		return text;
	}

	internal unsafe static bool TryUInt64ToDecStr<TChar>(ulong value, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = FormattingHelpers.CountDigits(value);
		if (num <= destination.Length)
		{
			charsWritten = num;
			fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
			{
				UInt64ToDecChars(reference + num, value);
			}
			return true;
		}
		charsWritten = 0;
		return false;
	}

	internal unsafe static bool TryUInt64ToDecStr<TChar>(ulong value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = FormattingHelpers.CountDigits(value);
		int num2 = Math.Max(digits, num);
		if (num2 <= destination.Length)
		{
			charsWritten = num2;
			fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
			{
				TChar* bufferEnd = reference + num2;
				bufferEnd = ((digits > num) ? UInt64ToDecChars(bufferEnd, value, digits) : UInt64ToDecChars(bufferEnd, value));
			}
			return true;
		}
		charsWritten = 0;
		return false;
	}

	private unsafe static void Int128ToNumber(Int128 value, ref NumberBuffer number)
	{
		number.DigitsCount = 39;
		if (Int128.IsPositive(value))
		{
			number.IsNegative = false;
		}
		else
		{
			number.IsNegative = true;
			value = -value;
		}
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt128ToDecChars(digitsPtr + 39, (UInt128)value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 39 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	public static string Int128ToDecStr(Int128 value)
	{
		if (!Int128.IsPositive(value))
		{
			return NegativeInt128ToDecStr(value, -1, NumberFormatInfo.CurrentInfo.NegativeSign);
		}
		return UInt128ToDecStr((UInt128)value, -1);
	}

	private unsafe static string NegativeInt128ToDecStr(Int128 value, int digits, string sNegative)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)(-value);
		int num = Math.Max(digits, FormattingHelpers.CountDigits(value2)) + sNegative.Length;
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			char* ptr2 = UInt128ToDecChars(ptr + num, value2, digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr2) = sNegative[num2];
			}
		}
		return text;
	}

	private unsafe static bool TryNegativeInt128ToDecStr<TChar>(Int128 value, int digits, ReadOnlySpan<TChar> sNegative, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)(-value);
		int num = Math.Max(digits, FormattingHelpers.CountDigits(value2)) + sNegative.Length;
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			TChar* ptr = UInt128ToDecChars(reference + num, value2, digits);
			for (int num2 = sNegative.Length - 1; num2 >= 0; num2--)
			{
				*(--ptr) = sNegative[num2];
			}
		}
		return true;
	}

	private unsafe static string Int128ToHexStr(Int128 value, char hexBase, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)value;
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits(value2));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			Int128ToHexChars(ptr + num, value2, hexBase, digits);
		}
		return text;
	}

	private unsafe static bool TryInt128ToHexStr<TChar>(Int128 value, char hexBase, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)value;
		int num = Math.Max(digits, FormattingHelpers.CountHexDigits(value2));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			Int128ToHexChars(reference + num, value2, hexBase, digits);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static TChar* Int128ToHexChars<TChar>(TChar* buffer, UInt128 value, int hexBase, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		ulong lower = value.Lower;
		ulong upper = value.Upper;
		if (upper != 0L)
		{
			buffer = Int64ToHexChars(buffer, lower, hexBase, 16);
			return Int64ToHexChars(buffer, upper, hexBase, digits - 16);
		}
		return Int64ToHexChars(buffer, lower, hexBase, Math.Max(digits, 1));
	}

	private unsafe static string UInt128ToBinaryStr(Int128 value, int digits)
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)value;
		int num = Math.Max(digits, 128 - (int)UInt128.LeadingZeroCount((UInt128)value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt128ToBinaryChars(ptr + num, value2, digits);
		}
		return text;
	}

	private unsafe static bool TryUInt128ToBinaryStr<TChar>(Int128 value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (digits < 1)
		{
			digits = 1;
		}
		UInt128 value2 = (UInt128)value;
		int num = Math.Max(digits, 128 - (int)UInt128.LeadingZeroCount((UInt128)value));
		if (num > destination.Length)
		{
			charsWritten = 0;
			return false;
		}
		charsWritten = num;
		fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
		{
			UInt128ToBinaryChars(reference + num, value2, digits);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static TChar* UInt128ToBinaryChars<TChar>(TChar* buffer, UInt128 value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		ulong lower = value.Lower;
		ulong upper = value.Upper;
		if (upper != 0L)
		{
			buffer = UInt64ToBinaryChars(buffer, lower, 64);
			return UInt64ToBinaryChars(buffer, upper, digits - 64);
		}
		return UInt64ToBinaryChars(buffer, lower, Math.Max(digits, 1));
	}

	private unsafe static void UInt128ToNumber(UInt128 value, ref NumberBuffer number)
	{
		number.DigitsCount = 39;
		number.IsNegative = false;
		byte* digitsPtr = number.DigitsPtr;
		byte* ptr = UInt128ToDecChars(digitsPtr + 39, value, 0);
		int num = (number.Scale = (number.DigitsCount = (int)(digitsPtr + 39 - ptr)));
		byte* digitsPtr2 = number.DigitsPtr;
		while (--num >= 0)
		{
			*(digitsPtr2++) = *(ptr++);
		}
		*digitsPtr2 = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ulong Int128DivMod1E19(ref UInt128 value)
	{
		UInt128 uInt;
		(value, uInt) = UInt128.DivRem(right: new UInt128(0uL, 10000000000000000000uL), left: value);
		return uInt.Lower;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static TChar* UInt128ToDecChars<TChar>(TChar* bufferEnd, UInt128 value) where TChar : unmanaged, IUtfChar<TChar>
	{
		while (value.Upper != 0L)
		{
			bufferEnd = UInt64ToDecChars(bufferEnd, Int128DivMod1E19(ref value), 19);
		}
		return UInt64ToDecChars(bufferEnd, value.Lower);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static TChar* UInt128ToDecChars<TChar>(TChar* bufferEnd, UInt128 value, int digits) where TChar : unmanaged, IUtfChar<TChar>
	{
		while (value.Upper != 0L)
		{
			bufferEnd = UInt64ToDecChars(bufferEnd, Int128DivMod1E19(ref value), 19);
			digits -= 19;
		}
		return UInt64ToDecChars(bufferEnd, value.Lower, digits);
	}

	internal unsafe static string UInt128ToDecStr(UInt128 value)
	{
		if (value.Upper == 0L)
		{
			return UInt64ToDecStr(value.Lower);
		}
		int num = FormattingHelpers.CountDigits(value);
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt128ToDecChars(ptr + num, value);
		}
		return text;
	}

	internal unsafe static string UInt128ToDecStr(UInt128 value, int digits)
	{
		if (digits <= 1)
		{
			return UInt128ToDecStr(value);
		}
		int num = Math.Max(digits, FormattingHelpers.CountDigits(value));
		string text = string.FastAllocateString(num);
		fixed (char* ptr = text)
		{
			UInt128ToDecChars(ptr + num, value, digits);
		}
		return text;
	}

	private unsafe static bool TryUInt128ToDecStr<TChar>(UInt128 value, int digits, Span<TChar> destination, out int charsWritten) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = FormattingHelpers.CountDigits(value);
		int num2 = Math.Max(digits, num);
		if (num2 <= destination.Length)
		{
			charsWritten = num2;
			fixed (TChar* reference = &MemoryMarshal.GetReference(destination))
			{
				TChar* bufferEnd = reference + num2;
				bufferEnd = ((digits > num) ? UInt128ToDecChars(bufferEnd, value, digits) : UInt128ToDecChars(bufferEnd, value));
			}
			return true;
		}
		charsWritten = 0;
		return false;
	}

	private static ulong ExtractFractionAndBiasedExponent<TNumber>(TNumber value, out int exponent) where TNumber : unmanaged, IBinaryFloatParseAndFormatInfo<TNumber>
	{
		ulong num = TNumber.FloatToBits(value);
		ulong num2 = num & TNumber.DenormalMantissaMask;
		exponent = (int)(num >> (int)TNumber.DenormalMantissaBits) & TNumber.InfinityExponent;
		if (exponent != 0)
		{
			num2 |= (ulong)(1L << (int)TNumber.DenormalMantissaBits);
			exponent -= TNumber.ExponentBias + TNumber.DenormalMantissaBits;
		}
		else
		{
			exponent = TNumber.MinBinaryExponent - TNumber.DenormalMantissaBits;
		}
		return num2;
	}

	private unsafe static void AccumulateDecimalDigitsIntoBigInteger(scoped ref NumberBuffer number, uint firstIndex, uint lastIndex, out BigInteger result)
	{
		BigInteger.SetZero(out result);
		byte* ptr = number.DigitsPtr + firstIndex;
		uint num = lastIndex - firstIndex;
		while (num != 0)
		{
			uint num2 = Math.Min(num, 9u);
			uint value = DigitsToUInt32(ptr, (int)num2);
			result.MultiplyPow10(num2);
			result.Add(value);
			ptr += num2;
			num -= num2;
		}
	}

	private static ulong AssembleFloatingPointBits<TFloat>(ulong initialMantissa, int initialExponent, bool hasZeroTail) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		uint num = BigInteger.CountSignificantBits(initialMantissa);
		int num2 = (int)(TFloat.NormalMantissaBits - num);
		int num3 = initialExponent - num2;
		ulong num4 = initialMantissa;
		int num5 = num3;
		if (num3 > TFloat.MaxBinaryExponent)
		{
			return TFloat.InfinityBits;
		}
		if (num3 < TFloat.MinBinaryExponent)
		{
			int num6 = num2 + num3 + TFloat.ExponentBias - 1;
			num5 = -TFloat.ExponentBias;
			if (num6 < 0)
			{
				num4 = RightShiftWithRounding(num4, -num6, hasZeroTail);
				if (num4 == 0L)
				{
					return TFloat.ZeroBits;
				}
				if (num4 > TFloat.DenormalMantissaMask)
				{
					num5 = initialExponent - (num6 + 1) - num2;
				}
			}
			else
			{
				num4 <<= num6;
			}
		}
		else if (num2 < 0)
		{
			num4 = RightShiftWithRounding(num4, -num2, hasZeroTail);
			if (num4 > TFloat.NormalMantissaMask)
			{
				num4 >>= 1;
				num5++;
				if (num5 > TFloat.MaxBinaryExponent)
				{
					return TFloat.InfinityBits;
				}
			}
		}
		else if (num2 > 0)
		{
			num4 <<= num2;
		}
		num4 &= TFloat.DenormalMantissaMask;
		return (ulong)((long)(num5 + TFloat.ExponentBias) << (int)TFloat.DenormalMantissaBits) | num4;
	}

	private static ulong ConvertBigIntegerToFloatingPointBits<TFloat>(ref BigInteger value, uint integerBitsOfPrecision, bool hasNonZeroFractionalPart) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		int denormalMantissaBits = TFloat.DenormalMantissaBits;
		if (integerBitsOfPrecision <= 64)
		{
			return AssembleFloatingPointBits<TFloat>(value.ToUInt64(), denormalMantissaBits, !hasNonZeroFractionalPart);
		}
		(uint Quotient, uint Remainder) tuple = Math.DivRem(integerBitsOfPrecision, 32u);
		uint item = tuple.Quotient;
		uint item2 = tuple.Remainder;
		uint num = item - 1;
		uint num2 = num - 1;
		int num3 = denormalMantissaBits + (int)(num2 * 32);
		bool flag = !hasNonZeroFractionalPart;
		ulong initialMantissa;
		if (item2 == 0)
		{
			initialMantissa = ((ulong)value.GetBlock(num) << 32) + value.GetBlock(num2);
		}
		else
		{
			int num4 = (int)item2;
			int num5 = 64 - num4;
			int num6 = num5 - 32;
			num3 += (int)item2;
			uint block = value.GetBlock(num2);
			uint num7 = block >> num4;
			ulong num8 = (ulong)value.GetBlock(num) << num6;
			initialMantissa = ((ulong)value.GetBlock(item) << num5) + num8 + num7;
			uint num9 = (uint)((1 << (int)item2) - 1);
			flag = flag && (block & num9) == 0;
		}
		for (uint num10 = 0u; num10 != num2; num10++)
		{
			flag &= value.GetBlock(num10) == 0;
		}
		return AssembleFloatingPointBits<TFloat>(initialMantissa, num3, flag);
	}

	private unsafe static uint DigitsToUInt32(byte* p, int count)
	{
		byte* ptr = p + count;
		uint num = 0u;
		while (p <= ptr - 8)
		{
			num = num * 100000000 + ParseEightDigitsUnrolled(p);
			p += 8;
		}
		while (p != ptr)
		{
			num = 10 * num + *p - 48;
			p++;
		}
		return num;
	}

	private unsafe static ulong DigitsToUInt64(byte* p, int count)
	{
		byte* ptr = p + count;
		ulong num = 0uL;
		while (ptr - p >= 8)
		{
			num = num * 100000000 + ParseEightDigitsUnrolled(p);
			p += 8;
		}
		while (p != ptr)
		{
			num = 10 * num + *p - 48;
			p++;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static uint ParseEightDigitsUnrolled(byte* chars)
	{
		ulong num = Unsafe.ReadUnaligned<ulong>(chars);
		if (!BitConverter.IsLittleEndian)
		{
		}
		num -= 3472328296227680304L;
		num = num * 10 + (num >> 8);
		num = (num & 0xFF000000FFL) * 4294967296000100L + ((num >> 16) & 0xFF000000FFL) * 42949672960001L >> 32;
		return (uint)num;
	}

	private unsafe static ulong NumberToFloatingPointBits<TFloat>(ref NumberBuffer number) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		uint digitsCount = (uint)number.DigitsCount;
		uint num = (uint)Math.Max(0, number.Scale);
		uint num2 = Math.Min(num, digitsCount);
		uint num3 = digitsCount - num2;
		if (digitsCount <= 19)
		{
			ulong num4 = DigitsToUInt64(number.DigitsPtr, (int)digitsCount);
			int num5 = (int)(number.Scale - num2 - num3);
			int num6 = Math.Abs(num5);
			if (num4 <= TFloat.MaxMantissaFastPath && num6 <= TFloat.MaxExponentFastPath)
			{
				double num7 = num4;
				double num8 = Pow10DoubleTable[num6];
				num7 = ((num3 == 0) ? (num7 * num8) : (num7 / num8));
				return TFloat.FloatToBits(TFloat.CreateSaturating(num7));
			}
			(int, ulong) tuple = ComputeFloat<TFloat>(num5, num4);
			if (tuple.Item1 > 0)
			{
				return tuple.Item2 | ((ulong)(uint)tuple.Item1 << (int)TFloat.DenormalMantissaBits);
			}
		}
		return NumberToFloatingPointBitsSlow<TFloat>(ref number, num, num2, num3);
	}

	private static ulong NumberToFloatingPointBitsSlow<TFloat>(ref NumberBuffer number, uint positiveExponent, uint integerDigitsPresent, uint fractionalDigitsPresent) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		uint num = (uint)(TFloat.NormalMantissaBits + 1);
		uint digitsCount = (uint)number.DigitsCount;
		uint num2 = positiveExponent - integerDigitsPresent;
		uint lastIndex = digitsCount;
		AccumulateDecimalDigitsIntoBigInteger(ref number, 0u, integerDigitsPresent, out var result);
		if (num2 != 0)
		{
			if (num2 > TFloat.OverflowDecimalExponent)
			{
				return TFloat.InfinityBits;
			}
			result.MultiplyPow10(num2);
		}
		uint num3 = BigInteger.CountSignificantBits(ref result);
		if (num3 >= num || fractionalDigitsPresent == 0)
		{
			return ConvertBigIntegerToFloatingPointBits<TFloat>(ref result, num3, fractionalDigitsPresent != 0);
		}
		uint num4 = fractionalDigitsPresent;
		if (number.Scale < 0)
		{
			num4 += (uint)(-number.Scale);
		}
		if (num3 == 0 && num4 - (int)digitsCount > TFloat.OverflowDecimalExponent)
		{
			return TFloat.ZeroBits;
		}
		AccumulateDecimalDigitsIntoBigInteger(ref number, integerDigitsPresent, lastIndex, out var result2);
		if (result2.IsZero())
		{
			return ConvertBigIntegerToFloatingPointBits<TFloat>(ref result, num3, fractionalDigitsPresent != 0);
		}
		BigInteger.Pow10(num4, out var result3);
		uint num5 = BigInteger.CountSignificantBits(ref result2);
		uint num6 = BigInteger.CountSignificantBits(ref result3);
		uint num7 = 0u;
		if (num6 > num5)
		{
			num7 = num6 - num5;
		}
		if (num7 != 0)
		{
			result2.ShiftLeft(num7);
		}
		uint num8 = num - num3;
		uint num9 = num8;
		if (num3 != 0)
		{
			if (num7 > num9)
			{
				return ConvertBigIntegerToFloatingPointBits<TFloat>(ref result, num3, fractionalDigitsPresent != 0);
			}
			num9 -= num7;
		}
		uint num10 = num7;
		if (BigInteger.Compare(ref result2, ref result3) < 0)
		{
			num10++;
		}
		result2.ShiftLeft(num9);
		BigInteger.DivRem(ref result2, ref result3, out var quo, out var rem);
		ulong num11 = quo.ToUInt64();
		bool flag = !number.HasNonZeroTail && rem.IsZero();
		uint num12 = BigInteger.CountSignificantBits(num11);
		if (num12 > num8)
		{
			int num13 = (int)(num12 - num8);
			flag = flag && (num11 & (ulong)((1L << num13) - 1)) == 0;
			num11 >>= num13;
		}
		ulong initialMantissa = (result.ToUInt64() << (int)num8) + num11;
		int initialExponent = (int)((num3 != 0) ? (num3 - 2) : (0 - num10 - 1));
		return AssembleFloatingPointBits<TFloat>(initialMantissa, initialExponent, flag);
	}

	private static ulong RightShiftWithRounding(ulong value, int shift, bool hasZeroTail)
	{
		if (shift >= 64)
		{
			return 0uL;
		}
		ulong num = (ulong)((1L << shift - 1) - 1);
		ulong num2 = (ulong)(1L << shift - 1);
		ulong num3 = (ulong)(1L << shift);
		bool lsbBit = (value & num3) != 0;
		bool roundBit = (value & num2) != 0;
		bool hasTailBits = !hasZeroTail || (value & num) != 0;
		return (value >> shift) + (ulong)(ShouldRoundUp(lsbBit, roundBit, hasTailBits) ? 1 : 0);
	}

	private static bool ShouldRoundUp(bool lsbBit, bool roundBit, bool hasTailBits)
	{
		if (roundBit)
		{
			return hasTailBits || lsbBit;
		}
		return false;
	}

	internal static (int Exponent, ulong Mantissa) ComputeFloat<TFloat>(long q, ulong w) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		ulong item = 0uL;
		if (w == 0L || q < TFloat.MinFastFloatDecimalExponent)
		{
			return default((int, ulong));
		}
		int infinityExponent;
		if (q > TFloat.MaxFastFloatDecimalExponent)
		{
			infinityExponent = TFloat.InfinityExponent;
			item = 0uL;
			return (Exponent: infinityExponent, Mantissa: item);
		}
		int num = BitOperations.LeadingZeroCount(w);
		w <<= num;
		(ulong, ulong) tuple = ComputeProductApproximation(TFloat.DenormalMantissaBits + 3, q, w);
		if (tuple.Item2 == ulong.MaxValue && (q < -27 || q > 55))
		{
			infinityExponent = -1;
			return (Exponent: infinityExponent, Mantissa: item);
		}
		int num2 = (int)(tuple.Item1 >> 63);
		item = tuple.Item1 >> num2 + 64 - TFloat.DenormalMantissaBits - 3;
		infinityExponent = CalculatePower((int)q) + num2 - num - -TFloat.MaxBinaryExponent;
		if (infinityExponent <= 0)
		{
			if (-infinityExponent + 1 >= 64)
			{
				infinityExponent = 0;
				item = 0uL;
				return (Exponent: infinityExponent, Mantissa: item);
			}
			item >>= -infinityExponent + 1;
			item += item & 1;
			item >>= 1;
			infinityExponent = ((item >= (ulong)(1L << (int)TFloat.DenormalMantissaBits)) ? 1 : 0);
			return (Exponent: infinityExponent, Mantissa: item);
		}
		if (tuple.Item2 <= 1 && q >= TFloat.MinExponentRoundToEven && q <= TFloat.MaxExponentRoundToEven && (item & 3) == 1 && item << num2 + 64 - TFloat.DenormalMantissaBits - 3 == tuple.Item1)
		{
			item &= 0xFFFFFFFFFFFFFFFEuL;
		}
		item += item & 1;
		item >>= 1;
		if (item >= (ulong)(2L << (int)TFloat.DenormalMantissaBits))
		{
			item = (ulong)(1L << (int)TFloat.DenormalMantissaBits);
			infinityExponent++;
		}
		item &= (ulong)(~(1L << (int)TFloat.DenormalMantissaBits));
		if (infinityExponent >= TFloat.InfinityExponent)
		{
			infinityExponent = TFloat.InfinityExponent;
			item = 0uL;
		}
		return (Exponent: infinityExponent, Mantissa: item);
	}

	private static (ulong high, ulong low) ComputeProductApproximation(int bitPrecision, long q, ulong w)
	{
		int num = 2 * (int)(q - -342);
		ulong low;
		ulong num2 = Math.BigMul(w, Pow5128Table[num], out low);
		ulong num3 = ((bitPrecision < 64) ? (ulong.MaxValue >> bitPrecision) : ulong.MaxValue);
		if ((num2 & num3) == num3)
		{
			ulong low2;
			ulong num4 = Math.BigMul(w, Pow5128Table[num + 1], out low2);
			low += num4;
			if (num4 > low)
			{
				num2++;
			}
		}
		return (high: num2, low: low);
	}

	internal static int CalculatePower(int q)
	{
		return (217706 * q >> 16) + 63;
	}

	private unsafe static bool TryNumberBufferToBinaryInteger<TInteger>(ref NumberBuffer number, ref TInteger value) where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		int num = number.Scale;
		if (num > TInteger.MaxDigitCount || num < number.DigitsCount || (!TInteger.IsSigned && number.IsNegative) || number.HasNonZeroTail)
		{
			return false;
		}
		byte* digitsPtr = number.DigitsPtr;
		TInteger val = TInteger.Zero;
		while (--num >= 0)
		{
			if (TInteger.IsGreaterThanAsUnsigned(val, TInteger.MaxValueDiv10))
			{
				return false;
			}
			val = TInteger.MultiplyBy10(val);
			if (*digitsPtr != 0)
			{
				TInteger val2 = val + TInteger.CreateTruncating(*(digitsPtr++) - 48);
				if (!TInteger.IsSigned && val2 < val)
				{
					return false;
				}
				val = val2;
			}
		}
		if (TInteger.IsSigned)
		{
			if (number.IsNegative)
			{
				val = -val;
				if (val > TInteger.Zero)
				{
					return false;
				}
			}
			else if (val < TInteger.Zero)
			{
				return false;
			}
		}
		value = val;
		return true;
	}

	internal static TInteger ParseBinaryInteger<TChar, TInteger>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		TInteger result;
		ParsingStatus parsingStatus = TryParseBinaryInteger<TChar, TInteger>(value, styles, info, out result);
		if (parsingStatus != ParsingStatus.OK)
		{
			ThrowOverflowOrFormatException<TChar, TInteger>(parsingStatus, value);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ParsingStatus TryParseBinaryInteger<TChar, TInteger>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info, out TInteger result) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		if ((styles & ~NumberStyles.Integer) == 0)
		{
			return TryParseBinaryIntegerStyle<TChar, TInteger>(value, styles, info, out result);
		}
		if ((styles & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
		{
			return TryParseBinaryIntegerHexNumberStyle<TChar, TInteger>(value, styles, out result);
		}
		if ((styles & NumberStyles.AllowBinarySpecifier) != NumberStyles.None)
		{
			return TryParseBinaryIntegerHexOrBinaryNumberStyle<TChar, TInteger, BinaryParser<TInteger>>(value, styles, out result);
		}
		return TryParseBinaryIntegerNumber<TChar, TInteger>(value, styles, info, out result);
	}

	private static ParsingStatus TryParseBinaryIntegerNumber<TChar, TInteger>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info, out TInteger result) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		result = TInteger.Zero;
		Span<byte> digits = stackalloc byte[TInteger.MaxDigitCount + 1];
		NumberBuffer number = new NumberBuffer(NumberBufferKind.Integer, digits);
		if (!TryStringToNumber(value, styles, ref number, info))
		{
			return ParsingStatus.Failed;
		}
		if (!TryNumberBufferToBinaryInteger(ref number, ref result))
		{
			return ParsingStatus.Overflow;
		}
		return ParsingStatus.OK;
	}

	internal static ParsingStatus TryParseBinaryIntegerStyle<TChar, TInteger>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info, out TInteger result) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		int i;
		uint num;
		if (!value.IsEmpty)
		{
			i = 0;
			num = TChar.CastToUInt32(value[0]);
			if ((styles & NumberStyles.AllowLeadingWhite) == 0 || !IsWhite(num))
			{
				goto IL_0066;
			}
			while (true)
			{
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					break;
				}
				num = TChar.CastToUInt32(value[i]);
				if (IsWhite(num))
				{
					continue;
				}
				goto IL_0066;
			}
		}
		goto IL_04ab;
		IL_04d7:
		if (IsWhite(num))
		{
			if ((styles & NumberStyles.AllowTrailingWhite) == 0)
			{
				goto IL_04ab;
			}
			for (i++; i < value.Length && IsWhite(TChar.CastToUInt32(value[i])); i++)
			{
			}
			if ((uint)i >= (uint)value.Length)
			{
				goto IL_0471;
			}
		}
		if (TrailingZeros(value, i))
		{
			goto IL_0471;
		}
		goto IL_04ab;
		IL_0471:
		bool flag;
		if (!flag)
		{
			goto IL_0474;
		}
		goto IL_04c1;
		IL_0245:
		TInteger val = TInteger.CreateTruncating(num - 48);
		i++;
		int num2 = 0;
		while (num2 < TInteger.MaxDigitCount - 2)
		{
			if ((uint)i >= (uint)value.Length)
			{
				goto IL_0269;
			}
			num = TChar.CastToUInt32(value[i]);
			if (IsDigit(num))
			{
				i++;
				val = TInteger.MultiplyBy10(val);
				val += TInteger.CreateTruncating(num - 48);
				num2++;
				continue;
			}
			goto IL_04d7;
		}
		if ((uint)i >= (uint)value.Length)
		{
			if (!TInteger.IsSigned)
			{
				goto IL_0471;
			}
			goto IL_0474;
		}
		num = TChar.CastToUInt32(value[i]);
		bool flag2;
		if (IsDigit(num))
		{
			i++;
			flag = (TInteger.IsSigned ? (val > TInteger.MaxValueDiv10) : (flag | (val > TInteger.MaxValueDiv10 || (val == TInteger.MaxValueDiv10 && num > 53))));
			val = TInteger.MultiplyBy10(val);
			val += TInteger.CreateTruncating(num - 48);
			if (TInteger.IsSigned)
			{
				flag |= TInteger.IsGreaterThanAsUnsigned(val, TInteger.MaxValue + (flag2 ? TInteger.One : TInteger.Zero));
			}
			if ((uint)i >= (uint)value.Length)
			{
				goto IL_0471;
			}
			num = TChar.CastToUInt32(value[i]);
			while (IsDigit(num))
			{
				flag = true;
				i++;
				if ((uint)i < (uint)value.Length)
				{
					num = TChar.CastToUInt32(value[i]);
					continue;
				}
				goto IL_04c1;
			}
		}
		goto IL_04d7;
		IL_04c1:
		result = TInteger.Zero;
		return ParsingStatus.Overflow;
		IL_0066:
		flag2 = false;
		if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None)
		{
			if (info.HasInvariantNumberSigns)
			{
				if (num == 45)
				{
					flag2 = true;
					i++;
					if ((uint)i >= (uint)value.Length)
					{
						goto IL_04ab;
					}
					num = TChar.CastToUInt32(value[i]);
				}
				else if (num == 43)
				{
					i++;
					if ((uint)i >= (uint)value.Length)
					{
						goto IL_04ab;
					}
					num = TChar.CastToUInt32(value[i]);
				}
			}
			else if (info.AllowHyphenDuringParsing() && num == 45)
			{
				flag2 = true;
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					goto IL_04ab;
				}
				num = TChar.CastToUInt32(value[i]);
			}
			else
			{
				value = value.Slice(i);
				i = 0;
				ReadOnlySpan<TChar> value2 = info.PositiveSignTChar<TChar>();
				ReadOnlySpan<TChar> value3 = info.NegativeSignTChar<TChar>();
				if (!value2.IsEmpty && value.StartsWith(value2))
				{
					i += value2.Length;
					if ((uint)i >= (uint)value.Length)
					{
						goto IL_04ab;
					}
					num = TChar.CastToUInt32(value[i]);
				}
				else if (!value3.IsEmpty && value.StartsWith(value3))
				{
					flag2 = true;
					i += value3.Length;
					if ((uint)i >= (uint)value.Length)
					{
						goto IL_04ab;
					}
					num = TChar.CastToUInt32(value[i]);
				}
			}
		}
		flag = !TInteger.IsSigned && flag2;
		val = TInteger.Zero;
		if (IsDigit(num))
		{
			if (num != 48)
			{
				goto IL_0245;
			}
			while (true)
			{
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					break;
				}
				num = TChar.CastToUInt32(value[i]);
				if (num == 48)
				{
					continue;
				}
				goto IL_0226;
			}
			goto IL_0474;
		}
		goto IL_04ab;
		IL_0269:
		if (!TInteger.IsSigned)
		{
			goto IL_0471;
		}
		goto IL_0474;
		IL_0226:
		if (IsDigit(num))
		{
			goto IL_0245;
		}
		if (!TInteger.IsSigned)
		{
			flag = false;
		}
		goto IL_04d7;
		IL_0474:
		if (!TInteger.IsSigned)
		{
			result = val;
		}
		else
		{
			result = (flag2 ? (-val) : val);
		}
		return ParsingStatus.OK;
		IL_04ab:
		result = TInteger.Zero;
		return ParsingStatus.Failed;
	}

	internal static ParsingStatus TryParseBinaryIntegerHexNumberStyle<TChar, TInteger>(ReadOnlySpan<TChar> value, NumberStyles styles, out TInteger result) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		return TryParseBinaryIntegerHexOrBinaryNumberStyle<TChar, TInteger, HexParser<TInteger>>(value, styles, out result);
	}

	private static ParsingStatus TryParseBinaryIntegerHexOrBinaryNumberStyle<TChar, TInteger, TParser>(ReadOnlySpan<TChar> value, NumberStyles styles, out TInteger result) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger> where TParser : struct, IHexOrBinaryParser<TInteger>
	{
		int i;
		uint num;
		if (!value.IsEmpty)
		{
			i = 0;
			num = TChar.CastToUInt32(value[0]);
			if ((styles & NumberStyles.AllowLeadingWhite) == 0 || !IsWhite(num))
			{
				goto IL_0066;
			}
			while (true)
			{
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					break;
				}
				num = TChar.CastToUInt32(value[i]);
				if (IsWhite(num))
				{
					continue;
				}
				goto IL_0066;
			}
		}
		goto IL_01f0;
		IL_00ca:
		TInteger val = TInteger.CreateTruncating(TParser.FromChar(num));
		i++;
		int num2 = 0;
		while (num2 < TParser.MaxDigitCount - 1)
		{
			if ((uint)i >= (uint)value.Length)
			{
				goto IL_01e3;
			}
			num = TChar.CastToUInt32(value[i]);
			uint num3 = TParser.FromChar(num);
			if (num3 <= TParser.MaxDigitValue)
			{
				i++;
				val = TParser.ShiftLeftForNextDigit(val);
				val += TInteger.CreateTruncating(num3);
				num2++;
				continue;
			}
			goto IL_021c;
		}
		if ((uint)i >= (uint)value.Length)
		{
			goto IL_01e3;
		}
		num = TChar.CastToUInt32(value[i]);
		if (TParser.IsValidChar(num))
		{
			while (true)
			{
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					break;
				}
				num = TChar.CastToUInt32(value[i]);
				if (TParser.IsValidChar(num))
				{
					continue;
				}
				goto IL_01dc;
			}
			goto IL_0206;
		}
		goto IL_021c;
		IL_0206:
		result = TInteger.Zero;
		return ParsingStatus.Overflow;
		IL_01e0:
		bool flag;
		if (!flag)
		{
			goto IL_01e3;
		}
		goto IL_0206;
		IL_01f0:
		result = TInteger.Zero;
		return ParsingStatus.Failed;
		IL_0066:
		flag = false;
		val = TInteger.Zero;
		if (TParser.IsValidChar(num))
		{
			if (num != 48)
			{
				goto IL_00ca;
			}
			while (true)
			{
				i++;
				if ((uint)i >= (uint)value.Length)
				{
					break;
				}
				num = TChar.CastToUInt32(value[i]);
				if (num == 48)
				{
					continue;
				}
				goto IL_00b9;
			}
			goto IL_01e3;
		}
		goto IL_01f0;
		IL_01dc:
		flag = true;
		goto IL_021c;
		IL_021c:
		if (IsWhite(num))
		{
			if ((styles & NumberStyles.AllowTrailingWhite) == 0)
			{
				goto IL_01f0;
			}
			for (i++; i < value.Length && IsWhite(TChar.CastToUInt32(value[i])); i++)
			{
			}
			if ((uint)i >= (uint)value.Length)
			{
				goto IL_01e0;
			}
		}
		if (TrailingZeros(value, i))
		{
			goto IL_01e0;
		}
		goto IL_01f0;
		IL_01e3:
		result = val;
		return ParsingStatus.OK;
		IL_00b9:
		if (TParser.IsValidChar(num))
		{
			goto IL_00ca;
		}
		goto IL_021c;
	}

	internal static decimal ParseDecimal<TChar>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		decimal result;
		ParsingStatus parsingStatus = TryParseDecimal(value, styles, info, out result);
		if (parsingStatus != ParsingStatus.OK)
		{
			if (parsingStatus == ParsingStatus.Failed)
			{
				ThrowFormatException(value);
			}
			ThrowOverflowException("Overflow_Decimal");
		}
		return result;
	}

	internal unsafe static bool TryNumberToDecimal(ref NumberBuffer number, ref decimal value)
	{
		byte* ptr = number.DigitsPtr;
		int num = number.Scale;
		bool isNegative = number.IsNegative;
		uint num2 = *ptr;
		if (num2 == 0)
		{
			value = new decimal(0, 0, 0, isNegative, (byte)Math.Clamp(-num, 0, 28));
			return true;
		}
		if (num > 29)
		{
			return false;
		}
		ulong num3 = 0uL;
		while (num > -28)
		{
			num--;
			num3 *= 10;
			num3 += num2 - 48;
			num2 = *(++ptr);
			if (num3 >= 1844674407370955161L)
			{
				break;
			}
			if (num2 != 0)
			{
				continue;
			}
			while (num > 0)
			{
				num--;
				num3 *= 10;
				if (num3 >= 1844674407370955161L)
				{
					break;
				}
			}
			break;
		}
		uint num4 = 0u;
		while ((num > 0 || (num2 != 0 && num > -28)) && (num4 < 429496729 || (num4 == 429496729 && (num3 < 11068046444225730969uL || (num3 == 11068046444225730969uL && num2 <= 53)))))
		{
			ulong num5 = (ulong)(uint)num3 * 10uL;
			ulong num6 = (ulong)((long)(uint)(num3 >> 32) * 10L) + (num5 >> 32);
			num3 = (uint)num5 + (num6 << 32);
			num4 = (uint)(int)(num6 >> 32) + num4 * 10;
			if (num2 != 0)
			{
				num2 -= 48;
				num3 += num2;
				if (num3 < num2)
				{
					num4++;
				}
				num2 = *(++ptr);
			}
			num--;
		}
		if (num2 >= 53)
		{
			if (num2 == 53 && (num3 & 1) == 0L)
			{
				num2 = *(++ptr);
				bool flag = !number.HasNonZeroTail;
				while (num2 != 0 && flag)
				{
					flag = flag && num2 == 48;
					num2 = *(++ptr);
				}
				if (flag)
				{
					goto IL_01a8;
				}
			}
			if (++num3 == 0L && ++num4 == 0)
			{
				num3 = 11068046444225730970uL;
				num4 = 429496729u;
				num++;
			}
		}
		goto IL_01a8;
		IL_01a8:
		if (num > 0)
		{
			return false;
		}
		if (num <= -29)
		{
			value = new decimal(0, 0, 0, isNegative, 28);
		}
		else
		{
			value = new decimal((int)num3, (int)(num3 >> 32), (int)num4, isNegative, (byte)(-num));
		}
		return true;
	}

	internal static TFloat ParseFloat<TChar, TFloat>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar> where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		if (!TryParseFloat<TChar, TFloat>(value, styles, info, out var result))
		{
			ThrowFormatException(value);
		}
		return result;
	}

	internal static ParsingStatus TryParseDecimal<TChar>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info, out decimal result) where TChar : unmanaged, IUtfChar<TChar>
	{
		Span<byte> digits = stackalloc byte[31];
		NumberBuffer number = new NumberBuffer(NumberBufferKind.Decimal, digits);
		result = default(decimal);
		if (!TryStringToNumber(value, styles, ref number, info))
		{
			return ParsingStatus.Failed;
		}
		if (!TryNumberToDecimal(ref number, ref result))
		{
			return ParsingStatus.Overflow;
		}
		return ParsingStatus.OK;
	}

	internal static bool SpanStartsWith<TChar>(ReadOnlySpan<TChar> span, TChar c) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (!span.IsEmpty)
		{
			return span[0] == c;
		}
		return false;
	}

	internal static bool SpanStartsWith<TChar>(ReadOnlySpan<TChar> span, ReadOnlySpan<TChar> value, StringComparison comparisonType) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (typeof(TChar) == typeof(char))
		{
			ReadOnlySpan<char> span2 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(span);
			ReadOnlySpan<char> value2 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(value);
			return span2.StartsWith(value2, comparisonType);
		}
		ReadOnlySpan<byte> span3 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(span);
		ReadOnlySpan<byte> value3 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(value);
		return span3.StartsWithUtf8(value3, comparisonType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ReadOnlySpan<TChar> SpanTrim<TChar>(ReadOnlySpan<TChar> span) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (typeof(TChar) == typeof(char))
		{
			return Unsafe.BitCast<ReadOnlySpan<char>, ReadOnlySpan<TChar>>(Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(span).Trim());
		}
		return Unsafe.BitCast<ReadOnlySpan<byte>, ReadOnlySpan<TChar>>(Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(span).TrimUtf8());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool SpanEqualsOrdinalIgnoreCase<TChar>(ReadOnlySpan<TChar> span, ReadOnlySpan<TChar> value) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (typeof(TChar) == typeof(char))
		{
			ReadOnlySpan<char> span2 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(span);
			ReadOnlySpan<char> value2 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<char>>(value);
			return span2.EqualsOrdinalIgnoreCase(value2);
		}
		ReadOnlySpan<byte> span3 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(span);
		ReadOnlySpan<byte> value3 = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(value);
		return span3.EqualsOrdinalIgnoreCaseUtf8(value3);
	}

	internal static bool TryParseFloat<TChar, TFloat>(ReadOnlySpan<TChar> value, NumberStyles styles, NumberFormatInfo info, out TFloat result) where TChar : unmanaged, IUtfChar<TChar> where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		Span<byte> digits = stackalloc byte[TFloat.NumberBufferLength];
		NumberBuffer number = new NumberBuffer(NumberBufferKind.FloatingPoint, digits);
		if (!TryStringToNumber(value, styles, ref number, info))
		{
			ReadOnlySpan<TChar> span = SpanTrim(value);
			ReadOnlySpan<TChar> value2 = info.PositiveInfinitySymbolTChar<TChar>();
			if (SpanEqualsOrdinalIgnoreCase(span, value2))
			{
				result = TFloat.PositiveInfinity;
				return true;
			}
			if (SpanEqualsOrdinalIgnoreCase(span, info.NegativeInfinitySymbolTChar<TChar>()))
			{
				result = TFloat.NegativeInfinity;
				return true;
			}
			ReadOnlySpan<TChar> value3 = info.NaNSymbolTChar<TChar>();
			if (SpanEqualsOrdinalIgnoreCase(span, value3))
			{
				result = TFloat.NaN;
				return true;
			}
			ReadOnlySpan<TChar> value4 = info.PositiveSignTChar<TChar>();
			if (SpanStartsWith(span, value4, StringComparison.OrdinalIgnoreCase))
			{
				span = span.Slice(value4.Length);
				if (SpanEqualsOrdinalIgnoreCase(span, value2))
				{
					result = TFloat.PositiveInfinity;
					return true;
				}
				if (SpanEqualsOrdinalIgnoreCase(span, value3))
				{
					result = TFloat.NaN;
					return true;
				}
				result = TFloat.Zero;
				return false;
			}
			ReadOnlySpan<TChar> value5 = info.NegativeSignTChar<TChar>();
			if (SpanStartsWith(span, value5, StringComparison.OrdinalIgnoreCase))
			{
				if (SpanEqualsOrdinalIgnoreCase(span.Slice(value5.Length), value3))
				{
					result = TFloat.NaN;
					return true;
				}
				if (info.AllowHyphenDuringParsing() && SpanStartsWith(span, TChar.CastFrom('-')) && SpanEqualsOrdinalIgnoreCase(span.Slice(1), value3))
				{
					result = TFloat.NaN;
					return true;
				}
			}
			result = TFloat.Zero;
			return false;
		}
		result = NumberToFloat<TFloat>(ref number);
		return true;
	}

	[DoesNotReturn]
	internal static void ThrowOverflowOrFormatException<TChar, TInteger>(ParsingStatus status, ReadOnlySpan<TChar> value) where TChar : unmanaged, IUtfChar<TChar> where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		if (status == ParsingStatus.Failed)
		{
			ThrowFormatException(value);
		}
		ThrowOverflowException<TInteger>();
	}

	[DoesNotReturn]
	internal static void ThrowFormatException<TChar>(ReadOnlySpan<TChar> value) where TChar : unmanaged, IUtfChar<TChar>
	{
		string message;
		if (typeof(TChar) == typeof(byte))
		{
			ReadOnlySpan<byte> readOnlySpan = Unsafe.BitCast<ReadOnlySpan<TChar>, ReadOnlySpan<byte>>(value);
			message = (Utf8.IsValid(readOnlySpan) ? SR.Format("Format_InvalidStringWithValue", Encoding.UTF8.GetString(readOnlySpan)) : "Format_InvalidString");
		}
		else
		{
			message = SR.Format("Format_InvalidStringWithValue", value.ToString());
		}
		throw new FormatException(message);
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException<TInteger>() where TInteger : unmanaged, IBinaryIntegerParseAndFormatInfo<TInteger>
	{
		throw new OverflowException(TInteger.OverflowMessage);
	}

	[DoesNotReturn]
	internal static void ThrowOverflowException(string message)
	{
		throw new OverflowException(message);
	}

	internal static TFloat NumberToFloat<TFloat>(ref NumberBuffer number) where TFloat : unmanaged, IBinaryFloatParseAndFormatInfo<TFloat>
	{
		TFloat val = ((number.DigitsCount == 0 || number.Scale < TFloat.MinDecimalExponent) ? TFloat.Zero : ((number.Scale <= TFloat.MaxDecimalExponent) ? TFloat.BitsToFloat(NumberToFloatingPointBits<TFloat>(ref number)) : TFloat.PositiveInfinity));
		if (!number.IsNegative)
		{
			return val;
		}
		return -val;
	}

	internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits)
	{
		char c = '\0';
		if (format.Length > 0)
		{
			c = format[0];
			if (char.IsAsciiLetter(c))
			{
				if (format.Length == 1)
				{
					digits = -1;
					return c;
				}
				if (format.Length == 2)
				{
					int num = format[1] - 48;
					if ((uint)num < 10u)
					{
						digits = num;
						return c;
					}
				}
				else if (format.Length == 3)
				{
					int num2 = format[1] - 48;
					int num3 = format[2] - 48;
					if ((uint)num2 < 10u && (uint)num3 < 10u)
					{
						digits = num2 * 10 + num3;
						return c;
					}
				}
				int num4 = 0;
				int num5 = 1;
				while ((uint)num5 < (uint)format.Length && char.IsAsciiDigit(format[num5]))
				{
					if (num4 >= 100000000)
					{
						ThrowHelper.ThrowFormatException_BadFormatSpecifier();
					}
					num4 = num4 * 10 + format[num5++] - 48;
				}
				if ((uint)num5 >= (uint)format.Length || format[num5] == '\0')
				{
					digits = num4;
					return c;
				}
			}
		}
		digits = -1;
		if (format.Length != 0 && c != 0)
		{
			return '\0';
		}
		return 'G';
	}

	internal static void NumberToString<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, char format, int nMaxDigits, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		bool isCorrectlyRounded = number.Kind == NumberBufferKind.FloatingPoint;
		bool suppressScientific;
		switch (format)
		{
		case 'C':
		case 'c':
			if (nMaxDigits < 0)
			{
				nMaxDigits = info.CurrencyDecimalDigits;
			}
			RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
			FormatCurrency(ref vlb, ref number, nMaxDigits, info);
			break;
		case 'F':
		case 'f':
			if (nMaxDigits < 0)
			{
				nMaxDigits = info.NumberDecimalDigits;
			}
			RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
			if (number.IsNegative)
			{
				vlb.Append(info.NegativeSignTChar<TChar>());
			}
			FormatFixed(ref vlb, ref number, nMaxDigits, null, info.NumberDecimalSeparatorTChar<TChar>(), null);
			break;
		case 'N':
		case 'n':
			if (nMaxDigits < 0)
			{
				nMaxDigits = info.NumberDecimalDigits;
			}
			RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
			FormatNumber(ref vlb, ref number, nMaxDigits, info);
			break;
		case 'E':
		case 'e':
			if (nMaxDigits < 0)
			{
				nMaxDigits = 6;
			}
			nMaxDigits++;
			RoundNumber(ref number, nMaxDigits, isCorrectlyRounded);
			if (number.IsNegative)
			{
				vlb.Append(info.NegativeSignTChar<TChar>());
			}
			FormatScientific(ref vlb, ref number, nMaxDigits, info, format);
			break;
		case 'G':
		case 'g':
			suppressScientific = false;
			if (nMaxDigits < 1)
			{
				if (number.Kind == NumberBufferKind.Decimal && nMaxDigits == -1)
				{
					suppressScientific = true;
					if (number.Digits[0] != 0)
					{
						goto IL_018e;
					}
					goto IL_01a3;
				}
				nMaxDigits = number.DigitsCount;
			}
			RoundNumber(ref number, nMaxDigits, isCorrectlyRounded);
			goto IL_018e;
		case 'P':
		case 'p':
			if (nMaxDigits < 0)
			{
				nMaxDigits = info.PercentDecimalDigits;
			}
			number.Scale += 2;
			RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
			FormatPercent(ref vlb, ref number, nMaxDigits, info);
			break;
		case 'R':
		case 'r':
			format = (char)(format - 11);
			goto case 'G';
		default:
			{
				ThrowHelper.ThrowFormatException_BadFormatSpecifier();
				break;
			}
			IL_018e:
			if (number.IsNegative)
			{
				vlb.Append(info.NegativeSignTChar<TChar>());
			}
			goto IL_01a3;
			IL_01a3:
			FormatGeneral(ref vlb, ref number, nMaxDigits, info, (char)(format - 2), suppressScientific);
			break;
		}
	}

	internal unsafe static void NumberToStringFormat<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, ReadOnlySpan<char> format, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = 0;
		byte* digitsPtr = number.DigitsPtr;
		int num2 = FindSection(format, (*digitsPtr == 0) ? 2 : (number.IsNegative ? 1 : 0));
		int num3;
		int num4;
		bool flag;
		bool flag2;
		int num5;
		int num6;
		int num9;
		while (true)
		{
			num3 = 0;
			num4 = -1;
			num5 = int.MaxValue;
			num6 = 0;
			flag = false;
			int num7 = -1;
			flag2 = false;
			int num8 = 0;
			num9 = num2;
			fixed (char* reference = &MemoryMarshal.GetReference(format))
			{
				char c;
				while (num9 < format.Length && (c = reference[num9++]) != 0)
				{
					switch (c)
					{
					case ';':
						break;
					case '#':
						num3++;
						continue;
					case '0':
						if (num5 == int.MaxValue)
						{
							num5 = num3;
						}
						num3++;
						num6 = num3;
						continue;
					case '.':
						if (num4 < 0)
						{
							num4 = num3;
						}
						continue;
					case ',':
						if (num3 <= 0 || num4 >= 0)
						{
							continue;
						}
						if (num7 >= 0)
						{
							if (num7 == num3)
							{
								num++;
								continue;
							}
							flag2 = true;
						}
						num7 = num3;
						num = 1;
						continue;
					case '%':
						num8 += 2;
						continue;
					case '‰':
						num8 += 3;
						continue;
					case '"':
					case '\'':
						while (num9 < format.Length && reference[num9] != 0 && reference[num9++] != c)
						{
						}
						continue;
					case '\\':
						if (num9 < format.Length && reference[num9] != 0)
						{
							num9++;
						}
						continue;
					case 'E':
					case 'e':
						if ((num9 < format.Length && reference[num9] == '0') || (num9 + 1 < format.Length && (reference[num9] == '+' || reference[num9] == '-') && reference[num9 + 1] == '0'))
						{
							while (++num9 < format.Length && reference[num9] == '0')
							{
							}
							flag = true;
						}
						continue;
					default:
						continue;
					}
					break;
				}
			}
			if (num4 < 0)
			{
				num4 = num3;
			}
			if (num7 >= 0)
			{
				if (num7 == num4)
				{
					num8 -= num * 3;
				}
				else
				{
					flag2 = true;
				}
			}
			if (*digitsPtr != 0)
			{
				number.Scale += num8;
				int pos = (flag ? num3 : (number.Scale + num3 - num4));
				RoundNumber(ref number, pos, isCorrectlyRounded: false);
				if (*digitsPtr != 0)
				{
					break;
				}
				num9 = FindSection(format, 2);
				if (num9 == num2)
				{
					break;
				}
				num2 = num9;
				continue;
			}
			if (number.Kind != NumberBufferKind.FloatingPoint)
			{
				number.IsNegative = false;
			}
			number.Scale = 0;
			break;
		}
		num5 = ((num5 < num4) ? (num4 - num5) : 0);
		num6 = ((num6 > num4) ? (num4 - num6) : 0);
		int num10;
		int num11;
		if (flag)
		{
			num10 = num4;
			num11 = 0;
		}
		else
		{
			num10 = ((number.Scale > num4) ? number.Scale : num4);
			num11 = number.Scale - num4;
		}
		num9 = num2;
		Span<int> span = stackalloc int[4];
		int num12 = -1;
		if (flag2 && info.NumberGroupSeparator.Length > 0)
		{
			int[] array = info.NumberGroupSizes();
			int num13 = 0;
			int i = 0;
			int num14 = array.Length;
			if (num14 != 0)
			{
				i = array[num13];
			}
			int num15 = i;
			int num16 = num10 + ((num11 < 0) ? num11 : 0);
			for (int num17 = ((num5 > num16) ? num5 : num16); num17 > i; i += num15)
			{
				if (num15 == 0)
				{
					break;
				}
				num12++;
				if (num12 >= span.Length)
				{
					int[] array2 = new int[span.Length * 2];
					span.CopyTo(array2);
					span = array2;
				}
				span[num12] = i;
				if (num13 < num14 - 1)
				{
					num13++;
					num15 = array[num13];
				}
			}
		}
		if (number.IsNegative && num2 == 0 && number.Scale != 0)
		{
			vlb.Append(info.NegativeSignTChar<TChar>());
		}
		bool flag3 = false;
		fixed (char* reference2 = &MemoryMarshal.GetReference(format))
		{
			byte* ptr = digitsPtr;
			char c;
			while (num9 < format.Length && (c = reference2[num9++]) != 0 && c != ';')
			{
				if (num11 > 0 && (c == '#' || c == '.' || c == '0'))
				{
					while (num11 > 0)
					{
						vlb.Append(TChar.CastFrom((char)((*ptr != 0) ? (*(ptr++)) : 48)));
						if (flag2 && num10 > 1 && num12 >= 0 && num10 == span[num12] + 1)
						{
							vlb.Append(info.NumberGroupSeparatorTChar<TChar>());
							num12--;
						}
						num10--;
						num11--;
					}
				}
				switch (c)
				{
				case '#':
				case '0':
					if (num11 < 0)
					{
						num11++;
						c = ((num10 <= num5) ? '0' : '\0');
					}
					else
					{
						c = ((*ptr != 0) ? ((char)(*(ptr++))) : ((num10 > num6) ? '0' : '\0'));
					}
					if (c != 0)
					{
						vlb.Append(TChar.CastFrom(c));
						if (flag2 && num10 > 1 && num12 >= 0 && num10 == span[num12] + 1)
						{
							vlb.Append(info.NumberGroupSeparatorTChar<TChar>());
							num12--;
						}
					}
					num10--;
					break;
				case '.':
					if (!(num10 != 0 || flag3) && (num6 < 0 || (num4 < num3 && *ptr != 0)))
					{
						vlb.Append(info.NumberDecimalSeparatorTChar<TChar>());
						flag3 = true;
					}
					break;
				case '‰':
					vlb.Append(info.PerMilleSymbolTChar<TChar>());
					break;
				case '%':
					vlb.Append(info.PercentSymbolTChar<TChar>());
					break;
				case '"':
				case '\'':
					while (num9 < format.Length && reference2[num9] != 0 && reference2[num9] != c)
					{
						AppendUnknownChar(ref vlb, reference2[num9++]);
					}
					if (num9 < format.Length && reference2[num9] != 0)
					{
						num9++;
					}
					break;
				case '\\':
					if (num9 < format.Length && reference2[num9] != 0)
					{
						AppendUnknownChar(ref vlb, reference2[num9++]);
					}
					break;
				case 'E':
				case 'e':
				{
					bool positiveSign = false;
					int num18 = 0;
					if (flag)
					{
						if (num9 < format.Length && reference2[num9] == '0')
						{
							num18++;
						}
						else if (num9 + 1 < format.Length && reference2[num9] == '+' && reference2[num9 + 1] == '0')
						{
							positiveSign = true;
						}
						else if (num9 + 1 >= format.Length || reference2[num9] != '-' || reference2[num9 + 1] != '0')
						{
							vlb.Append(TChar.CastFrom(c));
							break;
						}
						while (++num9 < format.Length && reference2[num9] == '0')
						{
							num18++;
						}
						if (num18 > 10)
						{
							num18 = 10;
						}
						int value = ((*digitsPtr != 0) ? (number.Scale - num4) : 0);
						FormatExponent(ref vlb, info, value, c, num18, positiveSign);
						flag = false;
						break;
					}
					vlb.Append(TChar.CastFrom(c));
					if (num9 < format.Length)
					{
						if (reference2[num9] == '+' || reference2[num9] == '-')
						{
							AppendUnknownChar(ref vlb, reference2[num9++]);
						}
						while (num9 < format.Length && reference2[num9] == '0')
						{
							AppendUnknownChar(ref vlb, reference2[num9++]);
						}
					}
					break;
				}
				default:
					AppendUnknownChar(ref vlb, c);
					break;
				case ',':
					break;
				}
			}
		}
		if (number.IsNegative && num2 == 0 && number.Scale == 0 && vlb.Length > 0)
		{
			vlb.Insert(0, info.NegativeSignTChar<TChar>());
		}
	}

	private static void FormatCurrency<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		string text = (number.IsNegative ? s_negCurrencyFormats[info.CurrencyNegativePattern] : s_posCurrencyFormats[info.CurrencyPositivePattern]);
		foreach (char c in text)
		{
			switch (c)
			{
			case '#':
				FormatFixed(ref vlb, ref number, nMaxDigits, info.CurrencyGroupSizes(), info.CurrencyDecimalSeparatorTChar<TChar>(), info.CurrencyGroupSeparatorTChar<TChar>());
				break;
			case '-':
				vlb.Append(info.NegativeSignTChar<TChar>());
				break;
			case '$':
				vlb.Append(info.CurrencySymbolTChar<TChar>());
				break;
			default:
				vlb.Append(TChar.CastFrom(c));
				break;
			}
		}
	}

	private unsafe static void FormatFixed<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, int[] groupDigits, ReadOnlySpan<TChar> sDecimal, ReadOnlySpan<TChar> sGroup) where TChar : unmanaged, IUtfChar<TChar>
	{
		int num = number.Scale;
		byte* ptr = number.DigitsPtr;
		if (num > 0)
		{
			if (groupDigits != null)
			{
				int num2 = 0;
				int num3 = num;
				int num4 = 0;
				if (groupDigits.Length != 0)
				{
					int num5 = groupDigits[num2];
					while (num > num5 && groupDigits[num2] != 0)
					{
						num3 += sGroup.Length;
						if (num2 < groupDigits.Length - 1)
						{
							num2++;
						}
						num5 += groupDigits[num2];
						ArgumentOutOfRangeException.ThrowIfNegative(num5 | num3, string.Empty);
					}
					num4 = ((num5 != 0) ? groupDigits[0] : 0);
				}
				num2 = 0;
				int num6 = 0;
				int digitsCount = number.DigitsCount;
				int num7 = ((num < digitsCount) ? num : digitsCount);
				fixed (TChar* reference = &MemoryMarshal.GetReference(vlb.AppendSpan(num3)))
				{
					TChar* ptr2 = reference + num3 - 1;
					for (int num8 = num - 1; num8 >= 0; num8--)
					{
						*(ptr2--) = TChar.CastFrom((char)((num8 < num7) ? ptr[num8] : 48));
						if (num4 > 0)
						{
							num6++;
							if (num6 == num4 && num8 != 0)
							{
								for (int num9 = sGroup.Length - 1; num9 >= 0; num9--)
								{
									*(ptr2--) = sGroup[num9];
								}
								if (num2 < groupDigits.Length - 1)
								{
									num2++;
									num4 = groupDigits[num2];
								}
								num6 = 0;
							}
						}
					}
					ptr += num7;
				}
			}
			else
			{
				do
				{
					vlb.Append(TChar.CastFrom((char)((*ptr != 0) ? (*(ptr++)) : 48)));
				}
				while (--num > 0);
			}
		}
		else
		{
			vlb.Append(TChar.CastFrom('0'));
		}
		if (nMaxDigits <= 0)
		{
			return;
		}
		vlb.Append(sDecimal);
		if (num < 0 && nMaxDigits > 0)
		{
			int num10 = Math.Min(-num, nMaxDigits);
			for (int i = 0; i < num10; i++)
			{
				vlb.Append(TChar.CastFrom('0'));
			}
			num += num10;
			nMaxDigits -= num10;
		}
		while (nMaxDigits > 0)
		{
			vlb.Append(TChar.CastFrom((char)((*ptr != 0) ? (*(ptr++)) : 48)));
			nMaxDigits--;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void AppendUnknownChar<TChar>(ref ValueListBuilder<TChar> vlb, char ch) where TChar : unmanaged, IUtfChar<TChar>
	{
		if (sizeof(TChar) == 2 || char.IsAscii(ch))
		{
			vlb.Append(TChar.CastFrom(ch));
		}
		else
		{
			AppendNonAsciiBytes(ref vlb, ch);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void AppendNonAsciiBytes(ref ValueListBuilder<TChar> reference, char ch2)
		{
			Rune rune = new Rune(ch2);
			rune.EncodeToUtf8(MemoryMarshal.AsBytes(reference.AppendSpan(rune.Utf8SequenceLength)));
		}
	}

	private static void FormatNumber<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		string text = (number.IsNegative ? s_negNumberFormats[info.NumberNegativePattern] : "#");
		foreach (char c in text)
		{
			switch (c)
			{
			case '#':
				FormatFixed(ref vlb, ref number, nMaxDigits, info.NumberGroupSizes(), info.NumberDecimalSeparatorTChar<TChar>(), info.NumberGroupSeparatorTChar<TChar>());
				break;
			case '-':
				vlb.Append(info.NegativeSignTChar<TChar>());
				break;
			default:
				vlb.Append(TChar.CastFrom(c));
				break;
			}
		}
	}

	private unsafe static void FormatScientific<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, NumberFormatInfo info, char expChar) where TChar : unmanaged, IUtfChar<TChar>
	{
		byte* digitsPtr = number.DigitsPtr;
		vlb.Append(TChar.CastFrom((char)((*digitsPtr != 0) ? (*(digitsPtr++)) : 48)));
		if (nMaxDigits != 1)
		{
			vlb.Append(info.NumberDecimalSeparatorTChar<TChar>());
		}
		while (--nMaxDigits > 0)
		{
			vlb.Append(TChar.CastFrom((char)((*digitsPtr != 0) ? (*(digitsPtr++)) : 48)));
		}
		int value = ((number.Digits[0] != 0) ? (number.Scale - 1) : 0);
		FormatExponent(ref vlb, info, value, expChar, 3, positiveSign: true);
	}

	private unsafe static void FormatExponent<TChar>(ref ValueListBuilder<TChar> vlb, NumberFormatInfo info, int value, char expChar, int minDigits, bool positiveSign) where TChar : unmanaged, IUtfChar<TChar>
	{
		vlb.Append(TChar.CastFrom(expChar));
		if (value < 0)
		{
			vlb.Append(info.NegativeSignTChar<TChar>());
			value = -value;
		}
		else if (positiveSign)
		{
			vlb.Append(info.PositiveSignTChar<TChar>());
		}
		TChar* ptr = stackalloc TChar[10];
		TChar* ptr2 = UInt32ToDecChars(ptr + 10, (uint)value, minDigits);
		vlb.Append(new ReadOnlySpan<TChar>(ptr2, (int)(ptr + 10 - ptr2)));
	}

	private unsafe static void FormatGeneral<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, NumberFormatInfo info, char expChar, bool suppressScientific) where TChar : unmanaged, IUtfChar<TChar>
	{
		int i = number.Scale;
		bool flag = false;
		if (!suppressScientific && (i > nMaxDigits || i < -3))
		{
			i = 1;
			flag = true;
		}
		byte* digitsPtr = number.DigitsPtr;
		if (i > 0)
		{
			do
			{
				vlb.Append(TChar.CastFrom((char)((*digitsPtr != 0) ? (*(digitsPtr++)) : 48)));
			}
			while (--i > 0);
		}
		else
		{
			vlb.Append(TChar.CastFrom('0'));
		}
		if (*digitsPtr != 0 || i < 0)
		{
			vlb.Append(info.NumberDecimalSeparatorTChar<TChar>());
			for (; i < 0; i++)
			{
				vlb.Append(TChar.CastFrom('0'));
			}
			while (*digitsPtr != 0)
			{
				vlb.Append(TChar.CastFrom(*(digitsPtr++)));
			}
		}
		if (flag)
		{
			FormatExponent(ref vlb, info, number.Scale - 1, expChar, 2, positiveSign: true);
		}
	}

	private static void FormatPercent<TChar>(ref ValueListBuilder<TChar> vlb, ref NumberBuffer number, int nMaxDigits, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		string text = (number.IsNegative ? s_negPercentFormats[info.PercentNegativePattern] : s_posPercentFormats[info.PercentPositivePattern]);
		foreach (char c in text)
		{
			switch (c)
			{
			case '#':
				FormatFixed(ref vlb, ref number, nMaxDigits, info.PercentGroupSizes(), info.PercentDecimalSeparatorTChar<TChar>(), info.PercentGroupSeparatorTChar<TChar>());
				break;
			case '-':
				vlb.Append(info.NegativeSignTChar<TChar>());
				break;
			case '%':
				vlb.Append(info.PercentSymbolTChar<TChar>());
				break;
			default:
				vlb.Append(TChar.CastFrom(c));
				break;
			}
		}
	}

	internal unsafe static void RoundNumber(ref NumberBuffer number, int pos, bool isCorrectlyRounded)
	{
		byte* digitsPtr = number.DigitsPtr;
		int i;
		for (i = 0; i < pos && digitsPtr[i] != 0; i++)
		{
		}
		if (i == pos && ShouldRoundUp(digitsPtr, i, number.Kind, isCorrectlyRounded))
		{
			while (i > 0 && digitsPtr[i - 1] == 57)
			{
				i--;
			}
			if (i > 0)
			{
				byte* num = digitsPtr + (i - 1);
				(*num)++;
			}
			else
			{
				number.Scale++;
				*digitsPtr = 49;
				i = 1;
			}
		}
		else
		{
			while (i > 0 && digitsPtr[i - 1] == 48)
			{
				i--;
			}
		}
		if (i == 0)
		{
			if (number.Kind != NumberBufferKind.FloatingPoint)
			{
				number.IsNegative = false;
			}
			number.Scale = 0;
		}
		digitsPtr[i] = 0;
		number.DigitsCount = i;
		unsafe static bool ShouldRoundUp(byte* dig, int num2, NumberBufferKind numberKind, bool flag)
		{
			byte b = dig[num2];
			if (b == 0 || flag)
			{
				return false;
			}
			return b >= 53;
		}
	}

	private unsafe static int FindSection(ReadOnlySpan<char> format, int section)
	{
		if (section == 0)
		{
			return 0;
		}
		fixed (char* reference = &MemoryMarshal.GetReference(format))
		{
			int num = 0;
			while (true)
			{
				if (num >= format.Length)
				{
					return 0;
				}
				char c2;
				char c = (c2 = reference[num++]);
				if ((uint)c <= 34u)
				{
					if (c == '\0')
					{
						break;
					}
					if (c != '"')
					{
						continue;
					}
				}
				else if (c != '\'')
				{
					switch (c)
					{
					default:
						continue;
					case '\\':
						if (num < format.Length && reference[num] != 0)
						{
							num++;
						}
						continue;
					case ';':
						break;
					}
					if (--section == 0)
					{
						if (num >= format.Length || reference[num] == '\0' || reference[num] == ';')
						{
							break;
						}
						return num;
					}
					continue;
				}
				while (num < format.Length && reference[num] != 0 && reference[num++] != c2)
				{
				}
			}
			return 0;
		}
	}

	private static int[] NumberGroupSizes(this NumberFormatInfo info)
	{
		return info._numberGroupSizes;
	}

	private static int[] CurrencyGroupSizes(this NumberFormatInfo info)
	{
		return info._currencyGroupSizes;
	}

	private static int[] PercentGroupSizes(this NumberFormatInfo info)
	{
		return info._percentGroupSizes;
	}

	private unsafe static bool TryParseNumber<TChar>(scoped ref TChar* str, TChar* strEnd, NumberStyles styles, ref NumberBuffer number, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		ReadOnlySpan<TChar> value = ReadOnlySpan<TChar>.Empty;
		bool flag = false;
		ReadOnlySpan<TChar> value2;
		ReadOnlySpan<TChar> value3;
		if ((styles & NumberStyles.AllowCurrencySymbol) != NumberStyles.None)
		{
			value = info.CurrencySymbolTChar<TChar>();
			value2 = info.CurrencyDecimalSeparatorTChar<TChar>();
			value3 = info.CurrencyGroupSeparatorTChar<TChar>();
			flag = true;
		}
		else
		{
			value2 = info.NumberDecimalSeparatorTChar<TChar>();
			value3 = info.NumberGroupSeparatorTChar<TChar>();
		}
		int num = 0;
		TChar* ptr = str;
		uint num2 = ((ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
		while (true)
		{
			if (!IsWhite(num2) || (styles & NumberStyles.AllowLeadingWhite) == 0 || ((num & 1) != 0 && (num & 0x20) == 0 && info.NumberNegativePattern != 2))
			{
				TChar* ptr2;
				if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None && (num & 1) == 0 && ((ptr2 = MatchChars(ptr, strEnd, info.PositiveSignTChar<TChar>())) != null || ((ptr2 = MatchNegativeSignChars(ptr, strEnd, info)) != null && (number.IsNegative = true))))
				{
					num |= 1;
					ptr = ptr2 - 1;
				}
				else if (num2 == 40 && (styles & NumberStyles.AllowParentheses) != NumberStyles.None && (num & 1) == 0)
				{
					num |= 3;
					number.IsNegative = true;
				}
				else
				{
					if (value.IsEmpty || (ptr2 = MatchChars(ptr, strEnd, value)) == null)
					{
						break;
					}
					num |= 0x20;
					value = ReadOnlySpan<TChar>.Empty;
					ptr = ptr2 - 1;
				}
			}
			num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = number.Digits.Length - 1;
		int num6 = 0;
		while (true)
		{
			TChar* ptr2;
			if (IsDigit(num2))
			{
				num |= 4;
				if (num2 != 48 || (num & 8) != 0)
				{
					if (num3 < num5)
					{
						number.Digits[num3] = (byte)num2;
						if (num2 != 48 || number.Kind != NumberBufferKind.Integer)
						{
							num4 = num3 + 1;
						}
					}
					else if (num2 != 48)
					{
						number.HasNonZeroTail = true;
					}
					if ((num & 0x10) == 0)
					{
						number.Scale++;
					}
					if (num3 < num5)
					{
						num6 = ((num2 == 48) ? (num6 + 1) : 0);
					}
					num3++;
					num |= 8;
				}
				else if ((num & 0x10) != 0)
				{
					number.Scale--;
				}
			}
			else if ((styles & NumberStyles.AllowDecimalPoint) != NumberStyles.None && (num & 0x10) == 0 && ((ptr2 = MatchChars(ptr, strEnd, value2)) != null || (flag && (num & 0x20) == 0 && (ptr2 = MatchChars(ptr, strEnd, info.NumberDecimalSeparatorTChar<TChar>())) != null)))
			{
				num |= 0x10;
				ptr = ptr2 - 1;
			}
			else
			{
				if ((styles & NumberStyles.AllowThousands) == 0 || (num & 4) == 0 || (num & 0x10) != 0 || ((ptr2 = MatchChars(ptr, strEnd, value3)) == null && (!flag || (num & 0x20) != 0 || (ptr2 = MatchChars(ptr, strEnd, info.NumberGroupSeparatorTChar<TChar>())) == null)))
				{
					break;
				}
				ptr = ptr2 - 1;
			}
			num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
		}
		bool flag2 = false;
		number.DigitsCount = num4;
		number.Digits[num4] = 0;
		if ((num & 4) != 0)
		{
			if ((num2 == 69 || num2 == 101) && (styles & NumberStyles.AllowExponent) != NumberStyles.None)
			{
				TChar* ptr3 = ptr;
				num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
				TChar* ptr2;
				if ((ptr2 = MatchChars(ptr, strEnd, info.PositiveSignTChar<TChar>())) != null)
				{
					num2 = (((ptr = ptr2) < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
				}
				else if ((ptr2 = MatchNegativeSignChars(ptr, strEnd, info)) != null)
				{
					num2 = (((ptr = ptr2) < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
					flag2 = true;
				}
				if (IsDigit(num2))
				{
					int num7 = 0;
					do
					{
						if (num7 >= 100000000)
						{
							num7 = int.MaxValue;
							number.Scale = 0;
							while (IsDigit(num2))
							{
								num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
							}
							break;
						}
						num7 = num7 * 10 + (int)(num2 - 48);
						num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
					}
					while (IsDigit(num2));
					if (flag2)
					{
						num7 = -num7;
					}
					number.Scale += num7;
				}
				else
				{
					ptr = ptr3;
					num2 = ((ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
				}
			}
			if (number.Kind == NumberBufferKind.FloatingPoint && !number.HasNonZeroTail)
			{
				int num8 = num4 - number.Scale;
				if (num8 > 0)
				{
					num6 = Math.Min(num6, num8);
					number.DigitsCount = num4 - num6;
					number.Digits[number.DigitsCount] = 0;
				}
			}
			while (true)
			{
				if (!IsWhite(num2) || (styles & NumberStyles.AllowTrailingWhite) == 0)
				{
					TChar* ptr2;
					if ((styles & NumberStyles.AllowTrailingSign) != NumberStyles.None && (num & 1) == 0 && ((ptr2 = MatchChars(ptr, strEnd, info.PositiveSignTChar<TChar>())) != null || ((ptr2 = MatchNegativeSignChars(ptr, strEnd, info)) != null && (number.IsNegative = true))))
					{
						num |= 1;
						ptr = ptr2 - 1;
					}
					else if (num2 == 41 && (num & 2) != 0)
					{
						num &= -3;
					}
					else
					{
						if (value.IsEmpty || (ptr2 = MatchChars(ptr, strEnd, value)) == null)
						{
							break;
						}
						value = ReadOnlySpan<TChar>.Empty;
						ptr = ptr2 - 1;
					}
				}
				num2 = ((++ptr < strEnd) ? TChar.CastToUInt32(*ptr) : 0u);
			}
			if ((num & 2) == 0)
			{
				if ((num & 8) == 0)
				{
					if (number.Kind != NumberBufferKind.Decimal)
					{
						number.Scale = 0;
					}
					if (number.Kind == NumberBufferKind.Integer && (num & 0x10) == 0)
					{
						number.IsNegative = false;
					}
				}
				str = ptr;
				return true;
			}
		}
		str = ptr;
		return false;
	}

	internal unsafe static bool TryStringToNumber<TChar>(ReadOnlySpan<TChar> value, NumberStyles styles, ref NumberBuffer number, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		fixed (TChar* reference = &MemoryMarshal.GetReference(value))
		{
			TChar* str = reference;
			if (!TryParseNumber(ref str, str + value.Length, styles, ref number, info) || ((int)(str - reference) < value.Length && !TrailingZeros(value, (int)(str - reference))))
			{
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool TrailingZeros<TChar>(ReadOnlySpan<TChar> value, int index) where TChar : unmanaged, IUtfChar<TChar>
	{
		return !value.Slice(index).ContainsAnyExcept(TChar.CastFrom('\0'));
	}

	private static bool IsWhite(uint ch)
	{
		if (ch != 32)
		{
			return ch - 9 <= 4;
		}
		return true;
	}

	private static bool IsDigit(uint ch)
	{
		return ch - 48 <= 9;
	}

	private static bool IsSpaceReplacingChar(uint c)
	{
		if (c != 160)
		{
			return c == 8239;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static TChar* MatchNegativeSignChars<TChar>(TChar* p, TChar* pEnd, NumberFormatInfo info) where TChar : unmanaged, IUtfChar<TChar>
	{
		TChar* ptr = MatchChars(p, pEnd, info.NegativeSignTChar<TChar>());
		if (ptr == null && info.AllowHyphenDuringParsing() && p < pEnd && TChar.CastToUInt32(*p) == 45)
		{
			ptr = p + 1;
		}
		return ptr;
	}

	private unsafe static TChar* MatchChars<TChar>(TChar* p, TChar* pEnd, ReadOnlySpan<TChar> value) where TChar : unmanaged, IUtfChar<TChar>
	{
		fixed (TChar* reference = &MemoryMarshal.GetReference(value))
		{
			TChar* ptr = reference;
			if (TChar.CastToUInt32(*ptr) != 0)
			{
				while (true)
				{
					uint num = ((p < pEnd) ? TChar.CastToUInt32(*p) : 0u);
					uint num2 = TChar.CastToUInt32(*ptr);
					if (num != num2 && (!IsSpaceReplacingChar(num2) || num != 32))
					{
						break;
					}
					p++;
					ptr++;
					if (TChar.CastToUInt32(*ptr) == 0)
					{
						return p;
					}
				}
			}
		}
		return null;
	}
}
