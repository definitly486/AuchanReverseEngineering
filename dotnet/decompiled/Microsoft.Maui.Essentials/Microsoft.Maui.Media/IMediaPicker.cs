using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace Microsoft.Maui.Media;

public interface IMediaPicker
{
	Task<FileResult?> PickPhotoAsync(MediaPickerOptions? options = null);

	Task<FileResult?> PickVideoAsync(MediaPickerOptions? options = null);
}
