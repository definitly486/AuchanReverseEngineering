using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Managers.Dialogs;

public interface ICurrentStoreSelectDialog
{
	Task ShowSelectAddressDialog(AddressViewModel.Parameter parameter);

	Task<AgreeState> ShowAskDeliveryTypeDialogAsync(ReceivingMethod method, bool selectedStoreHasOfflinePayment = true);

	void CloseDialogIfShown();
}
