using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Auchan.Common.Cashback.Wallet;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Cashback.Wallet;

public class WalletPassManager : IWalletPassManager
{
	public bool AddToWalletAvaliable => true;

	public Task<bool> AddPassAndroid(string addPassUrl)
	{
		Activity currentActivity = Platform.CurrentActivity;
		if (currentActivity == null || currentActivity.IsDestroyed)
		{
			return Task.FromResult(result: false);
		}
		currentActivity.StartActivity(new Intent("android.intent.action.VIEW", global::Android.Net.Uri.Parse(addPassUrl)));
		return Task.FromResult(result: true);
	}

	public Task<bool> AddPassiOS(Stream passFileStream)
	{
		throw new NotSupportedException("This API is not supported on Android");
	}

	public Task<bool> LoyaltyQrPassCheckiOS()
	{
		throw new NotSupportedException("This API is not supported on Android");
	}
}
