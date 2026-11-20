namespace System.IO;

internal static class DriveInfoInternal
{
	internal static string[] GetLogicalDrives()
	{
		return Interop.Sys.GetAllMountPoints();
	}
}
