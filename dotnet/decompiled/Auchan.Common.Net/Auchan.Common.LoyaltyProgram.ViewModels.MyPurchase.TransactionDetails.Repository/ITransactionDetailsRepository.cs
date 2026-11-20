using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.TransactionDetails.Repository;

public interface ITransactionDetailsRepository
{
	Task<Result<LoyaltyTransactionDetails, DomainError>> GetPurchaseDetails(string transactionDetails);
}
