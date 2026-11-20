using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

[ExcludeFromCodeCoverage]
internal abstract class DelegatingStream : Stream
{
	protected Stream InnerStream { get; private set; } = innerStream ?? throw new ArgumentNullException("innerStream");

	public override bool CanRead => InnerStream.CanRead;

	public override bool CanSeek => InnerStream.CanSeek;

	public override bool CanWrite => InnerStream.CanWrite;

	public override long Length => InnerStream.Length;

	public override long Position
	{
		get
		{
			return InnerStream.Position;
		}
		set
		{
			InnerStream.Position = value;
		}
	}

	public override int ReadTimeout
	{
		get
		{
			return InnerStream.ReadTimeout;
		}
		set
		{
			InnerStream.ReadTimeout = value;
		}
	}

	public override bool CanTimeout => InnerStream.CanTimeout;

	public override int WriteTimeout
	{
		get
		{
			return InnerStream.WriteTimeout;
		}
		set
		{
			InnerStream.WriteTimeout = value;
		}
	}

	protected DelegatingStream(Stream innerStream)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			InnerStream.Dispose();
		}
		base.Dispose(disposing);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return InnerStream.Seek(offset, origin);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return InnerStream.Read(buffer, offset, count);
	}

	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return InnerStream.ReadAsync(buffer, offset, count, cancellationToken);
	}

	public override int ReadByte()
	{
		return InnerStream.ReadByte();
	}

	public override void Flush()
	{
		InnerStream.Flush();
	}

	public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
	{
		return InnerStream.CopyToAsync(destination, bufferSize, cancellationToken);
	}

	public override Task FlushAsync(CancellationToken cancellationToken)
	{
		return InnerStream.FlushAsync(cancellationToken);
	}

	public override void SetLength(long value)
	{
		InnerStream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		InnerStream.Write(buffer, offset, count);
	}

	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		return InnerStream.WriteAsync(buffer, offset, count, cancellationToken);
	}

	public override void WriteByte(byte value)
	{
		InnerStream.WriteByte(value);
	}
}
