using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;

namespace Auchan.Common.Ecom.Cart.StampsWithdraw;

public class StampDiscountModel
{
	public int Stamps { get; private set; }

	public string CountDescription { get; private set; }

	public List<StampsWithdrawProductItemViewModel> Products { get; private set; }

	public StampDiscountModel(int stamps, string countDescription, IEnumerable<StampsWithdrawProductItemViewModel> products)
	{
		Stamps = stamps;
		CountDescription = countDescription;
		Products = products.ToList();
	}
}
