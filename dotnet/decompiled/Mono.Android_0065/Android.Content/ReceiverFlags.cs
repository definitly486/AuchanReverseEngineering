using System;
using System.Runtime.Versioning;

namespace Android.Content;

[Flags]
public enum ReceiverFlags
{
	[SupportedOSPlatform("android33.0")]
	Exported = 2,
	[SupportedOSPlatform("android33.0")]
	NotExported = 4,
	[SupportedOSPlatform("android26.0")]
	VisibleToInstantApps = 1
}
