using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services.TransactionDetails;

public interface ITransactionDetailsService
{
	Task<Result<LoyaltyTransactionDetails, DomainError>> GetTransactionDetails(string transactionId);
}
