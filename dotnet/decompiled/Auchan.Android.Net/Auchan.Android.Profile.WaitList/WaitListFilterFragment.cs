using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.WaitList;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.WaitList;

internal class WaitListFilterFragment : BaseBottomSheetDialogFragment<WaitListFilterViewModel>
{
	protected override int LayoutId => 2131493439;

	public override int Theme => 2131951914;

	public WaitListFilterFragment(Func<BrokerToken, WaitListFilterViewModel> newViewModel)
		: base((Func<Fragment, WaitListFilterViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296459);
		Switch switchActiveProducts = view.RequireViewById<Switch>(2131296339);
		TextView textView3 = view.RequireViewById<TextView>(2131298582);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		materialButton.Text = base.ViewModel.ApplyButtonText;
		textView3.Text = base.ViewModel.SwitchText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			switchActiveProducts.Checked = base.ViewModel.OnlyActive;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OnlyActive")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			base.ViewModel.OnAnswer(base.ViewModel.OnlyActive);
		}), ((View)materialButton).OnClick((Action)delegate
		{
			base.ViewModel.OnAnswer(switchActiveProducts.Checked);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
