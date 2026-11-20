namespace System.IO;

internal static class PathInternal
{
	internal static bool IsDirectorySeparator(char c)
	{
		return c == '/';
	}
}
