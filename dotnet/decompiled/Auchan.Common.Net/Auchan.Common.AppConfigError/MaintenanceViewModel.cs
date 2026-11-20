using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Maintenance;
using Auchan.Common.PersonalCabinet;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.AppConfigError;

public class MaintenanceViewModel : ScreenViewModel
{
	public class Parameter
	{
	}

	private readonly Parameter _parameter;

	private readonly IMaintenanceManager _maintenanceManager;

	private readonly IUserContext _userContext;

	private readonly IAdminContext _adminContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly string _promocode;

	public UICommand OnCloseCommand { get; } = new UICommand();

	public UICommand OnQRCodeCommand { get; } = new UICommand();

	public MaintenanceType Status => _adminContext.AppConfig.MaintenanceStatus;

	public string Title { get; }

	public string Message { get; }

	public string ButtonText { get; }

	public string MaintenanceInfoText { get; }

	public bool IsMaintenanceInfoAvailable => !string.IsNullOrEmpty(MaintenanceInfoText);

	public bool IsQRCodeButtonVisible
	{
		get
		{
			if (_userContext.Authorized && _userContext.Profile != null)
			{
				return _adminContext.AppConfig.MaintenanceStatus != MaintenanceType.Warning;
			}
			return false;
		}
	}

	public string QRCodeButtonText => "Показать карту лояльности";

	public MaintenanceViewModel(Parameter parameter, IMaintenanceManager maintenanceManager, IUserContext userContext, IAdminContext adminContext, IInfoMessageService infoMessageService)
	{
		_parameter = parameter;
		_maintenanceManager = maintenanceManager;
		_userContext = userContext;
		_adminContext = adminContext;
		_infoMessageService = infoMessageService;
		Title = _adminContext.AppConfig.MaintenanceTitle;
		Message = _adminContext.AppConfig.MaintenanceMessage;
		ButtonText = _adminContext.AppConfig.MaintenanceButtonTitle;
		_promocode = _adminContext.AppConfig?.MaintenancePromocode ?? string.Empty;
		string text = _adminContext.AppConfig?.MaintenancePromocodeMessage ?? string.Empty;
		if (!string.IsNullOrEmpty(_promocode))
		{
			text = text.Replace(_promocode, "<b>" + _promocode + "</b>");
		}
		MaintenanceInfoText = text.Replace("\u2028", "<br/>").Replace("\n", "<br/>");
	}

	public void OnActionClick()
	{
		OnActionClickAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnQRCodeClick()
	{
		OnQRCodeCommand.Trigger();
	}

	public void OnInformerClick()
	{
		DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task DoAsync()
		{
			if (!string.IsNullOrEmpty(_promocode))
			{
				await Clipboard.SetTextAsync(_promocode);
				_infoMessageService.ShowAlert("Промокод", "скопирован в буфер обмена", AlertButtons.OkButtons);
			}
		}
	}

	private async Task OnActionClickAsync()
	{
		if (!(await _maintenanceManager.CheckMaintenance()))
		{
			OnCloseCommand.Trigger();
		}
	}
}
