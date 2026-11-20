using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class AnalogsOutOfStockProductsAlgorithm : AbstractAlgorithm<AnalogsOutOfStockProductsArgument>
{
	public override string Name => "Товары не в наличии";

	public AnalogsOutOfStockProductsAlgorithm(ICache cache, AnalogsOutOfStockProductsArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static AnalogsOutOfStockProductsAlgorithm Create(IResolver resolver, AnalogsOutOfStockProductsArgument argument)
	{
		return resolver.Resolve<AnalogsOutOfStockProductsAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.AnalogsOutOfStockProducts(base.Argument.ProductIds, base.Argument.BlockId, RecomendationAnalyticActionsTag.Generic, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		if (base.Argument.ProductIds.Count == 1)
		{
			return $"{"AnalogsOutOfStockProductsAlgorithm"}_{base.Argument.ProductIds[0]}_{activeStore.Id}";
		}
		return null;
	}
}
