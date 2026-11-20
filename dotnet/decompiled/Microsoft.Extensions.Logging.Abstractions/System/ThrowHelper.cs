using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

internal static class ThrowHelper
{
	internal static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
	{
		if (argument == null)
		{
			Throw(paramName);
		}
	}

	[DoesNotReturn]
	private static void Throw(string paramName)
	{
		throw new ArgumentNullException(paramName);
	}
}
