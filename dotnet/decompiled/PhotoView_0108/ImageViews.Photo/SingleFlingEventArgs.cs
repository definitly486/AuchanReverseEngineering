using System;
using Android.Views;

namespace ImageViews.Photo;

public class SingleFlingEventArgs : EventArgs
{
	private bool handled;

	private MotionEvent event1;

	private MotionEvent event2;

	private float velocityX;

	private float velocityY;

	public bool Handled => handled;

	public SingleFlingEventArgs(bool handled, MotionEvent event1, MotionEvent event2, float velocityX, float velocityY)
	{
		this.handled = handled;
		this.event1 = event1;
		this.event2 = event2;
		this.velocityX = velocityX;
		this.velocityY = velocityY;
	}
}
