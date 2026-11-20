using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace Microsoft.Maui.Media;

public static class MediaPicker
{
	private static IMediaPicker? defaultImplementation;

	public static IMediaPicker Default => defaultImplementation ?? (defaultImplementation = new MediaPickerImplementation());

	public static Task<FileResult?> PickPhotoAsync(MediaPickerOptions? options = null)
	{
		return Default.PickPhotoAsync(options);
	}

	public static Task<FileResult?> PickVideoAsync(MediaPickerOptions? options = null)
	{
		return Default.PickVideoAsync(options);
	}
}
