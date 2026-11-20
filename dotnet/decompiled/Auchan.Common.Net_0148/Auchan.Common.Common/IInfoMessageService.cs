using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AppConfigError;
using Auchan.Common.Vpn;

namespace Auchan.Common.Common;

public interface IInfoMessageService
{
	void ShowCommonError(FullscreenErrorType errorType = FullscreenErrorType.Retry, bool closeable = true, Action? onNext = null);

	void ShowBlockedAccountError();

	void ShowVerticalSnackbar(string message, SnackbarStyle style = SnackbarStyle.Error, int seconds = 2)
	{
		ShowVerticalSnackbar(message, TimeSpan.FromSeconds(2L), style);
	}

	void ShowVerticalSnackbar(string message, TimeSpan duration, SnackbarStyle style = SnackbarStyle.Error);

	void ShowSnackbar(string message, SnackbarStyle style = SnackbarStyle.Error, int seconds = 2)
	{
		ShowSnackbar(message, TimeSpan.FromSeconds(seconds), style);
	}

	void ShowSnackbar(string message, TimeSpan duration, SnackbarStyle style = SnackbarStyle.Error);

	void ShowNotImplementedMessage();

	void ShowAlert(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken), bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = false);

	Task<AlertButton?> ShowAlertAsync(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken), bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = true);

	Task<(AlertButton? alertButton, string textfieldText)> ShowTextFieldAlertAsync(string title, string message, AlertButton[] alertButtons, CancellationToken token = default(CancellationToken));

	Task<AlertButton?> ShowActionSheetButtonsAsync(AlertButton[] alertButtons, CancellationToken token = default(CancellationToken));

	void ShowMaintenanceScreen(MaintenanceViewModel.Parameter parameter);

	Task ShowVpnScreenAsync(VpnViewModel.Parameter parameter);

	Task<AlertButton?> ShowDialogAsync(string title, string message, AlertButton[] alertButtons, bool isCanceledOnTouchOutside = true, bool isCanceledOnBack = true);

	void ShowHomePage();
}
