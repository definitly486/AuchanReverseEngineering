using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.Products;

public enum ProductUnitType
{
	[EnumMember(Value = "item")]
	Unit,
	[EnumMember(Value = "weight_kg")]
	Kilogram_1,
	[EnumMember(Value = "weight_100g")]
	Gram_100
}
