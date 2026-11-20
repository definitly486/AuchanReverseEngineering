using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Runtime.Intrinsics.Arm;

[Intrinsic]
[CLSCompliant(false)]
public abstract class Rdm : AdvSimd
{
	[Intrinsic]
	public new abstract class Arm64 : AdvSimd.Arm64
	{
		public new static bool IsSupported => IsSupported;

		public static Vector64<short> MultiplyRoundedDoublingAndAddSaturateHighScalar(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
		{
			return MultiplyRoundedDoublingAndAddSaturateHighScalar(addend, left, right);
		}

		public static Vector64<int> MultiplyRoundedDoublingAndAddSaturateHighScalar(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
		{
			return MultiplyRoundedDoublingAndAddSaturateHighScalar(addend, left, right);
		}

		public static Vector64<short> MultiplyRoundedDoublingAndSubtractSaturateHighScalar(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
		{
			return MultiplyRoundedDoublingAndSubtractSaturateHighScalar(addend, left, right);
		}

		public static Vector64<int> MultiplyRoundedDoublingAndSubtractSaturateHighScalar(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
		{
			return MultiplyRoundedDoublingAndSubtractSaturateHighScalar(addend, left, right);
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<short> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<short> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<int> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<int> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<short> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
		}

		public static Vector64<short> MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<short> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<int> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
		}

		public static Vector64<int> MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<int> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
		{
			return MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
		}
	}

	public new static bool IsSupported => IsSupported;

	public static Vector64<short> MultiplyRoundedDoublingAndAddSaturateHigh(Vector64<short> addend, Vector64<short> left, Vector64<short> right)
	{
		return MultiplyRoundedDoublingAndAddSaturateHigh(addend, left, right);
	}

	public static Vector64<int> MultiplyRoundedDoublingAndAddSaturateHigh(Vector64<int> addend, Vector64<int> left, Vector64<int> right)
	{
		return MultiplyRoundedDoublingAndAddSaturateHigh(addend, left, right);
	}

	public static Vector128<short> MultiplyRoundedDoublingAndAddSaturateHigh(Vector128<short> addend, Vector128<short> left, Vector128<short> right)
	{
		return MultiplyRoundedDoublingAndAddSaturateHigh(addend, left, right);
	}

	public static Vector128<int> MultiplyRoundedDoublingAndAddSaturateHigh(Vector128<int> addend, Vector128<int> left, Vector128<int> right)
	{
		return MultiplyRoundedDoublingAndAddSaturateHigh(addend, left, right);
	}

	public static Vector64<short> MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector64<short> minuend, Vector64<short> left, Vector64<short> right)
	{
		return MultiplyRoundedDoublingAndSubtractSaturateHigh(minuend, left, right);
	}

	public static Vector64<int> MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector64<int> minuend, Vector64<int> left, Vector64<int> right)
	{
		return MultiplyRoundedDoublingAndSubtractSaturateHigh(minuend, left, right);
	}

	public static Vector128<short> MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector128<short> minuend, Vector128<short> left, Vector128<short> right)
	{
		return MultiplyRoundedDoublingAndSubtractSaturateHigh(minuend, left, right);
	}

	public static Vector128<int> MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector128<int> minuend, Vector128<int> left, Vector128<int> right)
	{
		return MultiplyRoundedDoublingAndSubtractSaturateHigh(minuend, left, right);
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<short> addend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<short> addend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<int> addend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<int> addend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<short> addend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<short> addend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<int> addend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<int> addend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(addend, left, right, rightIndex);
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<short> minuend, Vector64<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector64<short> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<short> minuend, Vector64<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<int> minuend, Vector64<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector64<int> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<int> minuend, Vector64<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<short> minuend, Vector128<short> left, Vector64<short> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector128<short> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<short> minuend, Vector128<short> left, Vector128<short> right, [ConstantExpected(Max = 7)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<int> minuend, Vector128<int> left, Vector64<int> right, [ConstantExpected(Max = 1)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}

	public static Vector128<int> MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<int> minuend, Vector128<int> left, Vector128<int> right, [ConstantExpected(Max = 3)] byte rightIndex)
	{
		return MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(minuend, left, right, rightIndex);
	}
}
