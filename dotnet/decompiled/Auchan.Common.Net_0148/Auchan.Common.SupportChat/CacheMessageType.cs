using System.Runtime.Serialization;

namespace Auchan.Common.SupportChat;

public enum CacheMessageType
{
	[EnumMember(Value = "outgoing")]
	Outgoing,
	[EnumMember(Value = "incoming")]
	Incoming,
	[EnumMember(Value = "system")]
	System,
	[EnumMember(Value = "structChips")]
	StructChips,
	[EnumMember(Value = "structProducts")]
	StructProducts
}
