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
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal sealed class CollectionProductsFragment : BaseToolbarFragment<CollectionProductsViewModel>, IBannerNavigationSupport, IFragmentNavigation
{
	private const int RECOMMENDATIONS_RECYCLER_PADDING_BOTTOM = 8;

	private const int SIDES_MARGIN = 40;

	private const int ITEMS_MARGIN = 10;

	private readonly WeakReference<EndlessRecyclerView> _productList = new WeakReference<EndlessRecyclerView>(null);

	private readonly WeakReference<BannerBlockView> _banners = new WeakReference<BannerBlockView>(null);

	private RecyclerView? _toolbarRecyclerView;

	private LinearLayout? _topFiltersContainer;

	private readonly WeakReference<View> _recommendationRecycler = new WeakReference<View>(null);

	private readonly WeakReference<RecommendationsView> _recommendations = new WeakReference<RecommendationsView>(null);

	private ProductsScrollListener? _scrollListener;

	private int _itemWidth;

	private WeakReference<View> _filtersContainer = new WeakReference<View>(null);

	protected override int LayoutId => 2131493012;

	public CollectionProductsFragment(Func<BrokerToken, CollectionProductsViewModel> newViewModel)
		: base((Func<Fragment, CollectionProductsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
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
		TextView productsCount = frameLayout.RequireViewById<TextView>(2131298036);
		AppCompatImageButton appCompatImageButton = frameLayout.RequireViewById<AppCompatImageButton>(2131298314);
		_topFiltersContainer = frameLayout.RequireViewById<LinearLayout>(2131297172);
		LinearLayout sortButton = _topFiltersContainer.RequireViewById<LinearLayout>(2131298417);
		ImageView imageView = _topFiltersContainer.RequireViewById<ImageView>(2131298418);
		TextView sortTypeName = _topFiltersContainer.RequireViewById<TextView>(2131298419);
		ConstraintLayout filterButton = _topFiltersContainer.RequireViewById<ConstraintLayout>(2131297163);
		ImageView imageView2 = _topFiltersContainer.RequireViewById<ImageView>(2131297165);
		TextView textView = _topFiltersContainer.RequireViewById<TextView>(2131297168);
		View filtersBadge = _topFiltersContainer.RequireViewById<View>(2131297164);
		EndlessRecyclerView productList = frameLayout.RequireViewById<EndlessRecyclerView>(2131298017);
		_productList.SetTarget(productList);
		frameLayout.AddGoToTopButton(productList, delegate
		{
			productList.SmoothScrollToPosition(0);
		}, ViewLifecycleOwner);
		base.ToolbarTitle = base.ViewModel.Title ?? string.Empty;
		_toolbarRecyclerView = view.RequireViewById<RecyclerView>(2131298673);
		ObservableRecyclerAdapter<SelectionItemViewModel<Category>, CachingViewHolder> toolbarAdapter = new ObservableRecyclerAdapter<SelectionItemViewModel<Category>, CachingViewHolder>
		{
			CellLayoutId = 2131493510,
			BindViewHolderDelegate = OnBindCategory,
			DataSource = base.ViewModel.CategoryItemViewModels
		};
		_toolbarRecyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		_toolbarRecyclerView.SetAdapter(toolbarAdapter);
		_toolbarRecyclerView.Visibility = base.ViewModel.CategoriesVisible.ToVisibility();
		ConfigureProgressAndError(view);
		SetupProductList(productList);
		appCompatImageButton.SetOnClickListener(new ViewOnClickListener(OnOpenSearch));
		_topFiltersContainer.BringToFront();
		_topFiltersContainer.Visibility = ViewStates.Gone;
		imageView.SetColorFilter(new Color(ContextCompat.GetColor(Context, 2131099850)));
		imageView2.SetColorFilter(new Color(ContextCompat.GetColor(Context, 2131099850)));
		textView.Text = base.ViewModel.FiltersText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[7]
		{
			(delegate
			{
				filterButton.Visibility = base.ViewModel.IsFilteringAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFilteringAvailable")),
			(delegate
			{
				filtersBadge.Visibility = base.ViewModel.IsFiltersButtonBadgeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFiltersButtonBadgeVisible")),
			(delegate
			{
				sortButton.Visibility = base.ViewModel.IsSortButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSortButtonVisible")),
			(delegate
			{
				sortTypeName.Text = base.ViewModel.SortTypeName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SortTypeName")),
			(delegate
			{
				productsCount.Text = base.ViewModel.ProductsCount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductsCount")),
			(delegate
			{
				productsCount.Visibility = base.ViewModel.IsFilteringAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFilteringAvailable")),
			(delegate
			{
				toolbarAdapter.DataSource = base.ViewModel.CategoryItemViewModels;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CategoryItemViewModels"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)sortButton).OnClick((Action)delegate
		{
			base.ViewModel.SortCommand.Trigger();
		}), ((View)filterButton).OnClick((Action)delegate
		{
			base.ViewModel.FiltersCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
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
		base.ViewModel.OpenFiltersCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			ShowAsync<ProductsFiltersFragment, BrokerToken>(p).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.OnItemsResetCommand.SafeSubscribe(delegate(int position)
		{
			if (position >= 0)
			{
				_toolbarRecyclerView.ScrollToPosition(position);
			}
			productList.PostDelayed(delegate
			{
				((LinearLayoutManager)productList.GetLayoutManager()).ScrollToPositionWithOffset(1, 0);
			}, 350L);
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
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				emptyTitle.Text = base.ViewModel.EmptyOffersText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyOffersText")),
			(delegate
			{
				okButton.Text = base.ViewModel.OkEmptyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OkEmptyText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.Retry), ((View)showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), ((View)okButton).OnClick((Action)delegate
		{
			base.ViewModel.NavigateBackCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindCategory(ProductItemViewHolder vh, ProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		ViewGroup.LayoutParams layoutParameters = vh.ItemView.LayoutParameters;
		layoutParameters.Width = _itemWidth;
		vh.ItemView.LayoutParameters = layoutParameters;
		vh.AddFragmentManager(base.ParentFragmentManager);
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

	private void SetupProductList(EndlessRecyclerView productList)
	{
		ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder>
		{
			CellLayoutId = 2131493288,
			BindViewHolderDelegate = OnBindCategory,
			DataSource = base.ViewModel.Products
		};
		observableRecyclerAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		RecyclerView.Adapter adapter = CreateAdapter(productList, 0, OnCreateBanners, BindBanners);
		RecyclerView.Adapter adapter2 = CreateAdapter(productList, 0, OnCreateRecommendations, BindRecommendations);
		RecyclerView.Adapter adapter3 = CreateAdapter(productList, 2131492951, null, BindFilters);
		_itemWidth = GetItemWidth();
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup((int pos) => (pos > 2) ? 1 : 2));
		productList.SetAdapter(new ConcatAdapter(adapter, adapter2, adapter3, observableRecyclerAdapter));
		productList.SetLayoutManager(gridLayoutManager);
		productList.SetOnLoadMoreListener(new OnLoadMoreListener(delegate
		{
			base.ViewModel.LoadNextPage();
		}));
		productList.AddItemDecoration(new GridSpacesItemDecoration(40, -15, (int i) => i > 2, setUpWithBanners: true, 5, 5));
		productList.HasNextPage = true;
		_scrollListener = new ProductsScrollListener(delegate
		{
			OnScrolled(productList);
		});
		productList.AddOnScrollListener(_scrollListener);
	}

	private RecyclerView.Adapter CreateAdapter(RecyclerView recyclerView, int itemLayoutId, Func<RecyclerView, CachingViewHolder>? createViewHolderDelegate, Action<CachingViewHolder, CompositeDisposable> bindViewHolderDelegate)
	{
		ObservableRecyclerAdapter<CollectionProductsViewModel, CachingViewHolder> obj = new ObservableRecyclerAdapter<CollectionProductsViewModel, CachingViewHolder>
		{
			CellLayoutId = itemLayoutId,
			CreateViewHolderDelegate = ((createViewHolderDelegate != null) ? ((Func<ViewGroup, int, CachingViewHolder>)((ViewGroup p, int i) => createViewHolderDelegate(recyclerView))) : null),
			BindViewHolderDelegate = delegate(CachingViewHolder h, CollectionProductsViewModel vm, int i, CompositeDisposable d)
			{
				bindViewHolderDelegate(h, d);
			},
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<CollectionProductsViewModel>(base.ViewModel)
		};
		obj.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		return obj;
	}

	private CachingViewHolder OnCreateBanners(RecyclerView recyclerView)
	{
		BannerBlockView bannerBlockView = new BannerBlockView(recyclerView.Context, base.ViewModel.BannerNavigationSupport);
		_banners.SetTarget(bannerBlockView);
		return new CachingViewHolder(bannerBlockView);
	}

	private CachingViewHolder OnCreateRecommendations(RecyclerView recyclerView)
	{
		RecommendationsView recommendationsView = new RecommendationsView(recyclerView.Context);
		View view = recommendationsView.RequireViewById<View>(2131298179);
		view.SetPaddingDp(20, 0, 0, 8);
		_recommendations.SetTarget(recommendationsView);
		_recommendationRecycler.SetTarget(view);
		return new CachingViewHolder(recommendationsView);
	}

	private void BindBanners(CachingViewHolder viewHolder, ICollection<IDisposable> disposables)
	{
		BannerBlockView banners = (BannerBlockView)viewHolder.ItemView;
		OnBannerChanged();
		((INotifyCollectionChanged)base.ViewModel.SalesBannerList).OnCollectionChanged((Action)delegate
		{
			OnBannerChanged();
		}).AddTo(disposables);
		base.ViewModel.Recommendations.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateState(base.ViewModel.Recommendations.HasItems);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasItems")))).AddTo(disposables);
		void OnBannerChanged()
		{
			if (base.ViewModel.HasBanners)
			{
				banners.GetChildAt(0)?.SetPaddingDp(0, 0, 0, 10);
			}
			else
			{
				banners.GetChildAt(0)?.SetPadding(0, 0, 0, 1);
			}
			banners.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), (!base.ViewModel.HasBanners && !base.ViewModel.Recommendations.HasItems) ? 2131099847 : 2131099697)));
			banners.SyncBanners(base.ViewModel.SalesBannerList, ViewLifecycleOwner);
		}
		void UpdateState(bool hasItems)
		{
			bool flag = !base.ViewModel.HasBanners && !hasItems;
			banners.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), flag ? 2131099847 : 2131099697)));
		}
	}

	private void BindRecommendations(CachingViewHolder viewHolder, ICollection<IDisposable> disposables)
	{
		RecommendationsView recommendationsView = (RecommendationsView)viewHolder.ItemView;
		View recommendationRecycler = viewHolder.RequireCachedView<View>(2131298179);
		base.ViewModel.Recommendations.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateState(base.ViewModel.Recommendations.HasItems);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasItems")))).AddTo(disposables);
		_productList.Invoke(delegate(EndlessRecyclerView pl)
		{
			recommendationsView.SetupWithRecyclerView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, pl);
		});
		void UpdateState(bool hasItems)
		{
			if (hasItems)
			{
				recommendationRecycler.SetPaddingDp(20, 0, 0, 8);
			}
			else
			{
				recommendationRecycler.SetPadding(0, 0, 0, 1);
			}
			bool flag = !base.ViewModel.HasBanners && !hasItems;
			recommendationsView.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), flag ? 2131099847 : 2131099697)));
		}
	}

	private void BindFilters(CachingViewHolder viewHolder, ICollection<IDisposable> disposables)
	{
		LinearLayout sortButtonContainer = viewHolder.RequireCachedView<LinearLayout>(2131298417);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131298418);
		TextView sortTypeName = viewHolder.RequireCachedView<TextView>(2131298419);
		ConstraintLayout constraintLayout = viewHolder.RequireCachedView<ConstraintLayout>(2131297163);
		ImageView imageView2 = viewHolder.RequireCachedView<ImageView>(2131297165);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131297168);
		View filterBadge = viewHolder.RequireCachedView<View>(2131297164);
		imageView.SetColorFilter(new Color(ContextCompat.GetColor(Context, 2131099850)));
		imageView2.SetColorFilter(new Color(ContextCompat.GetColor(Context, 2131099850)));
		textView.Text = base.ViewModel.FiltersText;
		viewHolder.ItemView.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams parameters)
		{
			parameters.TopMargin = Converter.DpToPx(20f);
			parameters.BottomMargin = Converter.DpToPx(11f);
		});
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				filterBadge.Visibility = base.ViewModel.IsFiltersButtonBadgeVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFiltersButtonBadgeVisible")),
			(delegate
			{
				sortButtonContainer.Visibility = base.ViewModel.IsSortButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSortButtonVisible")),
			(delegate
			{
				sortTypeName.Visibility = base.ViewModel.IsSortButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSortButtonVisible")),
			(delegate
			{
				sortTypeName.Text = base.ViewModel.SortTypeName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SortTypeName"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(((View)sortButtonContainer).OnClick((Action)delegate
		{
			base.ViewModel.SortCommand.Trigger();
		}), ((View)constraintLayout).OnClick((Action)delegate
		{
			base.ViewModel.FiltersCommand.Trigger();
		})).AddTo(disposables);
	}

	private int GetItemWidth()
	{
		int num = (Converter.PxToDp(base.Activity.GetScreenWidthInPixels()) - 40 - 10) / 2;
		if (num < 0)
		{
			return 0;
		}
		return Converter.DpToPx(num);
	}

	private void OnScrolled(View recyclerView)
	{
		int[] location = new int[2];
		_filtersContainer.Invoke(delegate(View fc)
		{
			fc.GetLocationOnScreen(location);
		});
		int num = location[1];
		recyclerView.GetLocationOnScreen(location);
		int num2 = location[1];
		_recommendations.Invoke(delegate(RecommendationsView r)
		{
			r.GetLocationOnScreen(location);
		});
		int num3 = location[1];
		_banners.Invoke(delegate(BannerBlockView b)
		{
			b.GetLocationOnScreen(location);
		});
		int num4 = location[1];
		if (num <= num2 && num4 == 0 && num3 == 0)
		{
			if (_topFiltersContainer.Visibility != ViewStates.Visible)
			{
				_topFiltersContainer.Visibility = ViewStates.Visible;
			}
		}
		else if (_topFiltersContainer.Visibility != ViewStates.Gone)
		{
			_topFiltersContainer.Visibility = ViewStates.Gone;
		}
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}

	private void OnBindCategory(CachingViewHolder vh, SelectionItemViewModel<Category> vm, int position, CompositeDisposable disposable)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298646);
		title.Text = vm.Item.Name;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				title.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), vm.Selected ? 2131100630 : 2131099872)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")),
			(delegate
			{
				title.SetBackgroundResource(vm.Selected ? 2131230922 : 2131230920);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected"))
		})).AddTo(disposable);
		vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SelectCategory(vm);
		}).AddTo(disposable);
	}
}
