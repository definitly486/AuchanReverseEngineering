using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.DTO;

public enum SharedCartError
{
	Unknown,
	[EnumMember(Value = "BasketShareNotFound")]
	BasketShareNotFound,
	[EnumMember(Value = "ActiveProductsNotFound")]
	ActiveProductsNotFound
}
