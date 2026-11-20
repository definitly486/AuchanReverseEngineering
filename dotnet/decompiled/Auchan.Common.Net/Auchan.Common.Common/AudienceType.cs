using System.Runtime.Serialization;

namespace Auchan.Common.Common;

public enum AudienceType
{
	[EnumMember(Value = "All")]
	All,
	[EnumMember(Value = "Employees")]
	Employees,
	[EnumMember(Value = "Clients")]
	Clients
}
