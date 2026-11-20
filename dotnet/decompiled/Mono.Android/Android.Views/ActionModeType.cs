using System.Runtime.Versioning;

namespace Android.Views;

public enum ActionModeType
{
	[SupportedOSPlatform("android23.0")]
	Floating = 1,
	[SupportedOSPlatform("android23.0")]
	Primary = 0
}
