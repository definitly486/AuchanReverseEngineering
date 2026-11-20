using System.Runtime.Serialization;

namespace Auchan.Common.InfoPages;

public enum InfoContentType
{
	Unknown,
	[EnumMember(Value = "native")]
	Native,
	[EnumMember(Value = "web")]
	Webview
}
