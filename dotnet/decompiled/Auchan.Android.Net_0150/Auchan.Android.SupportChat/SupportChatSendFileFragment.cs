using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.SupportChat;

namespace Auchan.Android.SupportChat;

internal sealed class SupportChatSendFileFragment : BaseBottomSheetDialogFragment<SupportChatSendFileViewModel>
{
	protected override int LayoutId => 2131493109;

	public override int Theme => 2131951914;

	public SupportChatSendFileFragment(Func<BrokerToken, SupportChatSendFileViewModel> vmFactory)
		: base((Func<Fragment, SupportChatSendFileViewModel>)((Fragment thisFragment) => vmFactory(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Cancelable = true;
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131297563);
		Button button = view.RequireViewById<Button>(2131298211);
		Button button2 = view.RequireViewById<Button>(2131296927);
		View view2 = view.RequireViewById<View>(2131296789);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.ErrorText;
		button.Text = base.ViewModel.ResendText;
		button2.Text = base.ViewModel.DeleteText;
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.ResendCommand.Trigger), button2.OnClick(base.ViewModel.CloseCommand.Trigger), view2.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
