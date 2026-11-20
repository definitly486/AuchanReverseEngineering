using System;
using System.Runtime.Versioning;

namespace Android.Content.PM;

[Flags]
public enum PackageInfoFlags
{
	Activities = 1,
	[SupportedOSPlatform("android31.0")]
	Attributions = int.MinValue,
	Configurations = 0x4000,
	DisabledComponents = 0x200,
	DisabledUntilUsedComponents = 0x8000,
	Gids = 0x100,
	Instrumentation = 0x10,
	IntentFilters = 0x20,
	MetaData = 0x80,
	Permissions = 0x1000,
	Providers = 8,
	Receivers = 2,
	ResolvedFilter = 0x40,
	Services = 4,
	SharedLibraryFiles = 0x400,
	Signatures = 0x40,
	[SupportedOSPlatform("android28.0")]
	SigningCertificates = 0x8000000,
	UninstalledPackages = 0x2000,
	UriPermissionPatterns = 0x800,
	[SupportedOSPlatform("android23.0")]
	MatchAll = 0x20000,
	MatchDefaultOnly = 0x10000,
	[SupportedOSPlatform("android24.0")]
	MatchDirectBootAware = 0x80000,
	[SupportedOSPlatform("android24.0")]
	MatchDirectBootUnaware = 0x40000,
	[SupportedOSPlatform("android24.0")]
	MatchDisabledComponents = 0x200,
	[SupportedOSPlatform("android24.0")]
	MatchDisabledUntilUsedComponents = 0x8000,
	[SupportedOSPlatform("android24.0")]
	MatchSystemOnly = 0x100000,
	[SupportedOSPlatform("android24.0")]
	MatchUninstalledPackages = 0x2000
}
