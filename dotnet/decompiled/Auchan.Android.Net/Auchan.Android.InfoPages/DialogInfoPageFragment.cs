using System;
using Auchan.Common.Common;
using Auchan.Common.InfoPages;
using Google.Android.Material.BottomSheet;

namespace Auchan.Android.InfoPages;

internal class DialogInfoPageFragment : InfoPageFragment
{
	public DialogInfoPageFragment(Func<InfoPageViewModel.Parameter, InfoPageViewModel> newViewModel, IBrowserActivator browserActivator)
		: base(newViewModel, browserActivator)
	{
	}

	protected override void OnNavigationButtonClick()
	{
		(base.ParentFragment as BottomSheetDialogFragment)?.Dismiss();
	}
}
