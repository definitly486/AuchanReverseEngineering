using System;
using System.Runtime.Versioning;

namespace Android.Views;

[Flags]
public enum MotionEventActions
{
	[SupportedOSPlatform("android23.0")]
	ButtonPress = 0xB,
	[SupportedOSPlatform("android23.0")]
	ButtonRelease = 0xC,
	Cancel = 3,
	Down = 0,
	HoverEnter = 9,
	HoverExit = 0xA,
	HoverMove = 7,
	Mask = 0xFF,
	Move = 2,
	Outside = 4,
	Pointer1Down = 5,
	Pointer1Up = 6,
	Pointer2Down = 0x105,
	Pointer2Up = 0x106,
	Pointer3Down = 0x205,
	Pointer3Up = 0x206,
	PointerDown = 5,
	PointerIdMask = 0xFF00,
	PointerIdShift = 8,
	PointerIndexMask = 0xFF00,
	PointerIndexShift = 8,
	PointerUp = 6,
	Scroll = 8,
	Up = 1
}
