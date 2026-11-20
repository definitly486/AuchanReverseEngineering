using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.Maintenance;
using Auchan.Android.Utils;
using Auchan.Android.Vpn;
using Auchan.Common.AppConfigError;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Vpn;
using Java.Interop;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

public class DroidInfoMessageService : Java.Lang.Object, IInfoMessageService, IDialogInterfaceOnShowListener, IJavaObject, IDisposable, IJavaPeerable, IViewModelStateObserver
{
	private readonly WeakReference<ViewGroup> _activeView = new WeakReference<ViewGroup>(null);

	public void OnViewModelResumed(ScreenViewModel vm)
	{
		ViewGroup nativeView = vm.GetNativeView<ViewGroup>();
		_activeView.SetTarget(nativeView);
	}

	public void ShowCommonError(FullscreenErrorType errorType = FullscreenErrorType.Retry, bool closeable = true, Action? onNext = null)
	{
		AppCompatActivity activity = Platform.CurrentActivity as AppCompatActivity;
		if (activity != null)
		{
			activity.RunOnUiThread(delegate
			{
				ErrorFullscreenDialogFragment errorFullscreenDialogFragment = activity.SupportFragmentManager.FragmentFactory.Instantiate(activity.ClassLoader, Java.Lang.Class.FromType(typeof(ErrorFullscreenDialogFragment)).Name) as ErrorFullscreenDialogFragment;
				errorFullscreenDialogFragment.Arguments = new ErrorFullscreenViewModel.Parameter(errorType, closeable).ToNavBundle();
				errorFullscreenDialogFragment.Show(activity.SupportFragmentManager, errorFullscreenDialogFragment.Tag);
			});
		}
	}

	public void ShowBlockedAccountError()
	{
		AppCompatActivity activity = Platform.CurrentActivity as AppCompatActivity;
		if (activity != null)
		{
			activity.RunOnUiThread(delegate
			{
				(activity.SupportFragmentManager.FragmentFactory.Instantiate(activity.ClassLoader, Java.Lang.Class.FromType(typeof(BlockedAccountFragment)).Name) as BlockedAccountFragment)?.Show(activity.SupportFragmentManager, null);
			});
		}
	}

	public void ShowNotImplementedMessage()
	{
		ShowSnackbar("Будет доступно в следующем обновлении", TimeSpan.FromSeconds(2L), SnackbarStyle.None);
	}

	public void ShowVerticalSnackbar(string message, TimeSpan duration, SnackbarStyle style = SnackbarStyle.Error)
	{
		ShowSnackbar(message, duration, style);
	}

	public void ShowSnackbar(string message, TimeSpan duration, SnackbarStyle style = SnackbarStyle.Error)
	{
		MainThread.BeginInvokeOnMainThread(delegate
		{
			if (_activeView.TryGetTarget(out ViewGroup target))
			{
				AuchanSnackbar auchanSnackbar = AuchanSnackbar.Make(target, message, style, this);
				if (duration != default(TimeSpan))
				{
					auchanSnackbar.SetDuration(duration);
				}
				auchanSnackbar.Show();
			}
		});
	}

