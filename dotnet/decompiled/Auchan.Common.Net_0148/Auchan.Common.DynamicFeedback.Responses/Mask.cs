using System.Runtime.Serialization;

namespace Auchan.Common.DynamicFeedback.Responses;

public enum Mask
{
	[EnumMember(Value = "PhoneMask")]
	PhoneMask,
	[EnumMember(Value = "EmailMask")]
	EmailMask
}
