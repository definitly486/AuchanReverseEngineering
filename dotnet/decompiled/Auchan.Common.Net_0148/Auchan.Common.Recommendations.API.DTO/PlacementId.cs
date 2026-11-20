using System.Runtime.Serialization;

namespace Auchan.Common.Recommendations.API.DTO;

public enum PlacementId
{
	[EnumMember(Value = "01J91S9RPHDEZ2WPQB5GC8XNW2")]
	HomeScreen,
	[EnumMember(Value = "01J91SMWJKBQB239ZJM1V8YC2D")]
	Cart,
	[EnumMember(Value = "01K49RQW5T9NQ6K186ZE89A2EB")]
	EmptyCart,
	[EnumMember(Value = "01J91SDCFB8W6D1HZ5GJ8HG8AZ")]
	Category,
	[EnumMember(Value = "01J91SGJZKRWPE1YKVNFMVZ71A")]
	ProductDetails
}
