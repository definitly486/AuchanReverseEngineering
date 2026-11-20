using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.SocialStatus;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.SocialStatus;

internal class ConfirmedSocialStatusFragment : BaseBottomSheetDialogFragment<ConfirmedSocialStatusViewModel>
{
	public override int Theme => 2131951916;

	protected override int LayoutId => 2131493460;

	protected override bool FullScreen => true;

	public ConfirmedSocialStatusFragment(Func<Fragment, ConfirmedSocialStatusViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView titleView = view.RequireViewById<TextView>(2131298655);
		TextView textView = view.RequireViewById<TextView>(2131297571);
		TextView textView2 = view.RequireViewById<TextView>(2131298680);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298780);
		textView2.Text = base.ViewModel.ToolbarTitle;
		textView.SetLinkedHtml(base.ViewModel.Message, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		materialButton.Text = base.ViewModel.ButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			titleView.Text = base.ViewModel.Title;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.OnButtonCLick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnCloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
