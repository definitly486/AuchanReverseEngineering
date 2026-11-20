using System.Numerics;

namespace System.Net;

internal static class IPv6AddressHelper
{
	internal static (int longestSequenceStart, int longestSequenceLength) FindCompressionRange(ReadOnlySpan<ushort> numbers)
	{
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			if (numbers[i] == 0)
			{
				num3++;
				if (num3 > num)
				{
					num = num3;
					num2 = i - num3 + 1;
				}
			}
			else
			{
				num3 = 0;
			}
		}
		if (num <= 1)
		{
			return (longestSequenceStart: -1, longestSequenceLength: 0);
		}
		return (longestSequenceStart: num2, longestSequenceLength: num2 + num);
	}

	internal static bool ShouldHaveIpv4Embedded(ReadOnlySpan<ushort> numbers)
	{
		if (numbers[0] == 0 && numbers[1] == 0 && numbers[2] == 0 && numbers[3] == 0 && numbers[6] != 0)
		{
			if (numbers[4] == 0 && (numbers[5] == 0 || numbers[5] == ushort.MaxValue))
			{
				return true;
			}
			if (numbers[4] == ushort.MaxValue && numbers[5] == 0)
			{
				return true;
			}
		}
		if (numbers[4] == 0)
		{
			return numbers[5] == 24318;
		}
		return false;
	}

	internal unsafe static bool IsValidStrict<TChar>(TChar* name, int start, int end) where TChar : unmanaged, IBinaryInteger<TChar>
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = true;
		int start2 = 1;
		bool flag4 = false;
		if (start < end && name[start] == TChar.CreateTruncating('['))
		{
			start++;
			flag4 = true;
		}
		if (name[start] == TChar.CreateTruncating(':') && (start + 1 >= end || name[start + 1] != TChar.CreateTruncating(':')))
		{
			return false;
		}
		for (int i = start; i < end; i++)
		{
			int num3 = System.Net.IPv4AddressHelper.ToUShort(name[i]);
			if (System.HexConverter.IsHexChar(num3))
			{
				num2++;
				flag3 = false;
				continue;
			}
			if (num2 > 4)
			{
				return false;
			}
			if (num2 != 0)
			{
				num++;
				start2 = i - num2;
				num2 = 0;
			}
			if (num3 <= 46)
			{
				if (num3 != 37)
				{
					if (num3 != 46)
					{
						goto IL_0316;
					}
					if (flag2)
					{
						return false;
					}
					i = end;
					if (!System.Net.IPv4AddressHelper.IsValid(name, start2, ref i, allowIPv6: true, notImplicitFile: false, unknownScheme: false))
					{
						return false;
					}
					num++;
					start2 = i - num2;
					num2 = 0;
					flag2 = true;
					i--;
				}
				else
				{
					while (i + 1 < end)
					{
						i++;
						if (name[i] == TChar.CreateTruncating(']'))
						{
							goto IL_0194;
						}
						if (!(name[i] == TChar.CreateTruncating('/')))
						{
							continue;
						}
						goto IL_02e5;
					}
				}
			}
			else
			{
				if (num3 == 47)
				{
					goto IL_02e5;
				}
				if (num3 != 58)
				{
					if (num3 == 93)
					{
						goto IL_0194;
					}
					goto IL_0316;
				}
				if (i > 0 && name[i - 1] == TChar.CreateTruncating(':'))
				{
					if (flag)
					{
						return false;
					}
					flag = true;
					flag3 = false;
				}
				else
				{
					flag3 = true;
				}
			}
			num2 = 0;
			continue;
			IL_0316:
			return false;
			IL_02e5:
			return false;
			IL_0194:
			if (!flag4)
			{
				return false;
			}
			flag4 = false;
			if (i + 1 < end && name[i + 1] != TChar.CreateTruncating(':'))
			{
				return false;
			}
			if (i + 3 < end && name[i + 2] == TChar.CreateTruncating('0') && name[i + 3] == TChar.CreateTruncating('x'))
			{
				for (i += 4; i < end; i++)
				{
					if (!System.HexConverter.IsHexChar(System.Net.IPv4AddressHelper.ToUShort(name[i])))
					{
						return false;
					}
				}
				continue;
			}
			for (i += 2; i < end; i++)
			{
				if (!char.IsAsciiDigit((char)System.Net.IPv4AddressHelper.ToUShort(name[i])))
				{
					return false;
				}
			}
		}
		if (num2 != 0)
		{
			if (num2 > 4)
			{
				return false;
			}
			num++;
		}
		if (!flag3 && (flag ? (num < 8) : (num == 8)))
		{
			return !flag4;
		}
		return false;
	}

	internal static void Parse<TChar>(ReadOnlySpan<TChar> address, scoped Span<ushort> numbers, out ReadOnlySpan<TChar> scopeId) where TChar : unmanaged, IBinaryInteger<TChar>
	{
		int num = 0;
		int num2 = 0;
		int num3 = -1;
		bool flag = true;
		scopeId = ReadOnlySpan<TChar>.Empty;
		int i = ((address[0] == TChar.CreateTruncating('[')) ? 1 : 0);
		while (i < address.Length && address[i] != TChar.CreateTruncating(']'))
		{
			int num4 = System.Net.IPv4AddressHelper.ToUShort(address[i]);
			switch (num4)
			{
			case 37:
			{
				if (flag)
				{
					numbers[num2++] = (ushort)num;
					flag = false;
				}
				int num7 = i;
				for (i++; i < address.Length && address[i] != TChar.CreateTruncating(']') && address[i] != TChar.CreateTruncating('/'); i++)
				{
				}
				scopeId = address.Slice(num7, i - num7);
				for (; i < address.Length && address[i] != TChar.CreateTruncating(']'); i++)
				{
				}
				break;
			}
			case 58:
			{
				numbers[num2++] = (ushort)num;
				num = 0;
				i++;
				if (address[i] == TChar.CreateTruncating(':'))
				{
					num3 = num2;
					i++;
				}
				else if (num3 < 0 && num2 < 6)
				{
					break;
				}
				for (int j = i; j < address.Length && address[j] != TChar.CreateTruncating(']') && address[j] != TChar.CreateTruncating(':') && address[j] != TChar.CreateTruncating('%') && address[j] != TChar.CreateTruncating('/') && j < i + 4; j++)
				{
					if (address[j] == TChar.CreateTruncating('.'))
					{
						for (; j < address.Length && address[j] != TChar.CreateTruncating(']') && address[j] != TChar.CreateTruncating('/') && address[j] != TChar.CreateTruncating('%'); j++)
						{
						}
						int num6 = System.Net.IPv4AddressHelper.ParseHostNumber(address, i, j);
						numbers[num2++] = (ushort)(num6 >> 16);
						numbers[num2++] = (ushort)(num6 & 0xFFFF);
						i = j;
						num = 0;
						flag = false;
						break;
					}
				}
				break;
			}
			case 47:
				if (flag)
				{
					numbers[num2++] = (ushort)num;
					flag = false;
				}
				for (i++; i < address.Length && address[i] != TChar.CreateTruncating(']'); i++)
				{
				}
				break;
			default:
			{
				int num5 = System.HexConverter.FromChar(num4);
				num = num * 16 + num5;
				i++;
				break;
			}
			}
		}
		if (flag)
		{
			numbers[num2++] = (ushort)num;
		}
		if (num3 <= 0)
		{
			return;
		}
		int num8 = 7;
		int num9 = num2 - 1;
		if (num9 != num8)
		{
			for (int num10 = num2 - num3; num10 > 0; num10--)
			{
				numbers[num8--] = numbers[num9];
				numbers[num9--] = 0;
			}
		}
	}
}
