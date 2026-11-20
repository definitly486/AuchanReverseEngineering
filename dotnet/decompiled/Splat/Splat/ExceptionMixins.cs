using System;

namespace Splat;

internal static class ExceptionMixins
{
	public static void ThrowArgumentNullExceptionIfNull<T>(this T? value, string name)
	{
		if (value == null)
		{
			throw new ArgumentNullException(name);
		}
	}

	public static void ThrowArgumentNullExceptionIfNull<T>(this T? value, string name, string message)
	{
		if (value == null)
		{
			throw new ArgumentNullException(name, message);
		}
	}
}
