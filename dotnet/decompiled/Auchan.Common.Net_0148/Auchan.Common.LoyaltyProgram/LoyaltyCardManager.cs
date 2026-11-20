using System;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram;

public class LoyaltyCardManager : ILoyaltyCardManager
{
	private readonly Lazy<ILoyaltyCardService> _loyaltyCardService;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly IUserContext _userContext;

	public UICommand<string> CodeUpdatedCommand { get; } = new UICommand<string>();

	public LoyaltyCardManager(Lazy<ILoyaltyCardService> loyaltyCardService, Lazy<ILoyaltyManager> loyaltyManager, IUserContext userContext)
	{
		_loyaltyCardService = loyaltyCardService;
		_loyaltyManager = loyaltyManager;
		_userContext = userContext;
		_userContext.AfterLoggedIn += AfterLoggedIn;
	}

	public async Task<Result<LoyaltyCardEntity, DomainError>> GetLoyaltyCard(CancellationToken token, bool forceUpdate = false, int timeout = 15)
	{
		LoyaltyCardEntity loyaltyCard = _userContext.LoyaltyCard;
		bool flag = loyaltyCard == null || !loyaltyCard.QrCodeExpirationDate.HasValue || (loyaltyCard != null && loyaltyCard.QrCodeExpirationDate.HasValue && loyaltyCard.QrCodeExpirationDate < DateTime.Now);
		if (loyaltyCard != null && !flag && !forceUpdate)
		{
			return loyaltyCard;
		}
		try
		{
			Result<LoyaltyProgramQrCodeResponseDto, DomainError> result = await _loyaltyCardService.Value.GetLoyaltyCode(token, timeout);
			if (result.IsSuccess)
			{
				_userContext.SetLoyaltyCardCode(result.Value);
				return _userContext.LoyaltyCard;
			}
			return Result.Failure<LoyaltyCardEntity, DomainError>(result.Error);
		}
		catch
		{
			return Result.Failure<LoyaltyCardEntity, DomainError>(new CancellationError());
		}
	}

	public async Task<Result<Unit, DomainError>> BlockCardAsync()
	{
		Result<Unit, DomainError> result = await _loyaltyCardService.Value.BlockCardAsync();
		LoyaltyCardEntity loyaltyCard = _userContext.LoyaltyCard;
		if (result.IsSuccess && loyaltyCard != null)
		{
			_userContext.LoyaltyCard = new LoyaltyCardEntity
			{
				CardStatus = LoyaltyCardStatus.Blocked,
				CardNumber = loyaltyCard.CardNumber,
				Cvc = loyaltyCard.Cvc,
				EPointsAmount = loyaltyCard.EPointsAmount,
				StampsAmount = loyaltyCard.StampsAmount,
				PointsAmount = loyaltyCard.StampsAmount,
				QrCode = loyaltyCard.QrCode
			};
		}
		return result;
	}

	public async Task<Result<Unit, DomainError>> BlockAndReissueCardAsync(string? cardNumber = null, string? cardCvc = null)
	{
		if (!string.IsNullOrWhiteSpace(cardNumber))
		{
			cardNumber = Regex.Replace(cardNumber, "\\s+", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(60L));
		}
		Result<Unit, DomainError> result = await _loyaltyCardService.Value.BlockAndReissueCardAsync(cardNumber, cardCvc);
		if (result.IsSuccess)
		{
			_userContext.LoyaltyCard = new LoyaltyCardEntity
			{
				CardNumber = _userContext.LoyaltyCard.CardNumber,
				CardStatus = LoyaltyCardStatus.Active,
				Cvc = null,
				EPointsAmount = 0m,
				StampsAmount = 0m,
				PointsAmount = 0m,
				QrCode = null
			};
		}
		return result;
	}

	public async Task<bool> IsCardSilentRolloutNeeded()
	{
		if (string.IsNullOrEmpty(_userContext.Profile?.LoymaxLoyaltyId))
		{
			return false;
		}
		ProfileModel? profile = _userContext.Profile;
		if (profile == null || !profile.Birthday.HasValue)
		{
			return false;
		}
		if (!(_userContext.Profile?.LoyaltyFlag ?? false))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(_userContext.Profile?.LoymaxLoyaltyId))
		{
			return false;
		}
		await _loyaltyManager.Value.GetBalanceAsync();
		LoyaltyCardEntity? loyaltyCard = _userContext.LoyaltyCard;
		if (loyaltyCard != null && loyaltyCard.CardStatus == LoyaltyCardStatus.Blocked)
		{
			return false;
		}
		return true;
	}

	public async Task<LoyaltyCardState> GetCardState()
	{
		if (string.IsNullOrEmpty(_userContext.Profile?.LoymaxLoyaltyId))
		{
			return LoyaltyCardState.NotRollout;
		}
		await _loyaltyManager.Value.GetBalanceAsync();
		switch (_userContext.LoyaltyCard?.CardStatus)
		{
		case LoyaltyCardStatus.Blocked:
		case LoyaltyCardStatus.Closed:
			return LoyaltyCardState.NotRollout;
		case LoyaltyCardStatus.ClosedByFraud:
			return LoyaltyCardState.Blocked;
		default:
			return LoyaltyCardState.Active;
		}
	}

	public Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto fromChannel)
	{
		return _loyaltyCardService.Value.EnrollVirtualCard(fromChannel);
	}

	public Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(ProfileModel profileModel, LoyaltyEnrollmentRequestDto.ChannelDto fromChannel)
	{
		return _loyaltyCardService.Value.EnrollVirtualCard(profileModel, fromChannel);
	}

	public Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollPlasticCard(LoyaltyCardEntity card)
	{
		return _loyaltyCardService.Value.EnrollPlasticCard(card);
	}

	private Task AfterLoggedIn()
	{
		return GetLoyaltyCard(CancellationToken.None, forceUpdate: true);
	}

	public void Start()
	{
	}

	public void OnPaused()
	{
	}
}
