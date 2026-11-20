using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Extensions;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.Ecom.Banners;

public class BannerBlockView : FrameLayout
{
	private readonly View _content;

	private readonly SliderView _sliderView;

	private readonly TextView _salesAndNewsTitle;

	private readonly TextView _salesAndNewsDescription;

	private readonly TextView _salesAndNewsLinkTextView;

	private readonly Auchan.Common.Ecom.Banners.IBannerNavigationSupport _bannerNavigationSupport;

	public BannerBlockView(Context context, Auchan.Common.Ecom.Banners.IBannerNavigationSupport bannerNavigationSupport)
		: base(context)
	{
		_bannerNavigationSupport = bannerNavigationSupport;
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		View view = View.Inflate(context, 2131493133, this) ?? throw new InvalidOperationException("no layout found");
		_content = view.RequireViewById<View>(2131296838);
		_sliderView = view.RequireViewById<SliderView>(2131298283);
		_salesAndNewsTitle = view.RequireViewById<TextView>(2131298279);
		_salesAndNewsDescription = view.RequireViewById<TextView>(2131298274);
		_salesAndNewsLinkTextView = view.RequireViewById<TextView>(2131298277);
		SetupBannerPager(_sliderView);
	}

	private void SetupBannerPager(SliderView slider)
	{
		ViewPager2 viewPager = slider.ViewPager;
		slider.RequestLayout();
		EndlessRecyclerAdapter<Banner> salesAndNewsBannerAdapter = new EndlessRecyclerAdapter<Banner>
		{
			CellLayoutId = 2131493518,
			BindViewHolderDelegate = OnBindBanner,
			MinItemsForEndless = 3
		};
		viewPager.OffscreenPageLimit = 2;
		viewPager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(20f)));
		viewPager.Adapter = salesAndNewsBannerAdapter;
		viewPager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(null, delegate(int position, float positionOffset, int _)
		{
			int position2 = salesAndNewsBannerAdapter.RealPosition(position);
			slider.Indicator.AnimatePageSelected(position2);
		}));
	}

	private void OnBindBanner(CachingViewHolder holder, Banner model, int position, CompositeDisposable disposable)
	{
		holder.ItemView.OnClick((Action)delegate
		{
			model.NavigateTo.Activate(_bannerNavigationSupport);
		}).AddTo(disposable);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131298275);
		imageView.FromUrl(model.Image);
		((View)imageView).OnClick((Action)delegate
		{
			model.NavigateTo.Activate(_bannerNavigationSupport);
		}).AddTo(disposable);
	}

	public void SyncBanners(IReadOnlyList<Banner> newBanners, ILifecycleOwner lifecycleOwner)
	{
		if (_sliderView == null)
		{
			return;
		}
		bool flag = newBanners.Count > 0;
		bool flag2 = newBanners.Count > 1;
		_content.Visibility = flag.ToVisibility();
		if (flag)
		{
			if (!string.IsNullOrWhiteSpace(newBanners[0].PromoContent.Title))
			{
				_salesAndNewsTitle.SetText(newBanners[0].PromoContent.Title, TextView.BufferType.Normal);
				_salesAndNewsTitle.Visibility = ViewStates.Visible;
			}
			if (!string.IsNullOrWhiteSpace(newBanners[0].PromoContent.Description))
			{
				_salesAndNewsDescription.SetText(newBanners[0].PromoContent.Description, TextView.BufferType.Normal);
				_salesAndNewsDescription.Visibility = ViewStates.Visible;
			}
			if (!string.IsNullOrWhiteSpace(newBanners[0].PromoContent.LinkText))
			{
				_salesAndNewsLinkTextView.PaintFlags |= PaintFlags.UnderlineText;
				_salesAndNewsLinkTextView.SetText(newBanners[0].PromoContent.LinkText, TextView.BufferType.Normal);
				_salesAndNewsLinkTextView.Visibility = ViewStates.Visible;
			}
			((View)_salesAndNewsLinkTextView).OnClick((Action)delegate
			{
				newBanners[0].PromoContent.NavigateTo?.Activate(_bannerNavigationSupport);
			}).AutoDisposeOnDestroy(lifecycleOwner);
			ViewPager2 viewPager = _sliderView.ViewPager;
			EndlessRecyclerAdapter<Banner> endlessRecyclerAdapter = (EndlessRecyclerAdapter<Banner>)_sliderView.ViewPager.Adapter;
			int num = base.Context.Resources.DisplayMetrics.WidthPixels - viewPager.PaddingStart - viewPager.PaddingEnd;
			int correctedHeight = num * 31 / 67;
			((View)viewPager).UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
			{
				lp.Height = correctedHeight;
			});
			endlessRecyclerAdapter.DataSource = newBanners;
			viewPager.SetCurrentItem(endlessRecyclerAdapter.FirstItemAdapterPosition, smoothScroll: false);
			_sliderView.TouchListener.SetHeight(-2);
			CircleIndicator indicator = _sliderView.Indicator;
			indicator.Visibility = flag2.ToVisibility();
			if (flag2)
			{
				indicator.CreateIndicators(endlessRecyclerAdapter.DataSource.Count, 0);
			}
		}
	}
}
