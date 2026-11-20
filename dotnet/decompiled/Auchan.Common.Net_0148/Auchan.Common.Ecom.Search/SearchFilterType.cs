using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.Search;

public enum SearchFilterType
{
	[EnumMember(Value = "range")]
	Range,
	[EnumMember(Value = "check")]
	Check,
	[EnumMember(Value = "multi_check")]
	MultiCheck,
	[EnumMember(Value = "radio")]
	Radio
}
