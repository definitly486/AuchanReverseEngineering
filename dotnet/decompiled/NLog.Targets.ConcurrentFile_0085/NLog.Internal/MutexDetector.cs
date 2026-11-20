using System;
using NLog.Common;
using NLog.Internal.FileAppenders;

namespace NLog.Internal;

internal static class MutexDetector
{
	private static bool? _supportsSharableMutex;

	public static bool SupportsSharableMutex
	{
		get
		{
			bool? supportsSharableMutex = _supportsSharableMutex;
			if (!supportsSharableMutex.HasValue)
			{
				bool? flag = (_supportsSharableMutex = ResolveSupportsSharableMutex());
				return flag.Value;
			}
			return supportsSharableMutex == true;
		}
	}

	private static bool ResolveSupportsSharableMutex()
	{
		try
		{
			BaseMutexFileAppender.ForceCreateSharableMutex("NLogMutexTester").Close();
			return true;
		}
		catch (Exception ex)
		{
			InternalLogger.Debug(ex, "Failed to create sharable mutex processes");
		}
		return false;
	}
}
