using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public interface IShare
{
	Task RequestAsync(ShareTextRequest request);

	Task RequestAsync(ShareFileRequest request);
}
