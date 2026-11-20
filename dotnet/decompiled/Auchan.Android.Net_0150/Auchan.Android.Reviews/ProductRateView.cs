using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base.WidgetBases;

namespace Auchan.Android.Reviews;

[Register("auchan.ProductRateView")]
public class ProductRateView : ConstraintLayoutWidgetBase
{
	private ViewGroup _rateContainer;

	public RatingView RatingView { get; private set; }

	public TextView TitleText { get; private set; }

	public TextView RatingText { get; private set; }

	public TextView ReviewCountText { get; private set; }

	public TextView NoReviewsText { get; private set; }

	public TextView ShowAllReviewsText { get; private set; }

	public View RatingLayout { get; private set; }

	public Button AddReviewButton { get; private set; }

	public ViewGroup ShowAllReviewsButton { get; private set; }

	public bool HasReviews
	{
		get
		{
			return _rateContainer.Visibility == ViewStates.Visible;
		}
		set
		{
			_rateContainer.Visibility = ((!value) ? ViewStates.Gone : ViewStates.Visible);
			NoReviewsText.Visibility = (value ? ViewStates.Gone : ViewStates.Visible);
		}
	}

	protected ProductRateView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ProductRateView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public ProductRateView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public ProductRateView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public ProductRateView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493175, this);
		RatingLayout = view.RequireViewById<View>(2131298149);
		RatingView = view.RequireViewById<RatingView>(2131298148);
		TitleText = view.RequireViewById<TextView>(2131298244);
		RatingText = view.RequireViewById<TextView>(2131298139);
		ReviewCountText = view.RequireViewById<TextView>(2131298236);
		NoReviewsText = view.RequireViewById<TextView>(2131297692);
		ShowAllReviewsText = view.RequireViewById<TextView>(2131296430);
		AddReviewButton = view.RequireViewById<Button>(2131296358);
		ShowAllReviewsButton = view.RequireViewById<ViewGroup>(2131296431);
		_rateContainer = view.RequireViewById<ViewGroup>(2131298149);
	}
}
