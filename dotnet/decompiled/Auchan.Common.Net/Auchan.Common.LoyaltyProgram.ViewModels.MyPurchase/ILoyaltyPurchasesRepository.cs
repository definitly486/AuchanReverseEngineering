using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public interface ILoyaltyPurchasesRepository
{
	Task<Result<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]?), DomainError>> GetHistoryAsync(HistoryFilter? filter, int offset, int limit, bool includeStamps);

	Task<Result<LoyaltyProgramPurchase, DomainError>> GetTransactionDetailsAsync(string chequeNumber);
}
