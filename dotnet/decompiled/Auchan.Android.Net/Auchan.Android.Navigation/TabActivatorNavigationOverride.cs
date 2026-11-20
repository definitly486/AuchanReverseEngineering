using System;
using System.Linq;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Ecom.Cart;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Navigation;
using Google.Android.Material.BottomNavigation;

namespace Auchan.Android.Navigation;

internal sealed class TabActivatorNavigationOverride : INavigationOverride
{
	private readonly Lazy<INavigationService> _navigationService;

	public TabActivatorNavigationOverride(Lazy<INavigationService> navigationService)
	{
		_navigationService = navigationService;
	}

	public Task NavigateAsync(Fragment currentFragment, Fragment destination)
	{
		if (destination is TabActivatorFragment fragment)
		{
			TabActivatorViewModel.Parameter arg = fragment.RequireNavParam<TabActivatorViewModel.Parameter>();
			DoNavigate(currentFragment, arg).SafeFireAndForget((Action<Exception>)null, false);
		}
		return Task.CompletedTask;
	}

	private async Task DoNavigate(Fragment currentFragment, TabActivatorViewModel.Parameter arg)
	{
		BottomNavigationHostFragment bnh = currentFragment.Activity?.SupportFragmentManager.Fragments.FirstOrDefault() as BottomNavigationHostFragment;
		BottomNavigationView bnv = bnh?.View?.RequireViewById<BottomNavigationView>(2131296565);
		if (bnv != null)
		{
			int id = IdByTab(arg.Tab, bnv.SelectedItemId);
			if (bnv.SelectedItemId == id)
			{
				if (currentFragment is BaseFragmentWithViewModel baseFragmentWithViewModel && baseFragmentWithViewModel.GetViewModel().GetType() == arg.ActualDestination)
				{
					ScreenViewModel vm = baseFragmentWithViewModel.GetViewModel();
					await vm.DoPause();
					await vm.DoResume();
				}
				else if (bnh?.CurrentContainerFragment is IFragmentContainer fragmentContainer)
				{
					fragmentContainer.PostRepeatedOpenEvent();
					await Task.Delay(200);
				}
			}
			bnv.SelectedItemId = id;
		}
		if (arg.ActualDestination == typeof(CartScreenViewModel) && arg.Tab == BottomNavigationViewModel.TabbarItem.Cart && bnh?.CurrentContainerFragment is ContainerFragment<CartFragment> containerFragment)
		{
			containerFragment.PostRepeatedOpenEvent();
			return;
		}
		if (arg.ActualDestination == typeof(CatalogViewModel) && arg.Tab == BottomNavigationViewModel.TabbarItem.Catalog && bnh?.CurrentContainerFragment is ContainerFragment<CatalogFragment> containerFragment2)
		{
			containerFragment2.PostRepeatedOpenEvent();
			return;
		}
		await Task.Delay(200);
		if (arg.ActualDestination != null)
		{
			_navigationService.Value.NavigateTo(arg.ActualDestination, arg.ActualParameter);
		}
	}

	private static int IdByTab(BottomNavigationViewModel.TabbarItem tabbarItem, int @default)
	{
		return tabbarItem switch
		{
			BottomNavigationViewModel.TabbarItem.Home => 2131297642, 
			BottomNavigationViewModel.TabbarItem.Loyalty => 2131297643, 
			BottomNavigationViewModel.TabbarItem.Catalog => 2131297641, 
			BottomNavigationViewModel.TabbarItem.Cart => 2131297640, 
			BottomNavigationViewModel.TabbarItem.Profile => 2131297644, 
			_ => @default, 
		};
	}

	public bool ShouldOverrideNavigation(Fragment currentFragment, Fragment destination)
	{
		return destination is TabActivatorFragment;
	}
}
