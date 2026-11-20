using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class PopularInCategoryByPathAlgorithm : AbstractAlgorithm<PopularInCategoryByPathArgument>
{
	public override string Name => "Популярные товары для экрана категорий";

	public PopularInCategoryByPathAlgorithm(ICache cache, PopularInCategoryByPathArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static PopularInCategoryByPathAlgorithm Create(IResolver resolver, PopularInCategoryByPathArgument argument)
	{
		return resolver.Resolve<PopularInCategoryByPathAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.PopularInCategoryByPath(base.Argument.CategoryPaths, BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		if (base.Argument.CategoryPaths.Count == 1)
		{
			return $"popular_cat_{base.Argument.CategoryPaths[0]}_{activeStore.Id}";
		}
		return null;
	}
}
