using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class DateItemViewModel : SelectionItemViewModel<CheckoutDate, DeliveryDateTimeViewModel>
{
	public string DateText => base.Item.DayOfMonth;

	public string DayText => base.Item.Day;

	public DateItemViewModel(CheckoutDate item, DeliveryDateTimeViewModel parent, bool selected)
		: base(item, parent, selected)
	{
	}
}
