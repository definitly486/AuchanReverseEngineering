namespace DryIoc.FastExpressionCompiler.LightExpression;

internal static class HashCombiner
{
	public static int Combine<T1, T2>(T1 a, T2 b)
	{
		return Combine(a?.GetHashCode() ?? 0, b?.GetHashCode() ?? 0);
	}

	public static int Combine(int h1, int h2)
	{
		if (h1 == 0)
		{
			return h2;
		}
		return ((h1 << 5) + h1) ^ h2;
	}
}
