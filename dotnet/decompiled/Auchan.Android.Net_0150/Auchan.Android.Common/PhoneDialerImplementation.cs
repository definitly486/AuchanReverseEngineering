using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Auchan.Android.Common;

internal sealed class PhoneDialerImplementation : IPhoneDialer
{
	private const string intentCheck = "00000000000";

	public bool IsSupported
	{
		get
		{
			Intent intent = ResolveDialIntent("00000000000");
			Context context = Application.Context;
			if (context != null)
			{
				PackageManager packageManager = context.PackageManager;
				if (packageManager != null)
				{
					return intent.ResolveActivity(packageManager) != null;
				}
			}
			return false;
		}
	}

	public void Open(string number)
	{
		ValidateOpen(number);
		Intent intent = ResolveDialIntent(number);
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent.SetFlags(flags);
		Application.Context.StartActivity(intent);
	}

	private static Intent ResolveDialIntent(string number)
	{
		global::Android.Net.Uri uri = global::Android.Net.Uri.Parse("tel:" + number);
		return new Intent("android.intent.action.DIAL", uri);
	}

	private void ValidateOpen(string number)
	{
		if (string.IsNullOrWhiteSpace(number))
		{
			throw new ArgumentNullException("number");
		}
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}
	}
}
