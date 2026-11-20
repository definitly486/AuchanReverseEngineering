using System;

namespace Android.Runtime;

public class RaiseThrowableEventArgs : EventArgs
{
	private bool handled;

	public Exception Exception { get; private set; }

	public bool Handled
	{
		get
		{
			return handled;
		}
		set
		{
			if (value)
			{
				handled = value;
			}
		}
	}

	public RaiseThrowableEventArgs(Exception e)
	{
		Exception = e;
	}
}
