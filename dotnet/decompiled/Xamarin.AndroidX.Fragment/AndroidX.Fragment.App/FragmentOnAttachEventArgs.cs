using System;

namespace AndroidX.Fragment.App;

public class FragmentOnAttachEventArgs : EventArgs
{
	private FragmentManager p0;

	private Fragment p1;

	public FragmentOnAttachEventArgs(FragmentManager p0, Fragment p1)
	{
		this.p0 = p0;
		this.p1 = p1;
	}
}
