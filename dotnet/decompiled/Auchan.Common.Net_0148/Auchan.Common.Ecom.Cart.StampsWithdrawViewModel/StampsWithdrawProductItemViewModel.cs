namespace Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;

public class StampsWithdrawProductItemViewModel
{
	public string ImageUrl { get; set; } = string.Empty;

	public string Title { get; private set; }

	public string Price { get; set; } = string.Empty;

	public bool HasOldPrice => !string.IsNullOrWhiteSpace(OldPrice);

	public string OldPrice { get; set; } = string.Empty;

	public StampsWithdrawProductItemViewModel(string name, decimal discountPrice, decimal fullPrice, string? imageUrl)
	{
		Title = name;
		Price = $"{discountPrice:C2}";
		OldPrice = $"{fullPrice:N2}";
		ImageUrl = (string.IsNullOrEmpty(imageUrl) ? string.Empty : imageUrl);
	}
}
