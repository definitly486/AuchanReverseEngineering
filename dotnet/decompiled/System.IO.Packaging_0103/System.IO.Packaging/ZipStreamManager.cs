using System.IO.Compression;

namespace System.IO.Packaging;

internal class ZipStreamManager : IDisposable
{
	private ZipArchive _zipArchive;

	private FileAccess _packageFileAccess;

	private FileMode _packageFileMode;

	private bool _disposed;

	public ZipStreamManager(ZipArchive zipArchive, FileMode packageFileMode, FileAccess packageFileAccess)
	{
		_zipArchive = zipArchive;
		_packageFileMode = packageFileMode;
		_packageFileAccess = packageFileAccess;
	}

	public Stream Open(ZipArchiveEntry zipArchiveEntry, FileMode streamFileMode, FileAccess streamFileAccess)
	{
		bool canRead = true;
		bool canWrite = true;
		switch (_packageFileAccess)
		{
		case FileAccess.Read:
			switch (streamFileAccess)
			{
			case FileAccess.Read:
				canRead = true;
				canWrite = false;
				break;
			case FileAccess.Write:
				canRead = false;
				canWrite = false;
				break;
			case FileAccess.ReadWrite:
				canRead = true;
				canWrite = false;
				break;
			}
			break;
		case FileAccess.Write:
			switch (streamFileAccess)
			{
			case FileAccess.Read:
				canRead = false;
				canWrite = false;
				break;
			case FileAccess.Write:
				canRead = false;
				canWrite = true;
				break;
			case FileAccess.ReadWrite:
				canRead = false;
				canWrite = true;
				break;
			}
			break;
		case FileAccess.ReadWrite:
			switch (streamFileAccess)
			{
			case FileAccess.Read:
				canRead = true;
				canWrite = false;
				break;
			case FileAccess.Write:
				canRead = false;
				canWrite = true;
				break;
			case FileAccess.ReadWrite:
				canRead = true;
				canWrite = true;
				break;
			}
			break;
		}
		Stream stream = zipArchiveEntry.Open();
		return new ZipWrappingStream(zipArchiveEntry, stream, _packageFileMode, _packageFileAccess, canRead, canWrite);
	}

	public void Close(ZipArchiveEntry zipArchiveEntry)
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			_disposed = true;
		}
	}
}
