using System.Runtime.Serialization;

namespace Auchan.Common.Reviews;

public enum Channel
{
	[EnumMember(Value = "online")]
	Online,
	[EnumMember(Value = "offline")]
	Offline
}
