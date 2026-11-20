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
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews;
using Google.Android.Material.AppBar;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal sealed class CatalogProductsFragment : BaseToolbarFragment<CatalogProductsViewModel>, IBannerNavigationSupport, IFragmentNavigation
{
	private const int RECOMMENDATIONS_PADDING_BOTTOM = 20;

	private const int RECOMMENDATIONS_RECYCLER_PADDING_TOP = 10;

	private const int RECOMMENDATIONS_RECYCLER_PADDING_BOTTOM = 19;

	private const int ITEM_MARGIN = 10;

	private const int SIDES_MARGIN = 20;

	private const int ITEMS_MARGIN = 8;

	protected override int LayoutId => 2131493000;

	public CatalogProductsFragment(Func<BrokerToken, CatalogProductsViewModel> newViewModel)
		: base((Func<Fragment, CatalogProductsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override bool HasRightButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenBannerRulesCommand.SafeSubscribe(delegate(WebViewModel.Parameter p)
		{
			NavigateTo<WebFragment, WebViewModel.Parameter>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131296904);
		AppBarLayout appBarLayout = frameLayout.RequireViewById<AppBarLayout>(2131296451);
		EndlessRecyclerView productList = frameLayout.RequireViewById<EndlessRecyclerView>(2131298017);
		SearchView searchView = appBarLayout.RequireViewById<SearchView>(2131298322);
		View sortButton = frameLayout.RequireViewById<View>(2131298417);
		View filtersButton = frameLayout.RequireViewById<View>(2131297169);
		View filtersBadge = frameLayout.RequireViewById<View>(2131297170);
		View appBarSeparator = appBarLayout.RequireViewById<View>(2131297639);
		frameLayout.AddGoToTopButton(productList, delegate
		{
			productList.SmoothScrollToPosition(0);
		}, ViewLifecycleOwner);
		base.ToolbarTitle = base.ViewModel.Title ?? string.Empty;
		ConfigureProgressAndError(view);
		SetupProductList(productList);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
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
				sortButton.Visibility = base.ViewModel.IsSortButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSortButtonVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)searchView).OnClick((Action)delegate
		{
			SearchProductsResultFragment.OpenSearch(this);
		}), sortButton.OnClick((Action)delegate
		{
			base.ViewModel.SortCommand.Trigger();
		}), filtersButton.OnClick((Action)delegate
		{
			base.ViewModel.FiltersCommand.Trigger();
		}), ((INotifyCollectionChanged)base.ViewModel.Recommendations.Sections).OnCollectionChanged((Action)delegate
		{
			appBarSeparator.Visibility = (!base.ViewModel.Recommendations.HasItems).ToVisibility();
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
		base.ViewModel.OpenSortCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<ProductsOrderDialogFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenFiltersCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			ShowAsync<ProductsFiltersFragment, BrokerToken>(p).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.ClosePageCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
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
		RequireActivity().OnBackPressedDispatcher.AddCallback(ViewLifecycleOwner, new DelegateOnBackPressedCallback(delegate
		{
			OnNavigationButtonClick();
		}));
	}

	protected override void OnNavigationButtonClick()
	{
		base.ViewModel.TrackGoBack();
		base.OnNavigationButtonClick();
	}

	private void ConfigureProgressAndError(View view)
	{
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131296904);
		FrameLayout frameLayout2 = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = frameLayout2.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
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
			}
		};
		textView.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
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
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized")),
			(delegate
			{
				if (base.ViewModel.State == VisualState.Empty)
				{
					Show<EmptyCategoryPopupFragment>();
				}
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.Retry), ((View)showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindCategory(ProductItemViewHolder vh, ProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		vh.ItemView.UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
			lp.Height = Converter.DpToPx(288f);
		});
		vh.AddFragmentManager(base.ParentFragmentManager);
		vh.BindData(base.ViewModel, vm, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
		vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.NavigateToDetails(vm);
		}).AddTo(disposable);
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
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter3 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CreateViewHolderDelegate = (ViewGroup vg, int i) => new CachingViewHolder(new RecommendationsView(Context)),
			BindViewHolderDelegate = delegate(CachingViewHolder vh, object vm, int i, CompositeDisposable d)
			{
				BindRecommendationsBlock(productList, vh, d);
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
		productList.AddItemDecoration(new GridSpacesItemDecoration(10, 16, (int i) => i > 1, setUpWithBanners: true));
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

	private void BindRecommendationsBlock(RecyclerView productList, CachingViewHolder holder, CompositeDisposable disposable)
	{
		RecommendationsView recommendations = (RecommendationsView)holder.ItemView;
		recommendations.SectionTopMargin = Converter.DpToPx(10f);
		recommendations.AllSectionsBottomMargin = Converter.DpToPx(19f);
		RecommendationsView recommendationsView = recommendations;
		int sectionLeftMargin = (recommendations.SectionRightMargin = Converter.DpToPx(20f));
		recommendationsView.SectionLeftMargin = sectionLeftMargin;
		recommendations.SetupWithRecyclerView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, productList);
		ViewGroup sectionsRecycler = recommendations.RequireViewById<ViewGroup>(2131298179);
		sectionsRecycler.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), 2131099697)));
		OnCollectionChanged();
		base.ViewModel.Recommendations.Sections.OnCollectionChanged(OnCollectionChanged).AddTo(disposable);
		void OnCollectionChanged()
		{
			int bottom = (base.ViewModel.Recommendations.HasItems ? Converter.DpToPx(20f) : 0);
			recommendations.SetPadding(0, 0, 0, bottom);
			sectionsRecycler.SetPadding(0, 0, 0, bottom);
		}
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
