using Android.OS;
using Auchan.Android.InfoPages;

namespace Auchan.Android.Base;

public class BottomSheetInfoPageFragmentContainer : BaseBottomSheetDialogFragment
{
	protected override int LayoutId => 2131492993;

	public override int Theme => 2131951916;

	protected override bool FullScreen => true;

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		if (savedInstanceState == null)
		{
			base.ChildFragmentManager.Replace<DialogInfoPageFragment>(2131297216, base.Arguments).Commit();
		}
	}
}
