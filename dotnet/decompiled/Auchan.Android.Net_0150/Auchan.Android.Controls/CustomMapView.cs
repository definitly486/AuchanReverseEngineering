using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Com.Yandex.Mapkit.Mapview;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

[Register("auchan.controls.CustomMapView")]
internal sealed class CustomMapView : MapView
{
	private bool _isTouchable;

	public CustomMapView(Context context)
		: base(context)
	{
	}

	public CustomMapView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		ObtainStyledAttributes(context, attrs);
	}

	public CustomMapView(Context context, IAttributeSet attrs, int defStyle)
		: base(context, attrs, defStyle)
	{
		ObtainStyledAttributes(context, attrs);
	}

	protected CustomMapView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public override bool OnInterceptTouchEvent(MotionEvent ev)
	{
		if (!_isTouchable)
		{
			return true;
		}
		switch (ev.Action)
		{
		case MotionEventActions.Down:
			base.Parent.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
			break;
		case MotionEventActions.Up:
			base.Parent.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
			break;
		}
		return base.OnInterceptTouchEvent(ev);
	}

	public void SetTouchable(bool isTouchable)
	{
		_isTouchable = isTouchable;
	}

	private void ObtainStyledAttributes(Context context, IAttributeSet attrs)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.CustomMapView);
			_isTouchable = typedArray.GetBoolean(0, defValue: true);
			typedArray.Recycle();
		}
	}
}
