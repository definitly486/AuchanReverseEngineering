using System.IO;

namespace NLog.Internal.Fakeables;

internal interface IFileSystem
{
	bool FileExists(string path);

	TextReader LoadTextFile(string path);
}
