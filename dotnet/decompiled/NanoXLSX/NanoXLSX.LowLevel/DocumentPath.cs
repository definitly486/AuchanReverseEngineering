using System.IO;

namespace NanoXLSX.LowLevel;

internal class DocumentPath
{
	public string Filename { get; set; }

	public string Path { get; set; }

	public DocumentPath(string filename, string path)
	{
		Filename = filename;
		Path = path;
	}

	public string GetFullPath()
	{
		char altDirectorySeparatorChar;
		if (Path[Path.Length - 1] == System.IO.Path.AltDirectorySeparatorChar || Path[Path.Length - 1] == System.IO.Path.DirectorySeparatorChar)
		{
			altDirectorySeparatorChar = System.IO.Path.AltDirectorySeparatorChar;
			return altDirectorySeparatorChar + Path + Filename;
		}
		altDirectorySeparatorChar = System.IO.Path.AltDirectorySeparatorChar;
		string text = altDirectorySeparatorChar.ToString();
		string path = Path;
		altDirectorySeparatorChar = System.IO.Path.AltDirectorySeparatorChar;
		return text + path + altDirectorySeparatorChar + Filename;
	}
}
