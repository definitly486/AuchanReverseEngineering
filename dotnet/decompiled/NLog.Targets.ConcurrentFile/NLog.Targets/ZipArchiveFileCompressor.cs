using System.IO;
using System.IO.Compression;

namespace NLog.Targets;

internal sealed class ZipArchiveFileCompressor : IArchiveFileCompressor, IFileCompressor
{
	public void CompressFile(string fileName, string archiveFileName)
	{
		string entryName = Path.GetFileNameWithoutExtension(archiveFileName) + Path.GetExtension(fileName);
		CompressFile(fileName, archiveFileName, entryName);
	}

	public void CompressFile(string fileName, string archiveFileName, string entryName)
	{
		using FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using FileStream stream = new FileStream(archiveFileName, FileMode.CreateNew);
		using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Create);
		using Stream destination = zipArchive.CreateEntry(entryName).Open();
		fileStream.CopyTo(destination);
	}
}
