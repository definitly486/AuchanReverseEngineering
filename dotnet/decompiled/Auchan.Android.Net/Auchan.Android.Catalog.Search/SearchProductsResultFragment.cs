using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using EBind;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Catalog.Search;

internal sealed class SearchProductsResultFragment : BaseToolbarFragment<SearchProductsResultViewModel>
{
	private const int RECOMENDATION_POSITION = 0;

	private const int FILTERS_POSITION = 1;

	private const int SIDES_MARGIN = 20;

	private const int ITEMS_MARGIN = 8;

	private ViewGroup _searchView;

	private RecyclerView _productList;

	private ProductsScrollListener _scrollListener;

	private RecommendationsView _recommendations;

	private LinearLayout _topFiltersContainer;

	private RecyclerView _autohintsRecyclerView;

	private ConstraintLayout _filtersContainer;

	private readonly WeakReference<OnBackPressedCallback> _backPressedCallback = new WeakReference<OnBackPressedCallback>(null);

	protected override int LayoutId => 2131493091;

	public SearchProductsResultFragment(Func<SearchProductsResultViewModel.Parameter, SearchProductsResultViewModel> newViewModel)
		: base((Func<Fragment, SearchProductsResultViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<SearchProductsResultViewModel.Parameter>())))
	{
	}

	public static void OpenSearch(BaseFragment from)
	{
		_ = from.ParentFragmentManager;
		if (!from.TryPopToFragmentImmediate<SearchProductsResultFragment>())
		{
			from.NavigateTo<SearchProductsResultFragment, SearchProductsResultViewModel.Parameter>(new SearchProductsResultViewModel.Parameter(), 2131297216, add: true);
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_searchView = view.RequireViewById<ViewGroup>(2131298322);
		view.RequireViewById<View>(2131298669);
		SearchView searchView = _searchView.RequireViewById<SearchView>(2131298132);
		EditText searchEditText = searchView.RequireViewById<EditText>(2131298321);
		View clearButton = _searchView.RequireViewById<View>(2131298133);
		TextView textView = _searchView.RequireViewById<TextView>(2131296613);
		_productList = view.RequireViewById<RecyclerView>(2131298017);
		CoordinatorLayout coordinatorLayout = view.RequireViewById<CoordinatorLayout>(2131296842);
		NestedScrollView nestedScrollView = view.RequireViewById<NestedScrollView>(2131297081);
		View view2 = view.RequireViewById<View>(2131298087);
		TextView textView2 = view2.RequireViewById<TextView>(2131298080);
		TextView textView3 = nestedScrollView.RequireViewById<TextView>(2131297083);
		TextView textView4 = nestedScrollView.RequireViewById<TextView>(2131297071);
		_topFiltersContainer = view.RequireViewById<LinearLayout>(2131297172);
		LinearLayout linearLayout = _topFiltersContainer.RequireViewById<LinearLayout>(2131298417);
		_topFiltersContainer.RequireViewById<ImageView>(2131298418);
		TextView sortTypeName = _topFiltersContainer.RequireViewById<TextView>(2131298419);
		ConstraintLayout filtersButton = _topFiltersContainer.RequireViewById<ConstraintLayout>(2131297163);
		_topFiltersContainer.RequireViewById<ImageView>(2131297165);
		TextView textView5 = _topFiltersContainer.RequireViewById<TextView>(2131297168);
		View filtersButtonBadge = _topFiltersContainer.RequireViewById<View>(2131297164);
		_autohintsRecyclerView = view.RequireViewById<RecyclerView>(2131296478);
		coordinatorLayout.AddGoToTopButton(_productList, delegate
		{
			_productList.SmoothScrollToPosition(0);
		}, ViewLifecycleOwner);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		searchView.SetQuery(base.ViewModel.SearchQuery, submit: false);
		searchEditText.Ellipsize = TextUtils.TruncateAt.End;
		searchEditText.SetSelection(0);
		textView.Text = base.ViewModel.CancelButton;
		RecommendationsView recommendationsView = nestedScrollView.RequireViewById<RecommendationsView>(2131297079);
		recommendationsView.RequireViewById<View>(2131298179);
		ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder> adapter = SetupRecyclerView(_productList);
		_autohintsRecyclerView.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false));
		_autohintsRecyclerView.SetAdapter(new ObservableRecyclerAdapter<SearchAutofillItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Autofills,
			CellLayoutId = 2131493326,
			BindViewHolderDelegate = OnBindAutohint
		});
		textView3.Text = base.ViewModel.EmptySearchTitle;
		textView4.Text = base.ViewModel.EmptySearchSubtitle;
		textView2.Text = base.ViewModel.ProgressTitle;
		base.Activity.Window.HideKeyboardOnTouchOutside(_searchView, ViewLifecycleOwner);
		VisibilitySwitch<SearchVisualState> viewSwitch = new VisibilitySwitch<SearchVisualState>(base.ViewModel.SearchState)
		{
			{
				SearchVisualState.Content,
				coordinatorLayout
			},
			{
				SearchVisualState.InProgress,
				view2
			},
			{
				SearchVisualState.NotFound,
				nestedScrollView
			}
		};
		_topFiltersContainer.BringToFront();
		_topFiltersContainer.Visibility = ViewStates.Gone;
		textView5.Text = base.ViewModel.FiltersText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[8]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.SearchState);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchState")),
			(delegate
			{
				adapter.DataSource = base.ViewModel.ItemsForView;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsForView")),
			(delegate
			{
				searchView.SetQuery(base.ViewModel.SearchQuery, submit: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery")),
			(delegate
			{
				sortTypeName.Text = base.ViewModel.SortTypeName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SortTypeName")),
			(delegate
			{
				clearButton.Visibility = (!string.IsNullOrEmpty(base.ViewModel.SearchQuery)).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery")),
			(delegate
			{
				filtersButton.Visibility = base.ViewModel.FiltersAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FiltersAvailable")),
			(delegate
			{
				filtersButtonBadge.Visibility = base.ViewModel.FiltersSelected.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FiltersSelected")),
			(delegate
			{
				_autohintsRecyclerView.Visibility = base.ViewModel.AutofillsAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AutofillsAvailable"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		clearButton.SetOnClickListener(new ViewOnClickListener(base.ViewModel.OpenSearchFormWithClearCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		searchView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.OpenSearchFormCommand.Trigger(null);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner));
		textView.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		filtersButton.SetOnClickListener(new ViewOnClickListener(base.ViewModel.OpenSearchFiltersCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		linearLayout.SetOnClickListener(new ViewOnClickListener(base.ViewModel.OpenSearchSortsCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		recommendationsView.Setup(base.ViewModel, base.ViewModel.EmptyRecommendations, ViewLifecycleOwner, (View _) => base.ViewModel.WhenEmptyState);
		recommendationsView.HideWhenEmpty(base.ViewModel.EmptyRecommendations, ViewLifecycleOwner);
		base.ViewModel.OnPropertyChanges((SearchProductsResultViewModel x) => x.SearchQuery).SafeSubscribe(delegate
		{
			searchEditText.SetSelection(0);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToDetailsCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
		base.ViewModel.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.ProductRecommendationsViewModel.RecommendationsViewModel.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.ProductRecommendationsViewModel.RecommendationsViewModel.NavigateToProductCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
		base.ViewModel.ProductRecommendationsViewModel.RecommendationsViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
		base.ViewModel.ProductRecommendationsViewModel.RecommendationsViewModel.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.EmptyRecommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.EmptyRecommendations.NavigateToProductCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
		base.ViewModel.FullCloseCommand.SafeSubscribe(delegate
		{
			OnFullCloseCommand().SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenSearchFormCommand.SafeSubscribe(delegate(SearchProductsFormViewModel.Parameter p)
		{
			NavigateTo<SearchProductsFormFragment, SearchProductsFormViewModel.Parameter>(p, null, add: true);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenSearchFiltersCommand.SafeSubscribe(delegate
		{
			Show<SearchProductsFiltersFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenSearchSortsCommand.SafeSubscribe(delegate
		{
			Show<SearchProductsSortsFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, ViewLifecycleOwner);
		RxTaskExtensions.StartWithDefault(base.ViewModel.OnPropertyChanges((SearchProductsResultViewModel x) => x.SearchProductResults)).SafeSubscribe(delegate
		{
			_productList.ScrollToPosition(0);
		}, ViewLifecycleOwner);
		base.ViewModel.OnBindCompletedAsync().SafeFireAndForget((Action<Exception>)null, false);
		_backPressedCallback.SetTarget(RequireActivity().OnBackPressedDispatcher.AddCallback(ViewLifecycleOwner, base.ViewModel.CloseCommand.Trigger));
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		_backPressedCallback.Invoke(delegate(OnBackPressedCallback c)
		{
			c.Enabled = !hidden;
		});
	}

	private async Task OnFullCloseCommand()
	{
		FragmentManager fragmentManager = await this.GetParentFragmentManagerAsync();
		int num = fragmentManager.Fragments.Skip(Math.Max(0, fragmentManager.Fragments.IndexOf(this))).Count();
		for (int i = 0; i < num; i++)
		{
			fragmentManager.PopBackStackImmediate();
		}
	}

	private void OnBindAutohint(CachingViewHolder viewHolder, SearchAutofillItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		itemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.Text = itemViewModel.Text;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")))).AddTo(disposables);
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectAutofillItemCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
	}

	private ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder> SetupRecyclerView(RecyclerView productList)
	{
		ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<BaseItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.ItemsForView,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = OnBindCategory,
			CreateViewHolderDelegate = CreateViewHolder
		};
		observableRecyclerAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<object>(base.ViewModel),
			CreateViewHolderDelegate = (ViewGroup p, int i) => new CachingViewHolder(new RecommendationsView(p.Context)),
			BindViewHolderDelegate = delegate(CachingViewHolder h, object vm, int i, CompositeDisposable d)
			{
				_recommendations = (RecommendationsView)h.ItemView;
				_recommendations.ForceHideDivider();
				_recommendations.SetPaddingDp(0, 0, 0, 0);
				_recommendations.SetupWithRecyclerView(base.ViewModel, base.ViewModel.Recommendations, ViewLifecycleOwner, productList);
				View view = _recommendations.RequireViewById<View>(2131298179);
				view.SetPaddingDp(20, 24, 0, 16);
				view.SetBackgroundColor(new global::Android.Graphics.Color(ContextCompat.GetColor(RequireContext(), 2131099697)));
			}
		};
		observableRecyclerAdapter2.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		ObservableRecyclerAdapter<SearchProductsResultViewModel, CachingViewHolder> observableRecyclerAdapter3 = new ObservableRecyclerAdapter<SearchProductsResultViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493335,
			BindViewHolderDelegate = delegate(CachingViewHolder h, SearchProductsResultViewModel vm, int i, CompositeDisposable d)
			{
				BindFilters(h, d).SafeFireAndForget((Action<Exception>)null, false);
			},
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<SearchProductsResultViewModel>(base.ViewModel)
		};
		observableRecyclerAdapter3.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup((int pos) => (!IsWideItem(pos)) ? 1 : 2));
		productList.SetPaddingDp(0, 0, 0, 20);
		productList.SetAdapter(new ConcatAdapter(observableRecyclerAdapter2, observableRecyclerAdapter3, observableRecyclerAdapter));
		productList.SetLayoutManager(gridLayoutManager);
		productList.SetItemAnimator(null);
		productList.AddItemDecoration(new SearchItemDecoration(8, 16, (int i) => i != 0 && i != 1 && !(base.ViewModel.ItemsForView[i - 2] is ProductRecommendationsViewModel), (int i) => !base.ViewModel.ProductRecommendationsViewModel.ItemIndexGreaterThanStub(i), (int i) => i != 0 && i != 1 && base.ViewModel.ProductRecommendationsViewModel.ItemIndexLessThanStub(i)));
		_scrollListener = new ProductsScrollListener(OnScrolled);
		_scrollListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		productList.AddScrollListener(_scrollListener);
		return observableRecyclerAdapter;
	}

	private bool IsWideItem(int position)
	{
		if (position != 0 && position != 1)
		{
			if (base.ViewModel.ProductRecommendationsViewModel.IsVisible)
			{
				if (base.ViewModel.ProductRecommendationsViewModel.Index != position - 2)
				{
					if (position == 0)
					{
						return base.ViewModel.ProductRecommendationsViewModel.Index - (position - 2) == 2;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private int GetItemViewTypeDelegate(int position)
	{
		if (!(base.ViewModel.ItemsForView[position] is ProductItemViewModel))
		{
			return 2131493302;
		}
		return 2131493288;
	}

	private CachingViewHolder CreateViewHolder(ViewGroup parent, int type)
	{
		if (type != 2131493288)
		{
			return new CachingViewHolder(base.LayoutInflater.Inflate(type, parent, attachToRoot: false));
		}
		return new ProductItemViewHolder(base.LayoutInflater.Inflate(type, parent, attachToRoot: false));
	}

	private async Task BindFilters(CachingViewHolder viewHolder, ICollection<IDisposable> disposables)
	{
		_filtersContainer = viewHolder.RequireCachedView<ConstraintLayout>(2131297172);
		TextView productsCountText = viewHolder.RequireCachedView<TextView>(2131298005);
		LinearLayout linearLayout = viewHolder.RequireCachedView<LinearLayout>(2131298417);
		TextView sortTypeName = viewHolder.RequireCachedView<TextView>(2131298419);
		ConstraintLayout constraintLayout = viewHolder.RequireCachedView<ConstraintLayout>(2131297163);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131297168);
		View filterBadge = viewHolder.RequireCachedView<View>(2131297164);
		textView.Text = base.ViewModel.FiltersText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				productsCountText.Text = base.ViewModel.ProductCountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductCountText")),
			(delegate
			{
				filterBadge.Visibility = base.ViewModel.FiltersSelected.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FiltersSelected")),
			(delegate
			{
				sortTypeName.Text = base.ViewModel.SortTypeName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SortTypeName"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(linearLayout.OnClick(base.ViewModel.OpenSearchSortsCommand.Trigger), constraintLayout.OnClick(base.ViewModel.OpenSearchFiltersCommand.Trigger)).AddTo(disposables);
		_topFiltersContainer.Visibility = ViewStates.Gone;
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		OnScrolled();
	}

	private void OnScrolled()
	{
		System.Drawing.Point locationInWindow = _filtersContainer.GetLocationInWindow();
		System.Drawing.Point locationInWindow2 = _topFiltersContainer.GetLocationInWindow();
		int num = _topFiltersContainer.PaddingTop + locationInWindow2.Y;
		if (locationInWindow.Y <= num)
		{
			if (_topFiltersContainer.Visibility != ViewStates.Visible)
			{
				_topFiltersContainer.Visibility = ViewStates.Visible;
			}
		}
		else if (locationInWindow.Y >= num && _topFiltersContainer.Visibility != ViewStates.Gone)
		{
			_topFiltersContainer.Visibility = ViewStates.Gone;
		}
	}

	private void OnBindCategory(CachingViewHolder vh, BaseItemViewModel vm, int position, CompositeDisposable disposable)
	{
		if (vh is ProductItemViewHolder productItemViewHolder)
		{
			ProductItemViewModel model = vm as ProductItemViewModel;
			if (model != null)
			{
				ViewGroup.LayoutParams layoutParameters = vh.ItemView.LayoutParameters;
				layoutParameters.Width = GetItemWidth();
				vh.ItemView.LayoutParameters = layoutParameters;
				ViewGroup.LayoutParams layoutParameters2 = vh.ItemView.LayoutParameters;
				layoutParameters2.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
				layoutParameters2.Height = Converter.DpToPx(288f);
				vh.ItemView.LayoutParameters = layoutParameters2;
				productItemViewHolder.BindData(base.ViewModel, model, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
				productItemViewHolder.ItemView.Click += new DisposableDelegate<EventHandler>(delegate
				{
					base.ViewModel.NavigateToProductDetails(model);
				}, delegate(EventHandler h)
				{
					vh.ItemView.Click -= h;
				}).AddTo(disposable);
				return;
			}
		}
		if (vm is ProductRecommendationsViewModel productRecommendationsViewModel)
		{
			View view = vh.RequireCachedView<View>(2131297431);
			View view2 = vh.RequireCachedView<View>(2131298255);
			ImageView imageView = vh.RequireCachedView<ImageView>(2131296789);
			RecommendationsView recommendationsView = vh.RequireCachedView<RecommendationsView>(2131298180);
			view.Visibility = productRecommendationsViewModel.IsLeftAlignment.ToVisibility();
			view2.Visibility = (!productRecommendationsViewModel.IsLeftAlignment).ToVisibility();
			recommendationsView.SetupWithRecyclerView(base.ViewModel, base.ViewModel.ProductRecommendationsViewModel.RecommendationsViewModel, ViewLifecycleOwner, _productList);
			imageView.SetOnClickListener(new ViewOnClickListener((Action)delegate
			{
				base.ViewModel.ProductRecommendationsViewModel.Close();
			}).AddTo(disposable));
		}
	}

	private int GetItemWidth()
	{
		int num = (Converter.PxToDp(base.Activity.GetScreenWidthInPixels()) - 20 - 8) / 2;
		if (num >= 0)
		{
			return Converter.DpToPx(num);
		}
		return 0;
	}

	private void NavigateToProduct(ProductDetailsViewModel.Parameter parameter)
	{
		NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(parameter, null, add: true);
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
