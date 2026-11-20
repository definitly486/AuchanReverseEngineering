using System;

namespace Android.Content;

public class DialogMultiChoiceClickEventArgs : EventArgs
{
	private int which;

	private bool isChecked;

	public DialogMultiChoiceClickEventArgs(int which, bool isChecked)
	{
		this.which = which;
		this.isChecked = isChecked;
	}
}
