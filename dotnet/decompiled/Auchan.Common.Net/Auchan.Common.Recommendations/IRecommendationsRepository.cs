using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

public interface IRecommendationsRepository
{
	Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> Get(IAlgorithm algorithm, bool reload = true);

	Task<Result<(IAlgorithm From, IReadOnlyList<ProductWithAnalyticsInfo> Products), DomainError>> GetFirstAvailableAsync(IEnumerable<IAlgorithm> algorithms, bool reload = true);

	Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> GetMore(IAlgorithm algorithm, ICollection<string>? loadedGimaIds);
}
