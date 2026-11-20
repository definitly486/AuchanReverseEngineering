using System;
using System.IO;
using System.Linq;
using System.Text;
using NLog.Common;

namespace NLog.Internal;

internal static class StreamHelpers
{
	private static readonly byte[] Utf8BOM = Encoding.UTF8.GetPreamble();

	public static void CopyAndSkipBom(this Stream input, Stream output, Encoding encoding)
	{
		int num = Utf8BOM.Length;
		byte[] array = new byte[num];
		long position = input.Position;
		if (input.Read(array, 0, num) == num && array.SequenceEqual(Utf8BOM))
		{
			InternalLogger.Debug("input has UTF8 BOM");
		}
		else
		{
			InternalLogger.Debug("input hasn't a UTF8 BOM");
			input.Position = position;
		}
		input.Copy(output);
	}

	public static void Copy(this Stream input, Stream output)
	{
		input.CopyWithOffset(output, 0);
	}

	public static void CopyWithOffset(this Stream input, Stream output, int offset)
	{
		if (offset < 0)
		{
			throw new ArgumentException("cannot be negative", "offset");
		}
		if (offset > 0)
		{
			input.Seek(offset, SeekOrigin.Current);
		}
		byte[] array = new byte[4096];
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			output.Write(array, 0, count);
		}
	}

	public static void CopyToStream(this StringBuilder builder, MemoryStream ms, Encoding encoding, char[] transformBuffer)
	{
		int maxByteCount = encoding.GetMaxByteCount(builder.Length);
		long num = ms.Position;
		ms.SetLength(num + maxByteCount);
		for (int i = 0; i < builder.Length; i += transformBuffer.Length)
		{
			int num2 = Math.Min(builder.Length - i, transformBuffer.Length);
			builder.CopyTo(i, transformBuffer, 0, num2);
			maxByteCount = encoding.GetBytes(transformBuffer, 0, num2, ms.GetBuffer(), (int)num);
			num += maxByteCount;
		}
		ms.Position = num;
		if (num != ms.Length)
		{
			ms.SetLength(num);
		}
	}
}
