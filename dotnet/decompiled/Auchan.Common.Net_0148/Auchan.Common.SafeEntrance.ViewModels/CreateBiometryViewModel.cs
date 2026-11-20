using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.SafeEntrance.Managers;

namespace Auchan.Common.SafeEntrance.ViewModels;

public class CreateBiometryViewModel : BaseBiometryViewModel
{
	private readonly ISafeEntranceManager _safeEntranceManager;

	private string _tepmPinCode = string.Empty;

	[CompilerGenerated]
	private bool _003CIsReEnterPinCode_003Ek__BackingField;

	public bool IsReEnterPinCode
	{
		[CompilerGenerated]
		get
		{
			return _003CIsReEnterPinCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsReEnterPinCode_003Ek__BackingField != value)
			{
				_003CIsReEnterPinCode_003Ek__BackingField = value;
				RaisePropertyChanged("Subtitle");
				RaisePropertyChanged("Description");
				RaisePropertyChanged("IsReEnterPinCode");
			}
		}
	}

	public override string Title => "Создание PIN-кода";

	public override string Subtitle
	{
		get
		{
			if (!IsReEnterPinCode)
			{
				return "Придумайте PIN-код для входа в приложение \nи защиты ваших данных";
			}
			return "Введите PIN-код еще раз";
		}
	}

	public override string Description
	{
		get
		{
			if (!IsReEnterPinCode)
			{
				return "Запомните код \nи не сообщайте его никому";
			}
			return "Запомните код и используйте его \nдля дальнейшего входа в приложение";
		}
	}

	public override string EnteredWrongPinCode => "PIN-код не совпадает";

	public string ReEnterPinCodeText => "Введите PIN-код еще раз.";

	public string CloseString => "Закрыть";

	public CreateBiometryViewModel(ISafeEntranceManager safeEntranceManager)
	{
		_safeEntranceManager = safeEntranceManager;
		TabBarVisible = false;
	}

	protected override Task Start()
	{
		_safeEntranceManager.RemovePinCode();
		return Task.FromResult(result: true);
	}

	protected override async Task ProcceedWithEnteredPinCodeAsync(string pinCode)
	{
		if (IsReEnterPinCode)
		{
			if (!(pinCode == _tepmPinCode))
			{
				await WrongPinCodeEntered();
			}
			else
			{
				await _safeEntranceManager.CreatePinCodeAsync(base.EnteredPinCode);
				if (!_safeEntranceManager.IsBiometryCreated)
				{
					await _safeEntranceManager.CreateBiometryAsync();
				}
				Close();
			}
			_tepmPinCode = string.Empty;
		}
		else
		{
			IsReEnterPinCode = true;
			Init();
			RaisePropertyChanged("CodeStates");
			RaisePropertyChanged("Subtitle");
			RaisePropertyChanged("Description");
			_tepmPinCode = pinCode;
		}
	}

	protected override async Task WrongPinCodeEntered()
	{
		await base.WrongPinCodeEntered();
		if (IsReEnterPinCode && base.IsWrongPinCodeEntered)
		{
			await Task.Delay(1000);
			base.IsWrongPinCodeEntered = false;
			IsReEnterPinCode = false;
			Init();
			RaisePropertyChanged("IsWrongPinCodeEntered");
			RaisePropertyChanged("CodeStates");
		}
	}
}
