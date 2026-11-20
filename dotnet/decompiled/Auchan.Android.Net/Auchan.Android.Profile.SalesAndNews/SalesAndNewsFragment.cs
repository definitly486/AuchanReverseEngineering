using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Profile.SalesAndNews;
using VisibilitySwitch;

namespace Auchan.Android.Profile.SalesAndNews;

internal class SalesAndNewsFragment : BaseToolbarFragment<SalesAndNewsViewModel>, IBannerNavigationSupport, IFragmentNavigation
{
	protected override int LayoutId => 2131493086;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public SalesAndNewsFragment(Func<Fragment, SalesAndNewsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131298079);
		TextView textView = view2.RequireViewById<TextView>(2131298080);
		View emptyOrErrorView = view.RequireViewById<View>(2131297112);
		TextView textView2 = view.RequireViewById<TextView>(2131297083);
		TextView offersCounterText = view.RequireViewById<TextView>(2131298671);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298278);
		ObservableRecyclerAdapter<Banner, CachingViewHolder> salesAndNewsListAdapter = new ObservableRecyclerAdapter<Banner, CachingViewHolder>
		{
			CellLayoutId = 2131493517,
			BindViewHolderDelegate = OnBindSalesAndNewsInList,
			ClickCallback = OnSalesAndNewsClicked
		};
		recyclerView.SetAdapter(salesAndNewsListAdapter);
		base.ToolbarTitle = base.ViewModel.Title;
		textView.Text = base.ViewModel.ProgressTitle;
		textView2.Text = base.ViewModel.ErrorOrEmptyDescription;
		VisibilitySwitch<SalesAndNewsViewModel.VisualState> viewSwitch = new VisibilitySwitch<SalesAndNewsViewModel.VisualState>(base.ViewModel.State)
		{
			{
				SalesAndNewsViewModel.VisualState.Default,
				recyclerView
			},
			{
				SalesAndNewsViewModel.VisualState.InProgress,
				view2
			},
			{
				SalesAndNewsViewModel.VisualState.ErrorOrEmpty,
				emptyOrErrorView
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				emptyOrErrorView.Visibility = (!base.ViewModel.HasSalesAndNews).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasSalesAndNews")),
			(delegate
			{
				offersCounterText.Text = base.ViewModel.NewOffersCountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NewOffersCountText")),
			(delegate
			{
				salesAndNewsListAdapter.DataSource = base.ViewModel.SalesAndNewsList;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SalesAndNewsList"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		this.SetupBannersNavigation(base.ViewModel.BannerNavigationSupport, ViewLifecycleOwner);
	}

	private void OnSalesAndNewsClicked(CachingViewHolder vh, Banner vm, int pos)
	{
		base.ViewModel.OnSalesOrNewsClicked(vm);
	}

	private void OnBindSalesAndNewsInList(CachingViewHolder holder, Banner entry, int position, CompositeDisposable disposable)
	{
		holder.RequireCachedView<ImageView>(2131298275).FromUrl(entry.Image);
		holder.RequireCachedView<TextView>(2131298279).SetText(entry.PromoContent.Title, TextView.BufferType.Normal);
		holder.RequireCachedView<TextView>(2131298274).SetText(entry.PromoContent.Description, TextView.BufferType.Normal);
	}
}
