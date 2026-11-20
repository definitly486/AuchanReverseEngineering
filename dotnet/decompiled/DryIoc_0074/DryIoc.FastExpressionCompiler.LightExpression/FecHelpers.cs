using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal static class FecHelpers
{
	public static int GetFirstIndexByReferenceEquals<T>(this IReadOnlyList<T> source, T item) where T : class
	{
		if (source.Count != 0)
		{
			for (int i = 0; i < source.Count; i++)
			{
				if (source[i] == item)
				{
					return i;
				}
			}
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetArgument<T>(this IReadOnlyList<T> source, int index)
	{
		return source[index];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ParameterExpression GetParameter(this IReadOnlyList<ParameterExpression> source, int index)
	{
		return source[index];
	}

	public static IReadOnlyList<ParameterExpression> ToReadOnlyList(this IParameterProvider source)
	{
		int parameterCount = source.ParameterCount;
		ParameterExpression[] array = new ParameterExpression[parameterCount];
		for (int i = 0; i < parameterCount; i++)
		{
			array[i] = source.GetParameter(i);
		}
		return array;
	}
}
