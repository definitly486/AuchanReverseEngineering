using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Products.ViewModels.ProductDetails;

public class SalesIconsViewModel : BaseItemViewModel
{
	public bool IsNewProductVisible { get; }

	public bool IsCashbackVisible { get; }

	public bool IsDiscountVisible { get; }

	public string NewProductText { get; }

	public string CashbackText { get; }

	public string DiscountText { get; }

	public SalesIconsViewModel(Product product)
	{
		IsNewProductVisible = product.IsNew;
		IsCashbackVisible = product.Cashback != null;
		IsDiscountVisible = product.Discount != null && product.OldPrice != null;
		NewProductText = "новинка";
		CashbackText = (product.Cashback?.Amount.ToString() ?? string.Empty) + "%";
		DiscountText = $"-{product.Discount?.ValueInPercent}";
		if (IsNewProductVisible && IsCashbackVisible && IsDiscountVisible)
		{
			IsNewProductVisible = false;
		}
	}
}
