using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool.Models;

public enum GameAnimationClosePosition
{
	[EnumMember(Value = "top_left")]
	TopLeft,
	[EnumMember(Value = "top_right")]
	TopRight,
	[EnumMember(Value = "bottom_left")]
	BottomLeft,
	[EnumMember(Value = "bottom_right")]
	BottomRight
}
