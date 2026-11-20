using System;

namespace ImageViews.Photo;

public class ScaleChangedEventArgs : EventArgs
{
	private float scaleFactor;

	private float focusX;

	private float focusY;

	public ScaleChangedEventArgs(float scaleFactor, float focusX, float focusY)
	{
		this.scaleFactor = scaleFactor;
		this.focusX = focusX;
		this.focusY = focusY;
	}
}
