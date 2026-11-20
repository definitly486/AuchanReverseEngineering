using System;
using Android.Content;

namespace AndroidX.Activity.ContextAware;

public class ContextAvailableEventArgs : EventArgs
{
	private Context context;

	public ContextAvailableEventArgs(Context context)
	{
		this.context = context;
	}
}
