using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public static class ShareExtensions
{
	public static Task RequestAsync(this IShare share, string text, string title)
	{
		return share.RequestAsync(new ShareTextRequest(text, title));
	}
}
