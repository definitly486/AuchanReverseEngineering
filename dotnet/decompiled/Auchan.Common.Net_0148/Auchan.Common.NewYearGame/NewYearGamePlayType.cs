using System.Runtime.Serialization;

namespace Auchan.Common.NewYearGame;

public enum NewYearGamePlayType
{
	[EnumMember(Value = "banner")]
	Banner,
	[EnumMember(Value = "curtain")]
	Popup,
	[EnumMember(Value = "bubble")]
	Bubble
}
