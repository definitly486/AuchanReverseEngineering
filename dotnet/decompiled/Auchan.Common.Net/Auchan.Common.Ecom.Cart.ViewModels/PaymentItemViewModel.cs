using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class PaymentItemViewModel : SelectionItemViewModel<AvailablePayment, CheckoutViewModel>
{
	public PaymentItemViewModel(AvailablePayment item, CheckoutViewModel parent, bool selected)
		: base(item, parent, selected)
	{
	}
}
