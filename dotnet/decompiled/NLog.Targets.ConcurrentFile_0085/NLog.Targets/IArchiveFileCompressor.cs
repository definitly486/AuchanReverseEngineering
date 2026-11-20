namespace NLog.Targets;

internal interface IArchiveFileCompressor : IFileCompressor
{
	void CompressFile(string fileName, string archiveFileName, string entryName);
}
