using System.Threading.Tasks;
using Auchan.Common.SafeEntrance.Managers;

namespace Auchan.Common.SafeEntrance.ViewModels;

public class EnterBiometryViewModel : BaseBiometryViewModel
{
	private readonly ISafeEntranceManager _safeEntranceManager;

	private bool _runBiometryAtStart = true;

	public override string Title => "Введите PIN-код";

	public override string Subtitle => "Введите PIN-код для входа в приложение";

	public override string EnteredWrongPinCode => $"PIN-код введен неверно. \nОстал{((_safeEntranceManager.NumberOfPinCodeReEnters == 1) ? "а" : "о")}сь {_safeEntranceManager.NumberOfPinCodeReEnters} попытк{((_safeEntranceManager.NumberOfPinCodeReEnters == 1) ? "а" : "и")}";

	public string ForgotPinCode => "Забыли код?";

	public bool IsEntranceWithBiometry => _safeEntranceManager.CanEnterWithBiometry();

	public EnterBiometryViewModel(ISafeEntranceManager safeEntranceManager)
	{
		_safeEntranceManager = safeEntranceManager;
	}

	public async void OnShowBiometricLoginClick()
	{
		if (await _safeEntranceManager.ProcceedWithBiometryAsync())
		{
			Close();
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (_runBiometryAtStart && IsEntranceWithBiometry)
		{
			_runBiometryAtStart = false;
			if (await _safeEntranceManager.ProcceedWithBiometryAsync())
			{
				Close();
			}
		}
	}

	public async Task ForgotPinCodeClick()
	{
		await _safeEntranceManager.ForgotPinCodeAsync();
		_safeEntranceManager.MarkAuthIsNeeded();
	}

	protected override async Task ProcceedWithEnteredPinCodeAsync(string pinCode)
	{
		bool flag = await _safeEntranceManager.ValidateEnteredPinCodeAsync(pinCode);
		if (!flag && _safeEntranceManager.NumberOfPinCodeReEnters == 3)
		{
			_safeEntranceManager.MarkAuthIsNeeded();
		}
		else if (flag)
		{
			base.IsWrongPinCodeEntered = false;
			Close();
		}
		else
		{
			await WrongPinCodeEntered();
		}
	}
}
