using System;
using System.IO;

namespace NLog.Internal;

internal static class FileInfoExt
{
	public static DateTime GetLastWriteTimeUtc(this FileInfo fileInfo)
	{
		return fileInfo.LastWriteTimeUtc;
	}

	public static DateTime GetCreationTimeUtc(this FileInfo fileInfo)
	{
		return fileInfo.CreationTimeUtc;
	}

	public static DateTime LookupValidFileCreationTimeUtc(this FileInfo fileInfo)
	{
		return LookupValidFileCreationTimeUtc(fileInfo, (FileInfo f) => f.GetCreationTimeUtc(), (FileInfo f) => f.GetLastWriteTimeUtc()).Value;
	}

	public static DateTime LookupValidFileCreationTimeUtc(this FileInfo fileInfo, DateTime? fallbackTime)
	{
		if (fallbackTime > DateTime.MinValue)
		{
			return LookupValidFileCreationTimeUtc(fileInfo, (FileInfo f) => f.GetCreationTimeUtc(), (FileInfo f) => fallbackTime.Value, (FileInfo f) => f.GetLastWriteTimeUtc()).Value;
		}
		return fileInfo.LookupValidFileCreationTimeUtc();
	}

	internal static DateTime? LookupValidFileCreationTimeUtc<T>(T fileInfo, Func<T, DateTime?> primary, Func<T, DateTime?> fallback, Func<T, DateTime?> finalFallback = null)
	{
		DateTime? result = primary(fileInfo);
		if (result.HasValue && result.Value.Year < 1980 && !NLog.Internal.PlatformDetector.IsWin32)
		{
			result = fallback(fileInfo);
			if (finalFallback != null && (!result.HasValue || result.Value.Year < 1980))
			{
				result = finalFallback(fileInfo);
			}
		}
		return result;
	}
}
