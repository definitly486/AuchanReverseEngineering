using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace System;

internal static class PackedSpanHelpers
{
	private interface ITransform
	{
		static abstract short TransformInput(short input);

		static abstract Vector128<byte> TransformInput(Vector128<byte> input);

		static abstract Vector256<byte> TransformInput(Vector256<byte> input);

		static abstract Vector512<byte> TransformInput(Vector512<byte> input);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Vector256<byte> FixUpPackedVector256Result(Vector256<byte> result)
	{
		return Avx2.Permute4x64(result.AsInt64(), 216).AsByte();
	}
}
