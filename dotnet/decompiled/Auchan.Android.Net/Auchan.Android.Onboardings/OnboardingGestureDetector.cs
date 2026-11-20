using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Auchan.Android.Onboardings;

public class OnboardingGestureDetector : GestureDetector.SimpleOnGestureListener, View.IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<bool> _callback;

	private readonly View _parent;

	private readonly GestureDetector _detector;

	public OnboardingGestureDetector(Action<bool> callback, View parent)
	{
		_callback = callback;
		_parent = parent;
		_detector = new GestureDetector(parent.Context, this);
	}

	public bool OnTouch(View? v, MotionEvent? e)
	{
		return _detector.OnTouchEvent(e);
	}

	public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
	{
		bool result = false;
		try
		{
			float num = (float)_parent.Width * 0.25f;
			float num2 = (float)_parent.Width * 0.25f;
			float value = e2.GetY() - e1.GetY();
			float num3 = e2.GetX() - e1.GetX();
			if (Math.Abs(num3) > Math.Abs(value) && Math.Abs(num3) > num && Math.Abs(velocityX) > num2)
			{
				if (num3 > 0f)
				{
					_callback(obj: false);
					return false;
				}
				_callback(obj: true);
				return true;
			}
		}
		catch (Exception ex)
		{
			_ = ex.StackTrace;
		}
		return result;
	}
}
