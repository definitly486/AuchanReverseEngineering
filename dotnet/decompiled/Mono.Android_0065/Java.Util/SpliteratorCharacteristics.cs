using System.Runtime.Versioning;

namespace Java.Util;

public enum SpliteratorCharacteristics
{
	[SupportedOSPlatform("android24.0")]
	Concurrent = 4096,
	[SupportedOSPlatform("android24.0")]
	Distinct = 1,
	[SupportedOSPlatform("android24.0")]
	Immutable = 1024,
	[SupportedOSPlatform("android24.0")]
	Nonnull = 256,
	[SupportedOSPlatform("android24.0")]
	Ordered = 16,
	[SupportedOSPlatform("android24.0")]
	Sized = 64,
	[SupportedOSPlatform("android24.0")]
	Sorted = 4,
	[SupportedOSPlatform("android24.0")]
	Subsized = 16384
}
