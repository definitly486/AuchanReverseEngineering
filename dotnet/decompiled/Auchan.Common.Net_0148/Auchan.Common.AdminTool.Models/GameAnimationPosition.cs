using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool.Models;

public enum GameAnimationPosition
{
	[EnumMember(Value = "bottom")]
	Bottom,
	[EnumMember(Value = "left_center")]
	LeftCenter,
	[EnumMember(Value = "right_center")]
	RightCenter
}
