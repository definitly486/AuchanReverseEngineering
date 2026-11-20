using System.Runtime.Versioning;

namespace Android.Net;

public enum NetCapability
{
	[SupportedOSPlatform("android23.0")]
	CaptivePortal = 17,
	Cbs = 5,
	Dun = 2,
	Eims = 10,
	[SupportedOSPlatform("android31.0")]
	Enterprise = 29,
	[SupportedOSPlatform("android28.0")]
	Foreground = 19,
	Fota = 3,
	[SupportedOSPlatform("android31.0")]
	HeadUnit = 32,
	Ia = 7,
	Ims = 4,
	Internet = 12,
	[SupportedOSPlatform("android35.0")]
	LocalNetwork = 36,
	[SupportedOSPlatform("android29.0")]
	Mcx = 23,
	Mms = 0,
	[SupportedOSPlatform("android33.0")]
	Mmtel = 33,
	[SupportedOSPlatform("android36.0")]
	NotBandwidthConstrained = 37,
	[SupportedOSPlatform("android28.0")]
	NotCongested = 20,
	NotMetered = 11,
	NotRestricted = 13,
	[SupportedOSPlatform("android28.0")]
	NotRoaming = 18,
	[SupportedOSPlatform("android28.0")]
	NotSuspended = 21,
	NotVpn = 15,
	[SupportedOSPlatform("android33.0")]
	PrioritizeBandwidth = 35,
	[SupportedOSPlatform("android33.0")]
	PrioritizeLatency = 34,
	Rcs = 8,
	Supl = 1,
	[SupportedOSPlatform("android30.0")]
	TemporarilyNotMetered = 25,
	Trusted = 14,
	[SupportedOSPlatform("android23.0")]
	Validated = 16,
	WifiP2p = 6,
	Xcap = 9
}
