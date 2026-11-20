using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services.TransactionDetails;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.TransactionDetails.Repository;

public class TransactionDetailsRepository : ITransactionDetailsRepository
{
	private readonly ITransactionDetailsService _transactionDetailsService;

	public TransactionDetailsRepository(ITransactionDetailsService transactionDetailsService)
	{
		_transactionDetailsService = transactionDetailsService;
	}

	public async Task<Result<LoyaltyTransactionDetails, DomainError>> GetPurchaseDetails(string transactionDetails)
	{
		Result<LoyaltyTransactionDetails, DomainError> result = await _transactionDetailsService.GetTransactionDetails(transactionDetails);
		return result.IsFailure ? Result.Failure<LoyaltyTransactionDetails, DomainError>(result.Error) : Result.Success<LoyaltyTransactionDetails, DomainError>(result.Value);
	}
}
