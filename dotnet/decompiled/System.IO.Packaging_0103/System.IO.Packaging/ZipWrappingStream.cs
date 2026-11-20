using System.IO.Compression;

namespace System.IO.Packaging;

internal class ZipWrappingStream : Stream
{
	private Stream _baseStream;

	private ZipArchiveEntry _zipArchiveEntry;

	private FileMode _packageFileMode;

	private FileAccess _packageFileAccess;

	private bool _canRead;

	private bool _canWrite;

	public override bool CanRead
	{
		get
		{
			if (!_canRead)
			{
				return false;
			}
			return _baseStream.CanRead;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (!_canWrite)
			{
				return false;
			}
			return _baseStream.CanWrite;
		}
	}

	public override long Position
	{
		get
		{
			return _baseStream.Position;
		}
		set
		{
			_baseStream.Position = value;
		}
	}

	public override long Length
	{
		get
		{
			if (_packageFileAccess == FileAccess.Read)
			{
				return _zipArchiveEntry.Length;
			}
			return _baseStream.Length;
		}
	}

	public override bool CanSeek => _baseStream.CanSeek;

	public ZipWrappingStream(ZipArchiveEntry zipArchiveEntry, Stream stream, FileMode packageFileMode, FileAccess packageFileAccess, bool canRead, bool canWrite)
	{
		_zipArchiveEntry = zipArchiveEntry;
		_baseStream = stream;
		_packageFileMode = packageFileMode;
		_packageFileAccess = packageFileAccess;
		_canRead = canRead;
		_canWrite = canWrite;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		_baseStream.Write(buffer, offset, count);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return _baseStream.Read(buffer, offset, count);
	}

	public override void SetLength(long value)
	{
		_baseStream.SetLength(value);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _baseStream.Seek(offset, origin);
	}

	public override void Flush()
	{
		_baseStream.Flush();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_baseStream.Dispose();
		}
	}
}
