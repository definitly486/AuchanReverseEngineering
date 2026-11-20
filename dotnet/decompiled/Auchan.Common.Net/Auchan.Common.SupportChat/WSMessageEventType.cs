using System.Runtime.Serialization;

namespace Auchan.Common.SupportChat;

public enum WSMessageEventType
{
	Unknown,
	[EnumMember(Value = "pusher_internal:subscription_succeeded")]
	ConnectionSucceeded,
	[EnumMember(Value = "new_message")]
	NewMessage,
	[EnumMember(Value = "new_message.from_queue")]
	NewMessageFromQueue,
	[EnumMember(Value = "response.from_beesender")]
	MessageReceived,
	[EnumMember(Value = "acknowledge")]
	Acknowledge
}
