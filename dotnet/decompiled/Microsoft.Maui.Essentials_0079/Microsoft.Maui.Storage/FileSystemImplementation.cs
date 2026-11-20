using Android.App;

namespace Microsoft.Maui.Storage;

public class FileSystemImplementation : IFileSystem
{
	public string AppDataDirectory => PlatformAppDataDirectory;

	private string PlatformAppDataDirectory => Application.Context.FilesDir.AbsolutePath;
}
