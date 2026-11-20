namespace Auchan.Common.Ecom.Cart.Models;

public sealed class SelectedDateTime
{
	public required CheckoutDate Day { get; init; }

	public required CheckoutTime Time { get; init; }
}
