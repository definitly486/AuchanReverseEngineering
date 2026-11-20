using System;
using System.Runtime.InteropServices;

namespace Android.Runtime;

internal static class Logger
{
	private static bool hasNoLibLog;

	internal static LogCategories Categories;

	internal static bool LogAssembly => (Categories & LogCategories.Assembly) != 0;

	internal static bool LogDebugger => (Categories & LogCategories.Debugger) != 0;

	internal static bool LogGC => (Categories & LogCategories.GC) != 0;

	internal static bool LogGlobalRef => (Categories & LogCategories.GlobalRef) != 0;

	internal static bool LogLocalRef => (Categories & LogCategories.LocalRef) != 0;

	internal static bool LogTiming => (Categories & LogCategories.Timing) != 0;

	internal static bool LogBundle => (Categories & LogCategories.Bundle) != 0;

	internal static bool LogNet => (Categories & LogCategories.Net) != 0;

	internal static bool LogNetlink => (Categories & LogCategories.Netlink) != 0;

	[DllImport("liblog")]
	private static extern void __android_log_print(LogLevel level, string appname, string format, string args, nint zero);

	public static void Log(LogLevel level, string appname, string? log)
	{
		string[] array = (log ?? "").Split(new string[1] { "\n" }, StringSplitOptions.None);
		foreach (string args in array)
		{
			if (!hasNoLibLog)
			{
				try
				{
					__android_log_print(level, appname, "%s", args, IntPtr.Zero);
				}
				catch (DllNotFoundException)
				{
					hasNoLibLog = true;
				}
			}
		}
	}

	internal static void SetLogCategories(LogCategories categories)
	{
		Categories = categories;
	}
}
