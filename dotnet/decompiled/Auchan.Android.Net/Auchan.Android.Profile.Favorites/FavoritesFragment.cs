using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;
using Auchan.Common.Reviews;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.Profile.Favorites;

internal class FavoritesFragment : BaseFragment<FavoritesViewModel>
{
	private const int ITEM_MARGIN = 10;

	private BottomNavigationView _bottomNavigation;

	private RecyclerView _favoritesRecyclerView;

	private ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder> _favoritesAdapter;

	private SectionedGridRecyclerViewAdapter _sectionedAdapter;

	private ViewGroup _defaultLayout;

	private ViewGroup _emptyLayout;

	private ViewGroup _errorLayout;

	private ViewGroup _progressLayout;

	private AppCompatImageButton _sortButton;

	private RecyclerView _toolbarRecyclerView;

	private View _toolbarRecyclerViewInterceptor;

	protected override int LayoutId => 2131493028;

	public FavoritesFragment(Func<Fragment, FavoritesViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.GoToCatalogCommand.SafeSubscribe(OpenCatalog, this);
		base.ViewModel.CategoryTitleItemViewModel.SubscribeToCollectionChanged(delegate
		{
			UpdateTitles(base.ViewModel.CategoryTitleItemViewModel.ToList());
		}, this);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenSortCommand.SafeSubscribe(OnOpenSort, this);
		base.ViewModel.GoBackCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(ShowQtyInputDialog, this);
		base.ViewModel.ScrollToTopCommand.SafeSubscribe(delegate
		{
			_favoritesRecyclerView.ScrollToPosition(0);
		}, this);
		base.ViewModel.NavigateToReplacementCommand.SafeSubscribe(GoToStaticList, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		_defaultLayout = view.RequireViewById<ViewGroup>(2131296904);
		_emptyLayout = view.RequireViewById<ViewGroup>(2131297066);
		TextView textView2 = _emptyLayout.RequireViewById<TextView>(2131297069);
		TextView textView3 = _emptyLayout.RequireViewById<TextView>(2131297068);
		Button catalogButton = _emptyLayout.RequireViewById<Button>(2131297645);
		_errorLayout = view.RequireViewById<ViewGroup>(2131297111);
		_errorLayout.RequireViewById<Button>(2131298371).Visibility = ViewStates.Gone;
		_progressLayout = view.RequireViewById<ViewGroup>(2131298079);
		TextView textView4 = _progressLayout.RequireViewById<TextView>(2131298080);
		_favoritesRecyclerView = _defaultLayout.RequireViewById<RecyclerView>(2131298185);
		_toolbarRecyclerView = view.RequireViewById<RecyclerView>(2131298673);
		_toolbarRecyclerViewInterceptor = view.RequireViewById<View>(2131298674);
		AppCompatImageButton backButton = view.RequireViewById<AppCompatImageButton>(2131296490);
		_sortButton = view.RequireViewById<AppCompatImageButton>(2131298417);
		_favoritesRecyclerView.SetPaddingDp(15, 5, 15, 16);
		_favoritesRecyclerView.HasFixedSize = true;
		_favoritesRecyclerView.SetLayoutManager(new GridLayoutManager(base.Activity, 2));
		_favoritesAdapter = new ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder>
		{
			CellLayoutId = 2131493288,
			BindViewHolderDelegate = OnBindProduct,
			DataSource = base.ViewModel.FavoritesItemViewModels
		};
		_favoritesAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		_sectionedAdapter = new SectionedGridRecyclerViewAdapter(base.Activity, 2131493245, 2131298646, _favoritesRecyclerView, _favoritesAdapter);
		_sectionedAdapter.SetSections(new GridSection[1]
		{
			new GridSection
			{
				FirstPosition = 0,
				Title = "Заголовок"
			}
		});
		_favoritesRecyclerView.AddItemDecoration(new SectionedGridDecoration
		{
			Offset = 10
		});
		_favoritesRecyclerView.SetAdapter(_sectionedAdapter);
		ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder> toolbarAdapter = new ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493290,
			BindViewHolderDelegate = OnBindCategory
		};
		_toolbarRecyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		_toolbarRecyclerView.SetAdapter(toolbarAdapter);
		toolbarAdapter.DisposeViewHolders().AutoDisposeOnDestroy(ViewLifecycleOwner);
		textView.Text = base.ViewModel.Title;
		textView4.Text = base.ViewModel.ProgressTitle;
		textView2.Text = base.ViewModel.EmptyTitle;
		textView3.Text = base.ViewModel.EmptyMessage;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				toolbarAdapter.DataSource = base.ViewModel.CategoriesItemViewModels;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CategoriesItemViewModels")),
			(SwitchState, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				OnSelectedCategoryChanged(base.ViewModel.SelectedCategoryIndex).SafeFireAndForget((Action<Exception>)null, false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedCategoryIndex"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		ViewOnClickListener viewOnClickListener = new ViewOnClickListener(delegate(View v)
		{
			if (backButton.Id == v.Id)
			{
				base.ViewModel.OnBackClicked();
			}
			if (catalogButton.Id == v.Id)
			{
				base.ViewModel.OnGoToCatalogClick();
			}
			if (_sortButton.Id == v.Id)
			{
				base.ViewModel.OpenSort();
			}
		});
		catalogButton.SetOnClickListener(viewOnClickListener);
		backButton.SetOnClickListener(viewOnClickListener);
		_sortButton.SetOnClickListener(viewOnClickListener);
		viewOnClickListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private async Task OnSelectedCategoryChanged(int position)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
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
			_toolbarRecyclerViewInterceptor.Visibility = ViewStates.Gone;
		}, 200L);
	}

	private void SwitchState()
	{
		if (base.ViewModel.State == FavoritesViewModel.VisualState.Default)
		{
			_defaultLayout.Visibility = ViewStates.Visible;
			_sortButton.Visibility = ViewStates.Visible;
			_toolbarRecyclerView.Visibility = ViewStates.Visible;
			_progressLayout.Visibility = ViewStates.Gone;
			_errorLayout.Visibility = ViewStates.Gone;
			_emptyLayout.Visibility = ViewStates.Gone;
		}
		if (base.ViewModel.State == FavoritesViewModel.VisualState.InProgress)
		{
			_progressLayout.Visibility = ViewStates.Visible;
			_defaultLayout.Visibility = ViewStates.Gone;
			_sortButton.Visibility = ViewStates.Gone;
			_toolbarRecyclerView.Visibility = ViewStates.Gone;
			_errorLayout.Visibility = ViewStates.Gone;
			_emptyLayout.Visibility = ViewStates.Gone;
		}
		if (base.ViewModel.State == FavoritesViewModel.VisualState.Error)
		{
			_defaultLayout.Visibility = ViewStates.Gone;
			_sortButton.Visibility = ViewStates.Gone;
			_toolbarRecyclerView.Visibility = ViewStates.Gone;
			_progressLayout.Visibility = ViewStates.Gone;
			_errorLayout.Visibility = ViewStates.Visible;
			_emptyLayout.Visibility = ViewStates.Gone;
		}
		if (base.ViewModel.State == FavoritesViewModel.VisualState.Empty)
		{
			_defaultLayout.Visibility = ViewStates.Gone;
			_sortButton.Visibility = ViewStates.Gone;
			_toolbarRecyclerView.Visibility = ViewStates.Gone;
			_progressLayout.Visibility = ViewStates.Gone;
			_errorLayout.Visibility = ViewStates.Gone;
			_emptyLayout.Visibility = ViewStates.Visible;
		}
	}

	private void UpdateTitles(List<CategoryTitleItemViewModel> categoryTitleItemViewModels)
	{
		_sectionedAdapter.SetSections(categoryTitleItemViewModels.Select((CategoryTitleItemViewModel categoryTitle) => new GridSection
		{
			FirstPosition = categoryTitle.TitlePosition,
			Title = categoryTitle.Title
		}).ToArray());
	}

	private void OnBindProduct(ProductItemViewHolder vh, ProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		if (vm.Product != null)
		{
			ViewGroup.LayoutParams layoutParameters = vh.ItemView.LayoutParameters;
			layoutParameters.Width = GetItemWidth();
			vh.ItemView.LayoutParameters = layoutParameters;
			vh.BindData(base.ViewModel, vm, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
			vh.ItemView.OnClick((EventHandler)delegate
			{
				base.ViewModel.NavigateToProductDetails(vm);
			}).AddTo(disposable);
		}
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

	private void OnBindCategory(CachingViewHolder vh, CategoryItemViewModel vm, int position, CompositeDisposable disposable)
	{
		TextView title = vh.RequireCachedView<TextView>(2131298646);
		title.Text = vm.Title;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			title.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), vm.Selected ? 2131100630 : 2131099872)));
			title.SetBackgroundResource(vm.Selected ? 2131230922 : 2131230920);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		vm.BindEvents(vh.ItemView.OnClick((Action)delegate
		{
			SelectCategory(vm);
		})).AddTo(disposable);
	}

	private void SelectCategory(CategoryItemViewModel vm)
	{
		base.ViewModel.OnCategorySelected(vm);
		_favoritesRecyclerView.ScrollToPosition(0);
	}

	private void OpenCatalog(Unit _)
	{
		_bottomNavigation.SelectedItemId = 2131297641;
	}

	private void OnOpenSort(BrokerToken parameter)
	{
		ProductsOrderDialogFragment productsOrderDialogFragment = base.ParentFragmentManager.FragmentFactory.Instantiate<ProductsOrderDialogFragment>();
		productsOrderDialogFragment.Arguments = parameter.ToNavBundle();
		productsOrderDialogFragment.SetTargetFragment(this, 0);
		productsOrderDialogFragment.Show(base.ParentFragmentManager, null);
	}

	private void ShowQtyInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}
}
