using System;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.SafeEntrance.Enums;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices;

namespace Auchan.Common.SafeEntrance.Managers;

public class SafeEntranceManager : ISafeEntranceManager, INotifyPropertyChanged
{
	private const int DelayForEntranceInMinutes = 10;

	private readonly ISafeEntranceContext _safeEntranceContext;

	private readonly IUserContext _userContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IBiometryManager _biometryManager;

	private readonly ILogoutService _logoutService;

	private readonly LogoutInteractor _logoutInteractor;

	private bool _isAuthNeeded;

	[CompilerGenerated]
	private int _003CNumberOfPinCodeReEnters_003Ek__BackingField;

	public int NumberOfPinCodeReEnters
	{
		[CompilerGenerated]
		get
		{
			return _003CNumberOfPinCodeReEnters_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CNumberOfPinCodeReEnters_003Ek__BackingField != value)
			{
				_003CNumberOfPinCodeReEnters_003Ek__BackingField = value;
				OnPropertyChanged("NumberOfPinCodeReEnters");
			}
		}
	} = 3;

	public bool IsPinCodeCreated => _safeEntranceContext.IsPinCodeCreated;

	public bool IsBiometryCreated => _safeEntranceContext.IsBiometryCreated;

	public bool IsBiometryEnabledOnDevice
	{
		get
		{
			if (_biometryManager.CanAuthenticate() != BiometryTypes.None)
			{
				return IsPinCodeCreated;
			}
			return false;
		}
	}

	public bool PermissionDenied => _biometryManager.CanAuthenticate() == BiometryTypes.NotGrantedFaceId;

	public event PropertyChangedEventHandler? PropertyChanged;

	public SafeEntranceManager(ISafeEntranceContext safeEntranceContext, IInfoMessageService infoMessageService, IUserContext userContext, IBiometryManager biometryManager, ILogoutService logoutService, LogoutInteractor logoutInteractor)
	{
		_safeEntranceContext = safeEntranceContext;
		_userContext = userContext;
		_infoMessageService = infoMessageService;
		_biometryManager = biometryManager;
		_logoutService = logoutService;
		_logoutInteractor = logoutInteractor;
	}

	public void MarkAuthIsNeeded()
	{
		_isAuthNeeded = true;
	}

	public bool GetAuthIsNeededAndReset()
	{
		bool isAuthNeeded = _isAuthNeeded;
		_isAuthNeeded = false;
		return isAuthNeeded;
	}

	public async Task CreatePinCodeAsync(string pinCode)
	{
		if (!_safeEntranceContext.IsPinCodeCreated)
		{
			_safeEntranceContext.PinCode = pinCode;
			_safeEntranceContext.IsPinCodeCreated = true;
			await _infoMessageService.ShowDialogAsync("PIN-код сохранен!", "Используйте его для дальнейшего входа в приложение", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "ОК",
					Type = ActionType.Positive
				}
			});
		}
	}

	public async Task ForgotPinCodeAsync()
	{
		await RemovePinCodeAndLogout();
	}

	public async Task RemovePinCodeAndLogout()
	{
		RemovePinCode();
		if (ProcessLogoutResult(await _logoutInteractor.Logout()))
		{
			await _logoutService.LogoutAsync();
		}
	}

	public void RemovePinCode()
	{
		_safeEntranceContext.PinCode = string.Empty;
		_safeEntranceContext.IsPinCodeCreated = false;
		RemoveBiometry();
	}

	public async Task<bool> ValidateEnteredPinCodeAsync(string pinCode)
	{
		if (_safeEntranceContext.PinCode == pinCode)
		{
			return true;
		}
		Vibration.Vibrate();
		if (NumberOfPinCodeReEnters > 0)
		{
			NumberOfPinCodeReEnters--;
		}
		if (NumberOfPinCodeReEnters == 0)
		{
			await _infoMessageService.ShowDialogAsync("Внимание", "Вы исчерпали попытки ввода PIN-кода. Необходимо авторизоваться", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Закрыть",
					Type = ActionType.Positive
				}
			});
			await RemovePinCodeAndLogout();
			NumberOfPinCodeReEnters = 3;
		}
		return false;
	}

	public bool ShouldShowEnterPinCode()
	{
		TimeSpan timeSpan = DateTime.Now - _safeEntranceContext.UserEnteredBackground;
		if (_safeEntranceContext.IsUserEnteredForeground && timeSpan.TotalMinutes > 10.0 && _userContext.Authorized && _safeEntranceContext.IsPinCodeCreated)
		{
			return true;
		}
		return false;
	}

	public void MarkForegroundTransitionForSafeEntrance()
	{
		_safeEntranceContext.IsUserEnteredForeground = true;
	}

	public void MarkBackgroundTransitionForSafeEntrance()
	{
		_safeEntranceContext.IsUserEnteredForeground = false;
		_safeEntranceContext.UserEnteredBackground = DateTime.Now;
	}

	public BiometryTypes GetCurrentDeviceBiometryType()
	{
		return _biometryManager.CanAuthenticate();
	}

	public async Task CreateBiometryAsync()
	{
		BiometryTypes biometryTypes = _biometryManager.CanAuthenticate();
		_safeEntranceContext.BiometryType = (int)biometryTypes;
		switch (biometryTypes)
		{
		case BiometryTypes.Touch:
			await CreateBiometryForTouch();
			break;
		case BiometryTypes.Face:
			await CreateBiometryForFace();
			break;
		case BiometryTypes.Other:
			await CreateBiometryForGenericType();
			break;
		case BiometryTypes.NotGrantedFaceId:
			await CreateBiometryFromSettings();
			break;
		case BiometryTypes.None:
			break;
		}
	}

	public Task<bool> ProcceedWithBiometryAsync()
	{
		return _biometryManager.AuthenticateAsync();
	}

	public void RemoveBiometry()
	{
		_safeEntranceContext.IsBiometryCreated = false;
		_safeEntranceContext.BiometryType = 3;
	}

	public bool CanEnterWithBiometry()
	{
		BiometryTypes biometryTypes = _biometryManager.CanAuthenticate();
		_safeEntranceContext.BiometryType = (int)biometryTypes;
		if (biometryTypes != BiometryTypes.None)
		{
			return IsBiometryCreated;
		}
		return false;
	}

	private async Task CreateBiometryForTouch()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync("Доступен Touch ID", "Использовать отпечаток пальца для входа в приложение?", AlertButtons.YesNo);
		if ((object)obj != null && obj.Type == ActionType.Positive)
		{
			await _infoMessageService.ShowDialogAsync("Touch ID установлен", "Теперь вы можете использовать отпечаток пальца для авторизации", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Продолжить"
				}
			});
			SetBiometry(isBiometricSet: true);
		}
		else
		{
			await _infoMessageService.ShowDialogAsync("Touch ID не установлен", "Разрешение не получено, повторите попытку", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "OK"
				}
			});
		}
	}

	private async Task CreateBiometryForFace()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync("Доступен Face ID", "Использовать распознавание лица для входа в приложение?", AlertButtons.YesNo);
		if ((object)obj != null && obj.Type == ActionType.Positive)
		{
			await _infoMessageService.ShowDialogAsync("Face ID установлен", "Теперь вы можете использовать распознавание лица для авторизации", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Продолжить"
				}
			});
			SetBiometry(isBiometricSet: true);
		}
		else
		{
			await _infoMessageService.ShowDialogAsync("Face ID не установлен", "Разрешение не получено, повторите попытку", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "OK"
				}
			});
		}
	}

	private async Task CreateBiometryForGenericType()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync("Доступна биометрия", "Использовать биометрию для входа в приложение?", AlertButtons.YesNo);
		if ((object)obj != null && obj.Type == ActionType.Positive)
		{
			await _infoMessageService.ShowDialogAsync("Биометрия установлена", "Теперь вы можете использовать биометрию для авторизации", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Продолжить",
					Type = ActionType.Positive
				}
			});
			SetBiometry(isBiometricSet: true);
		}
		else
		{
			await _infoMessageService.ShowDialogAsync("Биометрия не установлена", "Разрешение не получено, повторите попытку", new AlertButton[1]
			{
				new AlertButton
				{
					Title = "OK",
					Type = ActionType.Positive
				}
			});
		}
	}

	private void SetBiometry(bool isBiometricSet)
	{
		_safeEntranceContext.IsBiometryCreated = isBiometricSet;
	}

	private async Task CreateBiometryFromSettings()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync(string.Empty, "Пожалуйста, перейдите в настройки и разрешите приложению доступ к чтению биометрии", new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Настройки",
				Type = ActionType.Positive
			},
			new AlertButton
			{
				Title = "Отмена",
				Type = ActionType.Negative
			}
		});
		if ((object)obj != null && obj.Type == ActionType.Positive)
		{
			_biometryManager.OpenBiometrySettings();
		}
	}

	private bool ProcessLogoutResult(Result<Unit, DomainError> result)
	{
		if (result.IsFailure)
		{
			_infoMessageService.ShowCommonError();
			return false;
		}
		return true;
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
