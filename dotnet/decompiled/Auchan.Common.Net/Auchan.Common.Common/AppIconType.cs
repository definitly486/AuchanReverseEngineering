using System.Runtime.Serialization;

namespace Auchan.Common.Common;

public enum AppIconType
{
	Unknown,
	[EnumMember(Value = "default")]
	Default,
	[EnumMember(Value = "sale60")]
	Sale60,
	[EnumMember(Value = "sale70")]
	Sale70,
	[EnumMember(Value = "newyear")]
	NewYear,
	[EnumMember(Value = "birthday")]
	Birthday
}
