using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using Android.OS;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Storage;

internal class FilePickerImplementation : IFilePicker
{
	public async Task<FileResult?> PickAsync(PickOptions? options = null)
	{
		return (await PlatformPickAsync(options))?.FirstOrDefault();
	}

	private async Task<IEnumerable<FileResult>> PlatformPickAsync(PickOptions options, bool allowMultiple = false)
	{
		string action = "android.intent.action.OPEN_DOCUMENT";
		Intent intent = new Intent(action);
		intent.SetType("*/*");
		intent.PutExtra("android.intent.extra.ALLOW_MULTIPLE", allowMultiple);
		string[] array = options?.FileTypes?.Value?.ToArray();
		if (array != null && array.Length != 0)
		{
			intent.PutExtra("android.intent.extra.MIME_TYPES", array);
		}
		Intent intent2 = Intent.CreateChooser(intent, options?.PickerTitle ?? "Select file");
		try
		{
			List<FileResult> resultList = new List<FileResult>();
			await IntermediateActivity.StartAsync(intent2, 11001, null, OnResult);
			return resultList;
			void OnResult(Intent intent3)
			{
				bool requireExtendedAccess = !OperatingSystem.IsAndroidVersionAtLeast(30) || !global::Android.OS.Environment.IsExternalStorageManager;
				if (intent3.ClipData == null)
				{
					string fullPath = FileSystemUtils.EnsurePhysicalPath(intent3.Data, requireExtendedAccess);
					resultList.Add(new FileResult(fullPath));
				}
				else
				{
					for (int i = 0; i < intent3.ClipData.ItemCount; i++)
					{
						global::Android.Net.Uri uri = intent3.ClipData.GetItemAt(i).Uri;
						string fullPath2 = FileSystemUtils.EnsurePhysicalPath(uri, requireExtendedAccess);
						resultList.Add(new FileResult(fullPath2));
					}
				}
			}
		}
		catch (OperationCanceledException)
		{
			return null;
		}
	}
}
