using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class SearchAlgorithm : AbstractAlgorithm<SearchArgument>
{
	public override string Name => "Поисковые рекомендации";

	public SearchAlgorithm(ICache cache, SearchArgument argument)
		: base((IGenericCache)cache, argument)
	{
	}

	public static SearchAlgorithm Create(IResolver resolver, SearchArgument argument)
	{
		return resolver.Resolve<SearchAlgorithm>(new object[1] { argument });
	}

	public override Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		return apiService.Search(base.Argument.SearchPhrase, BlockId, RecomendationAnalyticActionsTag.HorizontalShelf, token);
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return null;
	}
}
