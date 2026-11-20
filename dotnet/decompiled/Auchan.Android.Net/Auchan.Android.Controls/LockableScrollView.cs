using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.Widget;

namespace Auchan.Android.Controls;

[Register("auchan.LockableScrollView")]
public class LockableScrollView : NestedScrollView
{
	public bool Scrollable { get; set; } = true;

	protected LockableScrollView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LockableScrollView(Context context)
		: base(context)
	{
	}

	public LockableScrollView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public LockableScrollView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public override bool OnTouchEvent(MotionEvent? e)
	{
		if (Scrollable)
		{
			return base.OnTouchEvent(e);
		}
		return false;
	}

	public override bool OnInterceptTouchEvent(MotionEvent? ev)
	{
		if (Scrollable)
		{
			return base.OnInterceptTouchEvent(ev);
		}
		return false;
	}
}
