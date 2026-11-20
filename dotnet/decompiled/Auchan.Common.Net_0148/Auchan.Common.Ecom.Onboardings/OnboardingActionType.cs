using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.Onboardings;

public enum OnboardingActionType
{
	[EnumMember(Value = "native")]
	Native,
	[EnumMember(Value = "webview")]
	WebView,
	[EnumMember(Value = "deeplink")]
	Deeplink,
	[EnumMember(Value = "clipboard")]
	Clipboard,
	[EnumMember(Value = "close")]
	Close
}
