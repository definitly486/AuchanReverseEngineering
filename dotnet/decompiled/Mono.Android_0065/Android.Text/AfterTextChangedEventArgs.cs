using System;

namespace Android.Text;

public class AfterTextChangedEventArgs : EventArgs
{
	private IEditable? editable;

	public AfterTextChangedEventArgs(IEditable? editable)
	{
		this.editable = editable;
	}
}
