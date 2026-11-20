using System;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class LoyaltyPointsTransferToNumberViewModel : LoyaltyTransferInputViewModel
{
	private bool _isPhoneNumberComplete;

	private readonly Subject<string> _updatePhoneText = new Subject<string>();

	private readonly Subject<LoyaltyPointsSentToNumberNavigationParameter> _navigateToTransferSuccess = new Subject<LoyaltyPointsSentToNumberNavigationParameter>();

	private IUserContext _userContext;

	private readonly string _stampsLimitInformer;

	private string _pointsAmount = "";

	[CompilerGenerated]
	private string _003CPhoneText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsPhoneNumberInvalid_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPhoneNumberNotFoundLabel_003Ek__BackingField;

	public UICommand<LoyaltyTransferErrorViewModel.Parameter> NavigateToTransferFailure = new UICommand<LoyaltyTransferErrorViewModel.Parameter>();

	public UICommand NavigateToTransferOptionsCommand = new UICommand();

	public string PointsAmount
	{
		get
		{
			return _pointsAmount;
		}
		set
		{
			if (!string.Equals(_pointsAmount, value, StringComparison.Ordinal))
			{
				_pointsAmount = value;
				RaisePropertyChanged("PointsAmount");
				OnAmountInputChanged(value);
			}
		}
	}

	public string PhoneNumberHint => "Номер телефона";

	public string PhoneText
	{
		[CompilerGenerated]
		get
		{
			return _003CPhoneText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CPhoneText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPhoneText_003Ek__BackingField = value;
				RaisePropertyChanged("PhoneTextFormatted");
				RaisePropertyChanged("IsPhoneValid");
				RaisePropertyChanged("PhoneText");
			}
		}
	} = string.Empty;

	private string PhoneTextFormatted => $"+{"7"} {long.Parse(PhoneText):(000) 000-00-00}";

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public bool IsPhoneNumberComplete
	{
		get
		{
			return _isPhoneNumberComplete;
		}
		set
		{
			if (_isPhoneNumberComplete == value)
			{
				return;
			}
			_isPhoneNumberComplete = value;
			RaisePropertyChanged("IsPhoneValid");
			RaisePropertyChanged("IsPhoneNumberComplete");
			if (_isPhoneNumberComplete)
			{
				if ("7" + PhoneText == _userContext.Profile?.Phone)
				{
					ShowIncorrectPhone("Нельзя указать свой номер телефона");
				}
				else
				{
					IsPhoneNumberInvalid = false;
					RaisePropertyChanged("IsPhoneNumberInvalid");
				}
			}
			else
			{
				IsPhoneNumberInvalid = false;
				RaisePropertyChanged("IsPhoneNumberInvalid");
			}
			RaisePropertyChanged("IsTransferButtonEnabled");
		}
	}

	public bool IsPhoneNumberInvalid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsPhoneNumberInvalid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsPhoneNumberInvalid_003Ek__BackingField != value)
			{
				_003CIsPhoneNumberInvalid_003Ek__BackingField = value;
				RaisePropertyChanged("IsPhoneValid");
				RaisePropertyChanged("IsPhoneNumberInvalid");
			}
		}
	}

	public string PhoneNumberNotFoundLabel
	{
		[CompilerGenerated]
		get
		{
			return _003CPhoneNumberNotFoundLabel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPhoneNumberNotFoundLabel_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPhoneNumberNotFoundLabel_003Ek__BackingField = value;
				RaisePropertyChanged("PhoneNumberNotFoundLabel");
			}
		}
	} = string.Empty;

	public override bool IsPhoneValid
	{
		get
		{
			if (!string.IsNullOrEmpty(PhoneText) && IsPhoneNumberComplete)
			{
				return !IsPhoneNumberInvalid;
			}
			return false;
		}
	}

	public IObservable<string> UpdatePhoneCommand => _updatePhoneText.Debounce();

	public IObservable<LoyaltyPointsSentToNumberNavigationParameter> NavigateToTransferSuccess => _navigateToTransferSuccess.Debounce();

	protected override string ScreenName => "loyality_transfer";

	public string AmountLimitText
	{
		get
		{
			if (base.PointsType != LoyaltyPointType.Points)
			{
				return _stampsLimitInformer;
			}
			return "Не более 300 баллов за перевод\nНе более 900 баллов в сутки";
		}
	}

	public LoyaltyPointsTransferToNumberViewModel(LoyaltyPointsTransferNavigationParameter navigationParameter, ILoyaltyManager loyaltyManager, IInfoMessageService infoMessageService, IAdminContext adminContext, IUserContext userContext, IPointsTransferManager pointsTransferManager)
		: base(navigationParameter, loyaltyManager, infoMessageService, adminContext, pointsTransferManager)
	{
		base.PointsType = navigationParameter.PointType;
		_stampsLimitInformer = adminContext.StampsConfig?.StampsLimitInformer ?? "";
		_userContext = userContext;
	}

	protected override string ConfirmationDialogBody(int amount)
	{
		return $"{amount} {amount.GetLoyaltyPointsDeclinedAccusative(base.PointsType)} получателю:\n{PhoneTextFormatted}";
	}

	public void OnContactPhoneSelected(string phone)
	{
		if (string.IsNullOrEmpty(phone))
		{
			base.InfoMessageService.ShowSnackbar("Некорректный формат номера телефона");
		}
		else
		{
			_updatePhoneText.OnNext(phone);
		}
	}

	public async Task<bool> OnTransferButtonSelected()
	{
		if (!(await DoTransferAsync(base.EnteredAmount)))
		{
			return false;
		}
		_navigateToTransferSuccess.OnNext(new LoyaltyPointsSentToNumberNavigationParameter(base.PointsType, PhoneTextFormatted, base.EnteredAmount));
		return true;
	}

	protected override async Task<bool> TransferAsync(int amount)
	{
		string phone = "7" + PhoneText;
		Result<PointsTransferResponseDto, PointsTransactionError> result = await ((base.PointsType == LoyaltyPointType.Points) ? base.PointsTransferManager.TransferPointsAsync(phone, amount, "AUCH_PT") : base.PointsTransferManager.TransferPointsAsync(phone, amount, "STAMP_PT"));
		if (result.IsFailure)
		{
			PointsTransactionError error = result.Error;
			if (error.IncorrectPhone)
			{
				ShowIncorrectPhone(error.Message);
				return false;
			}
			base.InfoMessageService.ShowDialogAsync(error.Title, error.Message, new AlertButton[1]
			{
				new AlertButton
				{
					Title = "Понятно",
					Type = ActionType.Positive
				}
			}).SafeFireAndForget((Action<Exception>)null, false);
			return false;
		}
		return true;
	}

	private void ShowIncorrectPhone(string message)
	{
		PhoneNumberNotFoundLabel = message;
		IsPhoneNumberInvalid = true;
		RaisePropertyChanged("PhoneNumberNotFoundLabel");
		RaisePropertyChanged("IsPhoneNumberInvalid");
	}

	public override void PointsTabTapped()
	{
		if (base.PointsType != LoyaltyPointType.Points)
		{
			NavigateToTransferOptionsCommand.Trigger();
		}
	}

	public override void StampsTabTapped()
	{
		if (base.PointsType != LoyaltyPointType.Stamps)
		{
			SwitchTo(LoyaltyPointType.Stamps);
		}
	}

	private void SwitchTo(LoyaltyPointType pointsType)
	{
		base.PointsType = pointsType;
		base.EnteredAmount = 0;
		PointsAmount = "";
		PhoneText = "";
		RaisePropertyChanged("EnterPointsLabel");
		RaisePropertyChanged("PointsHint");
		RaisePropertyChanged("EnteredAmount");
		RaisePropertyChanged("PointsAmount");
		RaisePropertyChanged("PhoneText");
		RaisePropertyChanged("AmountLimitText");
	}
}
