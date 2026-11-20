using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews.Model;

namespace Auchan.Android.Reviews;

[Register("auchan.ReviewView")]
public class ReviewView : LinearLayoutWidgetBase
{
	private sealed class Controls
	{
		public RatingView RatingView { get; }

		public TextView NameText { get; }

		public TextView ReviewText { get; }

		public TextView DateText { get; }

		public TextView ResponseCountText { get; }

		public View ResponseThumb { get; }

		public TextView ShowAllButton { get; }

		public ViewGroup ThumbnailsContainer { get; }

		public View MenuOptionsView { get; }

		public TriggerWordsControls TriggerWordsControls { get; }

		public Controls(Context context, ViewGroup viewGroup)
		{
			viewGroup.SetClipChildren(clipChildren: false);
			viewGroup.SetClipToPadding(clipToPadding: false);
			View view = View.Inflate(context, 2131493182, viewGroup);
			RatingView = view.RequireViewById<RatingView>(2131298138);
			NameText = view.RequireViewById<TextView>(2131297635);
			ReviewText = view.RequireViewById<TextView>(2131298233);
			DateText = view.RequireViewById<TextView>(2131296890);
			ResponseCountText = view.RequireViewById<TextView>(2131298224);
			ResponseThumb = view.RequireViewById<View>(2131298225);
			ShowAllButton = view.RequireViewById<TextView>(2131298365);
			ThumbnailsContainer = view.RequireViewById<ViewGroup>(2131298633);
			MenuOptionsView = view.RequireViewById<View>(2131297562);
			TriggerWordsControls = new TriggerWordsControls(view);
		}
	}

	private readonly Controls _controls;

	private Review? _review;

	public TextView ShowAllButton => _controls.ShowAllButton;

	public View MenuOptionsView => _controls.MenuOptionsView;

	public ReviewViewMode Mode { get; private set; }

	public event Action<IReadOnlyList<string?>, int>? ThumbnailTappedEvent;

	protected ReviewView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		_controls = new Controls(base.Context, this);
	}

	public ReviewView(Context context)
		: base(context)
	{
		_controls = new Controls(context, this);
	}

	public ReviewView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		_controls = new Controls(context, this);
	}

	public ReviewView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		_controls = new Controls(context, this);
	}

	public ReviewView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		_controls = new Controls(context, this);
	}

	private static float ThumbnailHeight(ReviewViewMode mode)
	{
		return (mode == ReviewViewMode.CompactPreviewCarousel || mode == ReviewViewMode.CompactPreviewList) ? 28 : 56;
	}

	private float ThumbnailSpacing(ReviewViewMode mode)
	{
		return (mode == ReviewViewMode.CompactPreviewCarousel || mode == ReviewViewMode.CompactPreviewList) ? 8 : 4;
	}

	private static int MaxReviewLines(ReviewViewMode mode)
	{
		return mode switch
		{
			ReviewViewMode.CompactPreviewCarousel => 2, 
			ReviewViewMode.CompactPreviewList => 2, 
			ReviewViewMode.LargePreview => 5, 
			_ => int.MaxValue, 
		};
	}

	protected override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		base.OnLayout(changed, l, t, r, b);
		_controls.ReviewText.RequestLayout();
		if (changed && _controls.ReviewText.Text != _review?.Text)
		{
			_controls.ReviewText.Text = _review?.Text;
			_controls.ReviewText.Visibility = (_review?.IsTextVisible ?? false).ToVisibility();
			RequestLayout();
		}
		ShowAllButton.Visibility = ViewStates.Gone;
		if (Mode != ReviewViewMode.FullView && _controls.ReviewText.Layout != null && _controls.ReviewText.Layout.LineCount >= _controls.ReviewText.MaxLines)
		{
			int num = Math.Min(_controls.ReviewText.Layout.GetLineEnd(_controls.ReviewText.MaxLines - 1), _controls.ReviewText.Text.Length - _controls.ReviewText.Layout.GetEllipsisCount(_controls.ReviewText.MaxLines - 1));
			string text = _review?.Text.Substring(0, num - 1);
			if (num < _controls.ReviewText.Text.Length && text?.Length > "...".Length)
			{
				text = text.Substring(0, text.Length - "...".Length) + "...";
				_controls.ReviewText.Text = text;
				ShowAllButton.Visibility = ((Mode != ReviewViewMode.LargePreview) ? ViewStates.Gone : ViewStates.Visible);
			}
			else
			{
				bool flag = Mode == ReviewViewMode.LargePreview && _controls.ReviewText.Text.Length < _review?.Text.Length;
				ShowAllButton.Visibility = ((!flag) ? ViewStates.Gone : ViewStates.Visible);
			}
		}
	}

	public void Setup(Review review, Action onClick, ReviewViewMode mode, CompositeDisposable disposable)
	{
		_review = review;
		Mode = mode;
		_controls.TriggerWordsControls.Setup(review, onClick).AddTo(disposable);
		_controls.RatingView.SetupReadOnly(review.Rate, 16f, 2f);
		_controls.NameText.Text = review.UserName;
		_controls.ReviewText.TextFormatted = null;
		_controls.ReviewText.Text = review.Text;
		_controls.ReviewText.Visibility = review.IsTextVisible.ToVisibility();
		_controls.ReviewText.SetMaxLines(MaxReviewLines(Mode));
		_controls.ResponseCountText.Text = review.Comments.Count.ToString();
		_controls.DateText.Text = review.CreatedAt.ToLongDateWithFullMonth();
		ShowAllButton.Text = "Читать полностью";
		ShowAllButton.Visibility = (mode == ReviewViewMode.LargePreview && review.IsTextVisible).ToVisibility();
		ViewStates visibility = (review.Comments.Any() && mode == ReviewViewMode.CompactPreviewList).ToVisibility();
		_controls.ResponseCountText.Visibility = visibility;
		_controls.ResponseThumb.Visibility = visibility;
		_controls.ThumbnailsContainer.RemoveAllViews();
		string[] imageUrls = review.Images.Select((ReviewImage reviewImage) => reviewImage.Url).ToArray();
		foreach (ReviewImage img in review.Images)
		{
			ImageView imageView = new ImageView(base.Context);
			imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
			float dpValue = ThumbnailHeight(Mode);
			LayoutParams layoutParams = new LayoutParams(Converter.DpToPx(dpValue), Converter.DpToPx(dpValue));
			layoutParams.SetMargins(0, 0, Converter.DpToPx(ThumbnailSpacing(Mode)), 0);
			imageView.LayoutParameters = layoutParams;
			imageView.ClipToOutline = true;
			_controls.ThumbnailsContainer.AddView(imageView);
			((View)imageView).OnClick((Action)delegate
			{
				this.ThumbnailTappedEvent?.Invoke(imageUrls, review.Images.IndexOf(img));
			}).AddTo(disposable);
			imageView.FromUrl(img.ThumbnailUrl);
		}
		_controls.ThumbnailsContainer.Visibility = review.Images.Any().ToVisibility();
		RequestLayout();
	}

	public void ClearSubscriptions()
	{
		this.ThumbnailTappedEvent = null;
	}

	public IDisposable OnThumbnailTappedEvent(Action<IReadOnlyList<string?>, int> handler)
	{
		ThumbnailTappedEvent += handler;
		return Disposable.Create(delegate
		{
			ThumbnailTappedEvent -= handler;
		});
	}
}
