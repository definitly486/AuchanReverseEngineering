namespace NLog.Targets;

public interface IFileCompressor
{
	void CompressFile(string fileName, string archiveFileName);
}
