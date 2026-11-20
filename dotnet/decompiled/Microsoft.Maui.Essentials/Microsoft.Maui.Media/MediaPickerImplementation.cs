using System;
using System.Threading.Tasks;
using Android.Content;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;

namespace Microsoft.Maui.Media;

internal class MediaPickerImplementation : IMediaPicker
{
	public Task<FileResult> PickPhotoAsync(MediaPickerOptions options)
	{
		return PickAsync(options, photo: true);
	}

	public Task<FileResult> PickVideoAsync(MediaPickerOptions options)
	{
		return PickAsync(options, photo: false);
	}

	public async Task<FileResult> PickAsync(MediaPickerOptions options, bool photo)
	{
		Intent intent = new Intent("android.intent.action.GET_CONTENT");
		intent.SetType(photo ? "image/*" : "video/*");
		Intent intent2 = Intent.CreateChooser(intent, options?.Title);
		try
		{
			string path = null;
			await IntermediateActivity.StartAsync(intent2, 11002, null, OnResult);
			return new FileResult(path);
			void OnResult(Intent intent3)
			{
				path = FileSystemUtils.EnsurePhysicalPath(intent3.Data);
			}
		}
		catch (OperationCanceledException)
		{
			return null;
		}
	}
}
