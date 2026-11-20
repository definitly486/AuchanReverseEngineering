using System;

namespace Auchan.Common.Ecom.Products;

public static class ProductUnitTypeExtensions
{
	public static string ToPerUnitString(this ProductUnitType productUnitType)
	{
		return productUnitType switch
		{
			ProductUnitType.Unit => "1 шт", 
			ProductUnitType.Kilogram_1 => "1 кг", 
			ProductUnitType.Gram_100 => "100 гр", 
			_ => throw new ArgumentException($"{"productUnitType"} value {productUnitType} is not supported"), 
		};
	}
}
