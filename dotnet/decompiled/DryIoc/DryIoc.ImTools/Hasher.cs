using System.Runtime.CompilerServices;

namespace DryIoc.ImTools;

public static class Hasher
{
	public static int Combine<T1, T2>(T1 a, T2 b)
	{
		int num = b?.GetHashCode() ?? 0;
		if (a == null)
		{
			return num;
		}
		int hashCode = a.GetHashCode();
		if (hashCode == 0)
		{
			return num;
		}
		return Combine(hashCode, num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Combine(int h1, int h2)
	{
		return ((h1 << 5) + h1) ^ h2;
	}
}
