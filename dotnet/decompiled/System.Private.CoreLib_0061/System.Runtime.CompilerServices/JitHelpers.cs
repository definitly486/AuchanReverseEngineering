namespace System.Runtime.CompilerServices;

internal static class JitHelpers
{
	[Intrinsic]
	public static bool EnumEquals<T>(T x, T y) where T : struct, Enum
	{
		return x.Equals(y);
	}

	[Intrinsic]
	public static int EnumCompareTo<T>(T x, T y) where T : struct, Enum
	{
		return x.CompareTo(y);
	}

	[Intrinsic]
	internal static void DisableInline()
	{
		throw new NotImplementedException();
	}
}
