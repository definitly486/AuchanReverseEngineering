using System.Threading.Tasks;
using AndroidX.Fragment.App;

namespace Auchan.Android.Navigation;

public interface INavigationOverride
{
	bool ShouldOverrideNavigation(Fragment currentFragment, Fragment destination);

	Task NavigateAsync(Fragment currentFragment, Fragment destination);
}
