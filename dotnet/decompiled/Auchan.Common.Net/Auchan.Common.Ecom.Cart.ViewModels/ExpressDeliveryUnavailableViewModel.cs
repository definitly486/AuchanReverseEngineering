using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class ExpressDeliveryUnavailableViewModel : ScreenViewModel
{
	private bool _isOpeningAddressSelection;

	public override bool TabBarVisible => false;

	public string TitleText => "Быстрая доставка сейчас недоступна";

	public string DescriptionText => "Для оформления заказа вы можете выбрать другой способ получения";

	public string SelectAnotherReceivingMethodText => "Выбрать другой способ получения";

	public UICommand<AddressViewModel.Parameter> OpenAddressSelectionCommand { get; } = new UICommand<AddressViewModel.Parameter>();

	public void SelectAnotherReceivingMethod()
	{
		if (!_isOpeningAddressSelection)
		{
			_isOpeningAddressSelection = true;
			OpenAddressSelectionCommand.Trigger(new AddressViewModel.Parameter
			{
				ReceivingMethod = ReceivingMethod.Delivery
			});
		}
	}
}
