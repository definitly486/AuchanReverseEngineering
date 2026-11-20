using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class LoyaltyPointsTransferToCharityViewModel : LoyaltyTransferInputViewModel
{
	private readonly Subject<LoyaltyPointsSentToCharityNavigationParameter> _navigateToTransferSuccess = new Subject<LoyaltyPointsSentToCharityNavigationParameter>();

	private readonly Subject<InfoPageViewModel.Parameter> _navigateToCharityDetails = new Subject<InfoPageViewModel.Parameter>();

	public UICommand<LoyaltyTransferErrorViewModel.Parameter> NavigateToTransferFailure = new UICommand<LoyaltyTransferErrorViewModel.Parameter>();

	public override bool ShowStamps => false;

	public string TransferOperationDescriptionTitleText => "Благотворительный фонд «Поколение АШАН»";

	public string TransferOperationDescriptionText => "АШАН заботится о детях и молодых людях, оказавшихся в трудной жизненной ситуации. Вы можете помочь им вместе с нами!";

	public string MoreDetailsLabel => "Подробнее о фонде";

	public string MoreDetailsLink => "https://pokolenie-auchan.ru/";

	public string PointsAmount
	{
		get
		{
			if (base.EnteredAmount != 0)
			{
				return base.EnteredAmount.ToString();
			}
			return string.Empty;
		}
		set
		{
			if (!string.Equals(PointsAmount, value, StringComparison.Ordinal))
			{
				OnAmountInputChanged(value);
				RaisePropertyChanged("PointsAmount");
			}
		}
	}

	public IObservable<LoyaltyPointsSentToCharityNavigationParameter> NavigateToTransferSuccess => _navigateToTransferSuccess.Debounce();

	protected override string ScreenName => "loyality_transfer";

	public LoyaltyPointsTransferToCharityViewModel(LoyaltyPointsTransferNavigationParameter navigationParameter, ILoyaltyManager loyaltyManager, IInfoMessageService infoMessageService, IAdminContext adminContext, IPointsTransferManager pointsTransferManager)
		: base(navigationParameter, loyaltyManager, infoMessageService, adminContext, pointsTransferManager)
	{
		base.PointsType = LoyaltyPointType.Points;
	}

	protected override string ConfirmationDialogBody(int amount)
	{
		return $"{amount} {amount.GetLoyaltyPointsDeclined(base.PointsType)} в благотворительный фонд «Поколение АШАН»";
	}

	public void OnNavigateToCharityDetailsSelected()
	{
		Browser.OpenAsync("https://pokolenie-auchan.ru/");
	}

	public async Task OnTransferButtonSelected()
	{
		if (await DoTransferAsync(base.EnteredAmount))
		{
			_navigateToTransferSuccess.OnNext(new LoyaltyPointsSentToCharityNavigationParameter(base.EnteredAmount, base.PointsBalanceInt - base.EnteredAmount));
		}
	}

	protected override async Task<bool> TransferAsync(int amount)
	{
		Result<PointsTransferResponseDto, PointsTransactionError> result = await base.PointsTransferManager.TransferPointsAsync(null, amount, "AUCH_PT");
		if (result.IsFailure)
		{
			PointsTransactionError error = result.Error;
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
}
