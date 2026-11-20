using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;

namespace Auchan.Android.Profile.Orders;

public class OneTwoImages
{
	private FrameLayout _oneTwoImagesLayout;

	private ImageView _oneImage;

	private LinearLayout _twoImagesLayout;

	private ImageView _firstImage;

	private ImageView _secondImage;

	private CardView _oneImageCardView;

	public void FindAllViewsById(View view)
	{
		_oneTwoImagesLayout = view.RequireViewById<FrameLayout>(2131297746);
		_oneImageCardView = _oneTwoImagesLayout.RequireViewById<CardView>(2131297744);
		_oneImage = _oneImageCardView.RequireViewById<ImageView>(2131297743);
		_twoImagesLayout = view.RequireViewById<LinearLayout>(2131298772);
		_firstImage = _twoImagesLayout.RequireViewById<ImageView>(2131297185);
		_secondImage = _twoImagesLayout.RequireViewById<ImageView>(2131298327);
		_oneTwoImagesLayout.Visibility = ViewStates.Visible;
		_oneImageCardView.Visibility = ViewStates.Gone;
		_twoImagesLayout.Visibility = ViewStates.Gone;
	}

	public void Setup(IBindable bindable, IReadOnlyList<string> imageUrls, ILifecycleOwner lifecycleOwner, Action<int> onImageClicked)
	{
		if (imageUrls.Count == 0 || imageUrls.All(string.IsNullOrWhiteSpace))
		{
			_oneTwoImagesLayout.Visibility = ViewStates.Gone;
		}
		else
		{
			_oneTwoImagesLayout.Visibility = ViewStates.Visible;
		}
		if (imageUrls.Count == 1)
		{
			_oneImageCardView.Visibility = ViewStates.Visible;
			_oneImage.FromUrl(imageUrls.First());
			bindable.BindEvents(((View)_oneImage).OnClick((Action)delegate
			{
				onImageClicked(0);
			})).AutoDisposeOnDestroy(lifecycleOwner);
		}
		if (imageUrls.Count == 2)
		{
			_twoImagesLayout.Visibility = ViewStates.Visible;
			_firstImage.FromUrl(imageUrls.First());
			_secondImage.FromUrl(imageUrls.Last());
			bindable.BindEvents(((View)_firstImage).OnClick((Action)delegate
			{
				onImageClicked(0);
			}), ((View)_secondImage).OnClick((Action)delegate
			{
				onImageClicked(1);
			})).AutoDisposeOnDestroy(lifecycleOwner);
		}
	}
}
