using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile;
using Auchan.Common.Reviews;

namespace Auchan.Android.Catalog;

internal class StaticProductListFragment : BaseToolbarFragment<StaticProductListViewModel>
{
	private RecyclerView _productList;

	private RecyclerView _toolbarRecyclerView;

	private View _toolbarRecyclerViewInterceptor;

	protected override int LayoutId => 2131493099;

	public StaticProductListFragment(Func<BrokerToken, StaticProductListViewModel> newViewModel)
		: base((Func<Fragment, StaticProductListViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToProductCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnNavigateNext).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, this);
		base.ViewModel.SelectCategoryCommand.SafeSubscribe(delegate(int position)
		{
			_toolbarRecyclerViewInterceptor.Visibility = ViewStates.Visible;
			LinearLayoutManager linearLayoutManager = (LinearLayoutManager)_toolbarRecyclerView.GetLayoutManager();
			if (linearLayoutManager != null && linearLayoutManager.FindFirstVisibleItemPosition() == position)
			{
				linearLayoutManager.ScrollToPositionWithOffset(position, Converter.DpToPx(8f));
			}
			else
			{
				_toolbarRecyclerView.SmoothScrollToPosition(position);
			}
			_toolbarRecyclerView.PostDelayed(delegate
			{
				base.ViewModel.CategorySelected = false;
				_toolbarRecyclerViewInterceptor.Visibility = ViewStates.Gone;
			}, 200L);
		}, this);
		base.ViewModel.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		base.ToolbarTitle = base.ViewModel.Title;
		_toolbarRecyclerView = view.RequireViewById<RecyclerView>(2131298673);
		_toolbarRecyclerViewInterceptor = view.RequireViewById<View>(2131298674);
		ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493290,
			BindViewHolderDelegate = OnBindCategory,
			DataSource = base.ViewModel.CategoryItemViewModels
		};
		_toolbarRecyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		_toolbarRecyclerView.SetAdapter(adapter);
		_toolbarRecyclerView.Visibility = base.ViewModel.CategoriesVisible.ToVisibility();
		_productList = view.RequireViewById<RecyclerView>(2131298017);
		ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder>
		{
			CellLayoutId = 2131493288,
			BindViewHolderDelegate = OnBindCategory,
			ClickCallback = OnItemClick,
			DataSource = base.ViewModel.Products
		};
		observableRecyclerAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		_productList.HasFixedSize = true;
		int num = GetSideMargin();
		_productList.SetPaddingDp(num, 12, num, 20);
		_productList.SetAdapter(observableRecyclerAdapter);
		_productList.SetLayoutManager(new GridLayoutManager(base.Activity, 2));
		_productList.AddItemDecoration(new GridSpacesItemDecoration(10));
		int GetSideMargin()
		{
			int num2 = (Converter.PxToDp(base.Activity.GetScreenWidthInPixels()) - 324 - 20) / 2;
			if (num2 < 0)
			{
				return 0;
			}
			return num2;
		}
	}

	private void OnBindCategory(CachingViewHolder vh, CategoryItemViewModel vm, int position, CompositeDisposable disposable)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298646);
		title.Text = vm.Title;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), vm.Selected ? 2131100630 : 2131099872)));
			title.SetBackgroundResource(vm.Selected ? 2131230922 : 2131230920);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		vh.ItemView.OnClick((Action)delegate
		{
			SelectCategory(vm);
		}).AddTo(disposable);
	}

	private void SelectCategory(CategoryItemViewModel vm)
	{
		base.ViewModel.OnCategorySelected(vm);
		_productList.ScrollToPosition(0);
	}

	private void OnItemClick(ProductItemViewHolder vh, ProductItemViewModel vm, int pos)
	{
		base.ViewModel.NavigateToDetails(vm);
	}

	private void OnBindCategory(ProductItemViewHolder vh, ProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		vh.BindData(base.ViewModel, vm, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
	}

	private void OnNavigateNext(ProductDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductDetailsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
