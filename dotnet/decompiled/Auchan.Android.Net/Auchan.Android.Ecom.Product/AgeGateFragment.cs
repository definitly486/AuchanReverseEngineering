using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;

namespace Auchan.Android.Ecom.Product;

internal class AgeGateFragment : BaseBottomSheetDialogFragment<AgeGateViewModel>
{
	private sealed class Controls
	{
		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public View Close { get; } = view.RequireViewById<View>(2131296789);

		public TextView Message { get; } = view.RequireViewById<TextView>(2131297563);

		public TextView Yes { get; } = view.RequireViewById<TextView>(2131298855);

		public TextView No { get; } = view.RequireViewById<TextView>(2131297668);

		public Controls(View view)
		{
		}
	}

	protected override int LayoutId => 2131493443;

	public override int Theme => 2131951914;

	public AgeGateFragment(Func<BrokerToken, AgeGateViewModel> newViewModel)
		: base((Func<Fragment, AgeGateViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.Title.Text = base.ViewModel.Title;
		controls.Message.Text = base.ViewModel.Message;
		controls.Yes.Text = base.ViewModel.YesButtonText;
		controls.No.Text = base.ViewModel.NoButtonText;
		base.ViewModel.BindEvents(controls.Close.OnClick(base.ViewModel.Close), controls.Yes.OnClick(base.ViewModel.OnYes), controls.No.OnClick(base.ViewModel.OnNo)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}
}
