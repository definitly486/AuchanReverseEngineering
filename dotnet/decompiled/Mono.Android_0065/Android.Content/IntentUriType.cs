using System;
using System.Runtime.Versioning;

namespace Android.Content;

[Flags]
public enum IntentUriType
{
	None = 0,
	[SupportedOSPlatform("android22.0")]
	AllowUnsafe = 4,
	[SupportedOSPlatform("android22.0")]
	AndroidAppScheme = 2,
	Scheme = 1
}
