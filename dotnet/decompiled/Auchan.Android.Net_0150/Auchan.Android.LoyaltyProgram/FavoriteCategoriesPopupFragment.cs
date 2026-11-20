using System;
using System.Linq;
using System.Reactive.Disposables;
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
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.ViewModels;

namespace Auchan.Android.LoyaltyProgram;

internal class FavoriteCategoriesPopupFragment : BaseBottomSheetDialogFragment<FavoriteCategoriesPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493476;

	public FavoriteCategoriesPopupFragment(Func<FavoriteCategoriesPopupViewModel.Parameter, FavoriteCategoriesPopupViewModel> newViewModel)
		: base((Func<Fragment, FavoriteCategoriesPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<FavoriteCategoriesPopupViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		Button button = view.RequireViewById<Button>(2131296587);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296731);
		ObservableRecyclerAdapter<FavoriteCategoryItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<FavoriteCategoryItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493243,
			BindViewHolderDelegate = OnBindViewHolder,
			DataSource = base.ViewModel.Categories
		};
		recyclerView.SetLayoutManager(new LinearLayoutManager(RequireContext(), 1, reverseLayout: false));
		recyclerView.SetAdapter(adapter);
		recyclerView.Visibility = (base.ViewModel.Case == FavoriteCategoriesPopupViewModel.ForCase.AcceptingItems).ToVisibility();
		textView2.Visibility = base.ViewModel.DescriptionVisible.ToVisibility();
		textView.Text = base.ViewModel.Title;
		textView2.AddLinkedText(base.ViewModel.Description, new Color(ContextCompat.GetColor(RequireContext(), 2131100611)), underlineLinks: true, withDots: true);
		button.Text = base.ViewModel.ButtonText;
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowPopupCommand.SafeSubscribe(ShowPopup, ViewLifecycleOwner);
		base.ViewModel.NavigateToMyFavoriteCategories.SafeSubscribe(NavigateToMyFavoriteCategories, ViewLifecycleOwner);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenInfoPage, ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), ((View)button).OnClick((Action)delegate
		{
			base.ViewModel.ButtonClick().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OpenInfoPage(InfoPageViewModel.Parameter parameter)
	{
		Dismiss();
		Fragment parentFragment = base.ParentFragment;
		if (base.ParentFragment is FavoriteCategoriesPopupFragment favoriteCategoriesPopupFragment)
		{
			favoriteCategoriesPopupFragment.Dismiss();
			parentFragment = base.ParentFragment.ParentFragment;
		}
		parentFragment?.ParentFragmentManager.BeginTransaction().Hide(parentFragment).Add<InfoPageFragment>(parentFragment, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}

	private void ShowPopup(FavoriteCategoriesPopupViewModel.Parameter p)
	{
		Show<FavoriteCategoriesPopupFragment, FavoriteCategoriesPopupViewModel.Parameter>(p);
	}

	private void NavigateToMyFavoriteCategories(MyFavoriteCategoriesViewModel.Parameter p)
	{
		FragmentManager parentFragmentManager = base.ParentFragment.ParentFragmentManager;
		Fragment[] array = parentFragmentManager.Fragments.ToArray();
		Fragment fragment = array[Math.Max(array.IndexOf(this) - 1, 0)];
		parentFragmentManager.PopBackStack();
		parentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(fragment)
			.Add<MyFavoriteCategoriesFragment>(fragment, p.ToNavBundle())
			.Commit();
	}

	private void OnBindViewHolder(CachingViewHolder holder, FavoriteCategoryItemViewModel item, int position, CompositeDisposable disposable)
	{
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297360);
		ImageView imageView2 = holder.RequireCachedView<ImageView>(2131296728);
		TextView textView = holder.RequireCachedView<TextView>(2131296732);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296709);
		AppCompatCheckBox appCompatCheckBox = holder.RequireCachedView<AppCompatCheckBox>(2131296768);
		ImageView imageView3 = holder.RequireCachedView<ImageView>(2131296775);
		imageView2.FromUrl(item.Image);
		textView.Text = item.Name;
		textView2.Text = item.PreferenceValueText;
		appCompatCheckBox.Visibility = ViewStates.Gone;
		imageView3.Visibility = ViewStates.Gone;
		imageView.Visibility = (base.ViewModel.Case == FavoriteCategoriesPopupViewModel.ForCase.AcceptingItems).ToVisibility();
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			base.ViewModel.ShowCategoryInfo(item);
		})).AddTo(disposable);
	}
}
