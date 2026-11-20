using System.Runtime.Serialization;

namespace Auchan.Common.NewYearGame;

public enum NewYearGameActionType
{
	[EnumMember(Value = "ready")]
	Ready,
	[EnumMember(Value = "userData")]
	UserData,
	[EnumMember(Value = "pause")]
	Pause,
	[EnumMember(Value = "close")]
	Close,
	[EnumMember(Value = "back")]
	Back,
	[EnumMember(Value = "write-clipboard")]
	WriteClipboard
}
