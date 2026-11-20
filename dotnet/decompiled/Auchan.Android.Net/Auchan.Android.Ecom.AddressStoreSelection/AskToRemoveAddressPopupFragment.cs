using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal class AskToRemoveAddressPopupFragment : BaseBottomSheetDialogFragment<AskToRemoveAddressPopupViewModel>
{
	protected override int LayoutId => 2131493487;

	public override int Theme => 2131951914;

	public AskToRemoveAddressPopupFragment(Func<BrokerToken, AskToRemoveAddressPopupViewModel> newViewModel)
		: base((Func<Fragment, AskToRemoveAddressPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298659);
		TextView textView2 = view.RequireViewById<TextView>(2131297573);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		Button button = view.RequireViewById<Button>(2131298856);
		Button button2 = view.RequireViewById<Button>(2131297669);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		button.Text = base.ViewModel.YesText;
		button2.Text = base.ViewModel.NoText;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.Close), button2.OnClick(base.ViewModel.No), button.OnClick(base.ViewModel.Yes)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}
}
