using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Cart;

internal sealed class StampsLoyaltyNoConnectFragment : BaseBottomSheetDialogFragment<StampsLoyaltyNoConnectViewModel>
{
	private TextView _title;

	private TextView _descripion;

	private MaterialButton _continueButton;

	private ImageView _closeButton;

	protected override int LayoutId => 2131493495;

	public override int Theme => 2131951914;

	public StampsLoyaltyNoConnectFragment(Func<BrokerToken, StampsLoyaltyNoConnectViewModel> newViewModel)
		: base((Func<Fragment, StampsLoyaltyNoConnectViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		InitializeViews();
		SetValues();
		DoBind();
	}

	private void InitializeViews()
	{
		_title = View.RequireViewById<TextView>(2131298646);
		_descripion = View.RequireViewById<TextView>(2131296313);
		_continueButton = View.RequireViewById<MaterialButton>(2131296846);
		_closeButton = View.RequireViewById<ImageView>(2131296795);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	private void SetValues()
	{
		_title.Text = base.ViewModel.TitleText;
		_descripion.Text = base.ViewModel.DescriptionText;
		_continueButton.Text = base.ViewModel.ContinueText;
	}

	private void DoBind()
	{
		base.ViewModel.BindEvents(_closeButton.OnClick(Dismiss), _continueButton.OnClick(base.ViewModel.ContinueWithoutWithdrawalTapped)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
