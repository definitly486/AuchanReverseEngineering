namespace Auchan.Common.Ecom.Cart.ViewModels;

public class DiscountItemViewModel
{
	public string Title { get; private set; }

	public string Amount { get; private set; }

	public DiscountItemViewModel(string title, string amount)
	{
		Title = title;
		Amount = amount;
	}
}
