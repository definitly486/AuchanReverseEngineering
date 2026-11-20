using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration.DataProviders;

public interface ILoyaltyExpirationPointsDataProvider
{
	Task<Result<IEnumerable<FeedItemViewModel>, DomainError>> GetHistoryAsync(LoyaltyCurrencyDto[] currencies);

	Task<Result<(IEnumerable<FeedItemViewModel>, int), DomainError>> GetHistoryAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit);
}
