using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;

namespace Auchan.Android.Reviews;

[Register("auchan.RatePercentageView")]
public class RatePercentageView : ConstraintLayoutWidgetBase
{
	public ProgressBar ProgressBar { get; private set; }

	public TextView TitleText { get; private set; }

	public TextView CountText { get; private set; }

	protected RatePercentageView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RatePercentageView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public RatePercentageView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public RatePercentageView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public RatePercentageView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493176, this);
		ProgressBar = view.RequireViewById<ProgressBar>(2131298078);
		TitleText = view.RequireViewById<TextView>(2131298649);
		CountText = view.RequireViewById<TextView>(2131296854);
	}
}
