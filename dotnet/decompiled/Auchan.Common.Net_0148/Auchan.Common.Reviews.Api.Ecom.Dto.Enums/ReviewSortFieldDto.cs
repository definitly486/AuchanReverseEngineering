using System.Runtime.Serialization;

namespace Auchan.Common.Reviews.Api.Ecom.Dto.Enums;

public enum ReviewSortFieldDto
{
	[EnumMember(Value = "rate")]
	Rate,
	[EnumMember(Value = "created_at")]
	CreatedAt
}
