using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using AsyncAwaitBestPractices;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Authorization.Managers;

public class LoginManager : ILoginManager
{
	private TaskCompletionSource<bool> _tcs;

	private readonly SearchProductsManager _searchManager;

	public bool ShouldNavigateToProfile { get; set; }

	public LoginManager(SearchProductsManager searchManager)
	{
		_searchManager = searchManager;
	}

	public Task<bool> LoginAsync(bool displayOnboardings)
	{
		if (Platform.CurrentActivity is LoginActivity && _tcs != null)
		{
			return _tcs.Task;
		}
		_tcs = new TaskCompletionSource<bool>();
		if (Platform.CurrentActivity is MainNotAuthActivity mainNotAuthActivity)
		{
			Intent data = new Intent();
			mainNotAuthActivity.SetResult(Result.Ok, data);
			mainNotAuthActivity.Finish();
		}
		else
		{
			LoginActivityLaunchState state = (displayOnboardings ? LoginActivityLaunchState.Onboarding : LoginActivityLaunchState.Auth);
			Intent launchIntent = LoginActivity.GetLaunchIntent(Platform.CurrentActivity, state);
			launchIntent.AddFlags(ActivityFlags.ClearTop);
			launchIntent.AddFlags(ActivityFlags.NewTask);
			Activity? currentActivity = Platform.CurrentActivity;
			currentActivity.StartActivity(launchIntent);
			currentActivity.Finish();
		}
		DoResetSearchStateAsync().SafeFireAndForget((Action<Exception>)null, false);
		return _tcs.Task;
	}

	private async Task DoResetSearchStateAsync()
	{
		await Task.Delay(100);
		MainThread.BeginInvokeOnMainThread(delegate
		{
			_searchManager.ResetSearchState();
		});
	}

	public Task<bool> ProceedLoyaltyRolloutCardOptions()
	{
		_tcs = new TaskCompletionSource<bool>();
		Intent launchIntent = LoginActivity.GetLaunchIntent(Platform.CurrentActivity, LoginActivityLaunchState.LoyaltyRolloutCardOptions);
		Platform.CurrentActivity.StartActivity(launchIntent);
		return _tcs.Task;
	}

	public Task<bool> OpenCardBlocked()
	{
		_tcs = new TaskCompletionSource<bool>();
		Intent launchIntent = LoginActivity.GetLaunchIntent(Platform.CurrentActivity, LoginActivityLaunchState.LoyaltyCardBlocked);
		Platform.CurrentActivity.StartActivity(launchIntent);
		return _tcs.Task;
	}

	public void ProceedSuccessfulLogin()
	{
		_tcs.TrySetResult(result: true);
	}
}
