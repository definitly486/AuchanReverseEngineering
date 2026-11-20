using System.Runtime.Serialization;

namespace Auchan.Common.NewYearGame;

public enum NewYearGamePlayPosition
{
	[EnumMember(Value = "main")]
	Home,
	[EnumMember(Value = "loylcard")]
	Loyalty
}
