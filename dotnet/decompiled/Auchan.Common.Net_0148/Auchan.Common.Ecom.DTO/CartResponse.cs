namespace Auchan.Common.Ecom.DTO;

public class CartResponse
{
	public CartDto Cart { get; set; }

	public bool WasBasketChanged { get; set; }
}
