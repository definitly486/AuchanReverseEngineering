using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public static class Share
{
	private static IShare? defaultImplementation;

	private static IShare Current => Default;

	public static IShare Default => defaultImplementation ?? (defaultImplementation = new ShareImplementation());

	public static Task RequestAsync(ShareTextRequest request)
	{
		return Current.RequestAsync(request);
	}

	public static Task RequestAsync(ShareFileRequest request)
	{
		return Current.RequestAsync(request);
	}
}
