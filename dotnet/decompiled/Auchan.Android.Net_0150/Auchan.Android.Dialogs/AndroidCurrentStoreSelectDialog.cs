using System;
using System.Threading.Tasks;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Managers.Dialogs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Dialogs;

public class AndroidCurrentStoreSelectDialog : ICurrentStoreSelectDialog
{
	private readonly Lazy<FragmentFactory> _fragmentFactory;

	public AndroidCurrentStoreSelectDialog(Lazy<FragmentFactory> fragmentFactory)
	{
		_fragmentFactory = fragmentFactory;
	}

	public Task ShowSelectAddressDialog(AddressViewModel.Parameter parameter)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AddressFragment addressFragment = _fragmentFactory.Value.Instantiate<AddressFragment>();
			addressFragment.Arguments = parameter.ToNavBundle();
			addressFragment.Show(appCompatActivity.SupportFragmentManager, null);
			return addressFragment.Execute();
		}
		return Task.FromResult(AgreeState.None);
	}

	public Task<AgreeState> ShowAskDeliveryTypeDialogAsync(ReceivingMethod method, bool selectedStoreHasOfflinePayment = true)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AskDeliveryMethodFragment askDeliveryMethodFragment = _fragmentFactory.Value.Instantiate<AskDeliveryMethodFragment>();
			askDeliveryMethodFragment.Arguments = new AskDeliveryTypeViewModel.Parameter(method, selectedStoreHasOfflinePayment).ToNavBundle();
			askDeliveryMethodFragment.Show(appCompatActivity.SupportFragmentManager, null);
			return askDeliveryMethodFragment.Execute();
		}
		return Task.FromResult(AgreeState.None);
	}

	public void CloseDialogIfShown()
	{
	}
}
