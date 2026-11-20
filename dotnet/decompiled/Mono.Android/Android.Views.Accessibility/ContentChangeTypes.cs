using System;
using System.Runtime.Versioning;

namespace Android.Views.Accessibility;

[Flags]
public enum ContentChangeTypes
{
	[SupportedOSPlatform("android36.0")]
	Checked = 0x2000,
	ContentDescription = 4,
	[SupportedOSPlatform("android34.0")]
	ContentInvalid = 0x400,
	[SupportedOSPlatform("android32.0")]
	DragCancelled = 0x200,
	[SupportedOSPlatform("android32.0")]
	DragDropped = 0x100,
	[SupportedOSPlatform("android32.0")]
	DragStarted = 0x80,
	[SupportedOSPlatform("android34.0")]
	Enabled = 0x1000,
	[SupportedOSPlatform("android34.0")]
	Error = 0x800,
	[SupportedOSPlatform("android36.0")]
	Expanded = 0x4000,
	[SupportedOSPlatform("android28.0")]
	PaneAppeared = 0x10,
	[SupportedOSPlatform("android28.0")]
	PaneDisappeared = 0x20,
	[SupportedOSPlatform("android28.0")]
	PaneTitle = 8,
	[SupportedOSPlatform("android30.0")]
	StateDescription = 0x40,
	Subtree = 1,
	[SupportedOSPlatform("android36.0")]
	SupplementalDescription = 0x8000,
	Text = 2,
	Undefined = 0
}
