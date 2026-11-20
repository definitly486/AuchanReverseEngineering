using System.Runtime.Serialization;

namespace Auchan.Common.InfoPages;

public enum FAQType
{
	[EnumMember(Value = "default_faq")]
	Default,
	[EnumMember(Value = "loyalty_faq")]
	Loyalty,
	[EnumMember(Value = "employees_faq")]
	Employees
}
