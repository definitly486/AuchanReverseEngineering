using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Auchan.Android.Common.UiUtils;

[Register("helper.TouchListenerViewGroup")]
public class TouchListenerViewGroup : FrameLayout
{
	private readonly List<IOnTouchListener> _touchListeners = new List<IOnTouchListener>();

	public Action<MotionEvent> Callback { get; set; }

	public TouchListenerViewGroup(Context context)
		: base(context)
	{
	}

	public TouchListenerViewGroup(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public TouchListenerViewGroup(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public TouchListenerViewGroup(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected TouchListenerViewGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public void AddTouchListener(IOnTouchListener listener)
	{
		_touchListeners.Add(listener);
	}

	public override bool DispatchTouchEvent(MotionEvent e)
	{
		Clickable = true;
		Callback?.Invoke(e);
		_touchListeners.ForEach(delegate(IOnTouchListener listener)
		{
			listener.OnTouch(this, e);
		});
		return base.DispatchTouchEvent(e);
	}

	public void RemoveTouchListener(IOnTouchListener listener)
	{
		_touchListeners.Remove(listener);
		Callback = null;
	}

	public void PassRelatedTouchEvent(MotionEvent e)
	{
		if (e.Action == MotionEventActions.Down)
		{
			Clickable = false;
		}
		MotionEventActions action = e.Action;
		if (action == MotionEventActions.Up || action == MotionEventActions.Cancel)
		{
			bool flag = true;
		}
		else
		{
			bool flag = false;
		}
		base.DispatchTouchEvent(e);
	}
}
