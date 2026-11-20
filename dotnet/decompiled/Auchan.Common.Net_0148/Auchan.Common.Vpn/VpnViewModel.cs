using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Vpn;

public class VpnViewModel : ScreenViewModel
{
	public class Parameter
	{
		public bool RestartAppOnActionButton { get; }

		public Parameter(bool restartAppOnActionButton = false)
		{
			RestartAppOnActionButton = restartAppOnActionButton;
		}
	}

	public enum VisualState
	{
		Default,
		InProgress
	}

	private readonly Parameter _parameter;

	private readonly IRestartService _restartService;

	private readonly IVpnChecker _vpnChecker;

	private readonly AppMetrica _appMetrica;

	private readonly Lazy<ILoyaltyCardManager> _loyaltyCardManager;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CQrCode_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public UICommand CloseCommand { get; } = new UICommand();

	public string Title => "Не удается загрузить приложение";

	public string Message => "Попробуйте отключить VPN или Wi-Fi и нажмите \"Обновить\"";

	public string ButtonText => "Обновить";

	public string QrCode
	{
		[CompilerGenerated]
		get
		{
			return _003CQrCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CQrCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQrCode_003Ek__BackingField = value;
				RaisePropertyChanged("IsQrCodeVisible");
				RaisePropertyChanged("QrCode");
			}
		}
	} = "";

	public bool IsQrCodeVisible => !string.IsNullOrEmpty(QrCode);

	public string QrCodeText => "Ваша карта лояльности";

	public VpnViewModel(Parameter parameter, IRestartService restartService, IVpnChecker vpnChecker, AppMetrica appMetrica, Lazy<ILoyaltyCardManager> loyaltyCardManager)
	{
		_parameter = parameter;
		_restartService = restartService;
		_vpnChecker = vpnChecker;
		_appMetrica = appMetrica;
		_loyaltyCardManager = loyaltyCardManager;
	}

	protected override async Task Start()
	{
		_appMetrica.TrackVpnFullscreen();
		await Task.WhenAll(base.Start(), LoadQrCode());
	}

	public void OnActionClick()
	{
		OnActionClickAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OnActionClickAsync()
	{
		State = VisualState.InProgress;
		if (await _vpnChecker.GetVpnState() == VpnState.Block)
		{
			State = VisualState.Default;
		}
		else if (_parameter.RestartAppOnActionButton)
		{
			_restartService.Restart();
			State = VisualState.Default;
		}
		else
		{
			CloseCommand.Trigger();
			State = VisualState.Default;
		}
	}

	private async Task LoadQrCode()
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.Value.GetLoyaltyCard(CancellationToken.None);
		if (result.IsSuccess)
		{
			QrCode = result.Value.QrCode ?? string.Empty;
		}
	}
}
