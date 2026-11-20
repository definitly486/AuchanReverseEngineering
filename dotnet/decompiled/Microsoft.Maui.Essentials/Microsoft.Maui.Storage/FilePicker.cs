using System.Threading.Tasks;

namespace Microsoft.Maui.Storage;

public static class FilePicker
{
	private static IFilePicker? defaultImplementation;

	public static IFilePicker Default => defaultImplementation ?? (defaultImplementation = new FilePickerImplementation());

	public static Task<FileResult?> PickAsync(PickOptions? options = null)
	{
		return Default.PickAsync(options);
	}
}
