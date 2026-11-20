using System.Runtime.Versioning;

namespace Android.App;

public enum NotificationImportance
{
	[SupportedOSPlatform("android24.0")]
	Default = 3,
	[SupportedOSPlatform("android24.0")]
	High = 4,
	[SupportedOSPlatform("android24.0")]
	Low = 2,
	[SupportedOSPlatform("android24.0")]
	Max = 5,
	[SupportedOSPlatform("android24.0")]
	Min = 1,
	[SupportedOSPlatform("android24.0")]
	None = 0,
	[SupportedOSPlatform("android24.0")]
	Unspecified = -1000
}
