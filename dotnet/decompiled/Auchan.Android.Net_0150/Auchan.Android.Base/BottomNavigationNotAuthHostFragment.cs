using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Authorization;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using EBind;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Base;

[Register("auchan.Android.Base.BottomNavigationNotAuthHostFragment")]
internal class BottomNavigationNotAuthHostFragment : BaseFragment<BottomNavigationNotAuthViewModel>
{
	private const string CATALOG_CONTAINER_TAG = "CATALOG_CONTAINER_TAG";

	private const string AUTH_CONTAINER_TAG = "AUTH_CONTAINER_TAG";

	private readonly UnauthorizedCatalogContainerFragment _catalogContainerFragment;

	private BottomNavigationView _bottomNavigation;

	protected override int LayoutId => 2131492992;

	public BottomNavigationNotAuthHostFragment(Func<AndroidX.Fragment.App.Fragment, BottomNavigationNotAuthViewModel> newViewModel, UnauthorizedCatalogContainerFragment catalogContainerFragment)
		: base(newViewModel)
	{
		_catalogContainerFragment = catalogContainerFragment;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (savedInstanceState == null)
		{
			base.ChildFragmentManager.BeginTransaction().Add(2131297300, _catalogContainerFragment, "CATALOG_CONTAINER_TAG").Commit();
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_bottomNavigation = view.RequireViewById<BottomNavigationView>(2131296565);
		_bottomNavigation.SelectedItemId = 2131297641;
		_bottomNavigation.ItemSelected += new DisposableDelegate<EventHandler<NavigationBarView.ItemSelectedEventArgs>>(delegate
		{
			base.ViewModel.DoResetSearchStateAsync().SafeFireAndForget((Action<Exception>)null, false);
			NavigateToLogin();
		}, delegate(EventHandler<NavigationBarView.ItemSelectedEventArgs> h)
		{
			_bottomNavigation.ItemSelected -= h;
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void NavigateToLogin()
	{
		if (Platform.CurrentActivity is MainNotAuthActivity mainNotAuthActivity)
		{
			Intent data = new Intent();
			mainNotAuthActivity.SetResult(Result.Ok, data);
			mainNotAuthActivity.Finish();
		}
		else
		{
			FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
			supportFragmentManager.FragmentFactory.Instantiate<ToolbarContainerFragment>().Show(supportFragmentManager, "AUTH_CONTAINER_TAG");
		}
	}

	public ContainerFragment? GetContainer()
	{
		return base.ChildFragmentManager.FindFragmentByTag("CATALOG_CONTAINER_TAG") as ContainerFragment;
	}
}
