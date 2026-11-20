using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltyPointsExpirationService
{
	Task<Result<IEnumerable<ExpirationPointsEntity>, DomainError>> GetPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int timeout = 15);

	Task<Result<(IEnumerable<ExpirationPointsEntity>, int), DomainError>> GetPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15);

	Task<Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>> GetDelayedPointsAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15);
}
