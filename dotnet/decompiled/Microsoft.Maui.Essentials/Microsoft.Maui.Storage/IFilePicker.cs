using System.Threading.Tasks;

namespace Microsoft.Maui.Storage;

public interface IFilePicker
{
	Task<FileResult?> PickAsync(PickOptions? options = null);
}
