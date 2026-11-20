using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Ecom.Cart;

internal static class CartHelper
{
	public static decimal ComputeStock(decimal realStock, decimal basketStep, ProductUnitType unitType)
	{
		if (unitType != ProductUnitType.Unit)
		{
			return realStock - realStock % basketStep;
		}
		return realStock;
	}
}
