using System.Runtime.Versioning;

namespace Android.Content.PM;

public enum LaunchMode
{
	Multiple = 0,
	SingleInstance = 3,
	[SupportedOSPlatform("android31.0")]
	SingleInstancePerTask = 4,
	SingleTask = 2,
	SingleTop = 1
}
