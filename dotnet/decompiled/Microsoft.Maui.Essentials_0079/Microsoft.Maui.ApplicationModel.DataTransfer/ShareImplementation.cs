using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Microsoft.Maui.Storage;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

internal class ShareImplementation : IShare
{
	public Task RequestAsync(ShareTextRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (string.IsNullOrEmpty(request.Text) && string.IsNullOrEmpty(request.Uri))
		{
			throw new ArgumentException("Both the Text and Uri are invalid. Make sure to include at least one of them in the request.");
		}
		return PlatformRequestAsync(request);
	}

	public Task RequestAsync(ShareFileRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (request.File == null)
		{
			throw new ArgumentException(FileNullException("File"));
		}
		return PlatformRequestAsync(request);
	}

	private static string FileNullException(string file)
	{
		return "The " + file + " parameter in the request files is invalid";
	}

	private Task PlatformRequestAsync(ShareTextRequest request)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(request.Text))
		{
			list.Add(request.Text);
		}
		if (!string.IsNullOrWhiteSpace(request.Uri))
		{
			list.Add(request.Uri);
		}
		Intent intent = new Intent("android.intent.action.SEND");
		intent.SetType("text/plain");
		intent.PutExtra("android.intent.extra.TEXT", string.Join("\n", list));
		if (!string.IsNullOrWhiteSpace(request.Subject))
		{
			intent.PutExtra("android.intent.extra.SUBJECT", request.Subject);
		}
		Intent intent2 = Intent.CreateChooser(intent, request.Title ?? string.Empty);
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent2.SetFlags(flags);
		Application.Context.StartActivity(intent2);
		return Task.CompletedTask;
	}

	private Task PlatformRequestAsync(ShareFileRequest request)
	{
		return PlatformRequestAsync((ShareMultipleFilesRequest)request);
	}

	private Task PlatformRequestAsync(ShareMultipleFilesRequest request)
	{
		List<IParcelable> list = new List<IParcelable>(request.Files.Count);
		string text = null;
		foreach (ShareFile file in request.Files)
		{
			list.Add(FileSystemUtils.GetShareableFileUri(file));
			if (text == null)
			{
				text = file.ContentType;
			}
			else if (text != file.ContentType)
			{
				text = "*/*";
			}
		}
		string action = ((list.Count > 1) ? "android.intent.action.SEND_MULTIPLE" : "android.intent.action.SEND");
		Intent intent = new Intent(action);
		intent.SetType(text);
		intent.SetFlags(ActivityFlags.GrantReadUriPermission);
		if (list.Count > 1)
		{
			intent.PutParcelableArrayListExtra("android.intent.extra.STREAM", list);
		}
		else if (list.Count == 1)
		{
			intent.PutExtra("android.intent.extra.STREAM", list[0]);
		}
		if (!string.IsNullOrEmpty(request.Title))
		{
			intent.PutExtra("android.intent.extra.TITLE", request.Title);
		}
		Intent intent2 = Intent.CreateChooser(intent, request.Title ?? string.Empty);
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent2.SetFlags(flags);
		Application.Context.StartActivity(intent2);
		return Task.CompletedTask;
	}
}
