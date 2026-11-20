using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Common.UiUtils;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.Controls;

[Register("auchan.SliderView")]
public class SliderView : FrameLayout
{
	private TouchListenerViewGroup? _touchListener;

	private ViewPager2? _viewPager2;

	private CircleIndicator? _circleIndicator;

	public TouchListenerViewGroup TouchListener => _touchListener;

	public ViewPager2 ViewPager => _viewPager2;

	public CircleIndicator Indicator => _circleIndicator;

	protected SliderView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public SliderView(Context context)
		: base(context)
	{
		Initialize(context);
	}

	public SliderView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context);
	}

	public SliderView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context);
	}

	public SliderView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context);
	}

	private void Initialize(Context context)
	{
		View view = View.Inflate(context, 2131493192, this);
		_touchListener = view.RequireViewById<TouchListenerViewGroup>(2131298737);
		_viewPager2 = view.RequireViewById<ViewPager2>(2131298382);
		_circleIndicator = view.RequireViewById<CircleIndicator>(2131296781);
	}
}
