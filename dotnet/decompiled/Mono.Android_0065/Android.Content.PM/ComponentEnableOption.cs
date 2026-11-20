using System;
using System.Runtime.Versioning;

namespace Android.Content.PM;

[Flags]
public enum ComponentEnableOption
{
	None = 0,
	DontKillApp = 1,
	[SupportedOSPlatform("android30.0")]
	Synchronous = 2
}
