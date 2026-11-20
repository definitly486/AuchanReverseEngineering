using System.Runtime.Serialization;

namespace Auchan.Common.Reviews.Api.Ecom.Dto.Enums;

public enum ReviewSortDirectionDto
{
	[EnumMember(Value = "desc")]
	Descend,
	[EnumMember(Value = "asc")]
	Ascend
}
