using System;

namespace Android.Views;

[Flags]
public enum GravityFlags
{
	AxisClip = 8,
	AxisPullAfter = 4,
	AxisPullBefore = 2,
	AxisSpecified = 1,
	AxisXShift = 0,
	AxisYShift = 4,
	Bottom = 0x50,
	Center = 0x11,
	CenterHorizontal = 1,
	CenterVertical = 0x10,
	ClipHorizontal = 8,
	ClipVertical = 0x80,
	DisplayClipHorizontal = 0x1000000,
	DisplayClipVertical = 0x10000000,
	End = 0x800005,
	Fill = 0x77,
	FillHorizontal = 7,
	FillVertical = 0x70,
	HorizontalGravityMask = 7,
	Left = 3,
	NoGravity = 0,
	RelativeHorizontalGravityMask = 0x800007,
	RelativeLayoutDirection = 0x800000,
	Right = 5,
	Start = 0x800003,
	Top = 0x30,
	VerticalGravityMask = 0x70
}
