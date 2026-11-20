using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class CategoryPlacementsAndPopularsInCategoryAlgorithm : AbstractAlgorithm<CategoryPlacementsArgument>
{
	public override string Name => "CategoryPlacementsAndPopularsInCategoryAlgorithm";

	public CategoryPlacementsAndPopularsInCategoryAlgorithm(ICache cache, CategoryPlacementsArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static CategoryPlacementsAndPopularsInCategoryAlgorithm Create(IResolver resolver, CategoryPlacementsArgument argument)
	{
		return resolver.Resolve<CategoryPlacementsAndPopularsInCategoryAlgorithm>(new object[1] { argument });
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Task<Result<RecommendationList, DomainError>> task = apiService.PopularByInterestedPropertiesByCategoryPath(base.Argument.CategoryPath, base.Argument.BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
		Task<Result<RecommendationList, DomainError>> categoryPlacementsAsync = apiService.GetCategoryPlacementsAsync(base.Argument.PlacementId, base.Argument.BlockId, RecomendationAnalyticActionsTag.ProductPlacements, base.Argument.CategoryPath, token);
		Result<RecommendationList, DomainError>[] obj = await Task.WhenAll<Result<RecommendationList, DomainError>>(task, categoryPlacementsAsync);
		Result<RecommendationList, DomainError> result = obj[0];
		Result<RecommendationList, DomainError> result2 = obj[1];
		Result<RecommendationList, DomainError> result3 = result;
		if (result3.TryGetValue(out var value) && result2.TryGetValue(out var value2))
		{
			return value2.MergeWith(value);
		}
		if (result2.IsSuccess)
		{
			return result2;
		}
		return result3;
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return null;
	}
}
