using System;

namespace Android.Content;

public class DialogClickEventArgs : EventArgs
{
	private int which;

	public DialogClickEventArgs(int which)
	{
		this.which = which;
	}
}
