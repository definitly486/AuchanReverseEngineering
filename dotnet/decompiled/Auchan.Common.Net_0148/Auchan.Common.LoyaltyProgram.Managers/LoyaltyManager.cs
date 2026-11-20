using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Managers;

public class LoyaltyManager : ILoyaltyManager
{
	private readonly ILoyaltyProgramBalanceService _loyaltyProgramBalanceService;

	private readonly ILoyaltySocialStatusService _loyaltySocialStatusService;

	private readonly IAdminContext _adminContext;

	private readonly IUserContext _userContext;

	private readonly ICache _cache;

	private readonly ILoyaltyPointsExpirationService _loyaltyPointsExpirationService;

	public bool IsEPointsEnabled => _adminContext.AppConfig?.LoyaltyConfig?.EPointsBalanceEnabled == true;

	public string ConnectionErrorText => _adminContext.AppConfig?.LoyaltyConfig?.ConnectionErrorText ?? string.Empty;

	public string ConnectionErrorImage => _adminContext.AppConfig?.LoyaltyConfig?.ConnectionErrorImage ?? string.Empty;

	public bool IsTransferEnabled
	{
		get
		{
			if (!IsPointsTransferEnabled)
			{
				return _adminContext.StampsConfig?.AllowStampsTransfer == true;
			}
			return true;
		}
	}

	public bool IsPointsTransferEnabled
	{
		get
		{
			if (!IsPointsTransferToUserEnabled)
			{
				return IsPointsTransferToAuchanFundEnabled;
			}
			return true;
		}
	}

	public bool IsPointsTransferToUserEnabled => _adminContext.AppConfig?.LoyaltyConfig?.IsPointsTransferToUserEnabled == true;

	public bool IsPointsTransferToAuchanFundEnabled => _adminContext.AppConfig?.LoyaltyConfig?.IsPointsTransferToAuchanFundEnabled == true;

	public string PointsTransferDisabledMessage => _adminContext.AppConfig?.LoyaltyConfig?.PointsTransferDisabledMessage ?? string.Empty;

	public string PointsTransferToAuchanFundDisabledMessage => _adminContext.AppConfig?.LoyaltyConfig?.PointsTransferToAuchanFundDisabledMessage ?? string.Empty;

	public string PointsTransferToUserDisabledMessage => _adminContext.AppConfig?.LoyaltyConfig?.PointsTransferToUsersDisabledMessage ?? string.Empty;

	public bool IsConnectionLost { get; private set; }

	public LoyaltyManager(ILoyaltyProgramBalanceService loyaltyProgramBalanceService, ILoyaltySocialStatusService loyaltySocialStatusService, IAdminContext adminContext, IUserContext userContext, ICache cache, ILoyaltyPointsExpirationService loyaltyPointsExpirationService)
	{
		_loyaltyProgramBalanceService = loyaltyProgramBalanceService;
		_loyaltySocialStatusService = loyaltySocialStatusService;
		_adminContext = adminContext;
		_cache = cache;
		_userContext = userContext;
		_loyaltyPointsExpirationService = loyaltyPointsExpirationService;
		_userContext.AfterLoggedIn += async delegate
		{
			await UpdateSocialStatus();
		};
	}

	public async Task UpdateSocialStatus(bool updateProfile = true)
	{
		var (flag3, _, loyaltyProgramSocialStatusResponse2) = await GetSocialStatusAsync();
		if (_userContext.Profile == null)
		{
			return;
		}
		bool flag4 = flag3 && loyaltyProgramSocialStatusResponse2.IsEmployee;
		bool flag5 = flag3 && loyaltyProgramSocialStatusResponse2.IsSocial;
		_userContext.Profile.IsAuchanEmployee = flag4;
		_userContext.Profile.IsConfirmedSocialStatus = flag5 && !flag4;
		if (flag3)
		{
			_userContext.LoyaltyProgramSegments = loyaltyProgramSocialStatusResponse2.Segments.Select((LoyaltyProgramSocialStatusSegment x) => x.Code).ToList();
			if (_adminContext.AppConfigIsNotNull)
			{
				_adminContext.StampsConfig?.SetSocialStatus(loyaltyProgramSocialStatusResponse2);
			}
		}
		if (updateProfile)
		{
			_userContext.UpdateProfileWithNotify(_userContext.Profile, needUpdateEmployeeStatus: true);
		}
	}

	public IEnumerable<HintEntity> ProduceHintsList()
	{
		List<HintEntity> list = new List<HintEntity>();
		list.Add(new HintEntity
		{
			Text = new AttributedText("{0} Они начисляются вам при каждой покупке:", "Это баллы.")
		});
		if (IsEPointsEnabled)
		{
			list.Add(new HintEntity
			{
				Text = new AttributedText("{0} Они начисляются за каждую вторую покупку на сумму от 500 ₽", "Это экспресс-баллы.")
			});
		}
		if (_adminContext.StampsConfig?.ShowStampsBalance == true)
		{
			list.Add(new HintEntity
			{
				Text = new AttributedText("{0} Они начисляются за каждые 300 ₽ в чеке", "Это Марки.")
			});
		}
		list.Last().IsLast = true;
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Index = i;
		}
		return list;
	}

	public async Task<Result<LoyaltyCardEntity, DomainError>> GetBalanceAsync(int timeout = 15)
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyProgramBalanceService.GetBalanceAsync(timeout);
		IsConnectionLost = result.IsFailure;
		if (result.IsFailure)
		{
			if (_userContext.LoyaltyCard != null)
			{
				LoyaltyCardEntity loyaltyCardEntity = await _cache.TryGet<LoyaltyCardEntity>("CachedLoyaltyCardEntity");
				if (loyaltyCardEntity != null)
				{
					return loyaltyCardEntity;
				}
			}
			return Result.Failure<LoyaltyCardEntity, DomainError>(result.Error);
		}
		await _cache.Save("CachedLoyaltyCardEntity", result.Value);
		_userContext.SetLoyaltyCardProperties(result.Value, UpdateTime: true);
		return result.Value;
	}

	public async Task<Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>> GetDelayedPoints(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15)
	{
		if (((await _cache.TryGet<LoyaltyCardEntity>("CachedLoyaltyCardEntity"))?.DelayedPoints?.DelayedCurrencyList?.Length).GetValueOrDefault() == 0)
		{
			return Result.Failure<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>(new NoDataError());
		}
		Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError> result = await _loyaltyPointsExpirationService.GetDelayedPointsAsync(currencies, offset, limit, timeout);
		if (result.IsSuccess)
		{
			IEnumerable<DelayedPointsEntryEntity> item = result.Value.Item1;
			if (!item.Any())
			{
				return Result.Failure<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>(new NoDataError());
			}
			return result;
		}
		return Result.Failure<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>(result.Error);
	}

	public async Task<Result<LoyaltyProgramSocialStatusResponse, DomainError>> GetSocialStatusAsync(int timeout = 15)
	{
		Result<LoyaltyProgramSocialStatusResponse, DomainError> result = await _loyaltySocialStatusService.GetSocialStatusAsync(timeout);
		if (result.IsFailure)
		{
			return Result.Failure<LoyaltyProgramSocialStatusResponse, DomainError>(result.Error);
		}
		return result;
	}
}
