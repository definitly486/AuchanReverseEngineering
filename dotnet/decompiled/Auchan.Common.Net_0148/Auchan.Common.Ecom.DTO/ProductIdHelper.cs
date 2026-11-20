using System;
using System.Linq;

namespace Auchan.Common.Ecom.DTO;

public static class ProductIdHelper
{
	public static long TryGetProductId(string? productIdString)
	{
		if (productIdString == null || string.IsNullOrWhiteSpace(productIdString) || !productIdString.All(char.IsDigit))
		{
			return 0L;
		}
		return Convert.ToInt64(productIdString);
	}
}
