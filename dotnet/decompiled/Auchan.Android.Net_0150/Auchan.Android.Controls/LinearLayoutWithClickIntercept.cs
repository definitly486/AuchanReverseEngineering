using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls;

internal sealed class LinearLayoutWithClickIntercept : LinearLayout
{
	private readonly Stopwatch _stopwatch = new Stopwatch();

	public event Action<MotionEvent> ClickIntercepted;

	private LinearLayoutWithClickIntercept(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LinearLayoutWithClickIntercept(Context context)
		: base(context)
	{
	}

	public LinearLayoutWithClickIntercept(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public LinearLayoutWithClickIntercept(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public LinearLayoutWithClickIntercept(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public override bool OnInterceptTouchEvent(MotionEvent ev)
	{
		if (ev.Action == MotionEventActions.Down)
		{
			_stopwatch.Restart();
		}
		if (ev.Action == MotionEventActions.Up && _stopwatch.ElapsedMilliseconds < ViewConfiguration.LongPressTimeout)
		{
			this.ClickIntercepted?.Invoke(ev);
		}
		return base.OnInterceptTouchEvent(ev);
	}

	public IDisposable OnClickIntercepted(Action handler)
	{
		return OnClickIntercepted((Action<MotionEvent>)delegate
		{
			handler();
		});
	}

	public IDisposable OnClickIntercepted(Action<MotionEvent> handler)
	{
		ClickIntercepted += handler;
		return Disposable.Create(delegate
		{
			ClickIntercepted -= handler;
		});
	}
}
