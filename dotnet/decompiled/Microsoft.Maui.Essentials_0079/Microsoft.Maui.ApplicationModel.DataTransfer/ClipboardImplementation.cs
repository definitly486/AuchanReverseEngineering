using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

internal class ClipboardImplementation : IClipboard
{
	private static ClipboardManager? clipboardManager;

	private static ClipboardManager? ClipboardManager => clipboardManager ?? (clipboardManager = Application.Context.GetSystemService("clipboard") as ClipboardManager);

	public Task SetTextAsync(string? text)
	{
		if (ClipboardManager != null)
		{
			ClipboardManager.PrimaryClip = ClipData.NewPlainText("Text", text ?? string.Empty);
		}
		return Task.CompletedTask;
	}
}
