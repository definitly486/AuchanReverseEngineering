using System;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Auchan.Android.Common.UiUtils;

public class HorizontalSwipeTouchListener : RecyclerView.SimpleOnItemTouchListener
{
	private readonly Func<bool> _isEnabled;

	private float _initialX;

	private float _initialY;

	public HorizontalSwipeTouchListener(Func<bool> isEnabled)
	{
		_isEnabled = isEnabled;
	}

	public override bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
	{
		if (!_isEnabled())
		{
			return false;
		}
		int scaledTouchSlop = ViewConfiguration.Get(rv.Context).ScaledTouchSlop;
		switch (e.ActionMasked)
		{
		case MotionEventActions.Down:
			_initialX = e.GetX();
			_initialY = e.GetY();
			rv.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
			break;
		case MotionEventActions.Move:
		{
			float num = Math.Abs(e.GetX() - _initialX);
			float num2 = Math.Abs(e.GetY() - _initialY);
			if (num2 > num && num2 > (float)scaledTouchSlop)
			{
				rv.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
			}
			else if (num > (float)scaledTouchSlop)
			{
				rv.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
			}
			break;
		}
		case MotionEventActions.Up:
		case MotionEventActions.Cancel:
			rv.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
			break;
		}
		return false;
	}
}
