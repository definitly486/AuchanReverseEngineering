using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Helpers.Enums;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Dtos.Balance;
using Auchan.Common.LoyaltyProgram.Dtos.Triggers;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.Mappers;

public static class LoyaltyProgramMappers
{
	public static Loyalty Map(this LoyaltyDto dto)
	{
		return new Loyalty
		{
			StepOne = (dto?.StepOne?.Map() ?? new StepOne()),
			StepTwo = (dto?.StepTwo?.Map() ?? new StepTwo())
		};
	}

	public static StepOne Map(this StepOneDto dto)
	{
		return new StepOne
		{
			IsEnabled = dto.IsEnabled,
			AuchanPayPopupTexts = dto.AuchanPayPopupTexts,
			LoyaltyPopupTexts = dto.LoyaltyPopupTexts,
			TimesToShowCount = dto.TimesToShowCount
		};
	}

	public static StepTwo Map(this StepTwoDto dto)
	{
		return new StepTwo
		{
			IsEnabled = dto.IsEnabled,
			PositiveBalanceTexts = dto.PositiveBalanceText,
			ZeroBalanceText = dto.ZeroBalanceText,
			APayRefillText = dto.APayRefillText,
			PersonalDataWarningText = dto.PersonalDataWarningText,
			AuchanPayInfoMessage = dto.AuchanPayInfoMessage,
			RegistrationSuccessfulText = dto.RegistrationSuccessfulText,
			OnStartTriggerText = dto.OnStartTriggerText
		};
	}

	public static LoyaltyCardEntity Map(this LoyaltyProgramBalanceResponseDto dto)
	{
		LoyaltyCardStatus mappedValue = dto.Status.GetMappedValue(LoyaltyCardStatus.Blocked);
		return new LoyaltyCardEntity
		{
			CardNumber = dto.IdentifierNumber,
			PointsAmount = (dto.Balance?.Balances?.Where((LoyaltyProgramBalanceDetailsItemDto b) => b.PointsType == "AUCH_PT")?.Select((LoyaltyProgramBalanceDetailsItemDto b) => b.Points).Sum()).GetValueOrDefault(),
			EPointsAmount = (dto.Balance?.Balances?.Where((LoyaltyProgramBalanceDetailsItemDto b) => b.PointsType == "EXTRA_PT")?.Select((LoyaltyProgramBalanceDetailsItemDto b) => b.Points).Sum()).GetValueOrDefault(),
			StampsAmount = (dto.Balance?.Balances?.Where((LoyaltyProgramBalanceDetailsItemDto b) => b.PointsType == "STAMP_PT")?.Select((LoyaltyProgramBalanceDetailsItemDto b) => b.Points).Sum()).GetValueOrDefault(),
			CardStatus = mappedValue
		};
	}

	public static LoyaltyCardEntity Map(this BalanceDto dto)
	{
		LoyaltyCardStatus cardStatus = LoyaltyCardStatus.Active;
		ExpirationPointsEntity expirationPoints = null;
		BalanceDataDto? data = dto.Data;
		if (data != null && data.NextExpirationAmount.HasValue)
		{
			expirationPoints = new ExpirationPointsEntity
			{
				Points = dto.Data.NextExpirationAmount.GetValueOrDefault(),
				ExpirationDate = dto.Data.NextExpirationDate.GetValueOrDefault(),
				ExpirationCurrencyList = dto.Data.ExpirationCurrencyList
			};
		}
		DelayedPointsEntity delayedPoints = null;
		if (dto.Data?.ActivationCurrencyList != null && dto.Data.ActivationCurrencyList.Length != 0)
		{
			delayedPoints = new DelayedPointsEntity(new List<DelayedPointsEntryEntity>(new global::_003C_003Ez__ReadOnlySingleElementList<DelayedPointsEntryEntity>(new DelayedPointsEntryEntity
			{
				Points = dto.Data.NextActivationAmount.GetValueOrDefault(),
				OperationTime = dto.Data.NextActivationDate.GetValueOrDefault()
			})))
			{
				DelayedCurrencyList = dto.Data.ActivationCurrencyList
			};
		}
		return new LoyaltyCardEntity
		{
			CardNumber = string.Empty,
			PointsAmount = ((from b in dto.Data?.Items?.Where((ItemDto b) => b.CurrencyCode == "AUCH_PT")
				select b.CurrencyAmount).Sum()).GetValueOrDefault(),
			EPointsAmount = ((from b in dto.Data?.Items?.Where((ItemDto b) => b.CurrencyCode == "EXTRA_PT")
				select b.CurrencyAmount).Sum()).GetValueOrDefault(),
			StampsAmount = ((from b in dto.Data?.Items?.Where((ItemDto b) => b.CurrencyCode == "STAMP_PT")
				select b.CurrencyAmount).Sum()).GetValueOrDefault(),
			CardStatus = cardStatus,
			ExpirationPoints = expirationPoints,
			DelayedPoints = delayedPoints
		};
	}

