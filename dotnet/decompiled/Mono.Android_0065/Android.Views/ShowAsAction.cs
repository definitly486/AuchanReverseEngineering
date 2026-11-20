using System;

namespace Android.Views;

[Flags]
public enum ShowAsAction
{
	Always = 2,
	CollapseActionView = 8,
	IfRoom = 1,
	Never = 0,
	WithText = 4
}
