using System;
using System.Runtime.Versioning;

namespace Android.Views;

[Flags]
public enum SystemUiFlags
{
	Fullscreen = 4,
	HideNavigation = 2,
	Immersive = 0x800,
	ImmersiveSticky = 0x1000,
	LayoutFullscreen = 0x400,
	LayoutHideNavigation = 0x200,
	LayoutStable = 0x100,
	[SupportedOSPlatform("android26.0")]
	LightNavigationBar = 0x10,
	[SupportedOSPlatform("android23.0")]
	LightStatusBar = 0x2000,
	LowProfile = 1,
	Visible = 0,
	LayoutFlags = 0x600
}
