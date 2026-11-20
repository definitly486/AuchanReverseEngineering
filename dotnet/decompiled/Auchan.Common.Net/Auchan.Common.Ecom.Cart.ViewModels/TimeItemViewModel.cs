using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class TimeItemViewModel : SelectionItemViewModel<CheckoutTime, DeliveryDateTimeViewModel>
{
	public string TimeText => base.Item.Slot;

	public bool HasSurge => base.Item.HasSurge;

	public bool IsPriceVisible => CheckoutSlotPrice.IsVisible(base.Item.Price);

	public string PriceText => CheckoutSlotPrice.Format(base.Item.Price);

	public TimeItemViewModel(CheckoutTime item, DeliveryDateTimeViewModel parent, bool selected)
		: base(item, parent, selected)
	{
	}
}
