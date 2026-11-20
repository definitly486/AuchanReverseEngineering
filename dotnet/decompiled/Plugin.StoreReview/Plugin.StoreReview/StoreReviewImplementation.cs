using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;
using Plugin.StoreReview.Abstractions;
using Xamarin.Google.Android.Play.Core.Review;
using Xamarin.Google.Android.Play.Core.Review.Testing;

namespace Plugin.StoreReview;

public class StoreReviewImplementation : Java.Lang.Object, IStoreReview, IOnCompleteListener, IJavaObject, IDisposable, IJavaPeerable
{
	private IReviewManager? manager;

	private TaskCompletionSource<bool>? tcs;

	private bool forceReturn;

	private Android.Gms.Tasks.Task? launchTask;

	private Activity Activity => Platform.CurrentActivity ?? throw new NullReferenceException("Current Activity is null, ensure that .NET MAUI is configured for Essentials.");

	public Task<bool> OpenStoreListing(string appId)
	{
		return OpenStoreReviewPage(appId);
	}

	private static Intent GetRateIntent(string url)
	{
		Intent intent = new Intent("android.intent.action.VIEW", Android.Net.Uri.Parse(url));
		intent.AddFlags(ActivityFlags.NoHistory);
		intent.AddFlags(ActivityFlags.MultipleTask);
		if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
		{
			intent.AddFlags(ActivityFlags.ClearWhenTaskReset);
		}
		else
		{
			intent.AddFlags(ActivityFlags.ClearWhenTaskReset);
		}
		intent.SetFlags(ActivityFlags.ClearTop);
		intent.SetFlags(ActivityFlags.NewTask);
		return intent;
	}

	public Task<bool> OpenStoreReviewPage(string appId)
	{
		string url = "market://details?id=" + appId;
		try
		{
			Intent rateIntent = GetRateIntent(url);
			Application.Context.StartActivity(rateIntent);
			return System.Threading.Tasks.Task.FromResult(result: true);
		}
		catch (System.Exception)
		{
		}
		url = "https://play.google.com/store/apps/details?id=" + appId;
		try
		{
			Intent rateIntent2 = GetRateIntent(url);
			Application.Context.StartActivity(rateIntent2);
			return System.Threading.Tasks.Task.FromResult(result: true);
		}
		catch (System.Exception)
		{
		}
		return System.Threading.Tasks.Task.FromResult(result: false);
	}

	public async Task<ReviewStatus> RequestReview(bool testMode)
	{
		tcs?.TrySetCanceled();
		tcs = new TaskCompletionSource<bool>();
		if (testMode)
		{
			manager = new FakeReviewManager(Application.Context);
		}
		else
		{
			manager = ReviewManagerFactory.Create(Application.Context);
		}
		forceReturn = false;
		Android.Gms.Tasks.Task request = manager.RequestReviewFlow();
		request.AddOnCompleteListener(this);
		bool num = await tcs.Task;
		manager.Dispose();
		request.Dispose();
		return (!num) ? ReviewStatus.Error : ReviewStatus.Succeeded;
	}

	public void OnComplete(Android.Gms.Tasks.Task task)
	{
		if (!task.IsSuccessful || forceReturn)
		{
			tcs?.TrySetResult(forceReturn);
			launchTask?.Dispose();
			return;
		}
		try
		{
			if (!(task.GetResult(Java.Lang.Class.FromType(typeof(ReviewInfo))) is ReviewInfo p))
			{
				tcs?.TrySetResult(result: false);
				return;
			}
			forceReturn = true;
			launchTask = manager?.LaunchReviewFlow(Activity, p);
			launchTask?.AddOnCompleteListener(this);
		}
		catch (System.Exception)
		{
			tcs?.TrySetResult(result: false);
		}
	}
}