	public static LoyaltyCardEntity Map(this LoyaltyProgramQrCodeResponseDto dto)
	{
		if (dto == null)
		{
			return new LoyaltyCardEntity();
		}
		return new LoyaltyCardEntity
		{
			QrCode = dto.Data.QrCode,
			CardNumber = dto.Data.CardNumber
		};
	}

	public static (IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]?) Map(this LoymaxHistoryResponseDto dto)
	{
		List<LoyaltyProgramPurchase> item = new List<LoyaltyProgramPurchase>();
		if (dto.Data?.Items != null)
		{
			item = dto.Data.Items.Select((TransactionDetailsDto i) => i.MapPurchase()).ToList();
		}
		return (item, (dto.Meta?.Pagination?.Total).GetValueOrDefault(), dto.Data?.AvailableFilters);
	}

	public static LoyaltyProgramPurchase MapPurchase(this TransactionDetailsDto dto)
	{
		LoyaltyProgramPurchase obj = new LoyaltyProgramPurchase
		{
			Transaction = dto.MapTransaction(),
			TransactionId = (dto.TransactionId ?? ""),
			TransactionNumber = (dto.TransactionNumber ?? ""),
			OrderNumber = (dto.Order?.Number ?? ""),
			OperationType = dto.OperationType,
			OperationDate = dto.Date,
			Total = dto.TotalValue.GetValueOrDefault()
		};
		List<PointsBalanceDto>? pointsBalances = dto.PointsBalances;
		obj.Points = ((pointsBalances != null) ? pointsBalances.TotalPoints() : 0m);
		List<PointsBalanceDto>? pointsBalances2 = dto.PointsBalances;
		obj.EPoints = ((pointsBalances2 != null) ? pointsBalances2.TotalExpressPoints() : 0m);
		List<PointsBalanceDto>? pointsBalances3 = dto.PointsBalances;
		obj.Stamps = ((pointsBalances3 != null) ? pointsBalances3.TotalStamps() : 0m);
		obj.Source = dto.Channel;
		obj.StoreExternalId = TryParseStoreExternalId(dto.Location);
		obj.DelayedPoints = 0m;
		obj.DelayedPointsBookDate = DateTime.MinValue;
		obj.DelayedPointsIndex = 0;
		obj.Comments = dto.Comments ?? string.Empty;
		obj.IsOperationTimeOnly = false;
		obj.IsRefund = dto.IsRefund == true;
		return obj;
	}

	public static LoyaltyTransactionDetails MapTransaction(this TransactionDetailsDto dto)
	{
		return new LoyaltyTransactionDetails(dto.TypeName ?? string.Empty, string.Empty, dto.Date, (double)dto.TotalValue.GetValueOrDefault(), dto.PointsBalances.AddedPoints(), dto.PointsBalances.AddedExpressPoints(), dto.PointsBalances.AddedStamps(), dto.PointsBalances.RemovedPoints(), dto.PointsBalances.RemovedExpressPoints(), dto.PointsBalances.RemovedStamps(), (dto.OrderDetails?.DelayedPoints).GetValueOrDefault(), dto.OrderDetails?.DelayedPointsBookDate, dto.OrderDetails?.Products?.Select((ProductDto productDto) => productDto.Map()).ToList() ?? new List<LoyaltyProduct>());
	}

	private static LoyaltyProduct Map(this ProductDto dto)
	{
		return new LoyaltyProduct(dto.Code, dto.Domain, dto.ProcessedPoints.ProductPoints(), dto.ProcessedPoints.ProductExpressPoints(), dto.ProcessedPoints.ProductStamps(), dto.Quantity.GetValueOrDefault(), dto.Value.GetValueOrDefault(), dto.Image, dto.Name);
	}

	private static decimal AddedPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.Points)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() > default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal AddedExpressPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.EPoints)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() > default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal AddedStamps(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.Stamps)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() > default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal RemovedPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.Points)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() < default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal RemovedExpressPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.EPoints)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() < default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal RemovedStamps(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where(delegate(PointsBalanceDto x)
		{
			if (x.PointType == ExpirationPointType.Stamps)
			{
				decimal? points = x.Points;
				return (points.GetValueOrDefault() < default(decimal)) & points.HasValue;
			}
			return false;
		})?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal TotalPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where((PointsBalanceDto x) => x.PointType == ExpirationPointType.Points)?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal TotalExpressPoints(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where((PointsBalanceDto x) => x.PointType == ExpirationPointType.EPoints)?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal TotalStamps(this List<PointsBalanceDto>? dto)
	{
		return (dto?.Where((PointsBalanceDto x) => x.PointType == ExpirationPointType.Stamps)?.Select((PointsBalanceDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal ProductPoints(this List<ProcessedPointDto>? dto)
	{
		return (dto?.Where((ProcessedPointDto x) => x.PointType == ExpirationPointType.Points)?.Select((ProcessedPointDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal ProductStamps(this List<ProcessedPointDto>? dto)
	{
		return (dto?.Where((ProcessedPointDto x) => x.PointType == ExpirationPointType.Stamps)?.Select((ProcessedPointDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static decimal ProductExpressPoints(this List<ProcessedPointDto>? dto)
	{
		return (dto?.Where((ProcessedPointDto x) => x.PointType == ExpirationPointType.EPoints)?.Select((ProcessedPointDto b) => b.Points).Sum()).GetValueOrDefault();
	}

	private static int? TryParseStoreExternalId(string? storeExternalId)
	{
		if (int.TryParse(storeExternalId, out var result))
		{
			return result;
		}
		return null;
	}

	public static ExpirationPointsEntity[] Map(this LoyaltyOperationsResponseDto dto)
	{
		if (dto.Data == null || dto.Data.Length == 0)
		{
			return Array.Empty<ExpirationPointsEntity>();
		}
		return (from d in dto.Data
			where d.OperationDate.HasValue
			select new ExpirationPointsEntity
			{
				ExpirationDate = d.OperationDate.Value,
				Points = d.Amount,
				PointType = d.PointType
			} into e
			orderby e.ExpirationDate descending
			select e).ToArray();
	}

	public static (IEnumerable<DelayedPointsEntryEntity>, int) MapDelayed(this LoyaltyOperationsResponseDto dto)
	{
		if (dto.Data == null || dto.Data.Length == 0)
		{
			return (new List<DelayedPointsEntryEntity>(), (dto.Meta?.Pagination?.Total).GetValueOrDefault());
		}
		IEnumerable<DelayedPointsEntryEntity> enumerable = from d in dto.Data
			where d.Purchase != null && d.OperationDate.HasValue
			select new DelayedPointsEntryEntity
			{
				Points = d.Amount,
				ChequeNumber = d.Purchase.ChequeNumber,
				OperationTime = d.OperationDate.Value,
				PointsType = d.PointType,
				PointsTypeName = d.PointType.ToString(),
				TransactionDate = d.Purchase.PurchaseTime,
				TransactionId = d.Purchase.PurchaseId
			};
		return (enumerable, dto.Meta?.Pagination?.Total ?? enumerable.Count());
	}

	public static LoyaltyProgramSocialStatusResponse Map(this SocialStatusDto dto)
	{
		return new LoyaltyProgramSocialStatusResponse(new List<LoyaltyProgramSocialStatusSegment>(), dto.Data?.FirstOrDefault((Auchan.Common.LoyaltyProgramLoymax.Data x) => x.LogicalName == "EmployeeFlag")?.Value == true, dto.Data?.FirstOrDefault((Auchan.Common.LoyaltyProgramLoymax.Data x) => x.LogicalName == "SocialFlag")?.Value == true);
	}

	public static IEnumerable<string> GetCategoriesDtoNames(this LoyaltyUserCategoriesEntity userCategories)
	{
		if (userCategories.IsOldUser)
		{
			yield return "old_user";
		}
		if (userCategories.IsRetired)
		{
			yield return "retired";
		}
	}

	public static LoyaltyPersonalizedGreetingEntity Map(this LoyaltyProgramGreetingDto greetingDto)
	{
		return new LoyaltyPersonalizedGreetingEntity(greetingDto.Title, greetingDto.Description);
	}
}
