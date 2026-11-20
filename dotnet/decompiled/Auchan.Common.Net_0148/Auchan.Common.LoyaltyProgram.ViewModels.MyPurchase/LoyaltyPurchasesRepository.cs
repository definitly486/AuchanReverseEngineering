using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public class LoyaltyPurchasesRepository : ILoyaltyPurchasesRepository
{
	private readonly ILoyaltyProgramPurchasesHistoryService _purchasesHistoryService;

	public LoyaltyPurchasesRepository(ILoyaltyProgramPurchasesHistoryService purchasesHistoryService)
	{
		_purchasesHistoryService = purchasesHistoryService;
	}

	public async Task<Result<LoyaltyProgramPurchase, DomainError>> GetTransactionDetailsAsync(string chequeNumber)
	{
		return await _purchasesHistoryService.GetTransactionDetailsAsync(chequeNumber);
	}

	public async Task<Result<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]?), DomainError>> GetHistoryAsync(HistoryFilter? filter, int offset, int limit, bool includeStamps)
	{
		Result<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError> result = await _purchasesHistoryService.GetHistoryAsync(filter, offset, limit);
		if (result.IsFailure)
		{
			return Result.Failure<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError>(result.Error);
		}
		var (item, item2, item3) = result.Value;
		return Result.Success<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError>((item, item2, item3));
	}

	private static FeedItemViewModel ConvertToFeedItem(LoyaltyProgramPurchase item)
	{
		if (item.IsOperationTimeOnly)
		{
			return new DateItemViewModel(item.OperationDate);
		}
		return new PurchaseItemViewModel(item);
	}

	private static FeedItemViewModel ConvertToDelayedPointsFeedItem(LoyaltyProgramPurchase item)
	{
		if (item.IsOperationTimeOnly)
		{
			return new DateItemViewModel(item.DelayedPointsBookDate);
		}
		return new PurchaseItemViewModel(item);
	}
}
