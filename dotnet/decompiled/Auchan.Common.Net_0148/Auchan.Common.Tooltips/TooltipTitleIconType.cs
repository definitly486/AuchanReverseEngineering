using System.Runtime.Serialization;

namespace Auchan.Common.Tooltips;

public enum TooltipTitleIconType
{
	[EnumMember(Value = "None")]
	None,
	[EnumMember(Value = "Points")]
	Points,
	[EnumMember(Value = "Express points")]
	ExpressPoints,
	[EnumMember(Value = "Marks")]
	Marks,
	[EnumMember(Value = "Staff bird")]
	StaffBird
}
