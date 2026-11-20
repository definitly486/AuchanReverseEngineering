using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Favorites;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;
using Auchan.Common.Profile.WaitList;
using Google.Android.Material.BottomNavigation;
using VisibilitySwitch;

namespace Auchan.Android.Profile.WaitList;

internal class WaitListFragment : BaseFragment<WaitListViewModel>
{
	private const int ITEM_MARGIN = 10;

	private BottomNavigationView _bottomNavigation;

	private RecyclerView _waitListRecyclerView;

	private ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder> _productsAdapter;

	private SectionedGridRecyclerViewAdapter _sectionedAdapter;

	private bool _hidden;

	protected override int LayoutId => 2131493123;

	public WaitListFragment(Func<Fragment, WaitListViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.GoToCatalogCommand.SafeSubscribe(OpenCatalog, this);
		base.ViewModel.CategoryTitleItemViewModel.SafeSubscribeToCollectionChanged(delegate
		{
			UpdateTitles(base.ViewModel.CategoryTitleItemViewModel.ToList());
		}, this);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter _)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(_, null, add: true);
		}, this);
		base.ViewModel.GoBackCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, this);
		base.ViewModel.OpenFilterCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<WaitListFilterFragment, BrokerToken>(p);
		}, this);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		if (_hidden != hidden)
		{
			_hidden = hidden;
			base.OnHiddenChanged(hidden);
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296904);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131297066);
		View view2 = view.RequireViewById<View>(2131298676);
		TextView textView2 = viewGroup2.RequireViewById<TextView>(2131297069);
		TextView textView3 = viewGroup2.RequireViewById<TextView>(2131297068);
		Button button = viewGroup2.RequireViewById<Button>(2131297645);
		textView2.Text = base.ViewModel.EmptyTitle;
		textView3.Text = base.ViewModel.EmptyMessage;
		button.Text = base.ViewModel.GoToCatalogButtonText;
		ViewGroup viewGroup3 = view.RequireViewById<ViewGroup>(2131297111);
		Button button2 = viewGroup3.RequireViewById<Button>(2131296325);
		TextView textView4 = viewGroup3.RequireViewById<TextView>(2131298646);
		TextView textView5 = viewGroup3.RequireViewById<TextView>(2131297563);
		textView4.Text = base.ViewModel.ErrorTitle;
		textView5.Text = base.ViewModel.ErrorMessage;
		ViewGroup viewGroup4 = view.RequireViewById<ViewGroup>(2131298079);
		TextView textView6 = viewGroup4.RequireViewById<TextView>(2131298080);
		_waitListRecyclerView = viewGroup.RequireViewById<RecyclerView>(2131298185);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298673);
		AppCompatImageButton appCompatImageButton = view.RequireViewById<AppCompatImageButton>(2131296490);
		AppCompatImageButton filterButton = view.RequireViewById<AppCompatImageButton>(2131297163);
		base.ViewModel.RefreshProductsCommand.SafeSubscribe(delegate
		{
			_productsAdapter.NotifyDataSetChanged();
		}, ViewLifecycleOwner);
		int sideMargin = GetSideMargin();
		_waitListRecyclerView.SetPaddingDp(sideMargin, 0, sideMargin, 16);
		_waitListRecyclerView.HasFixedSize = true;
		_waitListRecyclerView.SetLayoutManager(new GridLayoutManager(base.Activity, 2));
		_productsAdapter = new ObservableRecyclerAdapter<ProductItemViewModel, ProductItemViewHolder>
		{
			CellLayoutId = 2131493288,
			BindViewHolderDelegate = OnBindProduct,
			DataSource = base.ViewModel.ProductItemViewModels
		};
		_sectionedAdapter = new SectionedGridRecyclerViewAdapter(base.Activity, 2131493245, 2131298646, _waitListRecyclerView, _productsAdapter);
		_sectionedAdapter.SetSections(new GridSection[1]
		{
			new GridSection
			{
				FirstPosition = 0,
				Title = "Заголовок"
			}
		});
		_waitListRecyclerView.AddItemDecoration(new SectionedGridDecoration
		{
			Offset = 10
		});
		_waitListRecyclerView.SetAdapter(_sectionedAdapter);
		ObservableRecyclerAdapter<CategoryItemWithCodeViewModel, CachingViewHolder> toolbarAdapter = new ObservableRecyclerAdapter<CategoryItemWithCodeViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493244,
			BindViewHolderDelegate = OnBindCategory,
			DataSource = base.ViewModel.CategoriesItemViewModels
		};
		recyclerView.SetAdapter(toolbarAdapter);
		textView.Text = base.ViewModel.Title;
		textView6.Text = base.ViewModel.ProgressTitle;
		VisibilitySwitch<WaitListViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<WaitListViewModel.VisualState>(WaitListViewModel.VisualState.Default)
		{
			{
				WaitListViewModel.VisualState.Default,
				viewGroup,
				recyclerView,
				view2
			},
			{
				WaitListViewModel.VisualState.Empty,
				viewGroup2
			},
			{
				WaitListViewModel.VisualState.InProgress,
				viewGroup4
			},
			{
				WaitListViewModel.VisualState.Error,
				viewGroup3
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				filterButton.Visibility = base.ViewModel.FilterIsActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FilterIsActive")),
			(delegate
			{
				toolbarAdapter.DataSource = base.ViewModel.CategoriesItemViewModels;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CategoriesItemViewModels"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button2.OnClick(base.ViewModel.OnGoToCatalogClick), button.OnClick(base.ViewModel.OnGoToCatalogClick), appCompatImageButton.OnClick(base.ViewModel.OnBackClicked), filterButton.OnClick(base.ViewModel.OpenFilter)).AutoDisposeOnDestroy(ViewLifecycleOwner);
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
			vh.BindData(base.ViewModel, vm, disposable, base.ViewModel.ShowQtyDialogCommand, showPackageLabel: true);
			vm.BindEvents(vh.ItemView.OnClick((Action)delegate
			{
				base.ViewModel.NavigateToProductDetails(vm);
			})).AddTo(disposable);
		}
	}

	private void OnBindCategory(CachingViewHolder vh, CategoryItemWithCodeViewModel vm, int position, CompositeDisposable disposable)
	{
		TextView title = vh.FindCachedView<TextView>(2131298646);
		View underline = vh.FindCachedView(2131298779);
		title.Text = ((!vm.Counter.HasValue) ? vm.Title : (vm.Title + $" ({vm.Counter})"));
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				title.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), vm.Selected ? 2131099706 : 2131099703)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")),
			(delegate
			{
				underline.Visibility = vm.Selected.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected"))
		})).AddTo(disposable);
		vm.BindEvents(vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.OnCategorySelected(vm);
		})).AddTo(disposable);
	}

	private void OpenCatalog(Unit _)
	{
		_bottomNavigation.SelectedItemId = 2131297641;
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
}
