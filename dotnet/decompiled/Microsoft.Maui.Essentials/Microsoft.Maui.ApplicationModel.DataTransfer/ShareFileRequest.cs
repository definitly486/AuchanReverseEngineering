namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public class ShareFileRequest : ShareRequestBase
{
	public ShareFile? File { get; set; }

	public ShareFileRequest(ShareFile file)
	{
		File = file;
	}
}
