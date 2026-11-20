using System;

namespace Android.Views;

[Flags]
public enum SoftInput
{
	AdjustNothing = 0x30,
	AdjustPan = 0x20,
	AdjustResize = 0x10,
	AdjustUnspecified = 0,
	IsForwardNavigation = 0x100,
	MaskAdjust = 0xF0,
	MaskState = 0xF,
	StateAlwaysHidden = 3,
	StateAlwaysVisible = 5,
	StateHidden = 2,
	StateUnchanged = 1,
	StateUnspecified = 0,
	StateVisible = 4
}
