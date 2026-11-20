using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool;

public enum PromotionKind
{
	[EnumMember(Value = "native")]
	Native,
	[EnumMember(Value = "web")]
	Webview,
	[EnumMember(Value = "catalog")]
	Catalog
}
