using System.Runtime.Serialization;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public enum OsTypeParameter
{
	[EnumMember(Value = "Android")]
	Android,
	[EnumMember(Value = "iOS")]
	iOS
}
