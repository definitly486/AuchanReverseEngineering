using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Cart.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Cart;

internal sealed class ExpressDeliveryUnavailableFragment : BaseFragment<ExpressDeliveryUnavailableViewModel>
{
	protected override int LayoutId => 2131493026;

	public ExpressDeliveryUnavailableFragment(Func<ExpressDeliveryUnavailableViewModel> newViewModel)
		: base((Func<Fragment, ExpressDeliveryUnavailableViewModel>)((Fragment _) => newViewModel()))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		TextView textView2 = view.RequireViewById<TextView>(2131296313);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298330);
		textView.Text = base.ViewModel.TitleText;
		textView2.Text = base.ViewModel.DescriptionText;
		materialButton.Text = base.ViewModel.SelectAnotherReceivingMethodText;
		base.ViewModel.OpenAddressSelectionCommand.SafeSubscribe(OpenAddressSelection, ViewLifecycleOwner);
		materialButton.OnClick(base.ViewModel.SelectAnotherReceivingMethod).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OpenAddressSelection(AddressViewModel.Parameter parameter)
	{
		FragmentManager parentFragmentManager = base.ParentFragmentManager;
		AddressFragment addressFragment = parentFragmentManager.FragmentFactory.Instantiate<AddressFragment>();
		addressFragment.Arguments = parameter.ToNavBundle();
		parentFragmentManager.PopBackStack();
		addressFragment.Show(parentFragmentManager, null);
	}
}
