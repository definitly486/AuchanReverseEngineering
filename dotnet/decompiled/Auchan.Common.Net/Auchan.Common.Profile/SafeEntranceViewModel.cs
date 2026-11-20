using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SafeEntrance.Enums;
using Auchan.Common.SafeEntrance.Managers;

namespace Auchan.Common.Profile;

public class SafeEntranceViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _navigateToCreateBiometry = new Subject<Unit>();

	private readonly ISafeEntranceManager _safeEntranceManager;

	private readonly ISafeEntranceContext _safeEntranceContext;

	public string Title => "Безопасный вход";

	public string SafeEntranceText => "Вход по PIN-коду";

	public string ChangePinCodeText => "Изменить PIN-код";

	public string BiometrySafeEntrance => SetEnterWithBiometryText();

	public bool IsPinCodeCreated => _safeEntranceManager.IsPinCodeCreated;

	public bool IsBiometryCreated => _safeEntranceManager.IsBiometryCreated;

	public bool IsBiometryEnabledOnDevice => _safeEntranceManager.IsBiometryEnabledOnDevice;

	public bool IsBiometryPermissionDenied => _safeEntranceManager.PermissionDenied;

	public IObservable<Unit> NavigateToCreateBiometryCommand => _navigateToCreateBiometry.Debounce();

	public SafeEntranceViewModel(ISafeEntranceManager safeEntranceManager, ISafeEntranceContext safeEntranceContext)
	{
		_safeEntranceManager = safeEntranceManager;
		_safeEntranceContext = safeEntranceContext;
		SetEnterWithBiometryText();
	}

	protected override Task Start()
	{
		_safeEntranceContext.OnPropertyChanges((ISafeEntranceContext x) => x.IsPinCodeCreated).StartWith(_safeEntranceContext.IsPinCodeCreated).Subscribe(delegate
		{
			RaisePropertyChanged("IsPinCodeCreated");
			RaisePropertyChanged("IsBiometryEnabledOnDevice");
		})
			.AddTo(base.CloseDisposable);
		_safeEntranceContext.OnPropertyChanges((ISafeEntranceContext x) => x.IsBiometryCreated).StartWith(_safeEntranceContext.IsBiometryCreated).Subscribe(delegate
		{
			RaisePropertyChanged("IsBiometryCreated");
		})
			.AddTo(base.CloseDisposable);
		return Task.FromResult(result: true);
	}

	public void OnNavigateToUpdatePinCodeClick()
	{
		_navigateToCreateBiometry.OnNext(Unit.Default);
	}

	public void ToggleSafeEntrance(bool isEnabled)
	{
		if (isEnabled != IsPinCodeCreated)
		{
			if (isEnabled)
			{
				_navigateToCreateBiometry.OnNext(Unit.Default);
			}
			else
			{
				_safeEntranceManager.RemovePinCode();
			}
		}
	}

	public async Task ToggleEnterWithBiometry(bool isEnabled)
	{
		if (isEnabled != IsBiometryCreated || IsBiometryPermissionDenied)
		{
			if (isEnabled && IsBiometryEnabledOnDevice)
			{
				await _safeEntranceManager.CreateBiometryAsync();
			}
			else
			{
				_safeEntranceManager.RemoveBiometry();
			}
			RaisePropertyChanged("IsBiometryCreated");
		}
	}

	private string SetEnterWithBiometryText()
	{
		string result = string.Empty;
		switch (_safeEntranceManager.GetCurrentDeviceBiometryType())
		{
		case BiometryTypes.Touch:
			result = "Вход по Touch ID";
			break;
		case BiometryTypes.Face:
		case BiometryTypes.NotGrantedFaceId:
			result = "Вход по Face ID";
			break;
		case BiometryTypes.Other:
			result = "Вход по биометрии";
			break;
		}
		return result;
	}
}
