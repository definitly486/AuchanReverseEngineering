using System.IO;

namespace System.Reflection.Internal;

internal static class StreamExtensions
{
	internal static int GetAndValidateSize(Stream stream, int size, string streamParameterName)
	{
		long num = stream.Length - stream.Position;
		if (size < 0 || size > num)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (size != 0)
		{
			return size;
		}
		if (num > int.MaxValue)
		{
			throw new ArgumentException("StreamTooLarge", streamParameterName);
		}
		return (int)num;
	}
}
