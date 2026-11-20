using System.Runtime.InteropServices;

namespace NLog.Internal;

internal static class PlatformDetector
{
	private static RuntimeOS? _currentOS;

	public static RuntimeOS CurrentOS
	{
		get
		{
			RuntimeOS? currentOS = _currentOS;
			if (!currentOS.HasValue)
			{
				RuntimeOS? runtimeOS = (_currentOS = GetCurrentRuntimeOS());
				return runtimeOS.Value;
			}
			return currentOS.GetValueOrDefault();
		}
	}

	public static bool IsWin32
	{
		get
		{
			if (CurrentOS != RuntimeOS.WindowsNT)
			{
				return CurrentOS == RuntimeOS.Windows9x;
			}
			return true;
		}
	}

	public static bool IsUnix
	{
		get
		{
			if (CurrentOS != RuntimeOS.Linux)
			{
				return CurrentOS == RuntimeOS.MacOSX;
			}
			return true;
		}
	}

	private static RuntimeOS GetCurrentRuntimeOS()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			return RuntimeOS.Linux;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return RuntimeOS.MacOSX;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return RuntimeOS.WindowsNT;
		}
		return RuntimeOS.Unknown;
	}
}
