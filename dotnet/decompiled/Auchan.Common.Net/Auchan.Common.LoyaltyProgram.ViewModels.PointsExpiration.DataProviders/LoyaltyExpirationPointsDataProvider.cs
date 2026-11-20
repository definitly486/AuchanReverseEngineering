using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration.DataProviders;

public class LoyaltyExpirationPointsDataProvider : ILoyaltyExpirationPointsDataProvider
{
	private readonly ILoyaltyPointsExpirationService _loyaltyPointsExpirationService;

	public LoyaltyExpirationPointsDataProvider(ILoyaltyPointsExpirationService loyaltyPointsExpirationService)
	{
		_loyaltyPointsExpirationService = loyaltyPointsExpirationService;
	}

	public async Task<Result<IEnumerable<FeedItemViewModel>, DomainError>> GetHistoryAsync(LoyaltyCurrencyDto[] currencies)
	{
		Result<IEnumerable<ExpirationPointsEntity>, DomainError> result = await _loyaltyPointsExpirationService.GetPointsExpirationsAsync(currencies);
		if (result.IsFailure)
		{
			return Result.Failure<IEnumerable<FeedItemViewModel>, DomainError>(result.Error);
		}
		return Result.Success<IEnumerable<FeedItemViewModel>, DomainError>(PrepareData(from e in result.Value
			orderby e.ExpirationDate
			group e by e.ExpirationDate.Date into e
			group e by new DateTime(e.Key.Year, e.Key.Month, 1)));
	}

	public async Task<Result<(IEnumerable<FeedItemViewModel>, int), DomainError>> GetHistoryAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit)
	{
		Result<(IEnumerable<ExpirationPointsEntity>, int), DomainError> result = await _loyaltyPointsExpirationService.GetPointsExpirationsAsync(currencies, offset, limit);
		if (result.IsFailure)
		{
			return Result.Failure<(IEnumerable<FeedItemViewModel>, int), DomainError>(result.Error);
		}
		return Result.Success<(IEnumerable<FeedItemViewModel>, int), DomainError>((from x in result.Value.Item1
			orderby x.ExpirationDate
			select new PointsExpirationItemViewModel(x), result.Value.Item2));
	}

	private static IEnumerable<FeedItemViewModel> PrepareData(IEnumerable<IGrouping<DateTime, IGrouping<DateTime, ExpirationPointsEntity>>> groupedData)
	{
		foreach (IGrouping<DateTime, IGrouping<DateTime, ExpirationPointsEntity>> yearMonthItems in groupedData)
		{
			yield return new MonthAndYearItemViewModel(yearMonthItems.Key);
			foreach (IGrouping<DateTime, ExpirationPointsEntity> dayMonthItems in yearMonthItems)
			{
				yield return new DateItemViewModel(dayMonthItems.Key);
				foreach (ExpirationPointsEntity item in dayMonthItems)
				{
					yield return new PointsExpirationItemViewModel(item);
				}
			}
		}
	}
}
