using Auchan.Common.Base;

namespace Auchan.Android.Base;

internal abstract class BaseFragmentWithViewModel : BaseFragment
{
	public abstract ScreenViewModel GetViewModel();
}
