using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Controls.AutoLayout;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Navigation;

public class NavigationService : BaseNavigationService
{
	private readonly List<INavigationOverride> _navigationOverrides;

	private readonly Dictionary<Type, Type> _fragmentsDict = new Dictionary<Type, Type>();

	public NavigationService(INavigationContext context, IUserContext userContext, IEnumerable<INavigationOverride> navigationOverrides, IExternalAppsLinkCreator externalAppsLinkCreator, IFeedbackContactsProvider feedbackContactsProvider, Lazy<ILoginManager> loginManager)
		: base(context, userContext, externalAppsLinkCreator, feedbackContactsProvider, loginManager)
	{
		_navigationOverrides = new List<INavigationOverride>(navigationOverrides);
		MapFragments();
	}

	public override void WriteFeedback()
	{
		Activity currentActivity = Platform.CurrentActivity;
		Intent intent = new Intent("android.intent.action.SENDTO");
		intent.SetData(global::Android.Net.Uri.Parse(_externalAppsLinkCreator.FeedbackMessageWithAppAndDeviceData));
		intent.AddFlags(ActivityFlags.NewTask);
		try
		{
			currentActivity?.ApplicationContext.StartActivity(intent);
		}
		catch (Exception)
		{
		}
	}

	protected override async Task PerformNavigationAsync(Type viewModelType, object parameter)
	{
		AppCompatActivity activity = GetActivity();
		if (activity == null)
		{
			DelayNavigation();
			NavigationFailure();
			return;
		}
		if (!HandleDialogFragments(activity.SupportFragmentManager))
		{
			NavigationFailure();
			return;
		}
		AndroidX.Fragment.App.Fragment rootFragment = GetRootFragment(activity);
		if (rootFragment == null)
		{
			DelayNavigation();
			NavigationFailure();
			return;
		}
		AndroidX.Fragment.App.Fragment currentFragment = GetCurrentFragment(rootFragment);
		if (currentFragment == null)
		{
			DelayNavigation();
			NavigationFailure();
			return;
		}
		if (!CanNavigateFrom(currentFragment))
		{
			NavigationFailure();
			return;
		}
		Type type;
		try
		{
			type = _fragmentsDict[viewModelType];
		}
		catch (Exception)
		{
			throw;
		}
		AndroidX.Fragment.App.Fragment fragment = activity.SupportFragmentManager.FragmentFactory.Instantiate(type);
		if (parameter != null)
		{
			fragment.Arguments = parameter.ToNavBundle();
		}
		try
		{
			currentFragment.ParentFragmentManager.ExecutePendingTransactions();
		}
		catch (Exception)
		{
			ResetDelayedNavigation();
			NavigationFailure();
			return;
		}
		await NavigateAsync(currentFragment, fragment);
	}

	private void MapFragments()
	{
		List<Type> genericBaseTypes = new List<Type>
		{
			typeof(BaseFragment<>),
			typeof(BaseToolbarFragment<>),
			typeof(BaseBottomSheetDialogFragment<>),
			typeof(BaseDialogFragment<>),
			typeof(BaseScannerFragment<>),
			typeof(AutoLayoutFragment<>),
			typeof(AutoLayoutFragment<, >),
			typeof(AutoLayoutToolbarFragment<>),
			typeof(AutoLayoutToolbarFragment<, >)
		};
		foreach (Type item in from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.BaseType != null && t.BaseType.IsGenericType && !t.IsGenericType && genericBaseTypes.Contains(t.BaseType.GetGenericTypeDefinition())
			select t)
		{
			Type[] array = item.BaseType?.GetGenericArguments();
			if (array != null && array.Length >= 1)
			{
				Type type = array[0];
				if (type.IsSubclassOf(typeof(ScreenViewModel)) && !_fragmentsDict.ContainsKey(type))
				{
					_fragmentsDict[type] = item;
				}
			}
		}
	}

	private AppCompatActivity GetActivity()
	{
		if (Platform.CurrentActivity is MainActivity mainActivity && mainActivity.Lifecycle.CurrentState.IsAtLeast(Lifecycle.State.Created))
		{
			return mainActivity;
		}
		return null;
	}

	private AndroidX.Fragment.App.Fragment GetRootFragment(AppCompatActivity activity)
	{
		return activity.SupportFragmentManager.FindFragmentById(2131296564);
	}

	private static AndroidX.Fragment.App.Fragment GetCurrentFragment(AndroidX.Fragment.App.Fragment rootFragment)
	{
		if (!(rootFragment is PriceCheckerFragment))
		{
			if (!(rootFragment is BottomNavigationHostFragment bottomNavigationHostFragment))
			{
				if (rootFragment is BottomNavigationNotAuthHostFragment bottomNavigationNotAuthHostFragment)
				{
					return bottomNavigationNotAuthHostFragment.GetContainer().ChildFragmentManager.Fragments.Where((AndroidX.Fragment.App.Fragment f) => !(f is DialogFragment)).LastOrDefault();
				}
				return null;
			}
			return bottomNavigationHostFragment.GetContainer().ChildFragmentManager.Fragments.Where((AndroidX.Fragment.App.Fragment f) => !(f is DialogFragment)).LastOrDefault();
		}
		return rootFragment.ParentFragmentManager.Fragments.Where((AndroidX.Fragment.App.Fragment f) => !(f is DialogFragment)).LastOrDefault();
	}

	private bool HandleDialogFragments(FragmentManager rootManager, int depth = 0)
	{
		if (depth > 9)
		{
			return false;
		}
		bool flag = true;
		List<AndroidX.Fragment.App.Fragment> list = rootManager.Fragments.ToList();
		if (list.Any())
		{
			flag = list.All((AndroidX.Fragment.App.Fragment x) => HandleDialogFragments(x.ChildFragmentManager, depth + 1));
		}
		if (flag && list.All((AndroidX.Fragment.App.Fragment x) => CanNavigateFrom(x)))
		{
			list.SelectNotNull((AndroidX.Fragment.App.Fragment x) => x as DialogFragment).ForEach(delegate(DialogFragment x)
			{
				x.DismissAllowingStateLoss();
			});
			return true;
		}
		return false;
	}

	private bool CanNavigateFrom(AndroidX.Fragment.App.Fragment currentFragment)
	{
		switch ((currentFragment as IOnNavigateFrom)?.OnNavigateFrom() ?? NavigationPossibilityType.Possible)
		{
		case NavigationPossibilityType.Possible:
			return true;
		case NavigationPossibilityType.Impossible:
			ResetDelayedNavigation();
			return false;
		case NavigationPossibilityType.Delayed:
			DelayNavigation();
			return false;
		default:
			return true;
		}
	}

	private async Task NavigateAsync(AndroidX.Fragment.App.Fragment currentFragment, AndroidX.Fragment.App.Fragment fragment)
	{
		NavigationSuccessful();
		await currentFragment.Activity.WaitForStateAsync(Lifecycle.State.Resumed);
		foreach (INavigationOverride navigationOverride in _navigationOverrides)
		{
			if (navigationOverride.ShouldOverrideNavigation(currentFragment, fragment))
			{
				await navigationOverride.NavigateAsync(currentFragment, fragment);
				return;
			}
		}
		if (fragment is BaseBottomSheetDialogFragment)
		{
			(fragment as BaseBottomSheetDialogFragment).Show(await currentFragment.GetChildFragmentManagerAsync(), null);
		}
		else
		{
			(await currentFragment.GetParentFragmentManagerAsync()).BeginTransaction().Hide(currentFragment).Add(currentFragment.Id, fragment)
				.AddToBackStack(null)
				.Commit();
		}
	}
}
