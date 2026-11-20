using System.Runtime.Serialization;

namespace Auchan.Common.Reviews;

public enum CheckAddingStatus
{
	[EnumMember(Value = "no_product")]
	NoProduct,
	[EnumMember(Value = "can_review")]
	CanReview,
	[EnumMember(Value = "already_reviewed")]
	AlreadyReviewed
}
