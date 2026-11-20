using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndroidX.Fragment.App;
using Auchan.Android.Authorization.Login;
using Auchan.Android.Navigation;
using Google.Android.Material.BottomSheet;
using Java.Lang;

namespace Auchan.Android.Authorization;

public class AuthorizationNavigationOverride : INavigationOverride
{
	private readonly List<Type> _typesToOverride = new List<Type>
	{
		typeof(LoginFragment),
		typeof(AuthOrRegisterFragment)
	};

	public Task NavigateAsync(Fragment currentFragment, Fragment destination)
	{
		FragmentActivity activity = currentFragment.Activity;
		(activity.SupportFragmentManager.FragmentFactory.Instantiate(activity.ClassLoader, Class.FromType(typeof(ToolbarContainerFragment)).Name) as BottomSheetDialogFragment).Show(activity.SupportFragmentManager, "ToolbarContainerFragment");
		return Task.CompletedTask;
	}

	public bool ShouldOverrideNavigation(Fragment currentFragment, Fragment destination)
	{
		return _typesToOverride.Contains(destination.GetType());
	}
}
