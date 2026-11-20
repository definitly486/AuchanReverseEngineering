using System.IO.Compression;

namespace System.IO.Packaging;

public sealed class ZipPackagePart : PackagePart
{
	private ZipPackage _zipPackage;

	private ZipArchiveEntry _zipArchiveEntry;

	private ZipArchive _zipArchive;

	private ZipStreamManager _zipStreamManager;

	protected override Stream GetStreamCore(FileMode streamFileMode, FileAccess streamFileAccess)
	{
		if (_zipArchiveEntry != null)
		{
			if (streamFileMode == FileMode.Create && _zipArchiveEntry.Archive.Mode != ZipArchiveMode.Create)
			{
				using Stream stream = _zipStreamManager.Open(_zipArchiveEntry, streamFileMode, streamFileAccess);
				stream.SetLength(0L);
			}
			return _zipStreamManager.Open(_zipArchiveEntry, streamFileMode, streamFileAccess);
		}
		return null;
	}

	internal ZipPackagePart(ZipPackage zipPackage, ZipArchive zipArchive, ZipArchiveEntry zipArchiveEntry, ZipStreamManager zipStreamManager, PackUriHelper.ValidatedPartUri partUri, string contentType, CompressionOption compressionOption)
		: base(zipPackage, partUri, contentType, compressionOption)
	{
		_zipPackage = zipPackage;
		_zipArchive = zipArchive;
		_zipStreamManager = zipStreamManager;
		_zipArchiveEntry = zipArchiveEntry;
	}
}
