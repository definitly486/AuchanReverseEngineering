using System.Runtime.Serialization;

namespace Auchan.Common.SupportChat;

public enum MessageStatusType
{
	[EnumMember(Value = "sent")]
	Sent,
	[EnumMember(Value = "inProgress")]
	InProgress,
	[EnumMember(Value = "error")]
	Error
}
