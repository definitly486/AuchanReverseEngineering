using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Google.Android.Material.AppBar;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal class CategoryFragment : BaseToolbarFragment<CategoryViewModel>
{
	protected override int LayoutId => 2131493002;

	public CategoryFragment(Func<CategoryViewModel.Parameter, CategoryViewModel> newViewModel)
		: base((Func<Fragment, CategoryViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CategoryViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateNextCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnNavigateNext).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.OnDismiss.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			OnNavigationButtonClick();
		}).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar supportActionBar = view.RequireViewById<Toolbar>(2131298669);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296731);
		SearchView searchView = view.RequireViewById<AppBarLayout>(2131296451).RequireViewById<SearchView>(2131298322);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		(base.Activity as AppCompatActivity)?.SetSupportActionBar(supportActionBar);
		recyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity));
		ObservableRecyclerAdapter<CategoryItemViewModel, ExpandableCategoryViewHolder> categoryAdapter = new ObservableRecyclerAdapter<CategoryItemViewModel, ExpandableCategoryViewHolder>
		{
			CellLayoutId = 2131493223,
			BindViewHolderDelegate = OnBindCategory,
			ClickCallback = OnCategoryClicked
		};
		recyclerView.SetAdapter(categoryAdapter);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		base.ToolbarTitle = base.ViewModel.Title;
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			VisualState.Default,
			{
				VisualState.InProgress,
				frameLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				categoryAdapter.DataSource = base.ViewModel.Categories;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Categories"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)searchView).OnClick((Action)delegate
		{
			OnOpenSearch();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnCategoryClicked(ExpandableCategoryViewHolder vh, CategoryItemViewModel vm, int pos)
	{
		base.ViewModel.ToggleCategoryIfNeeded(vm).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnBindCategory(ExpandableCategoryViewHolder holder, CategoryItemViewModel model, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131298655);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296857);
		View chevron = holder.RequireCachedView<View>(2131296775);
		textView.Text = model.Title;
		textView2.Visibility = ViewStates.Gone;
		holder.IsSubCategory = model is SubCategoryItemViewModel;
		model.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			chevron.Activated = model.IsExpanded;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpanded")))).AddTo(disposable);
	}

	private void OnNavigateNext(BrokerToken parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<CatalogProductsFragment>(base.ParentFragment, parameter.ToNavBundle(), null, 2131297216)
			.AddToBackStack(null)
			.Commit();
	}

	private void OnOpenSearch()
	{
		SearchProductsResultFragment.OpenSearch(this);
	}
}
