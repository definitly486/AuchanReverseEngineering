using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.ApplicationModel;

public class BrowserLaunchOptions
{
	public Color? PreferredToolbarColor { get; }

	public BrowserLaunchMode LaunchMode { get; set; }

	public BrowserTitleMode TitleMode { get; }

	public BrowserLaunchFlags Flags { get; }

	internal bool HasFlag(BrowserLaunchFlags flag)
	{
		return Flags.HasFlag(flag);
	}
}
