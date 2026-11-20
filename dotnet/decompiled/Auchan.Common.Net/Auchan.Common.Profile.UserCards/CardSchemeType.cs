using System.Runtime.Serialization;

namespace Auchan.Common.Profile.UserCards;

public enum CardSchemeType
{
	[EnumMember(Value = "UNKN")]
	UNKN,
	[EnumMember(Value = "VISA")]
	VISA,
	[EnumMember(Value = "PLUS")]
	PLUS,
	[EnumMember(Value = "MCRD")]
	MCRD,
	[EnumMember(Value = "ECRD")]
	ECRD,
	[EnumMember(Value = "CIRR")]
	CIRR,
	[EnumMember(Value = "MAES")]
	MAES,
	[EnumMember(Value = "CIMA")]
	CIMA,
	[EnumMember(Value = "MIRC")]
	MIRC,
	[EnumMember(Value = "ACAP")]
	ACAP,
	[EnumMember(Value = "ACGC")]
	ACGC
}
