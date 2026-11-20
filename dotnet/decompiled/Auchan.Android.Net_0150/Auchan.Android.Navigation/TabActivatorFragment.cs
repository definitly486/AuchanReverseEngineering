using System;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Common.Navigation;

namespace Auchan.Android.Navigation;

internal sealed class TabActivatorFragment : BaseFragment<TabActivatorViewModel>
{
	protected override int LayoutId
	{
		get
		{
			throw new NotImplementedException("dead code");
		}
	}

	public TabActivatorFragment(Func<TabActivatorViewModel.Parameter, TabActivatorViewModel> newViewModel)
		: base((Func<Fragment, TabActivatorViewModel>)((Fragment @this) => newViewModel(@this.RequireNavParam<TabActivatorViewModel.Parameter>())))
	{
	}
}
