using System.Buffers;
using System.Text;

namespace System.IO;

internal abstract class CachedConsoleStream : ConsoleStream
{
	private readonly StringBuilder _buffer = new StringBuilder();

	private readonly Encoding _encoding;

	private readonly Decoder _decoder;

	public CachedConsoleStream(Encoding encoding)
		: base(FileAccess.Write)
	{
		_encoding = encoding;
		_decoder = _encoding.GetDecoder();
	}

	public override int Read(Span<byte> buffer)
	{
		throw Error.GetReadNotSupported();
	}

	public override void Write(ReadOnlySpan<byte> buffer)
	{
		int maxCharCount = _encoding.GetMaxCharCount(buffer.Length);
		char[] array = null;
		Span<char> span = (((uint)maxCharCount > 512u) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxCharCount))) : stackalloc char[512]);
		Span<char> chars = span;
		try
		{
			int chars2 = _decoder.GetChars(buffer, chars, flush: false);
			if (chars2 > 0)
			{
				WriteOrCache(this, _buffer, chars.Slice(0, chars2));
			}
		}
		finally
		{
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}
	}

	protected abstract void Print(ReadOnlySpan<char> line);

	private static void WriteOrCache(CachedConsoleStream stream, StringBuilder cache, Span<char> charBuffer)
	{
		int num = ((ReadOnlySpan<char>)charBuffer).LastIndexOf('\n');
		if (num != -1)
		{
			Span<char> span = charBuffer.Slice(0, num);
			if (cache.Length > 0)
			{
				stream.Print(cache.Append(span).ToString().AsSpan());
				cache.Clear();
			}
			else
			{
				stream.Print(span);
			}
			if (num + 1 < charBuffer.Length)
			{
				cache.Append(charBuffer.Slice(num + 1));
			}
		}
		else
		{
			cache.Append(charBuffer);
		}
	}
}
