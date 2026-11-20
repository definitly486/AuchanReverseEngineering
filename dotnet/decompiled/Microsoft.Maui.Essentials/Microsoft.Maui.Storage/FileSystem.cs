namespace Microsoft.Maui.Storage;

public static class FileSystem
{
	private static IFileSystem? currentImplementation;

	public static string AppDataDirectory => Current.AppDataDirectory;

	public static IFileSystem Current => currentImplementation ?? (currentImplementation = new FileSystemImplementation());
}
