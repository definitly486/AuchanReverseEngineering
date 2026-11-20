using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using AndroidX.Core.Content;
using Java.IO;

namespace Microsoft.Maui.Storage;

[ContentProvider(new string[] { "${applicationId}.fileProvider" }, Name = "microsoft.maui.essentials.fileProvider", Exported = false, GrantUriPermissions = true)]
[MetaData("android.support.FILE_PROVIDER_PATHS", Resource = "@xml/microsoft_maui_essentials_fileprovider_file_paths")]
public class FileProvider : AndroidX.Core.Content.FileProvider
{
	internal static bool AlwaysFailExternalMediaAccess { get; set; }

	public static FileProviderLocation TemporaryLocation { get; set; }

	internal static string Authority => Application.Context.PackageName + ".fileProvider";

	internal static File GetTemporaryRootDirectory()
	{
		if (TemporaryLocation == FileProviderLocation.Internal)
		{
			return Application.Context.CacheDir;
		}
		bool flag = TemporaryLocation == FileProviderLocation.External;
		bool flag2 = Application.Context.ExternalCacheDir != null && IsMediaMounted(Application.Context.ExternalCacheDir);
		if (AlwaysFailExternalMediaAccess)
		{
			flag2 = false;
		}
		if (flag && !flag2)
		{
			throw new InvalidOperationException("Unable to access the external storage, the media is not mounted.");
		}
		if (!flag2)
		{
			return Application.Context.CacheDir;
		}
		return Application.Context.ExternalCacheDir;
	}

	private static bool IsMediaMounted(File location)
	{
		return global::Android.OS.Environment.GetExternalStorageState(location) == "mounted";
	}

	internal static bool IsFileInPublicLocation(string filename)
	{
		File file = new File(filename);
		filename = file.CanonicalPath;
		List<string> list = new List<string>
		{
			Application.Context?.GetExternalFilesDir(null)?.CanonicalPath,
			Application.Context?.ExternalCacheDir?.CanonicalPath
		};
		if (OperatingSystem.IsAndroidVersionAtLeast(24))
		{
			list.Add(Application.Context?.CacheDir?.CanonicalPath);
		}
		foreach (string item in list)
		{
			if (!string.IsNullOrWhiteSpace(item))
			{
				string text = (filename.EndsWith(File.Separator) ? filename : (filename + File.Separator));
				if (text.StartsWith(item, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static global::Android.Net.Uri GetUriForFile(File file)
	{
		return AndroidX.Core.Content.FileProvider.GetUriForFile(Application.Context, Authority, file);
	}
}
