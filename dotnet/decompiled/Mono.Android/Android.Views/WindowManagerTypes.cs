using System.Runtime.Versioning;

namespace Android.Views;

public enum WindowManagerTypes
{
	[SupportedOSPlatform("android22.0")]
	AccessibilityOverlay = 2032,
	Application = 2,
	ApplicationAttachedDialog = 1003,
	ApplicationMedia = 1001,
	[SupportedOSPlatform("android26.0")]
	ApplicationOverlay = 2038,
	ApplicationPanel = 1000,
	ApplicationStarting = 3,
	ApplicationSubPanel = 1002,
	BaseApplication = 1,
	[SupportedOSPlatform("android25.0")]
	DrawnApplication = 4,
	InputMethod = 2011,
	InputMethodDialog = 2012,
	Keyguard = 2004,
	KeyguardDialog = 2009,
	Phone = 2002,
	PriorityPhone = 2007,
	PrivatePresentation = 2030,
	SearchBar = 2001,
	StatusBar = 2000,
	StatusBarPanel = 2014,
	SystemAlert = 2003,
	SystemDialog = 2008,
	SystemError = 2010,
	SystemOverlay = 2006,
	Toast = 2005,
	Wallpaper = 2013
}
