using System;
using System.Runtime.Versioning;

namespace Android.Views;

[Flags]
public enum WindowManagerFlags
{
	AllowLockWhileScreenOn = 1,
	AltFocusableIm = 0x20000,
	BlurBehind = 4,
	DimBehind = 2,
	DismissKeyguard = 0x400000,
	Dither = 0x1000,
	DrawsSystemBarBackgrounds = int.MinValue,
	ForceNotFullscreen = 0x800,
	Fullscreen = 0x400,
	HardwareAccelerated = 0x1000000,
	IgnoreCheekPresses = 0x8000,
	KeepScreenOn = 0x80,
	[SupportedOSPlatform("android22.0")]
	LayoutAttachedInDecor = 0x40000000,
	LayoutInOverscan = 0x2000000,
	LayoutInScreen = 0x100,
	LayoutInsetDecor = 0x10000,
	LayoutNoLimits = 0x200,
	LocalFocusMode = 0x10000000,
	NotFocusable = 8,
	NotTouchModal = 0x20,
	NotTouchable = 0x10,
	Scaled = 0x4000,
	Secure = 0x2000,
	ShowWallpaper = 0x100000,
	ShowWhenLocked = 0x80000,
	SplitTouch = 0x800000,
	TouchableWhenWaking = 0x40,
	TranslucentNavigation = 0x8000000,
	TranslucentStatus = 0x4000000,
	TurnScreenOn = 0x200000,
	WatchOutsideTouch = 0x40000
}
