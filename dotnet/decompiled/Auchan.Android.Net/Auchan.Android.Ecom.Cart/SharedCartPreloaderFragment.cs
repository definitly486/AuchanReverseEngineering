using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.Cart;

internal class SharedCartPreloaderFragment : BaseToolbarFragment<SharedCartPreloaderViewModel>
{
	protected override int LayoutId => 2131493075;

	public SharedCartPreloaderFragment(Func<SharedCartPreloaderViewModel.Parameter, SharedCartPreloaderViewModel> newViewModel)
		: base((Func<Fragment, SharedCartPreloaderViewModel>)((Fragment fragment) => newViewModel(fragment.RequireNavParam<SharedCartPreloaderViewModel.Parameter>())))
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
		preloaderControls.Progress.Title.Text = base.ViewModel.ProgressTitle;
		preloaderControls.Error.Title.Text = base.ViewModel.ErrorTitle;
		preloaderControls.Error.Message.Text = base.ViewModel.ErrorMessage;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			visibilitySwitch.State = base.ViewModel.State;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(preloaderControls.Error.Action.OnClick(base.ViewModel.RetryCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.GoBackCommand.SafeSubscribe(delegate
		{
			OnNavigationButtonClick();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowSharedCartIsObsoletedCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<SharedCartIsObsoletedFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
	}
}
