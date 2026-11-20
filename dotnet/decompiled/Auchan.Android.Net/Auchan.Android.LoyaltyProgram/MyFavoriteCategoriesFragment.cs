using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using Android.Content;
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
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.LoyaltyProgram;

internal class MyFavoriteCategoriesFragment : BaseToolbarFragment<MyFavoriteCategoriesViewModel>
{
	private BottomNavigationView? _bottomNavigation;

	protected override int LayoutId => 2131493063;

	public MyFavoriteCategoriesFragment(Func<MyFavoriteCategoriesViewModel.Parameter, MyFavoriteCategoriesViewModel> newViewModel)
		: base((Func<Fragment, MyFavoriteCategoriesViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<MyFavoriteCategoriesViewModel.Parameter>())))
	{
	}

	public override void OnAttach(Context context)
	{
		base.OnAttach(context);
		RequireActivity().OnBackPressedDispatcher.AddCallback(this, OnBackPressed);
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = base.Activity?.RequireViewById<BottomNavigationView>(2131296565);
		base.ToolbarTitle = base.ViewModel.Title;
		View view2 = view.RequireViewById<View>(2131296490);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296731);
		Button button = view.RequireViewById<Button>(2131296587);
		button.Text = base.ViewModel.ButtonText;
		ObservableRecyclerAdapter<FavoriteCategoryItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<FavoriteCategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493243,
			BindViewHolderDelegate = OnBindCategoryViewHolder,
			DataSource = base.ViewModel.Categories
		};
		ObservableRecyclerAdapter<string, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<string, CachingViewHolder>
		{
			CellLayoutId = 2131493242,
			BindViewHolderDelegate = OnBindHeaderViewHolder,
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<string>("header")
		};
		recyclerView.SetLayoutManager(new LinearLayoutManager(RequireContext(), 1, reverseLayout: false));
		recyclerView.SetAdapter(new ConcatAdapter(observableRecyclerAdapter2, observableRecyclerAdapter));
		recyclerView.SetPaddingDp(0, 0, 0, 0);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			button.Enabled = base.ViewModel.Accepted || base.ViewModel.CategoriesSelected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CategoriesSelected")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnButtonClick), view2.OnClick(OnBackPressed)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToCategoryCommand.SafeSubscribe(NavigateToCategory, ViewLifecycleOwner);
		base.ViewModel.ShowPopupCommand.SafeSubscribe(delegate(FavoriteCategoriesPopupViewModel.Parameter p)
		{
			Show<FavoriteCategoriesPopupFragment, FavoriteCategoriesPopupViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.GoToCatalogCommand.SafeSubscribe(GoToCatalog, ViewLifecycleOwner);
	}

	private void OnBindHeaderViewHolder(CachingViewHolder holder, string item, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131296965);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296958);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297451);
		textView.Text = base.ViewModel.DescriptionTitle;
		textView2.Text = base.ViewModel.Description;
		textView3.AddLinkedText(base.ViewModel.Link, new Color(ContextCompat.GetColor(RequireContext(), 2131100611)), underlineLinks: true);
		textView3.Visibility = base.ViewModel.DetailsAvailable.ToVisibility();
	}

	private void OnBindCategoryViewHolder(CachingViewHolder holder, FavoriteCategoryItemViewModel item, int position, CompositeDisposable disposable)
	{
		ImageView infoImage = holder.RequireCachedView<ImageView>(2131297360);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131296728);
		TextView textView = holder.RequireCachedView<TextView>(2131296732);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296709);
		AppCompatCheckBox checkBox = holder.RequireCachedView<AppCompatCheckBox>(2131296768);
		ImageView imageView2 = holder.RequireCachedView<ImageView>(2131296775);
		imageView.FromUrl(item.Image);
		textView.Text = item.Name;
		textView2.Text = item.PreferenceValueText;
		textView.Enabled = base.ViewModel.Accepted;
		imageView.Enabled = base.ViewModel.Accepted;
		checkBox.Visibility = (!base.ViewModel.Accepted).ToVisibility();
		imageView2.Visibility = base.ViewModel.Accepted.ToVisibility();
		infoImage.Visibility = (!base.ViewModel.Accepted).ToVisibility();
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			checkBox.Checked = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		base.ViewModel.BindEvents(((View)infoImage).OnClick((Action)delegate
		{
			base.ViewModel.ShowCategoryInfo(item);
		}), ((View)checkBox).OnClick((Action)delegate
		{
			base.ViewModel.SelectCategory(item, checkBox.Checked);
		}), holder.ItemView.OnClick((Action)delegate
		{
			OnItemClick(item, checkBox);
		})).AddTo(disposable);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			infoImage.Enabled = !base.ViewModel.CategoriesSelected || item.Selected;
			checkBox.Enabled = item.Selected || !base.ViewModel.CategoriesSelected;
			holder.ItemView.Enabled = item.Selected || !base.ViewModel.CategoriesSelected;
			holder.ItemView.Alpha = ((base.ViewModel.CategoriesSelected && !item.Selected) ? 0.4f : 1f);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CategoriesSelected")))).AddTo(disposable);
	}

	private void OnItemClick(FavoriteCategoryItemViewModel item, AppCompatCheckBox checkBox)
	{
		if (base.ViewModel.Accepted)
		{
			if (!base.ViewModel.CategoriesSelected || item.Selected)
			{
				base.ViewModel.OpenCategory(item);
			}
		}
		else if (!base.ViewModel.CategoriesSelected || item.Selected)
		{
			base.ViewModel.SelectCategory(item, !checkBox.Checked);
		}
	}

	private void GoToCatalog(Unit _)
	{
		_bottomNavigation.SelectedItemId = 2131297641;
	}

	private void NavigateToCategory(BrokerToken parameter)
	{
		NavigateTo<CatalogProductsFragment, BrokerToken>(parameter, null, add: true);
	}

	private void OnBackPressed()
	{
		base.ParentFragmentManager.PopBackStack();
	}
}
