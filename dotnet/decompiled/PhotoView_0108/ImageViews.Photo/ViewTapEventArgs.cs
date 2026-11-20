using System;
using Android.Views;

namespace ImageViews.Photo;

public class ViewTapEventArgs : EventArgs
{
	private View view;

	private float x;

	private float y;

	public ViewTapEventArgs(View view, float x, float y)
	{
		this.view = view;
		this.x = x;
		this.y = y;
	}
}
