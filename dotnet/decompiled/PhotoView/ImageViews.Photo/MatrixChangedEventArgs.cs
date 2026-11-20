using System;
using Android.Graphics;

namespace ImageViews.Photo;

public class MatrixChangedEventArgs : EventArgs
{
	private RectF rect;

	public MatrixChangedEventArgs(RectF rect)
	{
		this.rect = rect;
	}
}
