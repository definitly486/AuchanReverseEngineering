using System.Collections.Generic;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public class ShareMultipleFilesRequest : ShareRequestBase
{
	public List<ShareFile>? Files { get; set; } = new List<ShareFile>();

	public static explicit operator ShareMultipleFilesRequest(ShareFileRequest request)
	{
		return new ShareMultipleFilesRequest
		{
			Title = request.Title,
			Files = new List<ShareFile> { request.File },
			PresentationSourceBounds = request.PresentationSourceBounds
		};
	}
}
