using System;

namespace Android.Views;

[Flags]
public enum MenuPerformFlags
{
	None = 0,
	AlwaysPerformClose = 2,
	PerformNoClose = 1
}
