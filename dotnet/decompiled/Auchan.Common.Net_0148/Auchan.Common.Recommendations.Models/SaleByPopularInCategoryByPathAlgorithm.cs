using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class SaleByPopularInCategoryByPathAlgorithm : AbstractAlgorithm<SaleByPopularInCategoryByPathArgument>
{
	public override string Name => "Популярные товары со скидкой для главного экрана";

	public SaleByPopularInCategoryByPathAlgorithm(ICache cache, SaleByPopularInCategoryByPathArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static SaleByPopularInCategoryByPathAlgorithm Create(IResolver resolver, SaleByPopularInCategoryByPathArgument argument)
	{
		return resolver.Resolve<SaleByPopularInCategoryByPathAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.SaleByPopularInCategoryByPath(base.Argument.CategoryPaths, BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		if (base.Argument.CategoryPaths.Count == 1)
		{
			return $"sale_by_popular_cat_{base.Argument.CategoryPaths[0]}_{activeStore.Id}";
		}
		return null;
	}
}
