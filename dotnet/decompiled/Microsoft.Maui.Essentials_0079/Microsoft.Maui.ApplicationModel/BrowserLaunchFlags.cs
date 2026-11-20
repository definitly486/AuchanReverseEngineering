using System;

namespace Microsoft.Maui.ApplicationModel;

[Flags]
public enum BrowserLaunchFlags
{
	None = 0,
	LaunchAdjacent = 1,
	PresentAsPageSheet = 2,
	PresentAsFormSheet = 4
}
