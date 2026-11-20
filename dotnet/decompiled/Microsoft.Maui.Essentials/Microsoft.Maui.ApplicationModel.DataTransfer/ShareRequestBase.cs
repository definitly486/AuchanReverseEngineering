using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public abstract class ShareRequestBase
{
	public string? Title { get; set; }

	public Rect PresentationSourceBounds { get; set; } = Rect.Zero;
}
