using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class RelatedAlgorithm : AbstractAlgorithm<RelatedArgument>
{
	public override string Name => "С этим товаром покупают";

	public RelatedAlgorithm(ICache cache, RelatedArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static RelatedAlgorithm Create(IResolver resolver, RelatedArgument argument)
	{
		return resolver.Resolve<RelatedAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.Related(base.Argument.ProductIds, BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		if (base.Argument.ProductIds.Count == 1)
		{
			return $"related_{base.Argument.ProductIds[0]}_{activeStore.Id}";
		}
		return null;
	}
}
