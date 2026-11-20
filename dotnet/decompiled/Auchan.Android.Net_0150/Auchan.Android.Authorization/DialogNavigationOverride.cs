using System.Threading.Tasks;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Navigation;

namespace Auchan.Android.Authorization;

public class DialogNavigationOverride : INavigationOverride
{
	public async Task NavigateAsync(Fragment currentFragment, Fragment destination)
	{
		FragmentManager manager = await currentFragment.GetParentFragmentManagerAsync();
		((BaseBottomSheetDialogFragment)destination).Show(manager, null);
	}

	public bool ShouldOverrideNavigation(Fragment currentFragment, Fragment destination)
	{
		return destination is BaseBottomSheetDialogFragment;
	}
}
