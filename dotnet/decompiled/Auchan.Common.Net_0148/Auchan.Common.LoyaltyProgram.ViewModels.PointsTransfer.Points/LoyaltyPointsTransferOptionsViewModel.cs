using System;
using Auchan.Common.AdminTool;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Abstract;
using Auchan.Common.Navigation;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class LoyaltyPointsTransferOptionsViewModel : LoyaltyBaseTransferViewModel
{
	private readonly ILoyaltyManager _loyaltyManager;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	private string _title;

	public UICommand<LoyaltyPointsTransferNavigationParameter> NavigateToCharityTransferCommand = new UICommand<LoyaltyPointsTransferNavigationParameter>();

	public UICommand<LoyaltyPointsTransferNavigationParameter> NavigateToPhoneNumberTransferCommand = new UICommand<LoyaltyPointsTransferNavigationParameter>();

	public string TransferRulesText => "К переводу доступны только баллы, экспресс-баллы перевести невозможно. Переведенные баллы возврату не подлежат.";

	public string CharityOptionTitle { get; } = "В благотворительный фонд «Поколение АШАН»";

	public string CharityOptionDescription { get; } = "АШАН заботится о детях и молодых людях, оказавшихся в трудной жизненной ситуации. Вы можете помочь им вместе с нами!";

	public string PhoneNumberOptionTitle { get; } = "Родным и друзьям";

	public string PhoneNumberOptionDescription { get; } = "У ваших близких есть карта АШАН? Вы можете подарить им свои баллы!";

	public bool IsTransferDisabled => !_loyaltyManager.IsTransferEnabled;

	public bool IsPointsTransferDisabled => !_loyaltyManager.IsPointsTransferEnabled;

	public bool IsPointsTransferToAuchanFundDisabled => !_loyaltyManager.IsPointsTransferToAuchanFundEnabled;

	public bool IsPointsTransferToUserDisabled => !_loyaltyManager.IsPointsTransferToUserEnabled;

	public string PointsTransferDisabledMessage => _loyaltyManager.PointsTransferDisabledMessage;

	public string PointsTransferToAuchanFundDisabledMessage => _loyaltyManager.PointsTransferToAuchanFundDisabledMessage;

	public string PointsTransferToUserDisabledMessage => _loyaltyManager.PointsTransferToUserDisabledMessage;

	public string Title
	{
		get
		{
			if (base.State == VisualState.Error)
			{
				return _title;
			}
			return base.ScreenTitle;
		}
		set
		{
			if (!string.Equals(_title, value, StringComparison.Ordinal))
			{
				_title = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	protected override string ScreenName => "loyality_transfer";

	public LoyaltyPointsTransferOptionsViewModel(ILoyaltyManager loyaltyManager, IInfoMessageService infoMessageService, IAdminContext adminContext, UrlNavigationHandler urlNavigationHandler)
		: base(loyaltyManager, infoMessageService, adminContext)
	{
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
		_title = base.ScreenTitle;
		base.PointsType = LoyaltyPointType.Points;
	}

	protected override string ConfirmationDialogBody(int amount)
	{
		return "";
	}

	public void OnTransferToCharitySelected()
	{
		if (_loyaltyManager.IsConnectionLost)
		{
			base.State = VisualState.Error;
			Title = "Перевод баллов в Фонд АШАН";
		}
		else
		{
			NavigateToCharityTransferCommand.Trigger(GetLoyaltyPointsTransferNavigationParameter(LoyaltyPointType.Points, replacePrevious: false));
		}
	}

	public void OnTransferToPhoneNumberSelected()
	{
		if (_loyaltyManager.IsConnectionLost)
		{
			base.State = VisualState.Error;
			Title = "Перевод баллов участнику ПЛ";
		}
		else
		{
			NavigateToPhoneNumberTransferCommand.Trigger(GetLoyaltyPointsTransferNavigationParameter(LoyaltyPointType.Points, replacePrevious: false));
		}
	}

	public override void StampsTabTapped()
	{
		if (base.PointsType != LoyaltyPointType.Stamps)
		{
			NavigateToPhoneNumberTransferCommand.Trigger(GetLoyaltyPointsTransferNavigationParameter(LoyaltyPointType.Stamps, replacePrevious: false));
		}
	}

	public void HandleUrl(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
