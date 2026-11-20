using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArgumentNullException(System.ExceptionArgument argument)
	{
		throw CreateArgumentNullException(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ArgumentNullException CreateArgumentNullException(System.ExceptionArgument argument)
	{
		return new ArgumentNullException(argument.ToString());
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(System.ExceptionArgument argument)
	{
		throw CreateArgumentOutOfRangeException(argument);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(System.ExceptionArgument argument)
	{
		return new ArgumentOutOfRangeException(argument.ToString());
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException()
	{
		throw CreateInvalidOperationException();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static InvalidOperationException CreateInvalidOperationException()
	{
		return new InvalidOperationException();
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_EndPositionNotReached()
	{
		throw CreateInvalidOperationException_EndPositionNotReached();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static InvalidOperationException CreateInvalidOperationException_EndPositionNotReached()
	{
		return new InvalidOperationException("EndPositionNotReached");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_PositionOutOfRange()
	{
		throw CreateArgumentOutOfRangeException_PositionOutOfRange();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ArgumentOutOfRangeException CreateArgumentOutOfRangeException_PositionOutOfRange()
	{
		return new ArgumentOutOfRangeException("position");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_OffsetOutOfRange()
	{
		throw CreateArgumentOutOfRangeException_OffsetOutOfRange();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ArgumentOutOfRangeException CreateArgumentOutOfRangeException_OffsetOutOfRange()
	{
		return new ArgumentOutOfRangeException("offset");
	}

	[DoesNotReturn]
	public static void ThrowArgumentValidationException<T>(ReadOnlySequenceSegment<T> startSegment, int startIndex, ReadOnlySequenceSegment<T> endSegment)
	{
		throw CreateArgumentValidationException(startSegment, startIndex, endSegment);
	}

	private static Exception CreateArgumentValidationException<T>(ReadOnlySequenceSegment<T> startSegment, int startIndex, ReadOnlySequenceSegment<T> endSegment)
	{
		if (startSegment == null)
		{
			return CreateArgumentNullException(System.ExceptionArgument.startSegment);
		}
		if (endSegment == null)
		{
			return CreateArgumentNullException(System.ExceptionArgument.endSegment);
		}
		if (startSegment != endSegment && startSegment.RunningIndex > endSegment.RunningIndex)
		{
			return CreateArgumentOutOfRangeException(System.ExceptionArgument.endSegment);
		}
		if ((uint)startSegment.Memory.Length < (uint)startIndex)
		{
			return CreateArgumentOutOfRangeException(System.ExceptionArgument.startIndex);
		}
		return CreateArgumentOutOfRangeException(System.ExceptionArgument.endIndex);
	}

	[DoesNotReturn]
	public static void ThrowArgumentValidationException(Array array, int start)
	{
		throw CreateArgumentValidationException(array, start);
	}

	private static Exception CreateArgumentValidationException(Array array, int start)
	{
		if (array == null)
		{
			return CreateArgumentNullException(System.ExceptionArgument.array);
		}
		if ((uint)start > (uint)array.Length)
		{
			return CreateArgumentOutOfRangeException(System.ExceptionArgument.start);
		}
		return CreateArgumentOutOfRangeException(System.ExceptionArgument.length);
	}

	[DoesNotReturn]
	public static void ThrowStartOrEndArgumentValidationException(long start)
	{
		throw CreateStartOrEndArgumentValidationException(start);
	}

	private static ArgumentOutOfRangeException CreateStartOrEndArgumentValidationException(long start)
	{
		if (start < 0)
		{
			return CreateArgumentOutOfRangeException(System.ExceptionArgument.start);
		}
		return CreateArgumentOutOfRangeException(System.ExceptionArgument.length);
	}
}
