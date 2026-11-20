using System;
using System.Runtime.Versioning;

namespace Android.Content.PM;

[Flags]
public enum ConfigChanges
{
	[SupportedOSPlatform("android36.0")]
	AssetsPaths = int.MinValue,
	[SupportedOSPlatform("android26.0")]
	ColorMode = 0x4000,
	Density = 0x1000,
	FontScale = 0x40000000,
	[SupportedOSPlatform("android31.0")]
	FontWeightAdjustment = 0x10000000,
	[SupportedOSPlatform("android34.0")]
	GrammaticalGender = 0x8000,
	Keyboard = 0x10,
	KeyboardHidden = 0x20,
	LayoutDirection = 0x2000,
	Locale = 4,
	Mcc = 1,
	Mnc = 2,
	Navigation = 0x40,
	Orientation = 0x80,
	[SupportedOSPlatform("android36.0")]
	ResourcesUnused = 0x8000000,
	ScreenLayout = 0x100,
	ScreenSize = 0x400,
	SmallestScreenSize = 0x800,
	Touchscreen = 8,
	UiMode = 0x200
}
