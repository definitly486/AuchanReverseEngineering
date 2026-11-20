using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public static class Clipboard
{
	private static IClipboard? defaultImplementation;

	public static IClipboard Default => defaultImplementation ?? (defaultImplementation = new ClipboardImplementation());

	public static Task SetTextAsync(string? text)
	{
		return Default.SetTextAsync(text ?? string.Empty);
	}
}
