using System;

namespace ImageViews.Photo;

public class ViewDragEventArgs : EventArgs
{
	private float deltaX;

	private float deltaY;

	public float DeltaX => deltaX;

	public float DeltaY => deltaY;

	public ViewDragEventArgs(float deltaX, float deltaY)
	{
		this.deltaX = deltaX;
		this.deltaY = deltaY;
	}
}
