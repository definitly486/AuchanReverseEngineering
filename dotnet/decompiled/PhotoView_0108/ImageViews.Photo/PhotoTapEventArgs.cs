using System;
using Android.Widget;

namespace ImageViews.Photo;

public class PhotoTapEventArgs : EventArgs
{
	private ImageView view;

	private float x;

	private float y;

	public PhotoTapEventArgs(ImageView view, float x, float y)
	{
		this.view = view;
		this.x = x;
		this.y = y;
	}
}
