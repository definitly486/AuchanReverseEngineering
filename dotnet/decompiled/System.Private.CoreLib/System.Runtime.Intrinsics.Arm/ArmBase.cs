using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
public abstract class ArmBase
{
	[Intrinsic]
	public abstract class Arm64
	{
		public static bool IsSupported => IsSupported;

		public static int LeadingSignCount(int value)
		{
			return LeadingSignCount(value);
		}

		public static int LeadingSignCount(long value)
		{
			return LeadingSignCount(value);
		}

		public static int LeadingZeroCount(long value)
		{
			return LeadingZeroCount(value);
		}

		public static int LeadingZeroCount(ulong value)
		{
			return LeadingZeroCount(value);
		}

		public static long MultiplyHigh(long left, long right)
		{
			return MultiplyHigh(left, right);
		}

		public static ulong MultiplyHigh(ulong left, ulong right)
		{
			return MultiplyHigh(left, right);
		}

		public static long ReverseElementBits(long value)
		{
			return ReverseElementBits(value);
		}

		public static ulong ReverseElementBits(ulong value)
		{
			return ReverseElementBits(value);
		}
	}

	public static bool IsSupported => IsSupported;

	public static int LeadingZeroCount(int value)
	{
		return LeadingZeroCount(value);
	}

	public static int LeadingZeroCount(uint value)
	{
		return LeadingZeroCount(value);
	}

	public static int ReverseElementBits(int value)
	{
		return ReverseElementBits(value);
	}

	public static uint ReverseElementBits(uint value)
	{
		return ReverseElementBits(value);
	}

	public static void Yield()
	{
		Yield();
	}
}
