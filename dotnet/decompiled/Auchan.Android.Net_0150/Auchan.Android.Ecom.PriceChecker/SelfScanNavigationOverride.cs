using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using Auchan.Android.Navigation;

namespace Auchan.Android.Ecom.PriceChecker;

public class SelfScanNavigationOverride : INavigationOverride
{
	public List<Type> _typesToOverride = new List<Type> { typeof(PriceCheckerFragment) };

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
		currentFragment.RequireActivity().SupportFragmentManager.BeginTransaction().Replace(2131296564, destination).AddToBackStack(null)
			.Commit();
		return Task.CompletedTask;
	}
}
