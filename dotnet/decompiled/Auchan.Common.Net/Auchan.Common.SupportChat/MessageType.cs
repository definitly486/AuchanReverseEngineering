using System.Runtime.Serialization;

namespace Auchan.Common.SupportChat;

public enum MessageType
{
	[EnumMember(Value = "text")]
	Text,
	[EnumMember(Value = "image")]
	Image,
	[EnumMember(Value = "file")]
	File,
	[EnumMember(Value = "location")]
	Location
}
