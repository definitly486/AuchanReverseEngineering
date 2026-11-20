using System.Runtime.Serialization;

namespace Auchan.Common.Promotions;

public enum PromotionMessageType
{
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "sendRequest")]
	SendRequest,
	[EnumMember(Value = "sendRequestResult")]
	SendRequestResult
}