	public void ShowAlert(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken), bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = false)
	{
		Activity currentActivity = Platform.CurrentActivity;
		AppCompatActivity activity = currentActivity as AppCompatActivity;
		if (activity == null)
		{
			return;
		}
		activity.RunOnUiThread(delegate
		{
			AndroidX.AppCompat.App.AlertDialog.Builder builder = new AndroidX.AppCompat.App.AlertDialog.Builder(activity);
			builder.SetTitle(title).SetMessage(message);
			AlertButton[] array = alertButtons;
			foreach (AlertButton alertButton in array)
			{
				switch (alertButton.Type)
				{
				case ActionType.Positive:
					builder.SetPositiveButton(alertButton.Title, DecorateAlertButtonAction(alertButton.Action));
					break;
				case ActionType.Negative:
				case ActionType.Destructive:
					builder.SetNegativeButton(alertButton.Title, DecorateAlertButtonAction(alertButton.Action));
					break;
				}
			}
			AndroidX.AppCompat.App.AlertDialog alertDialog = builder.Create();
			alertDialog.SetCanceledOnTouchOutside(isCanceledOnTouchOutside);
			alertDialog.SetCancelable(isCanceledOnBack);
			alertDialog.ShowCentered();
			token.Register(alertDialog.Dismiss, useSynchronizationContext: true);
		});
	}

	public Task<AlertButton?> ShowAlertAsync(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken), bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = true)
	{
		if (alertButtons == null)
		{
			throw new ArgumentNullException("alertButtons");
		}
		Activity currentActivity = Platform.CurrentActivity;
		AppCompatActivity activity = currentActivity as AppCompatActivity;
		if (activity != null)
		{
			if (activity.IsFinishing)
			{
				return Task.FromResult<AlertButton>(null);
			}
			TaskCompletionSource<AlertButton?> tcs = new TaskCompletionSource<AlertButton>();
			activity.RunOnUiThread(delegate
			{
				AndroidX.AppCompat.App.AlertDialog.Builder builder = new AndroidX.AppCompat.App.AlertDialog.Builder(activity);
				TextView textView = new TextView(activity);
				textView.SetPaddingDp(25, 20, 25, 5);
				textView.SetTextColor(Color.Black);
				textView.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
				textView.SetTextSize(ComplexUnitType.Sp, 18f);
				textView.SetMaxLines(3);
				textView.SetText(title.ToCharArray(), 0, title.Length);
				builder.SetCustomTitle(textView).SetMessage(message);
				AlertButton[] array = alertButtons;
				foreach (AlertButton alertButton in array)
				{
					EventHandler<DialogClickEventArgs> handler = DecorateAlertButtonAction(delegate
					{
						alertButton.Action?.Invoke();
						tcs.TrySetResult(alertButton);
					});
					switch (alertButton.Type)
					{
					case ActionType.Positive:
						builder.SetPositiveButton(alertButton.Title, handler);
						break;
					case ActionType.Negative:
					case ActionType.Destructive:
						builder.SetNegativeButton(alertButton.Title, handler);
						break;
					}
				}
				DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
				{
					tcs.TrySetResult(null);
				});
				AndroidX.AppCompat.App.AlertDialog alertDialog = builder.Create();
				alertDialog.SetCanceledOnTouchOutside(isCanceledOnTouchOutside);
				alertDialog.SetCancelable(isCanceledOnBack);
				alertDialog.SetOnCancelListener(dialogInterfaceOnDismissListener);
				alertDialog.SetOnDismissListener(dialogInterfaceOnDismissListener);
				alertDialog.ShowCentered();
				token.Register(alertDialog.Dismiss, useSynchronizationContext: true);
			});
			return tcs.Task;
		}
		return Task.FromResult<AlertButton>(null);
	}

	public Task<(AlertButton? alertButton, string textfieldText)> ShowTextFieldAlertAsync(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken))
	{
		if (alertButtons == null)
		{
			throw new ArgumentNullException("alertButtons");
		}
		Activity currentActivity = Platform.CurrentActivity;
		AppCompatActivity activity = currentActivity as AppCompatActivity;
		if (activity != null)
		{
			TaskCompletionSource<(AlertButton? alertButton, string textfieldText)> tcs = new TaskCompletionSource<(AlertButton, string)>();
			activity.RunOnUiThread(delegate
			{
				AndroidX.AppCompat.App.AlertDialog.Builder builder = new AndroidX.AppCompat.App.AlertDialog.Builder(activity);
				EditText editText = new EditText(activity);
				editText.Hint = "Ваш e-mail";
				editText.SetSingleLine();
				FrameLayout frameLayout = new FrameLayout(activity);
				FrameLayout.LayoutParams layoutParameters = new FrameLayout.LayoutParams(-1, -2)
				{
					LeftMargin = Util.ConvertDpToPixels(20f),
					RightMargin = Util.ConvertDpToPixels(20f)
				};
				editText.LayoutParameters = layoutParameters;
				frameLayout.AddView(editText);
				builder.SetTitle(title).SetMessage(message).SetView(frameLayout);
				AlertButton[] array = alertButtons;
				foreach (AlertButton alertButton in array)
				{
					EventHandler<DialogClickEventArgs> handler = DecorateAlertButtonAction(delegate
					{
						alertButton.Action?.Invoke();
						tcs.TrySetResult((alertButton, editText.Text ?? string.Empty));
					});
					switch (alertButton.Type)
					{
					case ActionType.Positive:
						builder.SetPositiveButton(alertButton.Title, handler);
						break;
					case ActionType.Negative:
					case ActionType.Destructive:
						builder.SetNegativeButton(alertButton.Title, handler);
						break;
					}
				}
				DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
				{
					tcs.TrySetResult((null, string.Empty));
				});
				AndroidX.AppCompat.App.AlertDialog alertDialog = builder.Create();
				alertDialog.SetOnCancelListener(dialogInterfaceOnDismissListener);
				alertDialog.SetOnDismissListener(dialogInterfaceOnDismissListener);
				alertDialog.ShowCentered();
				token.Register(alertDialog.Dismiss, useSynchronizationContext: true);
			});
			return tcs.Task;
		}
		return Task.FromResult<(AlertButton, string)>((null, string.Empty));
	}

	public Task<AlertButton?> ShowActionSheetButtonsAsync(AlertButton[] alertButtons, CancellationToken token = default(CancellationToken))
	{
		throw new NotImplementedException();
	}

	public void ShowMaintenanceScreen(MaintenanceViewModel.Parameter parameter)
	{
		AppCompatActivity activity = Platform.CurrentActivity as AppCompatActivity;
		if (activity == null)
		{
			return;
		}
		Task.Run(async delegate
		{
			await Task.Delay(500);
			activity.RunOnUiThread(delegate
			{
				try
				{
					MaintenanceDialogFragment maintenanceDialogFragment = activity.SupportFragmentManager.FragmentFactory.Instantiate(activity.ClassLoader, Java.Lang.Class.FromType(typeof(MaintenanceDialogFragment)).Name) as MaintenanceDialogFragment;
					maintenanceDialogFragment.Arguments = parameter.ToNavBundle();
					maintenanceDialogFragment.Show(activity.SupportFragmentManager, maintenanceDialogFragment.Tag);
				}
				catch
				{
				}
			});
		}).SafeFireAndForget((Action<System.Exception>)null, false);
	}

	public async Task ShowVpnScreenAsync(VpnViewModel.Parameter parameter)
	{
		AppCompatActivity activity = (AppCompatActivity)(await Platform.WaitForActivityAsync());
		await MainThread.InvokeOnMainThreadAsync(() => ShowVpnDialogFragmentAsync());
		async Task ShowVpnDialogFragmentAsync()
		{
			VpnDialogFragment vpnDialogFragment = (await activity.GetSupportFragmentManagerAsync()).FragmentFactory.Instantiate(activity.ClassLoader, Java.Lang.Class.FromType(typeof(VpnDialogFragment)).Name) as VpnDialogFragment;
			vpnDialogFragment.Arguments = parameter.ToNavBundle();
			vpnDialogFragment.Show(activity.SupportFragmentManager, vpnDialogFragment.Tag);
		}
	}

	public void OnShow(IDialogInterface? dialog)
	{
		(dialog as AndroidX.AppCompat.App.AlertDialog)?.GetButton(-2)?.SetAllCaps(allCaps: false);
	}

	private EventHandler<DialogClickEventArgs> DecorateAlertButtonAction(Action? action)
	{
		return delegate(object? s, DialogClickEventArgs e)
		{
			action?.Invoke();
			(s as IDialogInterface)?.Dismiss();
		};
	}

	public Task<AlertButton?> ShowDialogAsync(string title, string message, AlertButton[] alertButtons, bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = true)
	{
		bool isCanceledOnTouchOutside2 = isCanceledOnTouchOutside;
		bool isCanceledOnBack2 = isCanceledOnBack;
		return ShowAlertAsync(title, message, alertButtons, default(CancellationToken), isCanceledOnTouchOutside2, isCanceledOnBack2);
	}

	public void ShowHomePage()
	{
		if (Platform.CurrentActivity is LoginActivity loginActivity)
		{
			loginActivity.ProceedSuccessfulLogin();
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
