using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Bumptech.Glide;
using Google.Android.Material.AppBar;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal class UnauthorizedCatalogFragment : BaseToolbarFragment<CatalogViewModel>
{
	protected override int LayoutId => 2131493001;

	public UnauthorizedCatalogFragment(Func<Fragment, CatalogViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateNextCommand.ObserveOn(MainThread.Scheduler).Subscribe(NavigateNextForResult).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.NavigateToProductsCommand.ObserveOn(MainThread.Scheduler).Subscribe(OnNavigateToProductsNext).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Toolbar supportActionBar = view.RequireViewById<Toolbar>(2131298669);
		(base.Activity as AppCompatActivity)?.SetSupportActionBar(supportActionBar);
		CoordinatorLayout coordinatorLayout = view.RequireViewById<CoordinatorLayout>(2131296904);
		RecyclerView recyclerView = coordinatorLayout.RequireViewById<RecyclerView>(2131296731);
		AppBarLayout appBarLayout = coordinatorLayout.RequireViewById<AppBarLayout>(2131296451);
		SearchView searchView = appBarLayout.RequireViewById<SearchView>(2131298322);
		TextView textView = appBarLayout.RequireViewById<TextView>(2131298655);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView2 = view.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				coordinatorLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		base.ToolbarTitle = base.ViewModel.Title;
		textView.Text = base.ViewModel.Title;
		recyclerView.SetLayoutManager(new GridLayoutManager(base.Activity, 3));
		recyclerView.AddItemDecoration(new GridSpacesItemDecoration(8));
		appBarLayout.AddOnOffsetChangedListener(new AppBarStateChangeListener(OnStateChanged));
		OnStateChanged(AppBarStateChangeListener.State.Expanded);
		ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder> categoryAdapter = new ObservableRecyclerAdapter<CategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493222,
			BindViewHolderDelegate = OnBindCategory,
			ClickCallback = OnCategoryItemClick
		};
		recyclerView.SetAdapter(categoryAdapter);
		searchView.QueryHint = base.ViewModel.SearchPlaceholder;
		searchView.SetOnClickListener(new ViewOnClickListener(OnOpenSearch));
		textView2.Text = base.ViewModel.ProgressTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
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
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				categoryAdapter.DataSource = base.ViewModel.TopCategories;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TopCategories")),
			(delegate
			{
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)button).OnClick((EventHandler)delegate
		{
			base.ViewModel.Retry();
		}), ((View)showQrButton).OnClick((EventHandler)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnStateChanged(AppBarStateChangeListener.State state)
	{
		if (base.ToolbarTitleLabel != null)
		{
			base.ToolbarTitleLabel.Visibility = ((state != AppBarStateChangeListener.State.Collapsed) ? ViewStates.Gone : ViewStates.Visible);
		}
	}

	private void OnCategoryItemClick(CachingViewHolder vh, CategoryItemViewModel vm, int arg3)
	{
		base.ViewModel.NavigateToCategory(vm);
	}

	private void OnBindCategory(CachingViewHolder holder, CategoryItemViewModel model, int position, CompositeDisposable disposable)
	{
		ImageView imageView = holder.FindCachedView<ImageView>(2131296728);
		holder.ItemView.ContentDescription = model.Title;
		Glide.With(RequireContext()).Clear(imageView);
		imageView.SetImageResource(2131231086);
		imageView.ClipToOutline = true;
		if (!string.IsNullOrWhiteSpace(model.Category.ImageUrl))
		{
			imageView.FromUrlAnimated(model.Category.ImageUrl);
		}
	}

	private void NavigateNextForResult(CategoryViewModel.Parameter parameter)
	{
		NavigateTo<CategoryFragment, CategoryViewModel.Parameter>(parameter, null, add: true);
	}

	private void OnNavigateToProductsNext(BrokerToken parameter)
	{
		NavigateTo<CatalogProductsFragment, BrokerToken>(parameter, null, add: true);
	}

	private void OnOpenSearch(View obj)
	{
		SearchProductsResultFragment.OpenSearch(this);
	}
}
