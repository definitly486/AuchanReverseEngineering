using System;

namespace Microsoft.Maui.ApplicationModel;

public class AppActionEventArgs : EventArgs
{
	public AppAction AppAction { get; }

	public AppActionEventArgs(AppAction appAction)
	{
		AppAction = appAction;
	}
}
