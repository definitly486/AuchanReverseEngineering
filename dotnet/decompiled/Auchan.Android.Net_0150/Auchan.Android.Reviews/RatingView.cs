using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using EBind;

namespace Auchan.Android.Reviews;

[Register("auchan.RatingView")]
public class RatingView : LinearLayoutWidgetBase
{
	private LinearLayout _starsLayout;

	private readonly List<StarView> _starViews = new List<StarView>();

	protected RatingView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RatingView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public RatingView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public RatingView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public RatingView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet? attrs)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493177, this);
		_starsLayout = view.RequireViewById<LinearLayout>(2131298464);
	}

	private ImageView AddStarView(float starSize, float starSpacing, StarView.Style style = StarView.Style.Grey)
	{
		RelativeLayout relativeLayout = new RelativeLayout(base.Context);
		ImageView imageView = new ImageView(base.Context);
		imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
		LayoutParams layoutParams = new LayoutParams(Converter.DpToPx(starSize), Converter.DpToPx(starSize));
		layoutParams.SetMargins(0, 0, Converter.DpToPx(starSpacing), 0);
		imageView.LayoutParameters = layoutParams;
		imageView.ClipToOutline = true;
		_starViews.Add(new StarView(imageView, style));
		relativeLayout.AddView(imageView);
		_starsLayout.AddView(relativeLayout);
		return imageView;
	}

	public void Setup(Action<int> onStarClicked, ILifecycleOwner viewLifecycleOwner, float starSize = 40f, float starSpacing = 4f, int starsCount = 5, int initialRating = 0)
	{
		_starsLayout.RemoveAllViews();
		_starViews.Clear();
		for (int i = 0; i < starsCount; i++)
		{
			ImageView starImageView = AddStarView(starSize, starSpacing);
			int i2 = i;
			starImageView.Touch += new DisposableDelegate<EventHandler<TouchEventArgs>>(delegate(object? _, TouchEventArgs args)
			{
				MotionEvent? motionEvent = args.Event;
				if (motionEvent == null || motionEvent.Action != MotionEventActions.Down)
				{
					args.Handled = false;
				}
				else
				{
					ApplyInteractiveSelection(i2);
					onStarClicked(i2);
					args.Handled = true;
				}
			}, delegate(EventHandler<TouchEventArgs> h)
			{
				starImageView.Touch -= h;
			}).AutoDisposeOnDestroy(viewLifecycleOwner);
		}
		if (initialRating > 0)
		{
			ApplyInteractiveSelection(initialRating - 1);
		}
	}

	private void ApplyInteractiveSelection(int selectedStarIndex)
	{
		for (int i = 0; i < _starViews.Count; i++)
		{
			_starViews[i].SetStyle((i > selectedStarIndex) ? StarView.Style.Grey : StarView.Style.Gold);
		}
	}

	public void SetupReadOnly(double rating, float starSize = 40f, float starSpacing = 4f, int starsCount = 5)
	{
		_starsLayout.RemoveAllViews();
		_starViews.Clear();
		double num = rating;
		for (int i = 0; i < starsCount; i++)
		{
			StarView.Style style = StarView.Style.Grey;
			if (num >= 0.5)
			{
				style = StarView.Style.Gold;
			}
			else if (num > 0.0)
			{
				style = StarView.Style.HalfGrey;
			}
			num -= 1.0;
			AddStarView(starSize, starSpacing, style);
		}
	}
}
