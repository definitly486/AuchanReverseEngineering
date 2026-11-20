using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.ViewModels;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal sealed class MyFavoriteCategoriesPreloaderFragment : BaseToolbarFragment<MyFavoriteCategoriesPreloaderViewModel>
{
	protected override int LayoutId => 2131493075;

	public MyFavoriteCategoriesPreloaderFragment(MyFavoriteCategoriesPreloaderViewModel viewModel)
		: base((Func<Fragment, MyFavoriteCategoriesPreloaderViewModel>)((Fragment thisFragment) => viewModel))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		PreloaderControls preloaderControls = new PreloaderControls(view);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.InProgress,
				preloaderControls.Progress.Layout
			},
			{
				VisualState.Error,
				preloaderControls.Error.Layout
			},
			{
				VisualState.Default,
				preloaderControls.DefaultLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			visibilitySwitch.State = base.ViewModel.State;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.GoBackCommand.SafeSubscribe(delegate
		{
			OnNavigationButtonClick();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenCategoriesCommand.SafeSubscribe(delegate(MyFavoriteCategoriesViewModel.Parameter p)
		{
			OpenCategoriesAsync(p).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
	}

	private async Task OpenCategoriesAsync(MyFavoriteCategoriesViewModel.Parameter parameter)
	{
		FragmentManager obj = await this.GetParentFragmentManagerAsync();
		IList<Fragment> fragments = obj.Fragments;
		Fragment fragment = fragments[Math.Max(fragments.IndexOf(this) - 1, 0)];
		obj.PopBackStack();
		obj.BeginTransaction().AddToBackStack(null).Hide(fragment)
			.Add<MyFavoriteCategoriesFragment>(fragment, parameter.ToNavBundle())
			.Commit();
	}
}
