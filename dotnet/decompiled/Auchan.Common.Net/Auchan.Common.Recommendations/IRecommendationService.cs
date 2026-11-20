using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

public interface IRecommendationService
{
	Task<Result<RecommendationList, DomainError>> Get(IAlgorithm algorithm);
}
