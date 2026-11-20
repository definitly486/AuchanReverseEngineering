using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("specialfolder")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public class SpecialFolderLayoutRenderer : LayoutRenderer
{
	[DefaultParameter]
	public Environment.SpecialFolder Folder { get; set; }

	public string File { get; set; } = string.Empty;

	public string Dir { get; set; } = string.Empty;

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		string value = PathHelpers.CombinePaths(GetFolderPath(Folder), Dir, File);
		builder.Append(value);
	}

	internal static string GetFolderPath(Environment.SpecialFolder folder)
	{
		try
		{
			string folderPath = Environment.GetFolderPath(folder);
			if (!string.IsNullOrEmpty(folderPath))
			{
				return folderPath;
			}
		}
		catch
		{
			string folderPathFromEnvironment = GetFolderPathFromEnvironment(folder);
			if (!string.IsNullOrEmpty(folderPathFromEnvironment))
			{
				return folderPathFromEnvironment;
			}
			throw;
		}
		return GetFolderPathFromEnvironment(folder);
	}

	private static string GetFolderPathFromEnvironment(Environment.SpecialFolder folder)
	{
		try
		{
			string folderWindowsEnvironmentVariable = GetFolderWindowsEnvironmentVariable(folder);
			if (string.IsNullOrEmpty(folderWindowsEnvironmentVariable))
			{
				return string.Empty;
			}
			if (!PlatformDetector.IsWin32)
			{
				return string.Empty;
			}
			return Environment.GetEnvironmentVariable(folderWindowsEnvironmentVariable) ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string GetFolderWindowsEnvironmentVariable(Environment.SpecialFolder folder)
	{
		return folder switch
		{
			Environment.SpecialFolder.CommonApplicationData => "COMMONAPPDATA", 
			Environment.SpecialFolder.LocalApplicationData => "LOCALAPPDATA", 
			Environment.SpecialFolder.ApplicationData => "APPDATA", 
			Environment.SpecialFolder.UserProfile => "USERPROFILE", 
			_ => string.Empty, 
		};
	}
}
