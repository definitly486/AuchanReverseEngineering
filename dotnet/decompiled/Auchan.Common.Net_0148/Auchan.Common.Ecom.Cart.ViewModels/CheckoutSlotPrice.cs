namespace Auchan.Common.Ecom.Cart.ViewModels;

public static class CheckoutSlotPrice
{
	public static bool IsVisible(decimal? price)
	{
		return price.HasValue;
	}

	public static string Format(decimal? price)
	{
		return $"{price:C0}";
	}
}
