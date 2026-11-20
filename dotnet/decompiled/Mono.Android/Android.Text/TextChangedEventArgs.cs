using System;
using System.Collections.Generic;

namespace Android.Text;

public class TextChangedEventArgs : EventArgs
{
	private IEnumerable<char>? text;

	private int after;

	private int before;

	private int start;

	public IEnumerable<char>? Text => text;

	public TextChangedEventArgs(IEnumerable<char>? text, int start, int before, int after)
	{
		this.text = text;
		this.start = start;
		this.before = before;
		this.after = after;
	}
}
