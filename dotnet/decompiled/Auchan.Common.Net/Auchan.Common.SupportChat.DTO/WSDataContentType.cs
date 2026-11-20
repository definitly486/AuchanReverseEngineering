using System.Runtime.Serialization;

namespace Auchan.Common.SupportChat.DTO;

public enum WSDataContentType
{
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "text")]
	Text,
	[EnumMember(Value = "buttons")]
	Buttons,
	[EnumMember(Value = "file")]
	File,
	[EnumMember(Value = "image")]
	Image,
	[EnumMember(Value = "location")]
	Location,
	[EnumMember(Value = "operator_info")]
	OperatorInfo
}
