using System;

namespace Android.Views.Accessibility;

[Flags]
public enum Action
{
	AccessibilityFocus = 0x40,
	ClearAccessibilityFocus = 0x80,
	ClearFocus = 2,
	ClearSelection = 8,
	Click = 0x10,
	Collapse = 0x80000,
	Copy = 0x4000,
	Cut = 0x10000,
	Dismiss = 0x100000,
	Expand = 0x40000,
	Focus = 1,
	LongClick = 0x20,
	NextAtMovementGranularity = 0x100,
	NextHtmlElement = 0x400,
	Paste = 0x8000,
	PreviousAtMovementGranularity = 0x200,
	PreviousHtmlElement = 0x800,
	ScrollBackward = 0x2000,
	ScrollForward = 0x1000,
	Select = 4,
	SetSelection = 0x20000,
	SetText = 0x200000
}
