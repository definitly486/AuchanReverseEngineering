using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NLog.Internal;

[ExcludeFromCodeCoverage]
internal static class PlatformDetector
{
	private static PlatformSystem? _currentOS;

	public static PlatformSystem CurrentOS
	{
		get
		{
			PlatformSystem? currentOS = _currentOS;
			if (!currentOS.HasValue)
			{
				PlatformSystem? platformSystem = (_currentOS = GetCurrentRuntimeOS());
				return platformSystem.Value;
			}
			return currentOS.GetValueOrDefault();
		}
	}

	public static bool IsWin32
	{
		get
		{
			if (CurrentOS != PlatformSystem.WindowsNT)
			{
				return CurrentOS == PlatformSystem.Windows9x;
			}
			return true;
		}
	}

	public static bool IsUnix
	{
		get
		{
			if (CurrentOS != PlatformSystem.Linux)
			{
				return CurrentOS == PlatformSystem.MacOSX;
			}
			return true;
		}
	}

	private static PlatformSystem GetCurrentRuntimeOS()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			return PlatformSystem.Linux;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return PlatformSystem.MacOSX;
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return PlatformSystem.WindowsNT;
		}
		return PlatformSystem.Unknown;
	}
}
