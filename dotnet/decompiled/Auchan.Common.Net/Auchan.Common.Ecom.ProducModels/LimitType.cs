using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.ProducModels;

public enum LimitType
{
	None,
	[EnumMember(Value = "кг")]
	Kg,
	[EnumMember(Value = "шт")]
	Pcs
}
