using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class ReplacementItemViewModel : SelectionItemViewModel<Replacement, CheckoutViewModel>
{
	public ReplacementItemViewModel(Replacement item, CheckoutViewModel parent, bool selected)
		: base(item, parent, selected)
	{
	}
}
