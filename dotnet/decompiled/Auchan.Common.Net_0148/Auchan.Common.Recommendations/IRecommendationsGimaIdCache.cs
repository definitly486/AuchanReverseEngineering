using System.Diagnostics.CodeAnalysis;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Recommendations;

public interface IRecommendationsGimaIdCache
{
	int Count(IAlgorithm algorithm);

	void Clear();

	void Clear(IAlgorithm algorithm);

	void Cache(IAlgorithm algorithm, RecommendationList response);

	bool TryGetCachedRecommendationResponse(IAlgorithm algorithm, [NotNullWhen(true)] out RecommendationList? response);
}
