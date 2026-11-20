using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public interface ICartItemViewModel
{
	ProductOffer ProductOffer { get; set; }

	void OnItemDeleted();
}
