using System.Threading.Tasks;
using AndroidX.Fragment.App;

namespace Auchan.Android.Base;

internal interface IFragmentNavigation
{
	void NavigateTo<TFragment>(int? containerViewId = null, bool add = false) where TFragment : Fragment;

	void NavigateTo<TFragment, TParameter>(TParameter parameter, int? containerViewId = null, bool add = false) where TFragment : Fragment where TParameter : class;

	Task NavigateToAsync<TFragment>(int? containerViewId = null, bool add = false) where TFragment : Fragment;

	Task NavigateToAsync<TFragment, TParameter>(TParameter parameter, int? containerViewId = null, bool add = false) where TFragment : Fragment where TParameter : class;
}
