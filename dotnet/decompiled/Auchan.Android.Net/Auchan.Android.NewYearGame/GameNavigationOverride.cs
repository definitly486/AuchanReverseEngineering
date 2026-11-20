using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Navigation;

namespace Auchan.Android.NewYearGame;

public class GameNavigationOverride : INavigationOverride
{
	public List<Type> _typesToOverride = new List<Type> { typeof(NewYearGameFragment) };

	public bool ShouldOverrideNavigation(Fragment currentFragment, Fragment destination)
	{
		if (!_typesToOverride.Contains(currentFragment.GetType()))
		{
			return _typesToOverride.Contains(destination.GetType());
		}
		return false;
	}

	public Task NavigateAsync(Fragment currentFragment, Fragment destination)
	{
		FragmentManager supportFragmentManager = currentFragment.Activity.SupportFragmentManager;
		BottomNavigationHostFragment bottomNavigationHostFragment = supportFragmentManager.FindFragmentById(2131296564) as BottomNavigationHostFragment;
		FragmentTransaction fragmentTransaction = supportFragmentManager.BeginTransaction();
		if (bottomNavigationHostFragment != null)
		{
			fragmentTransaction.Hide(bottomNavigationHostFragment);
		}
		fragmentTransaction.Add(2131296564, destination).AddToBackStack(null).Commit();
		return Task.CompletedTask;
	}
}
