using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace System.Reflection;

internal static class Throw
{
	[DoesNotReturn]
	internal static void InvalidArgument(string message, string parameterName)
	{
		throw new ArgumentException(message, parameterName);
	}

	[DoesNotReturn]
	internal static void ArgumentNull(string parameterName)
	{
		throw new ArgumentNullException(parameterName);
	}

	[DoesNotReturn]
	internal static void ArgumentOutOfRange(string parameterName)
	{
		throw new ArgumentOutOfRangeException(parameterName);
	}

	[DoesNotReturn]
	internal static void OutOfBounds()
	{
		throw new BadImageFormatException("OutOfBoundsRead");
	}

	[DoesNotReturn]
	internal static void ImageTooSmall()
	{
		throw new BadImageFormatException("ImageTooSmall");
	}

	[DoesNotReturn]
	internal static void ImageTooSmallOrContainsInvalidOffsetOrCount()
	{
		throw new BadImageFormatException("ImageTooSmallOrContainsInvalidOffsetOrCount");
	}

	[DoesNotReturn]
	internal static void ReferenceOverflow()
	{
		throw new BadImageFormatException("RowIdOrHeapOffsetTooLarge");
	}

	[DoesNotReturn]
	internal static void TableNotSorted(TableIndex tableIndex)
	{
		throw new BadImageFormatException(System.SR.Format("MetadataTableNotSorted", tableIndex));
	}

	[DoesNotReturn]
	internal static void InvalidOperation_PEImageNotAvailable()
	{
		throw new InvalidOperationException("PEImageNotAvailable");
	}

	[DoesNotReturn]
	internal static void PEReaderDisposed()
	{
		throw new ObjectDisposedException("PEReader");
	}
}
