using System.Runtime.CompilerServices;

namespace System.Buffers;

public static class BuffersExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void CopyTo<T>(this in ReadOnlySequence<T> source, Span<T> destination)
	{
		if (source.IsSingleSegment)
		{
			ReadOnlySpan<T> span = source.First.Span;
			if (span.Length > destination.Length)
			{
				System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.destination);
			}
			span.CopyTo(destination);
		}
		else
		{
			CopyToMultiSegment(in source, destination);
		}
	}

	private static void CopyToMultiSegment<T>(in ReadOnlySequence<T> sequence, Span<T> destination)
	{
		if (sequence.Length > destination.Length)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.destination);
		}
		SequencePosition position = sequence.Start;
		ReadOnlyMemory<T> memory;
		while (sequence.TryGet(ref position, out memory))
		{
			ReadOnlySpan<T> span = memory.Span;
			span.CopyTo(destination);
			if (position.GetObject() != null)
			{
				destination = destination.Slice(span.Length);
				continue;
			}
			break;
		}
	}

	public static T[] ToArray<T>(this in ReadOnlySequence<T> sequence)
	{
		T[] array = new T[sequence.Length];
		CopyTo(in sequence, array);
		return array;
	}
}
