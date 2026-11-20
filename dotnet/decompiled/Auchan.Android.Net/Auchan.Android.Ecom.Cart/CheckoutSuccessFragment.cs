using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Reviews;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.Ecom.Cart;

internal class CheckoutSuccessFragment : BaseFragment<CheckoutSuccessViewModel>
{
	private BottomNavigationView? _bottomNavigation;

	protected override int LayoutId => 2131493010;

	public CheckoutSuccessFragment(Func<CheckoutSuccessViewModel.Parameter, CheckoutSuccessViewModel> newViewModel)
		: base((Func<Fragment, CheckoutSuccessViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CheckoutSuccessViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToHomeCommand.SafeSubscribe(delegate
		{
			NavigateToHome();
		}, this);
		base.ViewModel.NavigateToOrders.SafeSubscribe(NavigateToOrders, this);
		base.ViewModel.AddToOrderButtonItemViewModel.AddToCartButtonCommand.SafeSubscribe(delegate
		{
			NavigateToCatalog();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		NestedScrollView scrollView = view.RequireViewById<NestedScrollView>(2131298303);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView hintText = view.RequireViewById<TextView>(2131297563);
		Button continueButton = view.RequireViewById<Button>(2131296325);
		Button button = view.RequireViewById<Button>(2131298739);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297819);
		RecommendationsView recommendationsView = view.RequireViewById<RecommendationsView>(2131298181);
		recommendationsView.SetupWithScrollView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, scrollView);
		recommendationsView.RequireViewById<RecyclerView>(2131298179);
		SnackView warningAdultInfo = view.RequireViewById<SnackView>(2131298822);
		AddToOrderButtonControls addToOrderButtonControls = new AddToOrderButtonControls(view.RequireViewById<View>(2131296350));
		ConstraintLayout tooltip = view.RequireViewById<ConstraintLayout>(2131298692);
		TextView textView2 = tooltip.RequireViewById<TextView>(2131298702);
		TextView textView3 = tooltip.RequireViewById<TextView>(2131298691);
		Button button2 = tooltip.RequireViewById<Button>(2131298685);
		Button button3 = tooltip.RequireViewById<Button>(2131298682);
		textView2.Text = base.ViewModel.TooltipTitle;
		textView3.Text = base.ViewModel.TooltipDescription;
		button2.Text = base.ViewModel.TooltipButtonText;
		button3.Text = base.ViewModel.AddToOrderButtonItemViewModel.AddToCartButtonText;
		base.ViewModel.Recommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(GoToItemCard, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyRecommendationsInputDialog, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		ObservableRecyclerAdapter<CheckoutItemViewModel, CachingViewHolder> itemsAdapter = new ObservableRecyclerAdapter<CheckoutItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493268,
			BindViewHolderDelegate = OnBindItem
		};
		recyclerView.SetAdapter(itemsAdapter);
		textView.Text = base.ViewModel.MessageText;
		continueButton.Text = base.ViewModel.ActionButtonText;
		button.Text = base.ViewModel.TrackButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				warningAdultInfo.Text = base.ViewModel.AdultWarningText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AdultWarningText")),
			(delegate
			{
				warningAdultInfo.Visibility = base.ViewModel.IsAdultOrder.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAdultOrder")),
			(delegate
			{
				hintText.Text = base.ViewModel.HintText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HintText")),
			(delegate
			{
				tooltip.Visibility = base.ViewModel.NeedShowTooltip.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NeedShowTooltip")),
			(delegate
			{
				itemsAdapter.DataSource = base.ViewModel.Items;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Items"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.AddToOrderButtonItemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			continueButton.Visibility = (!base.ViewModel.AddToOrderButtonItemViewModel.IsVisible).ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsVisible")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(continueButton.OnClick(base.ViewModel.OnContinueClick), button.OnClick(base.ViewModel.OnTrackClick), ((View)button2).OnClick((Action)delegate
		{
			tooltip.Visibility = ViewStates.Gone;
		}), ((View)tooltip).OnClick((Action)delegate
		{
			tooltip.Visibility = ViewStates.Gone;
		}), ((View)button3).OnClick((Action)delegate
		{
			tooltip.Visibility = ViewStates.Gone;
			base.ViewModel.AddToOrderButtonItemViewModel.AddToCartButtonCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		addToOrderButtonControls.Setup(base.ViewModel.AddToOrderButtonItemViewModel).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.AddToOrderButtonItemViewModel.AddToCartButtonCommand.SafeSubscribe(delegate
		{
			PopToRoot();
		}, ViewLifecycleOwner);
	}

	private void OnBindItem(CachingViewHolder viewHolder, CheckoutItemViewModel item, int position, CompositeDisposable disposable)
	{
		new OrderListCellControls(viewHolder.RequireCachedView<View>(2131297767)).Setup(item.Order, item.Order.IsAdult);
	}

	private void PopToRoot()
	{
		for (int i = 0; i < base.ParentFragmentManager.BackStackEntryCount; i++)
		{
			base.ParentFragmentManager.PopBackStack();
		}
	}

	private void NavigateToCatalog()
	{
		PopToRoot();
		if (_bottomNavigation != null)
		{
			_bottomNavigation.SelectedItemId = 2131297641;
		}
	}

	private void NavigateToHome()
	{
		PopToRoot();
		if (_bottomNavigation != null)
		{
			_bottomNavigation.SelectedItemId = 2131297642;
		}
	}

	private void NavigateToOrders(Unit _)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<OrdersFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void GoToItemCard(ProductDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductDetailsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void ShowQtyRecommendationsInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
