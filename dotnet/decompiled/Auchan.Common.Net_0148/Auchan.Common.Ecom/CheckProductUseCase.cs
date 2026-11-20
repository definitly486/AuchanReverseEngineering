using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;

namespace Auchan.Common.Ecom;

public class CheckProductUseCase
{
	private readonly IEcomContext _ecomContext;

	private readonly ICurrentStoreSelectDialog _currentStoreSelectDialog;

	private readonly IInfoMessageService _infoMessageService;

	public CheckProductUseCase(IEcomContext ecomContext, ICurrentStoreSelectDialog currentStoreSelectDialog, IInfoMessageService infoMessageService)
	{
		_ecomContext = ecomContext;
		_currentStoreSelectDialog = currentStoreSelectDialog;
		_infoMessageService = infoMessageService;
	}

	public async Task<bool> CanAdd(Product product, ProductOffer? offer = null, bool forPriceChecker = false)
	{
		if (_ecomContext.ReceivingMethod.IsDelivery() && product.IsAdult)
		{
			AgreeState agreeState = await _currentStoreSelectDialog.ShowAskDeliveryTypeDialogAsync(ReceivingMethod.Pickup);
			int storeId = _ecomContext.ActiveStore.Id;
			ReceivingMethod receivingMethod = _ecomContext.ReceivingMethod;
			switch (agreeState)
			{
			case AgreeState.Yes:
				await _currentStoreSelectDialog.ShowSelectAddressDialog(new AddressViewModel.Parameter
				{
					ReceivingMethod = ReceivingMethod.Pickup,
					ProductOffer = offer
				});
				if (forPriceChecker)
				{
					AppAnalytics.AppMetrica.TrackEvent("pickup_auto_switch_accepted", ("merchant_id", storeId.ToString()), ("product_id", product.ProductId ?? ""));
				}
				if ((storeId != _ecomContext.ActiveStore.Id || receivingMethod != _ecomContext.ReceivingMethod) && forPriceChecker)
				{
					_infoMessageService.ShowSnackbar("Товар добавлен в корзину для магазина " + _ecomContext.ActiveStore.Name, SnackbarStyle.Success);
				}
				break;
			case AgreeState.No:
				_currentStoreSelectDialog.CloseDialogIfShown();
				if (forPriceChecker)
				{
					AppAnalytics.AppMetrica.TrackEvent("alcohol_delivery_blocked", ("merchant_id", storeId.ToString()), ("product_id", product.ProductId ?? ""));
				}
				break;
			case AgreeState.None:
				_currentStoreSelectDialog.CloseDialogIfShown();
				if (forPriceChecker)
				{
					AppAnalytics.AppMetrica.TrackEvent("alcohol_delivery_blocked", ("merchant_id", storeId.ToString()), ("product_id", product?.ProductId ?? ""));
				}
				break;
			}
			return false;
		}
		if (_ecomContext.ReceivingMethodNotSelected)
		{
			_currentStoreSelectDialog.ShowSelectAddressDialog(new AddressViewModel.Parameter
			{
				ProductOffer = offer
			});
			return false;
		}
		return true;
	}
}
