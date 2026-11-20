using System.Diagnostics.CodeAnalysis;

namespace System;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowKeyNullException()
	{
		ThrowArgumentNullException("key");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(string name)
	{
		throw new ArgumentNullException(name);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(string name, string message)
	{
		throw new ArgumentNullException(name, message);
	}

	[DoesNotReturn]
	internal static void ThrowValueNullException()
	{
		throw new ArgumentException("ConcurrentDictionary_TypeOfValueIncorrect");
	}

	[DoesNotReturn]
	internal static void ThrowIncompatibleComparer()
	{
		throw new InvalidOperationException("InvalidOperation_IncompatibleComparer");
	}
}
