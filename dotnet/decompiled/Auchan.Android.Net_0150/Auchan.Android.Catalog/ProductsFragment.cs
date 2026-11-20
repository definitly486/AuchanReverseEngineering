using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Common;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews;
using Google.Android.Material.AppBar;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal sealed class ProductsFragment : BaseToolbarFragment<ProductsViewModel>, IBannerNavigationSupport, IFragmentNavigation
{
	private const int RECOMMENDATIONS_PADDING_BOTTOM = 20;

	private const int RECOMMENDATIONS_RECYCLER_PADDING_TOP = 10;

	private const int RECOMMENDATIONS_RECYCLER_PADDING_BOTTOM = 19;

	private const int ITEM_MARGIN = 10;

	protected override int LayoutId => 2131493003;

	public ProductsFragment(Func<ProductsViewModel.Parameter, ProductsViewModel> newViewModel)
		: base((Func<Fragment, ProductsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ProductsViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenBannerRulesCommand.SafeSubscribe(delegate(WebViewModel.Parameter p)
		{
			NavigateTo<WebFragment, WebViewModel.Parameter>(p);
		}, this);
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override bool HasRightButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131296904);
		AppBarLayout appBar = frameLayout.RequireViewById<AppBarLayout>(2131296451);
		EndlessRecyclerView productList = frameLayout.RequireViewById<EndlessRecyclerView>(2131298017);
		SearchView searchView = appBar.RequireViewById<SearchView>(2131298322);
		AppCompatImageButton sortButton = frameLayout.RequireViewById<AppCompatImageButton>(2131298417);
		AppCompatImageButton filtersButton = frameLayout.RequireViewById<AppCompatImageButton>(2131297169);
		TextView filtersBadge = frameLayout.RequireViewById<TextView>(2131297170);
		appBar.RequireViewById<View>(2131297639);
		frameLayout.AddGoToTopButton(productList, delegate
		{
			productList.SmoothScrollToPosition(0);
		}, ViewLifecycleOwner);
		ConfigureProgressAndError(view);
		SetupProductList(productList);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		searchView.SetOnClickListener(new ViewOnClickListener(OnOpenSearch));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				filtersButton.Visibility = base.ViewModel.IsFilteringAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFilteringAvailable")),
			(delegate
			{
				filtersBadge.Visibility = base.ViewModel.IsFiltersButtonBadgeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFiltersButtonBadgeVisible")),
			(delegate
			{
				filtersBadge.Text = base.ViewModel.FiltersBadgeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FiltersBadgeText")),
			(delegate
			{
				sortButton.Visibility = base.ViewModel.IsSortButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSortButtonVisible")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)sortButton).OnClick((Action)delegate
		{
			base.ViewModel.OpenSort().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)filtersButton).OnClick((Action)delegate
		{
			base.ViewModel.OpenFiltersAsync().SafeFireAndForget((Action<Exception>)null, false);
		}), ((INotifyCollectionChanged)base.ViewModel.Recommendations.Sections).OnCollectionChanged((Action)delegate
		{
			appBar.Visibility = (!base.ViewModel.Recommendations.HasItems).ToVisibility();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnItemsResetCommand.SafeSubscribe(delegate
		{
			productList?.SmoothScrollToPosition(0);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateBackCommand.SafeSubscribe(delegate
		{
			OnNavigationButtonClick();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenSortCommand.SafeSubscribe(OnOpenSort, ViewLifecycleOwner);
		base.ViewModel.OpenFiltersCommand.SafeSubscribe(OnOpenFilters, ViewLifecycleOwner);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowAllCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<StaticProductListFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		this.SetupBannersNavigation(base.ViewModel.BannerNavigationSupport, ViewLifecycleOwner);
	}

	private void ConfigureProgressAndError(View view)
	{
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131296904);
		FrameLayout frameLayout2 = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout2.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297067);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
		Button okButton = constraintLayout2.RequireViewById<Button>(2131297728);
		TextView emptyTitle = constraintLayout2.RequireViewById<TextView>(2131298646);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				frameLayout
			},
			{
				VisualState.InProgress,
				frameLayout2
			},
			{
				VisualState.Error,
				constraintLayout
			},
			{
				VisualState.Empty,
				constraintLayout2
			}
		};
		textView.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				okButton.Text = base.ViewModel.OkEmptyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OkEmptyText")),
			(delegate
			{
				emptyTitle.Text = base.ViewModel.EmptyOffersText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyOffersText")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				showQrButton.Visibility = base.ViewModel.IsCodeAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCodeAvailable"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)button).OnClick((Action)delegate
		{
			base.ViewModel.Retry();
		}), ((View)okButton).OnClick((Action)delegate
		{
			base.ViewModel.NavigateBackCommand.Trigger();
		}), ((View)showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindCategory(ProductItemViewHolder vh, ProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		vh.BindData(base.ViewModel, vm, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
		vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.NavigateToDetails(vm);
		}).AddTo(disposable);
	}

	private void OnOpenSearch(View obj)
	{
		SearchProductsResultFragment.OpenSearch(this);
	}

	private void OnOpenSort(BrokerToken parameter)
	{
		ProductsOrderDialogFragment productsOrderDialogFragment = base.ParentFragmentManager.FragmentFactory.Instantiate<ProductsOrderDialogFragment>();
		productsOrderDialogFragment.Arguments = parameter.ToNavBundle();
		productsOrderDialogFragment.SetTargetFragment(this, 0);
		productsOrderDialogFragment.Show(base.ParentFragmentManager, null);
	}

	private void OnOpenFilters(BrokerToken parameter)
	{
		ProductsFiltersDialogFragment productsFiltersDialogFragment = base.ParentFragmentManager.FragmentFactory.Instantiate<ProductsFiltersDialogFragment>();
		productsFiltersDialogFragment.Arguments = parameter.ToNavBundle();
		productsFiltersDialogFragment.SetTargetFragment(this, 0);
		productsFiltersDialogFragment.Show(base.ParentFragmentManager, null);
	}

	public void OnResult(int requestCode, ProductSortType value)
	{
		base.ViewModel.OnSortSelected(value);
	}

	public void OnResult(int requestCode, List<string> value)
	{
		base.ViewModel.OnFiltersSelected(value);
	}

	private void SetupProductList(EndlessRecyclerView productList)
	{
		ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder>
		{
			CellLayoutId = 2131493288,
			BindViewHolderDelegate = OnBindCategory,
			DataSource = base.ViewModel.Products
		};
		observableRecyclerAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CreateViewHolderDelegate = (ViewGroup vg, int i) => new CachingViewHolder(new BannerBlockView(Context, base.ViewModel.BannerNavigationSupport)),
			BindViewHolderDelegate = delegate(CachingViewHolder h, object vm, int i, CompositeDisposable d)
			{
				BindBanners(h, d);
			},
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<object>(base.ViewModel)
		};
		observableRecyclerAdapter2.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		int sideMargin = GetSideMargin();
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter3 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CreateViewHolderDelegate = (ViewGroup vg, int i) => new CachingViewHolder(new RecommendationsView(Context)),
			BindViewHolderDelegate = delegate(CachingViewHolder vh, object vm, int i, CompositeDisposable d)
			{
				BindRecommendationsBlock(productList, sideMargin, vh, d);
			},
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<object>(base.ViewModel)
		};
		observableRecyclerAdapter3.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup((int pos) => (pos != 0 && pos != 1) ? 1 : 2));
		productList.SetAdapter(new ConcatAdapter(observableRecyclerAdapter2, observableRecyclerAdapter3, observableRecyclerAdapter));
		productList.SetLayoutManager(gridLayoutManager);
		productList.SetOnLoadMoreListener(new OnLoadMoreListener(delegate
		{
			base.ViewModel.LoadNextPage();
		}));
		productList.AddItemDecoration(new GridSpacesItemDecoration(10, sideMargin, (int i) => i > 1, setUpWithBanners: true));
		productList.HasNextPage = true;
	}

	private void BindBanners(CachingViewHolder h, CompositeDisposable d)
	{
		BannerBlockView banners = (BannerBlockView)h.ItemView;
		banners.SyncBanners(base.ViewModel.SalesBannerList, ViewLifecycleOwner);
		((INotifyCollectionChanged)base.ViewModel.SalesBannerList).OnCollectionChanged((Action)delegate
		{
			banners.SyncBanners(base.ViewModel.SalesBannerList, ViewLifecycleOwner);
		}).AddTo(d);
	}

	private void BindRecommendationsBlock(RecyclerView productList, int sideMargin, CachingViewHolder holder, CompositeDisposable disposable)
	{
		RecommendationsView recommendations = (RecommendationsView)holder.ItemView;
		recommendations.SetupWithRecyclerView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, productList);
		recommendations.RequireViewById<View>(2131298182).Visibility = ViewStates.Visible;
		View rr = recommendations.RequireViewById<View>(2131298179);
		rr.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), 2131100630)));
		OnCollectionChanged();
		base.ViewModel.Recommendations.Sections.OnCollectionChanged(OnCollectionChanged).AddTo(disposable);
		void OnCollectionChanged()
		{
			bool hasItems = base.ViewModel.Recommendations.HasItems;
			recommendations.Visibility = hasItems.ToVisibility();
			recommendations.SetPaddingDp(0, 0, 0, hasItems ? 20 : 10);
			rr.Visibility = hasItems.ToVisibility();
			rr.SetPadding(sideMargin + 2, hasItems ? Converter.DpToPx(10f) : 0, sideMargin, hasItems ? Converter.DpToPx(19f) : 0);
		}
	}

	private int GetSideMargin()
	{
		int num = (Converter.PxToDp(base.Activity.GetScreenWidthInPixels()) - 324 - 20) / 2;
		if (num < 0)
		{
			return 0;
		}
		return num;
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
