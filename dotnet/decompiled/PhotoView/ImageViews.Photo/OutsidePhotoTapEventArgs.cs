using System;
using Android.Widget;

namespace ImageViews.Photo;

public class OutsidePhotoTapEventArgs : EventArgs
{
	private ImageView imageView;

	public OutsidePhotoTapEventArgs(ImageView imageView)
	{
		this.imageView = imageView;
	}
}
