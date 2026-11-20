using Microsoft.Maui.Storage;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public class ShareFile : FileBase
{
	public ShareFile(string fullPath, string contentType)
		: base(fullPath, contentType)
	{
	}
}
