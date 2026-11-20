using System;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;
using Java.Net;
using Java.Util;

namespace Microsoft.Maui.ApplicationModel.Communication;

internal class PhoneDialerImplementation : IPhoneDialer
{
	public bool IsSupported
	{
		get
		{
			Intent intent = ResolveDialIntent("00000000000");
			return PlatformUtils.IsIntentSupported(intent);
		}
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

	public void Open(string number)
	{
		ValidateOpen(number);
		string empty = string.Empty;
		empty = ((!OperatingSystem.IsAndroidVersionAtLeast(24)) ? (PhoneNumberUtils.FormatNumber(number, Locale.Default.Country) ?? empty) : (PhoneNumberUtils.FormatNumber(number, Locale.GetDefault(Locale.Category.Format).Country) ?? empty));
		if (empty.Contains(',', StringComparison.Ordinal) || empty.Contains(';', StringComparison.Ordinal) || empty.Contains('#', StringComparison.Ordinal))
		{
			empty = URLEncoder.Encode(empty, "UTF-8") ?? empty;
		}
		Intent intent = ResolveDialIntent(empty);
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent.SetFlags(flags);
		Application.Context.StartActivity(intent);
	}

	private static Intent ResolveDialIntent(string number)
	{
		global::Android.Net.Uri uri = global::Android.Net.Uri.Parse("tel:" + number);
		return new Intent("android.intent.action.DIAL", uri);
	}
}
