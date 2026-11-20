using System.Runtime.Versioning;

namespace Android.Views;

public enum TextDirection
{
	AnyRtl = 2,
	FirstStrong = 1,
	[SupportedOSPlatform("android23.0")]
	FirstStrongLtr = 6,
	[SupportedOSPlatform("android23.0")]
	FirstStrongRtl = 7,
	Inherit = 0,
	Locale = 5,
	Ltr = 3,
	Rtl = 4
}
