using System.Runtime.Serialization;

namespace Auchan.Common.Controls.Accordion;

public enum AccordionElementState
{
	[EnumMember(Value = "active")]
	Active,
	[EnumMember(Value = "inactive")]
	Inactive,
	[EnumMember(Value = "no_points")]
	NoPoints,
	[EnumMember(Value = "disabled")]
	Disabled,
	[EnumMember(Value = "no_loyalty")]
	NoLoyalty,
	[EnumMember(Value = "gone")]
	Gone
}
