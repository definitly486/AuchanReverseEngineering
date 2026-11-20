using System;
using System.Runtime.Versioning;

namespace Android.Content;

[Flags]
public enum ActivityFlags
{
	BroughtToFront = 0x400000,
	ClearTask = 0x8000,
	ClearTop = 0x4000000,
	ClearWhenTaskReset = 0x80000,
	ExcludeFromRecents = 0x800000,
	ForwardResult = 0x2000000,
	[SupportedOSPlatform("android24.0")]
	LaunchAdjacent = 0x1000,
	LaunchedFromHistory = 0x100000,
	[SupportedOSPlatform("android28.0")]
	MatchExternal = 0x800,
	MultipleTask = 0x8000000,
	NewDocument = 0x80000,
	NewTask = 0x10000000,
	NoAnimation = 0x10000,
	NoHistory = 0x40000000,
	NoUserAction = 0x40000,
	PreviousIsTop = 0x1000000,
	ReorderToFront = 0x20000,
	[SupportedOSPlatform("android30.0")]
	RequireDefault = 0x200,
	[SupportedOSPlatform("android30.0")]
	RequireNonBrowser = 0x400,
	ResetTaskIfNeeded = 0x200000,
	RetainInRecents = 0x2000,
	SingleTop = 0x20000000,
	TaskOnHome = 0x4000,
	DebugLogResolution = 8,
	[SupportedOSPlatform("android29.0")]
	DirectBootAuto = 0x100,
	ExcludeStoppedPackages = 0x10,
	FromBackground = 4,
	GrantPersistableUriPermission = 0x40,
	GrantPrefixUriPermission = 0x80,
	GrantReadUriPermission = 1,
	GrantWriteUriPermission = 2,
	IncludeStoppedPackages = 0x20,
	ReceiverForeground = 0x10000000,
	ReceiverNoAbort = 0x8000000,
	ReceiverRegisteredOnly = 0x40000000,
	ReceiverReplacePending = 0x20000000,
	[SupportedOSPlatform("android26.0")]
	ReceiverVisibleToInstantApps = 0x200000
}
