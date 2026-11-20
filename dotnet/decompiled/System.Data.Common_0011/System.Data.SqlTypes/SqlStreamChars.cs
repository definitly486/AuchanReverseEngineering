using System.IO;
using System.Runtime.CompilerServices;

namespace System.Data.SqlTypes;

internal sealed class SqlStreamChars
{
	public long Length
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public long Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int Read(char[] buffer, int offset, int count)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Write(char[] buffer, int offset, int count)
	{
		throw new NotSupportedException("Linked away");
	}
}
