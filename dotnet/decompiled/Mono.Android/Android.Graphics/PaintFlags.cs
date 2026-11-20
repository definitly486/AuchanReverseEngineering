using System;
using System.Runtime.Versioning;

namespace Android.Graphics;

[Flags]
public enum PaintFlags
{
	AntiAlias = 1,
	DevKernText = 0x100,
	Dither = 4,
	EmbeddedBitmapText = 0x400,
	FakeBoldText = 0x20,
	FilterBitmap = 2,
	LinearText = 0x40,
	StrikeThruText = 0x10,
	SubpixelText = 0x80,
	UnderlineText = 8,
	[SupportedOSPlatform("android36.0")]
	VerticalText = 0x1000
}
