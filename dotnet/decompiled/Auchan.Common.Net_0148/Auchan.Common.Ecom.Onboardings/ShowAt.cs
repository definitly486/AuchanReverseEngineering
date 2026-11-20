using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.Onboardings;

public enum ShowAt
{
	[EnumMember(Value = "before_auth")]
	BeforeAuth,
	[EnumMember(Value = "home_page")]
	HomePage,
	[EnumMember(Value = "loyalty_page")]
	LoyaltyPage
}
